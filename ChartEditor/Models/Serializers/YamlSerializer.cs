using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace ChartEditor.Models.Serializers
{
    public static class YamlSerializer<T>
    {
        public static void Save(string path, T data)
        {
            var serializer = new SerializerBuilder().Build();
            var yaml = serializer.Serialize(data);
            using (StreamWriter writer = new StreamWriter(path, false))
            {
                writer.WriteLine(yaml);
            }
        }

        public static T Load(string path)
        {
            var deserializer = new DeserializerBuilder().Build();
            string input;
            using (StreamReader reader = new StreamReader(path))
            {
                input = reader.ReadToEnd();
            }
            return deserializer.Deserialize<T>(input);
        }
    }
}
