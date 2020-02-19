using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Windows.Input;
using ExpenseTracker.Common;
using ExpenseTracker.Events;
using ExpenseTracker.ExpenseServiceReference;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Prism.Regions;

namespace ExpenseTracker.MainRegionModule.ViewModels
{
    [Export("EnterExpenseViewModel")]
    public class EnterExpenseViewModel : BindableBase, INavigationAware
    {
        ExpenseServiceClient expenseManagerClient = new ExpenseServiceClient();
        LoginManagerServiceReference.LoginManagerServiceClient loginManagerClient = new LoginManagerServiceReference.LoginManagerServiceClient();
        IEventAggregator _eventAggregator = null;
        private Int32 LoggedUserId = 0;

        #region Constructor
      

        [ImportingConstructor]
        public EnterExpenseViewModel(IEventAggregator eventAggregator)
        {
            this.ClearAllCommand = new DelegateCommand<Object>(this.ClearData, this.CanClearData);
            this.SaveCommand = new DelegateCommand<Object>(this.SaveData, this.CanSaveData);
            this.LostFocusCommand = new DelegateCommand<Object>(this.LostFocus, this.CanLostFocus);
            LoggedUserId = loginManagerClient.GetCurrentUser();
            RadioHomeSelected = true;
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<ViewModelCleanupEvent>().Subscribe(new Action<Object>(CleanViewModel));
        }
        
        private void InitializeCategories()
        {
            Categories = new ObservableCollection<Category>(expenseManagerClient.GetCategories(LoggedUserId));
            Items = new ObservableCollection<Item>(expenseManagerClient.GetItems(LoggedUserId));
            SelectedIndex = -1;
        }
        #endregion

        #region Commands
        public ICommand SaveCommand { get; private set; }
        public ICommand ClearAllCommand { get; private set; }
        public ICommand LostFocusCommand { get; private set; }
        #endregion

        #region private variables
        private int quantity;
        private float amount;
        private String remarks;
        private Boolean radioHomeSelected;
        private Boolean radioOfficeSelected;
        private Boolean radioNoneSelected;
        private ObservableCollection<Category> categories;
        private ObservableCollection<Item> items;
        private Category selectedCategory;
        private Item selectedItem;
        private Item itemTextChanged;
        private Int32 selectedIndex;
        #endregion

        #region properties
        public Item ItemTextChanged
        {
            get
            {
                return itemTextChanged;
            }
            set
            {
                itemTextChanged = value;
                OnPropertyChanged("itemTextChanged");
            }
        }
        public int Quantity
        {
            get
            {
                return quantity;
            }
            set
            {
                quantity = value;
                OnPropertyChanged("Quantity");
            }
        }

        public float Amount
        {
            get
            {
                return amount;
            }
            set
            {
                amount = value;
                OnPropertyChanged("Amount");
            }
        }

        public String Remarks
        {
            get
            {
                return remarks;
            }
            set
            {
                remarks = value;
                OnPropertyChanged("Remarks");
            }
        }

        public Boolean RadioHomeSelected
        {
            get
            {
                return radioHomeSelected;
            }
            set
            {
                radioHomeSelected = value;
                OnPropertyChanged("RadioHomeSelected");
            }
        }

        public Boolean RadioOfficeSelected
        {
            get
            {
                return radioOfficeSelected;
            }
            set
            {
                radioOfficeSelected = value;
                OnPropertyChanged("RadioOfficeSelected");
            }
        }

        public Boolean RadioNoneSelected
        {
            get
            {
                return radioNoneSelected;
            }
            set
            {
                radioNoneSelected = value;
                OnPropertyChanged("RadioNoneSelected");
            }
        }

        public ObservableCollection<Category> Categories
        {
            get
            {
                return categories;
            }
            set
            {
                categories = value;
                OnPropertyChanged("Categories");
            }
        }

        public ObservableCollection<Item> Items
        {
            get
            {
                return items;
            }
            set
            {
                items = value;
                OnPropertyChanged("Items");
            }
        }

