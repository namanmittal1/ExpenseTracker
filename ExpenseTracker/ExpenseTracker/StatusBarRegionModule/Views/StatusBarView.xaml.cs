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
using ExpenseTracker.StatusBarRegionModule.ViewModels;

namespace ExpenseTracker.StatusBarRegionModule.Views
{
    /// <summary>
    /// Interaction logic for StatusBar.xaml
    /// </summary>
   [Export("StatusBarView")]
    public partial class StatusBarView : UserControl
    {
        public StatusBarView()
        {
            InitializeComponent();
        }

        [Import("StatusBarViewModel")]
        public StatusBarViewModel ViewModel
        {
            set { this.DataContext = value; }
        }  

    }
}
