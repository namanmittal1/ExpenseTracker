﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ExpenseTracker.LoginManagerServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="User", Namespace="http://schemas.datacontract.org/2004/07/ExpenseCommon")]
    [System.SerializableAttribute()]
    public partial class User : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PasswordField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int UserIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UserNameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Password {
            get {
                return this.PasswordField;
            }
            set {
                if ((object.ReferenceEquals(this.PasswordField, value) != true)) {
                    this.PasswordField = value;
                    this.RaisePropertyChanged("Password");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int UserId {
            get {
                return this.UserIdField;
            }
            set {
                if ((this.UserIdField.Equals(value) != true)) {
                    this.UserIdField = value;
                    this.RaisePropertyChanged("UserId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UserName {
            get {
                return this.UserNameField;
            }
            set {
                if ((object.ReferenceEquals(this.UserNameField, value) != true)) {
                    this.UserNameField = value;
                    this.RaisePropertyChanged("UserName");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="LoginManagerServiceReference.ILoginManagerService")]
    public interface ILoginManagerService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILoginManagerService/Login", ReplyAction="http://tempuri.org/ILoginManagerService/LoginResponse")]
        int Login(ExpenseTracker.LoginManagerServiceReference.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILoginManagerService/Login", ReplyAction="http://tempuri.org/ILoginManagerService/LoginResponse")]
        System.Threading.Tasks.Task<int> LoginAsync(ExpenseTracker.LoginManagerServiceReference.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILoginManagerService/Logout", ReplyAction="http://tempuri.org/ILoginManagerService/LogoutResponse")]
        bool Logout();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILoginManagerService/Logout", ReplyAction="http://tempuri.org/ILoginManagerService/LogoutResponse")]
        System.Threading.Tasks.Task<bool> LogoutAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILoginManagerService/GetCurrentUser", ReplyAction="http://tempuri.org/ILoginManagerService/GetCurrentUserResponse")]
        int GetCurrentUser();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILoginManagerService/GetCurrentUser", ReplyAction="http://tempuri.org/ILoginManagerService/GetCurrentUserResponse")]
        System.Threading.Tasks.Task<int> GetCurrentUserAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILoginManagerService/GetUsersCount", ReplyAction="http://tempuri.org/ILoginManagerService/GetUsersCountResponse")]
        int GetUsersCount();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILoginManagerService/GetUsersCount", ReplyAction="http://tempuri.org/ILoginManagerService/GetUsersCountResponse")]
        System.Threading.Tasks.Task<int> GetUsersCountAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ILoginManagerServiceChannel : ExpenseTracker.LoginManagerServiceReference.ILoginManagerService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class LoginManagerServiceClient : System.ServiceModel.ClientBase<ExpenseTracker.LoginManagerServiceReference.ILoginManagerService>, ExpenseTracker.LoginManagerServiceReference.ILoginManagerService {
        
        public LoginManagerServiceClient() {
        }
        
        public LoginManagerServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public LoginManagerServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public LoginManagerServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public LoginManagerServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int Login(ExpenseTracker.LoginManagerServiceReference.User user) {
            return base.Channel.Login(user);
        }
        
        public System.Threading.Tasks.Task<int> LoginAsync(ExpenseTracker.LoginManagerServiceReference.User user) {
            return base.Channel.LoginAsync(user);
        }
        
        public bool Logout() {
            return base.Channel.Logout();
        }
        
        public System.Threading.Tasks.Task<bool> LogoutAsync() {
            return base.Channel.LogoutAsync();
        }
        
        public int GetCurrentUser() {
            return base.Channel.GetCurrentUser();
        }
        
        public System.Threading.Tasks.Task<int> GetCurrentUserAsync() {
            return base.Channel.GetCurrentUserAsync();
        }
        
        public int GetUsersCount() {
            return base.Channel.GetUsersCount();
        }
        
        public System.Threading.Tasks.Task<int> GetUsersCountAsync() {
            return base.Channel.GetUsersCountAsync();
        }
    }
}
