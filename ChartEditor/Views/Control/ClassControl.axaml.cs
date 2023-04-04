using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Media;

namespace ChartEditor.Views.Control
{
    public class ClassControl : TemplatedControl
    {
        public static readonly StyledProperty<SolidColorBrush> PointsColorProperty =
            AvaloniaProperty.Register<ClassControl, SolidColorBrush>("PointsColor");
        public static readonly StyledProperty<double> GridHeightProperty =
            AvaloniaProperty.Register<ClassControl, double>("GridHeight");
        public static readonly StyledProperty<double> GridWidthProperty =
            AvaloniaProperty.Register<ClassControl, double>("GridWidth");
        public static readonly StyledProperty<string> MainParametersProperty =
            AvaloniaProperty.Register<ClassControl, string>("MainParameters");
        public static readonly StyledProperty<string> AttributesProperty =
            AvaloniaProperty.Register<ClassControl, string>("Attributes");
        public static readonly StyledProperty<string> OperationsProperty =
            AvaloniaProperty.Register<ClassControl, string>("Operations");

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
        public string MainParameters
        {
            get => GetValue(MainParametersProperty);
            set => SetValue(MainParametersProperty, value);
        }
        public string Attributes
        {
            get => GetValue(AttributesProperty);
            set => SetValue(AttributesProperty, value);
        }
        public string Operations
        {
            get => GetValue(OperationsProperty);
            set => SetValue(OperationsProperty, value);
        }
    }
}
