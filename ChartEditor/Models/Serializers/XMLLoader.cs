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
    public class XMLLoader : IShapeLoader
    {
        public ObservableCollection<AbstractElement> Load(string path)
        {
            ObservableCollection<SerializebleElement> retVal;
            XmlSerializer formatter = new XmlSerializer(typeof(ObservableCollection<SerializebleElement>));

            using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                retVal = (ObservableCollection<SerializebleElement>)formatter.Deserialize(stream);
            }
            return ConvertElementToSerializeObject.FromSerializer(retVal);
        }
    }
}
