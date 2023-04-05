using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace ChartEditor.Models.Serializers
{
    public class JSONLoader : IShapeLoader
    {
        public ObservableCollection<AbstractElement> Load(string path)
        {
            var figuresJsontext = File.ReadAllText(path);

            var objects = JsonConvert.DeserializeObject<List<SerializebleElement>>(figuresJsontext,
                    new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.All,
                        Formatting = Formatting.Indented
                    });
            ObservableCollection<SerializebleElement> figuresList =
                new ObservableCollection<SerializebleElement>(objects);


            return ConvertElementToSerializeObject.FromSerializer(figuresList);
        }
    }
}
