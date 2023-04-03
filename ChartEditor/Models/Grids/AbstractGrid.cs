using Avalonia;
using DynamicData.Binding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartEditor.Models.Grids
{
    public abstract class AbstractGrid : AbstractElement
    {
        private Point startPoint;
        private double height;
        private double width;

        public Point StartPoint
        {
            get => startPoint;
            set => SetAndRaise(ref startPoint, value);
        }
        public double Height
        {
            get => height;
            set => SetAndRaise(ref height, value);
        }
        public double Width
        {
            get => width;
            set => SetAndRaise(ref width, value);
        }
    }
}
