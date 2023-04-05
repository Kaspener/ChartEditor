using ChartEditor.Models.Grids;
using ChartEditor.Models.Lines;
using DynamicData.Binding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ChartEditor.Models
{
    //[XmlInclude(typeof(AbstractGrid))]
    //[XmlInclude(typeof(AbstractLine))]
    //[XmlInclude(typeof(ClassElement))]
    //[XmlInclude(typeof(InterfaceElement))]
    //[XmlInclude(typeof(AggregationLine))]
    //[XmlInclude(typeof(AssociationLine))]
    //[XmlInclude(typeof(CompositionLine))]
    //[XmlInclude(typeof(DependencyLine))]
    //[XmlInclude(typeof(ImplementationLine))]
    //[XmlInclude(typeof(InheritanceLine))]

    public abstract class AbstractElement : AbstractNotifyPropertyChanged
    {
        private static uint id_generator = 0;
        protected uint id;
        public AbstractElement()
        {
            id = id_generator++;
        }

        public uint ID { get => id; set => SetAndRaise(ref id, value); }
    }
}
