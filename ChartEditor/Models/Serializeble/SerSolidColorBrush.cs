using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartEditor.Models.Serializeble
{
    [Serializable]
    public class SerSolidColorBrush
    {
        public SerColor sColor { get; set; }

        public SerSolidColorBrush() { }

        public SerSolidColorBrush(Avalonia.Media.Color c)
        {
            sColor = new SerColor(c);
        }

        public SerSolidColorBrush(Avalonia.Media.SolidColorBrush b)
        {
            sColor = new SerColor(b.Color);
        }


        public Avalonia.Media.SolidColorBrush SolidColorBrush()
        {
            Avalonia.Media.Color c = SerColor.Color(sColor);
            return new Avalonia.Media.SolidColorBrush(c);
        }

        static public Avalonia.Media.SolidColorBrush SolidColorBrush(SerSolidColorBrush b)
        {
            Avalonia.Media.Color c = SerColor.Color(b.sColor);
            return new Avalonia.Media.SolidColorBrush(c);
        }
    }
}
