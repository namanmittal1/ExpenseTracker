using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ExpenseTracker.Common;
using ExpenseTracker.NavigationModule.ViewModels;
using Microsoft.Practices.Prism.Regions;

namespace ExpenseTracker.NavigationModule.Views
{
    /// <summary>
    /// Interaction logic for LoginPanel.xaml
    /// </summary>
    [Export("LoginPanelView")]
    public partial class LoginPanelView : UserControl
    {
        public LoginPanelView()
        {
            InitializeComponent();
        }

        [Import("LoginPanelViewModel")]
        public LoginPanelViewModel ViewModel
        {
            set { this.DataContext = value; }
        }  
    }
}
