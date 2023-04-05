using ChartEditor.Models.Grids;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartEditor.Models.Serializers
{
    public class SerializebleLine : SerializebleElement
    {
        public string TypeLine { get; set; }
        public double Lenght { get; set; }
        public double Angle { get; set; }
        public string StartPoint { get; set; }
        public string EndPoint { get; set; }
        public uint FirstGridID { get; set; }
        public uint SecondGridID { get; set; }
        public double LineCenterX { get; set; }
        public int ConnectionPointFirst { get; set; }
        public int ConnectionPointSecond { get; set; }
    }
}
