using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartEditor.Models
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public ISolidColorBrush ColorOfEyes { get; set; }
    }
}
