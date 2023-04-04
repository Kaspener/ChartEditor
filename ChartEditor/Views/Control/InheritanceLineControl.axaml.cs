using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.VisualTree;
using System.Linq;
using System.Windows.Input;

namespace ChartEditor.Views.Control
{
    public class InheritanceLineControl : TemplatedControl
    {
        public static readonly StyledProperty<double> LenghtProperty =
            AvaloniaProperty.Register<InheritanceLineControl, double>("Lenght");
        public static readonly StyledProperty<double> TextInverseProperty =
            AvaloniaProperty.Register<InheritanceLineControl, double>("TextInverse");
        

        public double Lenght
        {
            get => GetValue(LenghtProperty);
            set => SetValue(LenghtProperty, value);
        }

        public double TextInverse
        {
            get => GetValue(TextInverseProperty);
            set => SetValue(TextInverseProperty, value);
        }
    }
}
