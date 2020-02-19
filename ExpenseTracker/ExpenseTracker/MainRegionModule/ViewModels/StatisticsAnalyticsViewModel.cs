using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using ExpenseTracker.Adorners;
using ExpenseTracker.ExpenseServiceReference;
using ExpenseTracker.StatisticsAnalyticsServiceReference;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.PubSubEvents;

namespace ExpenseTracker.MainRegionModule.ViewModels
{
    [Export("StatisticsAnalyticsViewModel")]
    public class StatisticsAnalyticsViewModel :BindableBase
    {
        IEventAggregator _eventAggregator = null;
        StatisticsAnalyticsServiceClient staticticsAnalyticsClient = new StatisticsAnalyticsServiceClient();
        ExpenseServiceClient expenseManagerClient = new ExpenseServiceClient();
        private static Grid gridLoaded { get; set; }
        WaitAdorner adorner = null;
        public ICommand LoadedCommand { get; private set; }
        LoginManagerServiceReference.LoginManagerServiceClient loginManagerClient = new LoginManagerServiceReference.LoginManagerServiceClient();

        private Boolean adornerVisibility;
        public Boolean AdornerVisibility
        {
            get
            {
                return adornerVisibility;
            }

            set
            {
                adornerVisibility = value;
                OnPropertyChanged("AdornerVisibility");
                //if (adornerVisibility)
                //    AdornerLayer.GetAdornerLayer(gridLoaded).Add(adorner);
                //else
                //    AdornerLayer.GetAdornerLayer(gridLoaded).Remove(adorner);
            }
        }

       [ImportingConstructor]
        public StatisticsAnalyticsViewModel(IEventAggregator eventAggregator)
       {
           _eventAggregator = eventAggregator;
           LoggedUserId = loginManagerClient.GetCurrentUser();
           this.SearchCommand = new DelegateCommand<Object>(this.SearchData, this.CanSearchData);
           this.TabControlSelectionChanged = new DelegateCommand<Object>(this.SelectionChange, this.CanSelectionChange);
           InitializeCategoriesItems();
           this.LoadedCommand = new DelegateCommand<Object>(this.UILoaded, this.CanSearchData);
           //_eventAggregator.GetEvent<ViewModelCleanupEvent>().Subscribe(new Action<Object>(CleanViewModel));
       }

       private void UILoaded(object obj)
       {
           //gridLoaded = obj as Grid;
           //adorner = new WaitAdorner(gridLoaded);
       }
       

       #region Analytics
       private void InitializeCategoriesItems()
       {
           Categories = new ObservableCollection<Category>(expenseManagerClient.GetCategories(LoggedUserId));
           Items = new ObservableCollection<Item>(expenseManagerClient.GetItems(LoggedUserId));
       }

       #region Variables
       public ICommand SearchCommand { get; private set; }

       private Boolean isStkCategoriesEnabled;
       private Boolean isStkItemsEnabled;
       private Boolean isStkPeriodEnabled;
       private Boolean isStkSourceEnabled;

       private Boolean isCbCategoriesChecked;
       private Boolean isCbItemsChecked;
       private Boolean isCbPeriodChecked;
       private Boolean isCbSourceChecked;
       private ObservableCollection<Category> categories;
       private ObservableCollection<Item> items;
       private ObservableCollection<AnalyticsData> analyticsData;
       private Category selectedCategory;
       private Item selectedItem;
       private String selectedSource;
       private DateTime dateFrom;
       private DateTime dateTo;
       private Int32 LoggedUserId = 0;
       private Item itemTextChanged;

       #endregion

       #region Properties

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
       public Boolean IsStkCategoriesEnabled
       {
           get
           { 
               return isStkCategoriesEnabled;
           }
           set
           {
               isStkCategoriesEnabled = value;
               OnPropertyChanged("IsStkCategoriesEnabled");
           }
       }
        public Boolean IsStkItemsEnabled
        {
            get
            {
                return isStkItemsEnabled;
            }
            set
            {
                isStkItemsEnabled = value;
                OnPropertyChanged("IsStkItemsEnabled");
            }
        }

        public Boolean IsStkPeriodEnabled
        {
            get
            {
                return isStkPeriodEnabled;
            }
            set
            {
                isStkPeriodEnabled = value;
                OnPropertyChanged("IsStkPeriodEnabled");
            }
        }


