﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace ExpenseTracker.Converters
{
    public class ImageConverter :IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            BitmapImage image = null ;
            Application.Current.Dispatcher.BeginInvoke((Action)(()=>
            {
            image  = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(value as string);
            image.EndInit();            
            }));
            return image;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
