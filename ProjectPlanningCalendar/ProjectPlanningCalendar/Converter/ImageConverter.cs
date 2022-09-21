using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPlanningCalendar
{
    public class ImageSourceConverter : IValueConverter
    {
        public object Convert(object? value, Type targetType, object parameter, CultureInfo culture)
        {
            string text = value as string;
            return ImageSource.FromResource(typeof(ImageSourceConverter).GetTypeInfo().Assembly.GetName().Name + ".Resources.Images." + text, typeof(ImageSourceConverter).GetTypeInfo().Assembly);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
