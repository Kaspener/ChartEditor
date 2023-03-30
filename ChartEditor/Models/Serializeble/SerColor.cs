using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartEditor.Models.Serializeble
{
    [Serializable]
    public class SerColor
    {
        public byte Red { get; set; }
        public byte Green { get; set; }
        public byte Blue { get; set; }
        public byte Alpha { get; set; }

        public SerColor() { }

        public SerColor(Avalonia.Media.Color c)
        { Red = c.R; Green = c.G; Blue = c.B; Alpha = c.A; }

        static public Avalonia.Media.Color Color(SerColor c)
        { return Avalonia.Media.Color.FromArgb(c.Alpha, c.Red, c.Green, c.Blue); }

    }
}
