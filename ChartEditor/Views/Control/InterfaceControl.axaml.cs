using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Media;

namespace ChartEditor.Views.Control
{
    public class InterfaceControl : TemplatedControl
    {
        public static readonly StyledProperty<SolidColorBrush> PointsColorProperty =
            AvaloniaProperty.Register<ClassControl, SolidColorBrush>("PointsColor");
        public static readonly StyledProperty<double> GridHeightProperty =
            AvaloniaProperty.Register<InterfaceControl, double>("GridHeight");
        public static readonly StyledProperty<double> GridWidthProperty =
            AvaloniaProperty.Register<InterfaceControl, double>("GridWidth");

        public SolidColorBrush PointsColor
        {
            get => GetValue(PointsColorProperty);
            set => SetValue(PointsColorProperty, value);
        }

        public double GridHeight
        {
            get => GetValue(GridHeightProperty);
            set => SetValue(GridHeightProperty, value);
        }
        public double GridWidth
        {
            get => GetValue(GridWidthProperty);
            set => SetValue(GridWidthProperty, value);
        }
    }
}
