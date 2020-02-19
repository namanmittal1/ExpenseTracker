using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ExpenseTracker.Common;
using ExpenseTracker.Events;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.PubSubEvents;

namespace ExpenseTracker.StatusBarRegionModule.ViewModels
{
    [Export("StatusBarViewModel")]
    public class StatusBarViewModel :BindableBase
    {
        IEventAggregator _eventAggregator = null;
        Queue<StatusMessageEntity> messages = new Queue<StatusMessageEntity>();
        private String statusMessage;
        private BitmapImage statusImage;
        private Brush statusColor;
        private BitmapImage OkImage { get; set; }
        private BitmapImage ErrorImage { get; set; }
        private BitmapImage WarningImage { get; set; }
        Thread thread = null;


        [ImportingConstructor]
        public StatusBarViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<SetStatusMessageEvent>().Subscribe(new Action<StatusMessage>(SetStatusMessage));
            thread = new Thread(new ThreadStart(StatusQueueMonitor));
            thread.IsBackground = true;
            thread.Start();
        }

        #region Properties
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

        #endregion

        public void SetStatusMessage(StatusMessage message)
        {
            StatusMessageEntity sme = new StatusMessageEntity();
            sme.StatusMessage = message.message;
            sme.StatusImage = GetIconImage(message.messageType);
            sme.StatusColor = GetStatusColor(message.messageType);
            messages.Enqueue(sme);
        }

        #region Private Methods
        private void StatusQueueMonitor()
        {
            while (true)
            {
                if (Application.Current == null)
                {
                    Thread.CurrentThread.Abort();
                }
                if (messages.Count < 1)
                {
                   // Application.Current.Dispatcher.Invoke((Action)(() =>
                    //{
                        StatusMessage = "";
                        StatusImage = null;
                        StatusColor = Brushes.Black;
                    //}));
                    continue;
                }
                else
                {
                    StatusMessageEntity sme = messages.Dequeue();
                    Application.Current.Dispatcher.Invoke((Action)(() =>
                    {
                        StatusMessage = sme.StatusMessage;
                        StatusImage = sme.StatusImage;
                        StatusColor = sme.StatusColor;
                    }));
                    Thread.Sleep(3000);
                }
            }
        }

        private BitmapImage GetIconImage(MessageType.MessageTypes messageTypes)
        {
            switch (messageTypes)
            {
                case MessageType.MessageTypes.Ok:
                    if (OkImage == null)
                    {
                        OkImage = LoadBitmapFromResource("Images/Ok.png");
                        return OkImage;
                    }
                    else
                    {
                        return OkImage;
                    }
                case MessageType.MessageTypes.Error:
                    if (ErrorImage == null)
                    {
                        ErrorImage = LoadBitmapFromResource("Images/Error.png");
                        return ErrorImage;
                    }
                    else
                    {
                        return ErrorImage;
                    }
                case MessageType.MessageTypes.Warning:
                    if (WarningImage == null)
                    {
                        WarningImage = LoadBitmapFromResource("Images/Warning.png");
                        return WarningImage;
                    }
                    else
                    {
                        return WarningImage;
                    }
            }
            return null;
        }

        private BitmapImage LoadBitmapFromResource(string pathInApplication, Assembly assembly = null)
        {
            if (assembly == null)
            {
                assembly = Assembly.GetCallingAssembly();
            }

            if (pathInApplication[0] == '/')
            {
                pathInApplication = pathInApplication.Substring(1);
            }

            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(@"pack://application:,,,/" + assembly.GetName().Name + ";component/" + pathInApplication, UriKind.Absolute);
            image.DecodePixelHeight = 20;
            image.DecodePixelWidth = 20;
            image.EndInit();
            image.Freeze();
            return image;
        }

        private Brush GetStatusColor(MessageType.MessageTypes messageTypes)
        {
            switch (messageTypes)
            {
                case MessageType.MessageTypes.Ok:
                    return Brushes.Green;
                   
                case MessageType.MessageTypes.Error:
                    return Brushes.Red;
                    
                case MessageType.MessageTypes.Warning:
                    return Brushes.Yellow;
                   
            }
            return Brushes.Black;
        }
        #endregion
    }
}
