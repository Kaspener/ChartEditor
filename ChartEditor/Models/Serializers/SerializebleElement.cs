using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ChartEditor.Models.Serializers
{
    [XmlInclude(typeof(SerializebleGrid))]
    [XmlInclude(typeof(SerializebleLine))]
    public abstract class SerializebleElement
    {
        public uint ID { get; set; }
    }
}
