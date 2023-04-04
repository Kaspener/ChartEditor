using ChartEditor.Models.Grids;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartEditor.ViewModels
{
    public class ParameterWindowViewModel : ViewModelBase
    {
        private GridStrings strings;

        public ParameterWindowViewModel()
        {
            strings = new GridStrings();
        }

        public GridStrings Strings
        {
            get => strings;
            set => this.RaiseAndSetIfChanged(ref strings, value);
        }
    }
}
