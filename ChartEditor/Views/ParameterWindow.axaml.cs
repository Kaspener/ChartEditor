using Avalonia.Controls;
using ChartEditor.ViewModels;

namespace ChartEditor.Views
{
    public partial class ParameterWindow : Window
    {
        public ParameterWindow()
        {
            InitializeComponent();
            DataContext = new ParameterWindowViewModel();
        }
    }
}
