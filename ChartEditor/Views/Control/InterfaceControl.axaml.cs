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
        public static readonly StyledProperty<string> MainParametersProperty =
            AvaloniaProperty.Register<InterfaceControl, string>("MainParameters");
        public static readonly StyledProperty<string> AttributesProperty =
            AvaloniaProperty.Register<InterfaceControl, string>("Attributes");
        public static readonly StyledProperty<string> OperationsProperty =
            AvaloniaProperty.Register<InterfaceControl, string>("Operations");
        public static readonly StyledProperty<bool> MainParametersAbstractProperty =
            AvaloniaProperty.Register<InterfaceControl, bool>("MainParametersAbstract");
        public static readonly StyledProperty<bool> MainParametersStaticProperty =
            AvaloniaProperty.Register<InterfaceControl, bool>("MainParametersStatic");
        public static readonly StyledProperty<bool> AttributesAbstractProperty =
            AvaloniaProperty.Register<InterfaceControl, bool>("AttributesAbstract");
        public static readonly StyledProperty<bool> AttributesStaticProperty =
            AvaloniaProperty.Register<InterfaceControl, bool>("AttributesStatic");
        public static readonly StyledProperty<bool> OperationsAbstractProperty =
            AvaloniaProperty.Register<InterfaceControl, bool>("OperationsAbstract");
        public static readonly StyledProperty<bool> OperationsStaticProperty =
            AvaloniaProperty.Register<InterfaceControl, bool>("OperationsStatic");

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
