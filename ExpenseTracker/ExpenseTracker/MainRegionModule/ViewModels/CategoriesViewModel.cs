using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ExpenseTracker.CategoriesManagerServiceReference;
using ExpenseTracker.Common;
using ExpenseTracker.Events;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Interactivity.InteractionRequest;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.PubSubEvents;


namespace ExpenseTracker.MainRegionModule.ViewModels
{
    [Export("CategoriesViewModel")]
    public class CategoriesViewModel : BindableBase
    {
        #region private variables
        private ObservableCollection<Category> categories;
        private Category _selectedCategory = null;
        IEventAggregator _eventAggregator = null;

        private Boolean isAddOpened;
        private Boolean isUpdateOpened;

        private String updateSelectedCategory;
        private String newCategory;
        private Int32 LoggedUserId = 0;
        CategoriesManagerServiceClient categoryManagerClient = new CategoriesManagerServiceClient();
        LoginManagerServiceReference.LoginManagerServiceClient loginManagerClient = new LoginManagerServiceReference.LoginManagerServiceClient();
        #endregion

        #region Commands
        public ICommand ShowAddCommand { get; private set; }
        public ICommand ShowUpdateCommand { get; private set; }
        public ICommand RemoveSelectedCategory { get; private set; }
        public ICommand AddCategoryCommand { get; private set; }
        public ICommand UpdateCategoryCommand { get; private set; }

        public ICommand CancelAddCommand { get; private set; }
        public ICommand CancelUpdateCommand { get; private set; }
        #endregion

        #region Properties
        public Boolean IsAddOpened
        {
            get { return isAddOpened; }
            set
            {
                isAddOpened = value;
                OnPropertyChanged("IsAddOpened");
            }
        }

        public Boolean IsUpdateOpened
        {
            get { return isUpdateOpened; }
            set
            {
                isUpdateOpened = value;
              //  UpdateSelectedCategory = SelectedCategory.CategoryName;
                OnPropertyChanged("IsUpdateOpened");
            }
        }

        public String UpdateSelectedCategory
        {
            get
            {
                return updateSelectedCategory;
            }
            set
            {
                updateSelectedCategory = value;
                OnPropertyChanged("UpdateSelectedCategory");
            }
        }

        public Int32 SelectedCategoryUserId { get; set; }

        public String NewCategory
        {
            get
            {
                return newCategory;
            }
            set
            {
                newCategory = value;
                OnPropertyChanged("NewCategory");
            }
        }

        public Category SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                _selectedCategory = value;
                if (_selectedCategory != null)
                {
                    (this.ShowUpdateCommand as DelegateCommand<Object>).RaiseCanExecuteChanged();
                    (this.RemoveSelectedCategory as DelegateCommand<Object>).RaiseCanExecuteChanged();
                    UpdateSelectedCategory = _selectedCategory.CategoryName;
                    SelectedCategoryUserId = _selectedCategory.UserId;
                }
                OnPropertyChanged("SelectedCategory");
                // DoSomething(value);
            }
        }

        /// <summary>
        /// A log of a starting process
        /// </summary>
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
        #endregion

        #region Constructor

       

        [ImportingConstructor]
        public CategoriesViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<ViewModelCleanupEvent>().Subscribe(new Action<Object>(CleanViewModel));
            LoggedUserId = loginManagerClient.GetCurrentUser();
            InitializeCategories();
            AttachCommands();
        }
       

        private void InitializeCategories()
        {
            Categories = new ObservableCollection<Category>(categoryManagerClient.GetCategories(LoggedUserId));
        }

        private void AttachCommands()
        {
            this.ShowAddCommand = new DelegateCommand<object>(this.ShowAdd, this.CanExecute);
            this.AddCategoryCommand = new DelegateCommand<Object>(this.AddCategory, this.CanExecute);
            this.CancelAddCommand = new DelegateCommand<Object>(this.CancelAdd, this.CanExecute);

            this.ShowUpdateCommand = new DelegateCommand<object>(this.ShowUpdate, this.CanShowRemoveUpdate);
            this.UpdateCategoryCommand = new DelegateCommand<Object>(this.UpdateCategory, this.CanExecute);
            this.CancelUpdateCommand = new DelegateCommand<Object>(this.CancelUpdate, this.CanExecute);

            this.RemoveSelectedCategory = new DelegateCommand<Object>(this.RemoveCategory, this.CanShowRemoveUpdate);
        }

        #endregion

        #region Execute Methods
        private void UpdateCategory(Object obj)
        {
            SelectedCategory.CategoryName = UpdateSelectedCategory;
            SelectedCategory.UserId=SelectedCategoryUserId;
            Boolean status = categoryManagerClient.UpdateCategory(SelectedCategory);
            if (status)
            {
                InitializeCategories();
                _eventAggregator.GetEvent<SetStatusMessageEvent>().Publish(new StatusMessage(MessageType.MessageTypes.Ok, "Category updated."));
                IsUpdateOpened = false;
            }

        }

        private void AddCategory(Object arg)
        {
            Category newCategory = new Category();
            newCategory.CategoryName = NewCategory;
            newCategory.UserId = LoggedUserId;
           Boolean status = categoryManagerClient.AddCategory(newCategory);
           if (status)
           {
               InitializeCategories();
               _eventAggregator.GetEvent<SetStatusMessageEvent>().Publish(new StatusMessage(MessageType.MessageTypes.Ok, "Category added."));
               IsAddOpened = false;
           }
        }

        private void RemoveCategory(Object args)
        {
            if (SelectedCategory == null)
                return;
           Boolean status = categoryManagerClient.RemoveCategory(SelectedCategory);
           if (status)
           {
               InitializeCategories();
               _eventAggregator.GetEvent<SetStatusMessageEvent>().Publish(new StatusMessage(MessageType.MessageTypes.Ok, "Category removed."));
               SelectedCategory = Categories.FirstOrDefault();
           }
        }

        public void CleanViewModel(Object obj)
        {
            //GC.SuppressFinalize(this);
           // new CategoriesViewModel();
        }
        #endregion

        #region Show Popup Methods
        private void ShowUpdate(object obj)
        {
            IsUpdateOpened = true;
        }
        private void ShowAdd(object arg)
        {
            IsAddOpened = true;
        }
        #endregion

        #region CanExecute Methods
        private bool CanExecute(object arg)
        {
            return true;
        }
        private bool CanShowRemoveUpdate(object arg)
        {
            if (SelectedCategory == null)
                return true;
            Boolean val = FreezeBasicCategories(SelectedCategory.CategoryName);
            if (!val)
                return true;
            else
                return false;
        }

        private Boolean FreezeBasicCategories(String categoryName)
        {
            List<CategoriesEnum> basicCategories = Enum.GetValues(typeof(CategoriesEnum)).OfType<CategoriesEnum>().ToList();
            if (basicCategories.Any(name => name.ToString().Equals(categoryName)))
            {
                return true;
            }
            else
                return false;
        }
               
        #endregion

        #region Hide popup Methods
        private void CancelAdd(object obj)
        {
            IsAddOpened = false;
        }

        private void CancelUpdate(object obj)
        {
            IsUpdateOpened = false;
        }
        #endregion

    }
}