        public Category SelectedCategory
        {
            get
            {
                return selectedCategory;
            }
            set
            {
                selectedCategory = value;
                OnPropertyChanged("SelectedCategory");
            }
        }

        public Item SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }

        public Int32 SelectedIndex
        {
            get
            {
                return selectedIndex;
            }
            set
            {
                selectedIndex = value;
                OnPropertyChanged("SelectedIndex");
            }
        }
        #endregion

        #region Methods

        private void LostFocus(object obj)
        {          
            if(obj!=null)
            {
                SelectedItem = new Item();
                SelectedItem.ItemName = obj.ToString();
                SelectedItem.LoggedinUserId = LoggedUserId;
                Item item = expenseManagerClient.GetSelectedItem(SelectedItem);
                if(item!=null)
                {
                    Quantity = item.ItemQuantity;
                    Amount = item.ItemAmount;
                    SelectedItem.ItemID = item.ItemID;
                    SelectedItem.LoggedinUserId = item.LoggedinUserId;
                }
                else
                {
                    Quantity = 0;
                    Amount = 0;
                    SelectedItem.ItemID = 0;
                }
            }            
        }

        private bool CanLostFocus(object arg)
        {
            return true;
        }


        private bool CanSaveData(object arg)
        {
            return true;
        }

        private void SaveData(object obj)
        {
            if (SelectedCategory == null)
            {
                _eventAggregator.GetEvent<SetStatusMessageEvent>().Publish(new StatusMessage(MessageType.MessageTypes.Error, "Please add/select Category."));
                return;
            }
            if(SelectedItem == null)
            {
                _eventAggregator.GetEvent<SetStatusMessageEvent>().Publish(new StatusMessage(MessageType.MessageTypes.Error, "Please enter/select an item"));
                return;
            }
            if(Quantity == 0 || Amount == 0.0 || Quantity==null || Amount == null)
            {
                _eventAggregator.GetEvent<SetStatusMessageEvent>().Publish(new StatusMessage(MessageType.MessageTypes.Error, "Please enter quantity and amount."));
                return;
            }
            Expense newExpense = new Expense();
            newExpense.SelectedCategory = SelectedCategory;
            newExpense.SelectedItem = SelectedItem;
            newExpense.SelectedItem.ItemQuantity = Quantity;
            newExpense.SelectedItem.ItemAmount = Amount;
            newExpense.RadioHomeSelected = RadioHomeSelected;
            newExpense.RadioNoneSelected = RadioNoneSelected;
            newExpense.RadioOfficeSelected = RadioOfficeSelected;
            if(String.IsNullOrEmpty(Remarks))
                newExpense.Remarks = " ";
            else
                newExpense.Remarks = Remarks;
            
            User usr = new User();
            usr.UserId = LoggedUserId;
            newExpense.LoggedInUser = usr;
            ExpenseServiceClient expenseClient = new ExpenseServiceClient();
            Boolean status = expenseClient.EnterExpense(newExpense);
            if (status)
            {
                _eventAggregator.GetEvent<SetStatusMessageEvent>().Publish(new StatusMessage(MessageType.MessageTypes.Ok, "New expense has been added."));
                Items = new ObservableCollection<Item>(expenseManagerClient.GetItems(LoggedUserId));
            }
            else
            {
                _eventAggregator.GetEvent<SetStatusMessageEvent>().Publish(new StatusMessage(MessageType.MessageTypes.Error, "Expense not added."));
            }
            Quantity = 0;
            SelectedIndex = -1;
            Amount = 0;
        }

        private bool CanClearData(object arg)
        {
            return true;
        }

        private void ClearData(object obj)
        {
            Quantity = 0;
            Amount = 0;
            Remarks = "";
            RadioHomeSelected = false;
            RadioNoneSelected = false;
            RadioOfficeSelected = false;
            SelectedCategory = null;
            SelectedItem = null;
            ItemTextChanged = null;
            SelectedIndex = -1;
        }

        #endregion

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
            //throw new NotImplementedException();
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            InitializeCategories();
        }

        public void CleanViewModel(Object obj)
        {
            //GC.SuppressFinalize(this);
         //   new EnterExpenseViewModel();
        }
    }
}
