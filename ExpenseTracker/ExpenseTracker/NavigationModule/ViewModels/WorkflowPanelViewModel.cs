using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ExpenseTracker.Common;
using ExpenseTracker.Events;
using ExpenseTracker.LoginManagerServiceReference;
using ExpenseTracker.MainRegionModule.ViewModels;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;

namespace ExpenseTracker.NavigationModule.ViewModels
{
    [Export("WorkflowPanelViewModel")]
    public class WorkflowPanelViewModel
    {
        public ICommand NavigateManageCategoriesCommand { get; private set; }
        public ICommand NavigateEnterExpenseView { get; private set; }
        IEventAggregator _eventAggregator = null;
        public ICommand NavigateLogoutView { get; private set; }

        public ICommand NavigateStatisticsAnalyticsView { get; private set; }
        public WorkflowPanelViewModel()
        {

        }
          [ImportingConstructor]
        public WorkflowPanelViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            this.NavigateManageCategoriesCommand = new DelegateCommand<Object>(this.ShowManageCategoriesView, this.CanShowManageCategoriesView);
            this.NavigateEnterExpenseView = new DelegateCommand<Object>(this.ShowEnterExpenseView, this.CanShowEnterExpenseView);
            this.NavigateLogoutView = new DelegateCommand<Object>(this.ShowLoginView, this.CanShowLoginView);
            this.NavigateStatisticsAnalyticsView= new DelegateCommand<Object>(this.ShowStatisticsAnalyticsView, this.CanShowStatisticsAnalyticsView);
        }

        private void ShowLoginView(object obj)
        {
            using (new MethodLogger(MethodBase.GetCurrentMethod()))
            {
                LoginManagerServiceClient logoutClient = new LoginManagerServiceClient();
                Boolean status = logoutClient.Logout();
                if (status)
                {
                    ExitApplication();
                    //_eventAggregator.GetEvent<ViewModelCleanupEvent>().Publish(0);
                    //ServiceLocator.Current.GetInstance<IRegionManager>().RequestNavigate(RegionNames.MainRegion, new Uri("/LoginView", UriKind.Relative));
                    //ServiceLocator.Current.GetInstance<IRegionManager>().RequestNavigate(RegionNames.NavigationRegion, new Uri("/LoginPanelView", UriKind.Relative));
                }
            }
        }

        private void ExitApplication()
        {
            Environment.Exit(0);
        }

        private bool CanShowLoginView(object arg)
        {
            return true;
        }

        private void ShowEnterExpenseView(object obj)
        {
            ServiceLocator.Current.GetInstance<IRegionManager>().RequestNavigate(RegionNames.MainRegion, new Uri("/EnterExpenseView", UriKind.Relative));
        }

        private bool CanShowEnterExpenseView(object arg)
        {
            return true;
        }

        private bool CanShowManageCategoriesView(object arg)
        {
            return true;
        }

        private void ShowManageCategoriesView(object obj)
        {
            ServiceLocator.Current.GetInstance<IRegionManager>().RequestNavigate(RegionNames.MainRegion, new Uri("/CategoriesView", UriKind.Relative));
        }



        public Boolean CanShowStatisticsAnalyticsView(object arg) 
        {
            return true;
        }

        public void ShowStatisticsAnalyticsView(object obj) 
        {
            ServiceLocator.Current.GetInstance<IRegionManager>().RequestNavigate(RegionNames.MainRegion, new Uri("/StatisticsAnalyticsView", UriKind.Relative));
        }
    }
}
