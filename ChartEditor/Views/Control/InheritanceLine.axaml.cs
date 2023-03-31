using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.VisualTree;
using System.Linq;
using System.Windows.Input;

namespace ChartEditor.Views.Control
{
    public class InheritanceLine : TemplatedControl
    {
        private Avalonia.Point pointEnd;

        public InheritanceLine()
        {
            PointEnd = new Avalonia.Point(180, 10);
        }

        public Avalonia.Point PointEnd
        {
            get { return pointEnd; }
            set { pointEnd = value; }
        }
    }
}
