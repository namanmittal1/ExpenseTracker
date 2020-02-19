using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using ExpenseTracker.LoginManagerServiceReference;

namespace ExpenseTracker
{
    public class InitializeHomeView
    {
       public void InitHomeViews()
       {
           try
           {
           LoginManagerServiceClient loginClient = new LoginManagerServiceClient();
          

               var userCount= loginClient.GetUsersCount();

               if (userCount == 0)
               {
                   ServiceLocator.Current.GetInstance<IRegionManager>().RequestNavigate(RegionNames.NavigationRegion, new Uri("/LoginPanelView", UriKind.Relative));
                   ServiceLocator.Current.GetInstance<IRegionManager>().RequestNavigate(RegionNames.MainRegion, new Uri("/CreateAccountView", UriKind.Relative));
                   ServiceLocator.Current.GetInstance<IRegionManager>().RequestNavigate(RegionNames.StatusBarRegion, new Uri("/StatusBarView", UriKind.Relative));
               }
               else
               {
                   ServiceLocator.Current.GetInstance<IRegionManager>().RequestNavigate(RegionNames.NavigationRegion, new Uri("/LoginPanelView", UriKind.Relative));
                   ServiceLocator.Current.GetInstance<IRegionManager>().RequestNavigate(RegionNames.MainRegion, new Uri("/LoginView", UriKind.Relative));
                   ServiceLocator.Current.GetInstance<IRegionManager>().RequestNavigate(RegionNames.StatusBarRegion, new Uri("/StatusBarView", UriKind.Relative));
               }
           }
           catch (Exception e)
           {
           }
       }

    }
}
