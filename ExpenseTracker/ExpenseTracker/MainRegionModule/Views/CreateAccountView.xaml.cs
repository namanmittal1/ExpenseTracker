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
using ExpenseTracker.MainRegionModule.ViewModels;

namespace ExpenseTracker.MainRegionModule.Views
{
    /// <summary>
    /// Interaction logic for CreateAccount.xaml
    /// </summary>
    [Export("CreateAccountView")]
    public partial class CreateAccountView : UserControl
    {
        public CreateAccountView()
        {
            InitializeComponent();
        }

        [Import("CreateAccountViewModel")]
        public CreateAccountViewModel ViewModel
        {
            set { this.DataContext = value; }
        }  
    }
}
