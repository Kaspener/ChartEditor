using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartEditor.Models.Serializers
{
    public class YAMLSaverLoaderFactory : ISaverLoaderFactory
    {
        public IShapeLoader CreateLoader()
        {
            return new YAMLLoader();
        }

        public IShapeSaver CreateSaver()
        {
            return new YAMLSaver();
        }

        public bool IsMatch(string path)
        {
            return ".yaml".Equals(Path.GetExtension(path));
        }
    }
}
