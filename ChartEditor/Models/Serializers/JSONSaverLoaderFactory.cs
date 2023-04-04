using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartEditor.Models.Serializers
{
    public class JSONSaverLoaderFactory : ISaverLoaderFactory
    {
        public IShapeLoader CreateLoader()
        {
            return new JSONLoader();
        }

        public IShapeSaver CreateSaver()
        {
            return new JSONSaver();
        }

        public bool IsMatch(string path)
        {
            return ".json".Equals(Path.GetExtension(path));
        }
    }
}
