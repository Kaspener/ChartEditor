using Avalonia;
using Avalonia.Data;
using Avalonia.Data.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartEditor.Converters
{
    public class LenghtToTreePointsConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is double lenght && targetType.IsAssignableTo(typeof(IList<Point>)))
            {
                List<Point> ls = new List<Point>
                {
                    new Point(lenght-20, 2.5),
                    new Point(lenght, 10),
                    new Point(lenght-20, 17.5)
                };
                return ls;
            }
            return new BindingNotification(new InvalidCastException(), BindingErrorType.Error);
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
