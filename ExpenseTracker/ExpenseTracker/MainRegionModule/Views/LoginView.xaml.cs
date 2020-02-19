﻿using System;
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
    /// Interaction logic for LoginView.xaml
    /// </summary>
    [Export("LoginView")]
    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            InitializeComponent();
        }


        [Import("LoginViewModel")]
        public LoginViewModel ViewModel
        {
            set { this.DataContext = value; }
        }

     
    }
}