        public Boolean IsStkSourceEnabled
        {
            get
            {
                return isStkSourceEnabled;
            }
            set
            {
                isStkSourceEnabled = value;
                OnPropertyChanged("IsStkSourceEnabled");
            }
        }

        public Boolean IsCbCategoriesChecked
        {
            get
            {
                return isCbCategoriesChecked;
            }
            set
            {
                isCbCategoriesChecked = value;
                IsStkCategoriesEnabled = value;
                OnPropertyChanged("IsCbCategoriesChecked");
            }
        }
        public Boolean IsCbItemsChecked
        {
            get
            {
                return isCbItemsChecked;
            }
            set
            {
                isCbItemsChecked = value;
                IsStkItemsEnabled = value;
                OnPropertyChanged("IsCbItemsChecked");
            }
        }
        public Boolean IsCbPeriodChecked
        {
            get
            {
                return isCbPeriodChecked;
            }
            set
            {
                isCbPeriodChecked = value;
                IsStkPeriodEnabled = value;
                DateFrom = DateTime.Now.Date;
                DateTo = DateTime.Now.Date;
                OnPropertyChanged("IsCbPeriodChecked");
            }
        }
        public Boolean IsCbSourceChecked
        {
            get
            {
                return isCbSourceChecked;
            }
            set
            {
                isCbSourceChecked = value;
                IsStkSourceEnabled = value;
                OnPropertyChanged("IsCbSourceChecked");
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

        public ObservableCollection<AnalyticsData> Data
        {
            get
            {
                return analyticsData;
            }
            set
            {
                analyticsData = value;
                OnPropertyChanged("Data");
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

        public String SelectedSource
        {
            get
            {
                return selectedSource;
            }
            set
            {
                selectedSource = value;
                OnPropertyChanged("SelectedSource");
            }
        }

        public DateTime DateFrom
        {
            get
            {
                return dateFrom;
            }
            set
            {
                dateFrom = value;
                OnPropertyChanged("DateFrom");
            }
        }
        public DateTime DateTo
        {
            get
            {
                return dateTo;
            }
            set
            {
                dateTo = value;
                OnPropertyChanged("DateTo");
            }
        }
       #endregion
        private bool CanSearchData(object arg)
        {
            return true;
        }

        private async void SearchData(object obj)
        {

            Task t = SearchDataAsync(obj);
            AdornerVisibility = true;
            Console.WriteLine("");
            await t;
            if (t.IsCompleted)
            {
                AdornerVisibility = false;
            }           

        }

        private Task SearchDataAsync(Object obj)
        {
            return Task.Run((Action)(() =>
             {
                 Thread.Sleep(1000);
                 Int32 categoryid = 0;
                 Int32 itemId = 0;
                 String fromDate = DateTime.MinValue.ToString();
                 String toDate = DateTime.MinValue.ToString();
                 String source = "";

                 if (IsCbCategoriesChecked && SelectedCategory!=null)
                     categoryid = SelectedCategory.CategoryID;
                 else
                     categoryid = 0;

                 if (IsCbItemsChecked && SelectedItem!=null)
                     itemId = SelectedItem.ItemID;
                 else
                     itemId = 0;

                 if (IsCbPeriodChecked && (DateFrom != DateTime.MinValue || DateTo != DateTime.MinValue))
                 {
                     fromDate = DateFrom.ToString("yyyy-MM-dd");
                     toDate = DateTo.ToString("yyyy-MM-dd");

                     var time = TimeSpan.Parse(DateTime.Now.TimeOfDay.ToString());
                     toDate = toDate + " " +time.ToString();
                 }
                 else
                 {
                     fromDate = DateTime.MinValue.ToString();
                     toDate = DateTime.MinValue.ToString();
                 }

                 if (IsCbSourceChecked && SelectedSource!=null)
                     source = SelectedSource;
                 else
                     source = "";

                 List<AnalyticsData> preparedData = new List<AnalyticsData>();
                 List<AnalyticsData> data = staticticsAnalyticsClient.GetAnalyticsData(LoggedUserId, categoryid, itemId, fromDate, toDate, source);
                 foreach (AnalyticsData i in data)
                 {
                     AnalyticsData tempData = new AnalyticsData();
                     tempData.Amount = i.Amount;
                     tempData.CategoryName = i.CategoryName;
                     tempData.Date = i.Date;
                     tempData.ItemName = i.ItemName;
                     tempData.Quantity = i.Quantity;
                     tempData.Remarks = i.Remarks;
                     if (i.RadioHomeSelected == 1)
                         tempData.Source = "Home";
                     else if (i.RadioOfficeSelected == 1)
                         tempData.Source = "Office";
                     else if (i.RadioNoneSelected == 1)
                         tempData.Source = "None";

                     preparedData.Add(tempData);

                 }
                 Data = new ObservableCollection<AnalyticsData>(preparedData);
             }));
        }

       #endregion

        #region Statistics

        #region variables
        public ICommand TabControlSelectionChanged { get; private set; }
        private float firstColumnValue;
        private float secondColumnValue;
        private float thirdColumnValue;
        private float fourthColumnValue;
        private float fifthColumnValue;

        private String firstColumnName;
        private String secondColumnName;
        private String thirdColumnName;
        private String fourthColumnName;
        private String fifthColumnName;
        #endregion

        #region Properties
        public float FirstColumnValue
        {
            get
            {
                return firstColumnValue;
            }
            set
            {
                firstColumnValue = value;
                OnPropertyChanged("FirstColumnValue");
            }
        }

        public float SecondColumnValue
        {
            get
            {
                return secondColumnValue;
            }
            set
            {
                secondColumnValue = value;
                OnPropertyChanged("SecondColumnValue");
            }
        }

        public float ThirdColumnValue
        {
            get
            {
                return thirdColumnValue;
            }
            set
            {
                thirdColumnValue = value;
                OnPropertyChanged("ThirdColumnValue");
            }
        }

        public float FourthColumnValue
        {
            get
            {
                return fourthColumnValue;
            }
            set
            {
                fourthColumnValue = value;
                OnPropertyChanged("FourthColumnValue");
            }
        }

        public float FifthColumnValue
        {
            get
            {
                return fifthColumnValue;
            }
            set
            {
                fifthColumnValue = value;
                OnPropertyChanged("FifthColumnValue");
            }
        }

        public String FirstColumnName
        {
            get
            {
                return firstColumnName;
            }
            set
            {
                firstColumnName = value;
                OnPropertyChanged("FirstColumnName");
            }
        }

        public String SecondColumnName
        {
            get
            {
                return secondColumnName;
            }
            set
            {
                secondColumnName = value;
                OnPropertyChanged("SecondColumnName");
            }
        }
        public String ThirdColumnName
        {
            get
            {
                return thirdColumnName;
            }
            set
            {
                thirdColumnName = value;
                OnPropertyChanged("ThirdColumnName");
            }
        }
        public String FourthColumnName
        {
            get
            {
                return fourthColumnName;
            }
            set
            {
                fourthColumnName = value;
                OnPropertyChanged("FourthColumnName");
            }
        }
        public String FifthColumnName
        {
            get
            {
                return fifthColumnName;
            }
            set
            {
                fifthColumnName = value;
                OnPropertyChanged("FifthColumnName");
            }
        }
        
        #endregion

        private bool CanSelectionChange(object arg)
        {
            return true;
        }

        private void SelectionChange(object obj)
        {
            if(obj!=null)
            {
                TabItem tb = obj as TabItem;
                if(tb.IsSelected)
                {
                    GetStatisticsDataFromDatabase();
                }
            }
        }

        private void GetStatisticsDataFromDatabase()
        {
            List<StatisticsData> data = staticticsAnalyticsClient.GetExpensesFromDataBase(LoggedUserId);
            SetData(data);
        }

        private void SetData(List<StatisticsData> data)
        {

            try
            {
                for (int i = 0; i < 5; i++)
                {
                    switch (i)
                    {
                        case 0:
                            FirstColumnName = data[i].CategoryName;
                            FirstColumnValue = data[i].ExpenseAmount;
                            break;
                        case 1:
                            SecondColumnName = data[i].CategoryName;
                            SecondColumnValue = data[i].ExpenseAmount;
                            break;
                        case 2:
                            ThirdColumnName = data[i].CategoryName;
                            ThirdColumnValue = data[i].ExpenseAmount;
                            break;
                        case 3:
                            FourthColumnName = data[i].CategoryName;
                            FourthColumnValue = data[i].ExpenseAmount;
                            break;
                        case 4:
                            FifthColumnName = data[i].CategoryName;
                            FifthColumnValue = data[i].ExpenseAmount;
                            break;
                    }
                }
            }
            catch (Exception e)
            {
            }
        }
        

        #endregion
    }
}
