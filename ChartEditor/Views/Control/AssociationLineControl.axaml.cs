using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace ChartEditor.Views.Control
{
    public class AssociationLineControl : TemplatedControl
    {
        public static readonly StyledProperty<double> LenghtProperty =
            AvaloniaProperty.Register<AssociationLineControl, double>("Lenght");

        public double Lenght
        {
            get => GetValue(LenghtProperty);
            set => SetValue(LenghtProperty, value);
        }
    }
}
