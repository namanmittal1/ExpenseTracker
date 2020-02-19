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
    /// Interaction logic for CategoriesView.xaml
    /// </summary>
        [Export("CategoriesView")]
    public partial class CategoriesView : UserControl
    {
        public CategoriesView()
        {
            InitializeComponent();
        }

        [Import("CategoriesViewModel")]
        public CategoriesViewModel ViewModel
        {
            set { this.DataContext = value; }
        }  
    }
}
