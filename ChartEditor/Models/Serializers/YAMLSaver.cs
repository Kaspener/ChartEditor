using System.Collections.ObjectModel;
using System.IO;
using YamlDotNet.Serialization;

namespace ChartEditor.Models.Serializers
{
    public class YAMLSaver : IShapeSaver
    {
        public void Save(ObservableCollection<AbstractElement> figures, string path)
        {
            ObservableCollection<SerializebleElement> elements = ConvertElementToSerializeObject.ToSerializer(figures);
            var serializer = new SerializerBuilder().Build();
            var yaml = serializer.Serialize(elements);
            using (StreamWriter writer = new StreamWriter(path, false))
            {
                writer.WriteLine(yaml);
            }
        }
    }
}