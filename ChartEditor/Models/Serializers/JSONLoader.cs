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

            var objects = JsonConvert.DeserializeObject<List<AbstractElement>>(figuresJsontext,
                    new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.All,
                        Formatting = Formatting.Indented
                    });
            ObservableCollection<AbstractElement> figuresList =
                new ObservableCollection<AbstractElement>(objects);


            return figuresList;
        }
    }
}
