﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ExpenseTracker.ExpenseServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Expense", Namespace="http://schemas.datacontract.org/2004/07/ExpenseTrackerService.ExpenseModule")]
    [System.SerializableAttribute()]
    public partial class Expense : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ExpenseIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ExpenseTracker.ExpenseServiceReference.User LoggedInUserField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool RadioHomeSelectedField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool RadioNoneSelectedField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool RadioOfficeSelectedField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string RemarksField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ExpenseTracker.ExpenseServiceReference.Category SelectedCategoryField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ExpenseTracker.ExpenseServiceReference.Item SelectedItemField;
        
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
        public int ExpenseID {
            get {
                return this.ExpenseIDField;
            }
            set {
                if ((this.ExpenseIDField.Equals(value) != true)) {
                    this.ExpenseIDField = value;
                    this.RaisePropertyChanged("ExpenseID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ExpenseTracker.ExpenseServiceReference.User LoggedInUser {
            get {
                return this.LoggedInUserField;
            }
            set {
                if ((object.ReferenceEquals(this.LoggedInUserField, value) != true)) {
                    this.LoggedInUserField = value;
                    this.RaisePropertyChanged("LoggedInUser");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool RadioHomeSelected {
            get {
                return this.RadioHomeSelectedField;
            }
            set {
                if ((this.RadioHomeSelectedField.Equals(value) != true)) {
                    this.RadioHomeSelectedField = value;
                    this.RaisePropertyChanged("RadioHomeSelected");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool RadioNoneSelected {
            get {
                return this.RadioNoneSelectedField;
            }
            set {
                if ((this.RadioNoneSelectedField.Equals(value) != true)) {
                    this.RadioNoneSelectedField = value;
                    this.RaisePropertyChanged("RadioNoneSelected");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool RadioOfficeSelected {
            get {
                return this.RadioOfficeSelectedField;
            }
            set {
                if ((this.RadioOfficeSelectedField.Equals(value) != true)) {
                    this.RadioOfficeSelectedField = value;
                    this.RaisePropertyChanged("RadioOfficeSelected");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Remarks {
            get {
                return this.RemarksField;
            }
            set {
                if ((object.ReferenceEquals(this.RemarksField, value) != true)) {
                    this.RemarksField = value;
                    this.RaisePropertyChanged("Remarks");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ExpenseTracker.ExpenseServiceReference.Category SelectedCategory {
            get {
                return this.SelectedCategoryField;
            }
            set {
                if ((object.ReferenceEquals(this.SelectedCategoryField, value) != true)) {
                    this.SelectedCategoryField = value;
                    this.RaisePropertyChanged("SelectedCategory");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ExpenseTracker.ExpenseServiceReference.Item SelectedItem {
            get {
                return this.SelectedItemField;
            }
            set {
                if ((object.ReferenceEquals(this.SelectedItemField, value) != true)) {
                    this.SelectedItemField = value;
                    this.RaisePropertyChanged("SelectedItem");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Category", Namespace="http://schemas.datacontract.org/2004/07/ExpenseCommon")]
    [System.SerializableAttribute()]
    public partial class Category : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int CategoryIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CategoryNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int UserIdField;
        
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
        public int CategoryID {
            get {
                return this.CategoryIDField;
            }
            set {
                if ((this.CategoryIDField.Equals(value) != true)) {
                    this.CategoryIDField = value;
                    this.RaisePropertyChanged("CategoryID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CategoryName {
            get {
                return this.CategoryNameField;
            }
            set {
                if ((object.ReferenceEquals(this.CategoryNameField, value) != true)) {
                    this.CategoryNameField = value;
                    this.RaisePropertyChanged("CategoryName");
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
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Item", Namespace="http://schemas.datacontract.org/2004/07/ExpenseCommon")]
    [System.SerializableAttribute()]
    public partial class Item : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private float ItemAmountField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ItemIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ItemNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ItemQuantityField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int LoggedinUserIdField;
        
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
        public float ItemAmount {
            get {
                return this.ItemAmountField;
            }
            set {
                if ((this.ItemAmountField.Equals(value) != true)) {
                    this.ItemAmountField = value;
                    this.RaisePropertyChanged("ItemAmount");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ItemID {
            get {
                return this.ItemIDField;
            }
            set {
                if ((this.ItemIDField.Equals(value) != true)) {
                    this.ItemIDField = value;
                    this.RaisePropertyChanged("ItemID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ItemName {
            get {
                return this.ItemNameField;
            }
            set {
                if ((object.ReferenceEquals(this.ItemNameField, value) != true)) {
                    this.ItemNameField = value;
                    this.RaisePropertyChanged("ItemName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ItemQuantity {
            get {
                return this.ItemQuantityField;
            }
            set {
                if ((this.ItemQuantityField.Equals(value) != true)) {
                    this.ItemQuantityField = value;
                    this.RaisePropertyChanged("ItemQuantity");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int LoggedinUserId {
            get {
                return this.LoggedinUserIdField;
            }
            set {
                if ((this.LoggedinUserIdField.Equals(value) != true)) {
                    this.LoggedinUserIdField = value;
                    this.RaisePropertyChanged("LoggedinUserId");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ExpenseServiceReference.IExpenseService")]
    public interface IExpenseService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExpenseService/EnterExpense", ReplyAction="http://tempuri.org/IExpenseService/EnterExpenseResponse")]
        bool EnterExpense(ExpenseTracker.ExpenseServiceReference.Expense value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExpenseService/EnterExpense", ReplyAction="http://tempuri.org/IExpenseService/EnterExpenseResponse")]
        System.Threading.Tasks.Task<bool> EnterExpenseAsync(ExpenseTracker.ExpenseServiceReference.Expense value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExpenseService/GetCategories", ReplyAction="http://tempuri.org/IExpenseService/GetCategoriesResponse")]
        System.Collections.Generic.List<ExpenseTracker.ExpenseServiceReference.Category> GetCategories(int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExpenseService/GetCategories", ReplyAction="http://tempuri.org/IExpenseService/GetCategoriesResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<ExpenseTracker.ExpenseServiceReference.Category>> GetCategoriesAsync(int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExpenseService/GetItems", ReplyAction="http://tempuri.org/IExpenseService/GetItemsResponse")]
        System.Collections.Generic.List<ExpenseTracker.ExpenseServiceReference.Item> GetItems(int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExpenseService/GetItems", ReplyAction="http://tempuri.org/IExpenseService/GetItemsResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<ExpenseTracker.ExpenseServiceReference.Item>> GetItemsAsync(int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExpenseService/GetSelectedItem", ReplyAction="http://tempuri.org/IExpenseService/GetSelectedItemResponse")]
        ExpenseTracker.ExpenseServiceReference.Item GetSelectedItem(ExpenseTracker.ExpenseServiceReference.Item item);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExpenseService/GetSelectedItem", ReplyAction="http://tempuri.org/IExpenseService/GetSelectedItemResponse")]
        System.Threading.Tasks.Task<ExpenseTracker.ExpenseServiceReference.Item> GetSelectedItemAsync(ExpenseTracker.ExpenseServiceReference.Item item);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IExpenseServiceChannel : ExpenseTracker.ExpenseServiceReference.IExpenseService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ExpenseServiceClient : System.ServiceModel.ClientBase<ExpenseTracker.ExpenseServiceReference.IExpenseService>, ExpenseTracker.ExpenseServiceReference.IExpenseService {
        
        public ExpenseServiceClient() {
        }
        
        public ExpenseServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ExpenseServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ExpenseServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ExpenseServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool EnterExpense(ExpenseTracker.ExpenseServiceReference.Expense value) {
            return base.Channel.EnterExpense(value);
        }
        
        public System.Threading.Tasks.Task<bool> EnterExpenseAsync(ExpenseTracker.ExpenseServiceReference.Expense value) {
            return base.Channel.EnterExpenseAsync(value);
        }
        
        public System.Collections.Generic.List<ExpenseTracker.ExpenseServiceReference.Category> GetCategories(int userId) {
            return base.Channel.GetCategories(userId);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<ExpenseTracker.ExpenseServiceReference.Category>> GetCategoriesAsync(int userId) {
            return base.Channel.GetCategoriesAsync(userId);
        }
        
        public System.Collections.Generic.List<ExpenseTracker.ExpenseServiceReference.Item> GetItems(int userId) {
            return base.Channel.GetItems(userId);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<ExpenseTracker.ExpenseServiceReference.Item>> GetItemsAsync(int userId) {
            return base.Channel.GetItemsAsync(userId);
        }
        
        public ExpenseTracker.ExpenseServiceReference.Item GetSelectedItem(ExpenseTracker.ExpenseServiceReference.Item item) {
            return base.Channel.GetSelectedItem(item);
        }
        
        public System.Threading.Tasks.Task<ExpenseTracker.ExpenseServiceReference.Item> GetSelectedItemAsync(ExpenseTracker.ExpenseServiceReference.Item item) {
            return base.Channel.GetSelectedItemAsync(item);
        }
    }
}
