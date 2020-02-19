﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ExpenseTracker.AttachedBehaviours
{
    public static class TextBoxBehaviour
    {

        public static string GetSelectedText(DependencyObject obj)
        {
            return (string)obj.GetValue(SelectedTextProperty);
        }

        public static void SetSelectedText(DependencyObject obj, string value)
        {
            obj.SetValue(SelectedTextProperty, value);
        }

        // Using a DependencyProperty as the backing store for SelectedText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedTextProperty =
            DependencyProperty.RegisterAttached(
                "SelectedText",
                typeof(string),
                typeof(TextBoxBehaviour),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, SelectedTextChanged));

        private static void SelectedTextChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            TextBox tb = obj as TextBox;
            if (tb != null)
            {
                tb.GotFocus -= tb_SelectionChanged;
                tb.GotFocus += tb_SelectionChanged;

                string newValue = e.NewValue as string;

                if (newValue != null && newValue != tb.SelectedText)
                {
                    tb.SelectedText = newValue as string;
                }
            }
        }

        static void tb_SelectionChanged(object sender, RoutedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb != null)
            {
                tb.SelectAll();
            }
        }

    }
}
