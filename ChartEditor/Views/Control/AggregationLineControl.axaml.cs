using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace ChartEditor.Views.Control
{
    public class AggregationLineControl : TemplatedControl
    {
        public static readonly StyledProperty<double> LenghtProperty =
            AvaloniaProperty.Register<AggregationLineControl, double>("Lenght");

        public double Lenght
        {
            get => GetValue(LenghtProperty);
            set => SetValue(LenghtProperty, value);
        }
    }
}
