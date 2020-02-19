using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ExpenseTracker.Common;
using ExpenseTracker.NavigationModule.Views;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;

namespace ExpenseTracker.NavigationModule.ViewModels
{
    [Export("LoginPanelViewModel")]
    public class LoginPanelViewModel :BindableBase
    {

        public ICommand NavigateCreateNewAccountCommand { get; private set; }
        public ICommand NavigateLoginCommand { get; private set; }
        public ICommand ExitCommand { get; private set; }

        public LoginPanelViewModel()
        {
            this.NavigateCreateNewAccountCommand = new DelegateCommand<Object>(this.ShowCreateAccountView, this.CanShowCerateAccountView);
            this.NavigateLoginCommand = new DelegateCommand<Object>(this.ShowLoginView, this.CanShowLoginView);
            this.ExitCommand = new DelegateCommand<Object>(this.ExitApplication, this.CanExitApplication);
        }

        private bool CanExitApplication(object arg)
        {
            return true;
        }

        private void ExitApplication(object obj)
        {
            Environment.Exit(0);
        }

        private bool CanShowLoginView(object arg)
        {
            return true;
        }

        private void ShowLoginView(object obj)
        {
            ServiceLocator.Current.GetInstance<IRegionManager>().RequestNavigate(RegionNames.MainRegion, new Uri("/LoginView", UriKind.Relative));
        }

        private bool CanShowCerateAccountView(object arg)
        {
            return true;
        }

        private void ShowCreateAccountView(object obj)
        {
            ServiceLocator.Current.GetInstance<IRegionManager>().RequestNavigate(RegionNames.MainRegion, new Uri("/CreateAccountView", UriKind.Relative));
        }

    }
}
