using Avalonia.Controls.Shapes;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using Avalonia.Media;
using ChartEditor.Models.Serializeble;
using ChartEditor.Models;
using YamlDotNet.Serialization.NamingConventions;
using YamlDotNet.Serialization;
using ChartEditor.Models.Serializers;

namespace ChartEditor.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            ObservableCollection<Line> lines = new ObservableCollection<Line>();
            lines.Add(new Line { StartPoint = new Avalonia.Point(10, 36), EndPoint = new Avalonia.Point(45, 745), Stroke = new SolidColorBrush(Colors.Black) });
            lines.Add(new Line { StartPoint = new Avalonia.Point(345, 36), EndPoint = new Avalonia.Point(45, 34), Stroke = new SolidColorBrush(Colors.Yellow) });
            SolidColorBrush br = new SolidColorBrush(Colors.Black);
            YamlSerializer<SolidColorBrush>.Save("pernon.yaml", br);
            SolidColorBrush new_br = YamlSerializer<SolidColorBrush>.Load("pernon.yaml");
            //YamlSerializer<ObservableCollection<Line>>.Save("pernon.yaml", lines);
            //ObservableCollection<Line> new_collection = YamlSerializer<ObservableCollection<Line>>.Load("pernon.yaml");

        }
    }
}
