using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ExpenseTracker.Adorners
{
    public class WaitAdorner : Adorner
    {
        public WaitAdorner(UIElement adornedElement) :
            base(adornedElement)
        {
            
        }

        protected override void OnRender(System.Windows.Media.DrawingContext drawingContext)
        {

            //drawingContext.DrawRectangle(Brushes.Gray, null , new System.Windows.Rect(50, 50, 100, 100));
            //BitmapImage leftImage = new BitmapImage(new Uri(@"C:\Users\nmittal02\Pictures\Sample Pictures\images.gif"));
            //drawingContext.DrawImage(leftImage, new System.Windows.Rect(50, 50, 100, 100));
            Typeface tp = new Typeface("Times New Roman");
            FormattedText ft = new FormattedText("Please wait...", System.Globalization.CultureInfo.CurrentCulture,
                FlowDirection.LeftToRight, tp, 25, Brushes.White);
            Point p = new Point(150,90);
            drawingContext.DrawRectangle(Brushes.Black, null, new System.Windows.Rect(140, 80, 180, 50));
            drawingContext.DrawText(ft,p);
        }
    }
}
