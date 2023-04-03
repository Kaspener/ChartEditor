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
            set
            {
                Point oldPoint = StartPoint;
                SetAndRaise(ref startPoint, value);
                if (ChangeStartPoint != null)
                {
                    ChangeStartPointEventArgs args = new ChangeStartPointEventArgs
                    {
                        OldStartPoint = oldPoint,
                        NewStartPoint = StartPoint
                    };
                    ChangeStartPoint(this, args);
                }
            }
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
        public event EventHandler<ChangeStartPointEventArgs> ChangeStartPoint;
    }
}
