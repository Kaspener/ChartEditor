using DynamicData.Binding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartEditor.Models.Grids
{
    public class GridStrings : AbstractNotifyPropertyChanged
    {
        private string mainParameters;
        private string attributes;
        private string operations;
        private GridTextFonts fonts;

        public GridStrings(){
            Fonts = new GridTextFonts();
        }

        public string MainParameters
        {
            get => mainParameters;
            set => SetAndRaise(ref mainParameters, value);
        }
        public string Attributes
        {
            get => attributes;
            set => SetAndRaise(ref attributes, value);
        }
        public string Operations
        {
            get => operations;
            set => SetAndRaise(ref operations, value);
        }
        public GridTextFonts Fonts
        {
            get => fonts;
            set => SetAndRaise(ref fonts, value);
        }
    }
}
