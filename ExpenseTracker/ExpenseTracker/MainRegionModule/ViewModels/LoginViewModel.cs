using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Threading;
using ExpenseTracker.Adorners;
using ExpenseTracker.Common;
using ExpenseTracker.Events;
using ExpenseTracker.LoginManagerServiceReference;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;


namespace ExpenseTracker.MainRegionModule.ViewModels
{

   [Export("LoginViewModel")]
    public class LoginViewModel :BindableBase
    {     

       IEventAggregator _eventAggregator = null;
       private Int32 UserId { get; set; }
       public ICommand LoginCommand { get; private set; }
       public ICommand LoadedCommand { get; private set; }

       public static Grid gridLoaded { get; set; }

       WaitAdorner adorner = null;

       private Boolean IsLoggedIn;

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
                  // AdornerLayer.GetAdornerLayer(gridLoaded).Add(adorner);
               //else
                 //  AdornerLayer.GetAdornerLayer(gridLoaded).Remove(adorner);
           }
       }

       [ImportingConstructor]
       public LoginViewModel(IEventAggregator eventAggregator)
       {
           _eventAggregator = eventAggregator;
           _eventAggregator.GetEvent<ViewModelCleanupEvent>().Subscribe(new Action<Object>(CleanViewModel));
           this.LoginCommand = new DelegateCommand<Object>(this.Login, this.CanLogin);
           this.LoadedCommand = new DelegateCommand<Object>(this.UILoaded, this.CanLogin);
       }

       private void UILoaded(object obj)
       {
           //gridLoaded = obj as Grid;
           //adorner = new WaitAdorner(gridLoaded);
       }

       private bool CanLogin(object arg)
       {
           return true;
       }

       
       private async void Login(object obj)
       {
           // log.Info("Test start");
           using (new MethodLogger(MethodBase.GetCurrentMethod()))
           {
               Task t = LoginMethodAsync(obj);

               AdornerVisibility = true;

               await t;
               if (t.IsCompleted)
               {
                   AdornerVisibility = false;
                   if (IsLoggedIn)
                   {
                       ServiceLocator.Current.GetInstance<IRegionManager>().RequestNavigate(RegionNames.NavigationRegion, new Uri("/WorkflowPanelView", UriKind.Relative));
                       ServiceLocator.Current.GetInstance<IRegionManager>().RequestNavigate(RegionNames.MainRegion, new Uri("/EnterExpenseView", UriKind.Relative));
                   }
               }
           }
           // log.Info("Test stop");
       }

       private Task LoginMethodAsync(Object obj)
       {
           using (new MethodLogger(MethodBase.GetCurrentMethod()))
           {
               return Task.Run((Action)(() =>
                   {
                       Thread.Sleep(1000);
                       PasswordBox pb = obj as PasswordBox;
                       User loggedInUser = new User();
                       loggedInUser.UserName = AccountName;
                       loggedInUser.Password = pb.Password;

                       LoginManagerServiceClient loginClient = new LoginManagerServiceClient();
                       Int32 id = loginClient.Login(loggedInUser);

                       if (id != 0)
                       {
                           loggedInUser.UserId = id;
                           UserId = id;
                           _eventAggregator.GetEvent<SetStatusMessageEvent>().Publish(new StatusMessage(MessageType.MessageTypes.Ok, "Welcome " + AccountName));
                           IsLoggedIn = true;
                       }
                       else
                       {
                           loggedInUser.UserId = 0;
                           _eventAggregator.GetEvent<SetStatusMessageEvent>().Publish(new StatusMessage(MessageType.MessageTypes.Error, "Invalid Username or Password."));
                           IsLoggedIn = false;
                       }
                   }));
           }
       }

        public ICommand CreateAccountCommand { get; private set; }

         private String accountName;
         public String AccountName
         {
             get
             {
                 return accountName;
             }
             set
             {
                 accountName = value;
                 OnPropertyChanged("AccountName");
             }
         }

        public void CleanViewModel(Object obj)
         {
         }


    }
}
