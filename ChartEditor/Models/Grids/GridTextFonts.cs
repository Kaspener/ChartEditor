using DynamicData.Binding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartEditor.Models.Grids
{
    public class GridTextFonts : AbstractNotifyPropertyChanged
    {
        private bool isMainParametersAbstract;
        private bool isMainParametersStatic;
        private bool isAttributesAbstract;
        private bool isAttributesStatic;
        private bool isOperationsAbstract;
        private bool isOperationsStatic;

        public bool IsMainParametersAbstract
        {
            get => isMainParametersAbstract;
            set => SetAndRaise(ref isMainParametersAbstract, value);
        }
        public bool IsMainParametersStatic
        {
            get => isMainParametersStatic;
            set => SetAndRaise(ref isMainParametersStatic, value);
        }
        public bool IsAttributesAbstract
        {
            get => isAttributesAbstract;
            set => SetAndRaise(ref isAttributesAbstract, value);
        }
        public bool IsAttributesStatic
        {
            get => isAttributesStatic;
            set => SetAndRaise(ref isAttributesStatic, value);
        }
        public bool IsOperationsAbstract
        {
            get => isOperationsAbstract;
            set => SetAndRaise(ref isOperationsAbstract, value);
        }
        public bool IsOperationsStatic
        {
            get => isOperationsStatic;
            set => SetAndRaise(ref isOperationsStatic, value);
        }
    }
}
