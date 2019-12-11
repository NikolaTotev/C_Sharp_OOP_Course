using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Lab_11_Problem_2
{
    [ValueConversion(typeof(double), typeof(string))]
    class ValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double output = value == null ? 0 : (double) value;
            return string.Format("{0:F2}", output);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double output = 0;
            double.TryParse((string) value, out output);
            return output;
        }
    }
}
