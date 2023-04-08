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
        public static readonly StyledProperty<bool> MainParametersAbstractProperty =
            AvaloniaProperty.Register<ClassControl, bool>("MainParametersAbstract");
        public static readonly StyledProperty<bool> MainParametersStaticProperty =
            AvaloniaProperty.Register<ClassControl, bool>("MainParametersStatic");
        public static readonly StyledProperty<bool> AttributesAbstractProperty =
            AvaloniaProperty.Register<ClassControl, bool>("AttributesAbstract");
        public static readonly StyledProperty<bool> AttributesStaticProperty =
            AvaloniaProperty.Register<ClassControl, bool>("AttributesStatic");
        public static readonly StyledProperty<bool> OperationsAbstractProperty =
            AvaloniaProperty.Register<ClassControl, bool>("OperationsAbstract");
        public static readonly StyledProperty<bool> OperationsStaticProperty =
            AvaloniaProperty.Register<ClassControl, bool>("OperationsStatic");

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
        public bool MainParametersAbstract
        {
            get => GetValue(MainParametersAbstractProperty);
            set => SetValue(MainParametersAbstractProperty, value);
        }
        public bool MainParametersStatic
        {
            get => GetValue(MainParametersStaticProperty);
            set => SetValue(MainParametersStaticProperty, value);
        }
        public bool AttributesAbstract
        {
            get => GetValue(AttributesAbstractProperty);
            set => SetValue(AttributesAbstractProperty, value);
        }
        public bool AttributesStatic
        {
            get => GetValue(AttributesStaticProperty);
            set => SetValue(AttributesStaticProperty, value);
        }
        public bool OperationsAbstract
        {
            get => GetValue(OperationsAbstractProperty);
            set => SetValue(OperationsAbstractProperty, value);
        }
        public bool OperationsStatic
        {
            get => GetValue(OperationsStaticProperty);
            set => SetValue(OperationsStaticProperty, value);
        }

    }
}
