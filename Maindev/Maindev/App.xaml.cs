using System.Configuration;
using System.Data;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Navigation;

namespace Maindev
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
    }

    public class VisualBrushScaleConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length != 6) return Transform.Identity;
            double BEWt = (double)values[0];
            double BEHt = (double)values[1];
            
            double BIWt = (double)values[2];
            double BIHt = (double)values[3];

            double posx = (double)values[4];
            double posy = (double)values[5];

            double scalex=  BIWt / BEWt;
            double scaley = BIHt / BEHt;

            double centerx = -(posx) / BEWt;
            double centery = -(posy) / BEHt;


            var tg = new TransformGroup();
            tg.Children.Add(new ScaleTransform(scalex, scaley, 0,0));
            tg.Children.Add(new TranslateTransform(centerx, centery));
            return tg;
        }
        public object[] ConvertBack(object values, Type[] targetType, object parameter, CultureInfo culture)
        {
             throw new NotImplementedException();
        }

    }
}
