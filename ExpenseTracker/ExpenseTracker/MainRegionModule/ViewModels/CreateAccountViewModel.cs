using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using ExpenseTracker.Common;
using ExpenseTracker.Events;
using ExpenseTracker.NewAccountManagerServiceReference;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.PubSubEvents;

namespace ExpenseTracker.MainRegionModule.ViewModels
{
     [Export("CreateAccountViewModel")]
    public class CreateAccountViewModel:BindableBase
    {
         public ICommand CreateAccountCommand { get; private set; }
         IEventAggregator _eventAggregator = null;

        

         [ImportingConstructor]
         public CreateAccountViewModel(IEventAggregator eventAggregator)
         {
             _eventAggregator = eventAggregator;
             this.CreateAccountCommand = new DelegateCommand<Object>(this.CreateAccount, this.CanCreateAccount);
         }

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

         private bool CanCreateAccount(object arg)
         {
             return true;
         }

         private void CreateAccount(object obj)
         {
            PasswordBox pb = obj as PasswordBox;
            User newUser = new User();
            newUser.UserName = AccountName;
            newUser.Password = pb.Password;
            NewAccountManagerServiceClient newAccountClient = new NewAccountManagerServiceClient();
            Boolean status = newAccountClient.CreateNewAccount(newUser);
             if(status)
                 _eventAggregator.GetEvent<SetStatusMessageEvent>().Publish(new StatusMessage(MessageType.MessageTypes.Ok, "Account has been created"));
             else
                 _eventAggregator.GetEvent<SetStatusMessageEvent>().Publish(new StatusMessage(MessageType.MessageTypes.Error, "Account already exists."));


         }

    }
}
