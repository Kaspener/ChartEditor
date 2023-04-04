using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartEditor.Models.Serializers
{
    public interface ISaverLoaderFactory
    {
        IShapeLoader CreateLoader();
        IShapeSaver CreateSaver();

        bool IsMatch(string path);
    }
}
