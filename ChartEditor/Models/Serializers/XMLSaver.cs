using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ChartEditor.Models.Serializers
{
    public class XMLSaver : IShapeSaver
    {
        public void Save(ObservableCollection<AbstractElement> figures, string path)
        {
            var ser = ConvertElementToSerializeObject.ToSerializer(figures);
            XmlSerializer formatter = new XmlSerializer(typeof(ObservableCollection<SerializebleElement>));

            using (var stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.Write))
            {
                formatter.Serialize(stream, ser);
            }
        }
    }
}
