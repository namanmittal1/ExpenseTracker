using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Practices.Prism.Mvvm;

namespace ExpenseTracker.StatusBarRegionModule.ViewModels
{
    public class StatusMessageEntity: BindableBase
    {
        private String statusMessage;
        private BitmapImage statusImage;
        private Brush statusColor;
        public String StatusMessage
        {
            get
            {
                return statusMessage;
            }
            set
            {
                statusMessage = value;
                OnPropertyChanged("StatusMessage");
            }
        }

        public Brush StatusColor
        {
            get
            {
                return statusColor;
            }
            set
            {
                statusColor = value;
                OnPropertyChanged("StatusColor");
            }
        }

        public BitmapImage StatusImage
        {
            get
            {
                return statusImage;
            }
            set
            {
                statusImage = value;
                OnPropertyChanged("StatusImage");
            }
        }
    }
}
