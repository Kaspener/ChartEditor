using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartEditor.Models.Serializers
{
    public class JSONSaver : IShapeSaver
    {
        public void Save(ObservableCollection<AbstractElement> figures, string path)
        {
            ObservableCollection<SerializebleElement> ser = ConvertElementToSerializeObject.ToSerializer(figures);
            JsonSerializer serializer = new JsonSerializer();
            serializer.NullValueHandling = NullValueHandling.Ignore;
            string output = string.Empty;
            output = JsonConvert.SerializeObject(ser.ToList(),
                new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All,
                    Formatting = Formatting.Indented
                });

            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine(output);
            }
        }
    }
}
