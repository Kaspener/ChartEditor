using DynamicData.Binding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartEditor.Models
{
    public abstract class AbstractElement : AbstractNotifyPropertyChanged
    {
        private static uint id_generator = 0;
        protected uint id;
        public AbstractElement()
        {
            id = id_generator++;
        }

        public uint ID {get => id;}
    }
}
