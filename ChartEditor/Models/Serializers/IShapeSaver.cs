using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartEditor.Models.Serializers
{
    public interface IShapeSaver { 
        void Save(IEnumerable<AbstractElement> figures, string path);
    }
}
