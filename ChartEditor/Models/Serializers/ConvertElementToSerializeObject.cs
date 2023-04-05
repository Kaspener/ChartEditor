using Avalonia;
using Avalonia.Controls.Platform;
using ChartEditor.Models.Grids;
using ChartEditor.Models.Lines;
using DynamicData.Binding;
using HarfBuzzSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartEditor.Models.Serializers
{
    public static class ConvertElementToSerializeObject
    {
        public static ObservableCollection<SerializebleElement> ToSerializer(ObservableCollection<AbstractElement> elements)
        {
            ObservableCollection <SerializebleElement> serializebleElements= new ObservableCollection<SerializebleElement>();
            foreach (AbstractElement el in elements)
            {
                if (el is AbstractGrid grid)
                {
                    if (grid is ClassElement) serializebleElements.Add(new SerializebleGrid {TypeGrid="ClassElement", GridText = grid.GridText, Height = grid.Height, ID = grid.ID, Width = grid.Width, StartPoint = grid.StartPoint.ToString() });
                    if (grid is InterfaceElement) serializebleElements.Add(new SerializebleGrid {TypeGrid= "InterfaceElement", GridText = grid.GridText, Height = grid.Height, ID = grid.ID, Width = grid.Width, StartPoint = grid.StartPoint.ToString() });
                }
                if (el is AbstractLine line)
                {
                    SerializebleLine new_element = new SerializebleLine {Angle = line.Angle, ConnectionPointFirst = line.ConnectionPointFirst, ConnectionPointSecond = line.ConnectionPointSecond, EndPoint = line.EndPoint.ToString(), StartPoint = line.StartPoint.ToString(), ID = line.ID, Lenght = line.Lenght, LineCenterX = line.LineCenterX, FirstGridID = line.FirstGrid.ID, SecondGridID = line.SecondGrid.ID };
                    if (line is AggregationLine) new_element.TypeLine = "AggregationLine";
                    if (line is AssociationLine) new_element.TypeLine = "AssociationLine";
                    if (line is CompositionLine) new_element.TypeLine = "CompositionLine";
                    if (line is DependencyLine) new_element.TypeLine = "DependencyLine";
                    if (line is ImplementationLine) new_element.TypeLine = "ImplementationLine";
                    if (line is InheritanceLine) new_element.TypeLine = "InheritanceLine";
                    serializebleElements.Add(new_element);
                }
            }
            return serializebleElements;
        }
        public static ObservableCollection<AbstractElement> FromSerializer(ObservableCollection<SerializebleElement> elements)
        {
            ObservableCollection<AbstractElement> figures = new ObservableCollection<AbstractElement>();
            foreach(SerializebleElement element in elements)
            {
                if (element is SerializebleGrid grid)
                {
                    if (grid.TypeGrid == "ClassElement") figures.Add(new ClassElement { ID = grid.ID, Height = grid.Height, GridText = grid.GridText, Width = grid.Width, StartPoint = Point.Parse(grid.StartPoint)});
                    if (grid.TypeGrid == "InterfaceElement") figures.Add(new InterfaceElement { ID = grid.ID, Height = grid.Height, GridText = grid.GridText, Width = grid.Width, StartPoint = Point.Parse(grid.StartPoint) });
                }
                if (element is SerializebleLine line)
                {
                    if (line.TypeLine == "AggregationLine")
                    {
                        var new_element = new AggregationLine { ID = line.ID, Angle = line.Angle, ConnectionPointFirst = line.ConnectionPointFirst, ConnectionPointSecond = line.ConnectionPointSecond, Lenght = line.Lenght, LineCenterX = line.LineCenterX };
                        new_element.StartPoint = Point.Parse(line.StartPoint);
                        new_element.EndPoint = Point.Parse(line.EndPoint);
                        foreach(AbstractElement fig in figures)
                        {
                            if (fig is AbstractGrid grd)
                            {
                                if (fig.ID == line.FirstGridID)
                                {
                                    new_element.FirstGrid = grd;
                                    break;
                                }
                            }
                        }
                        foreach (AbstractElement fig in figures)
                        {
                            if (fig is AbstractGrid grd)
                            {
                                if (fig.ID == line.SecondGridID)
                                {
                                    new_element.SecondGrid = grd;
                                    break;
                                }
                            }
                        }
                        figures.Add(new_element);
                    }
                    if (line.TypeLine == "AssociationLine")
                    {
                        var new_element = new AssociationLine { ID = line.ID, Angle = line.Angle, ConnectionPointFirst = line.ConnectionPointFirst, ConnectionPointSecond = line.ConnectionPointSecond, Lenght = line.Lenght, LineCenterX = line.LineCenterX };
                        new_element.StartPoint = Point.Parse(line.StartPoint);
                        new_element.EndPoint = Point.Parse(line.EndPoint);
                        foreach (AbstractElement fig in figures)
                        {
                            if (fig is AbstractGrid grd)
                            {
                                if (fig.ID == line.FirstGridID)
                                {
                                    new_element.FirstGrid = grd;
                                    break;
                                }
                            }
                        }
                        foreach (AbstractElement fig in figures)
                        {
                            if (fig is AbstractGrid grd)
                            {
                                if (fig.ID == line.SecondGridID)
                                {
                                    new_element.SecondGrid = grd;
                                    break;
                                }
                            }
                        }
                        figures.Add(new_element);

                    }
                    if (line.TypeLine == "CompositionLine")
                    {
                        var new_element = new CompositionLine { ID = line.ID, Angle = line.Angle, ConnectionPointFirst = line.ConnectionPointFirst, ConnectionPointSecond = line.ConnectionPointSecond, Lenght = line.Lenght, LineCenterX = line.LineCenterX };
                        new_element.StartPoint = Point.Parse(line.StartPoint);
                        new_element.EndPoint = Point.Parse(line.EndPoint);
                        foreach (AbstractElement fig in figures)
                        {
                            if (fig is AbstractGrid grd)
                            {
                                if (fig.ID == line.FirstGridID)
                                {
                                    new_element.FirstGrid = grd;
                                    break;
                                }
                            }
                        }
                        foreach (AbstractElement fig in figures)
                        {
                            if (fig is AbstractGrid grd)
                            {
                                if (fig.ID == line.SecondGridID)
                                {
                                    new_element.SecondGrid = grd;
                                    break;
                                }
                            }
                        }
                        figures.Add(new_element);

                    }
                    if (line.TypeLine == "DependencyLine")
                    {
                        var new_element = new DependencyLine { ID = line.ID, Angle = line.Angle, ConnectionPointFirst = line.ConnectionPointFirst, ConnectionPointSecond = line.ConnectionPointSecond, Lenght = line.Lenght, LineCenterX = line.LineCenterX };
                        new_element.StartPoint = Point.Parse(line.StartPoint);
                        new_element.EndPoint = Point.Parse(line.EndPoint);
                        foreach (AbstractElement fig in figures)
                        {
                            if (fig is AbstractGrid grd)
                            {
                                if (fig.ID == line.FirstGridID)
                                {
                                    new_element.FirstGrid = grd;
                                    break;
                                }
                            }
                        }
                        foreach (AbstractElement fig in figures)
                        {
                            if (fig is AbstractGrid grd)
                            {
                                if (fig.ID == line.SecondGridID)
                                {
                                    new_element.SecondGrid = grd;
                                    break;
                                }
                            }
                        }
                        figures.Add(new_element);

                    }
                    if (line.TypeLine == "ImplementationLine")
                    {
                        var new_element = new ImplementationLine { ID = line.ID, Angle = line.Angle, ConnectionPointFirst = line.ConnectionPointFirst, ConnectionPointSecond = line.ConnectionPointSecond, Lenght = line.Lenght, LineCenterX = line.LineCenterX };
                        new_element.StartPoint = Point.Parse(line.StartPoint);
                        new_element.EndPoint = Point.Parse(line.EndPoint);
                        foreach (AbstractElement fig in figures)
                        {
                            if (fig is AbstractGrid grd)
                            {
                                if (fig.ID == line.FirstGridID)
                                {
                                    new_element.FirstGrid = grd;
                                    break;
                                }
                            }
                        }
                        foreach (AbstractElement fig in figures)
                        {
                            if (fig is AbstractGrid grd)
                            {
                                if (fig.ID == line.SecondGridID)
                                {
                                    new_element.SecondGrid = grd;
                                    break;
                                }
                            }
                        }
                        figures.Add(new_element);

                    }
                    if (line.TypeLine == "InheritanceLine")
                    {
                        var new_element = new InheritanceLine { ID = line.ID, Angle = line.Angle, ConnectionPointFirst = line.ConnectionPointFirst, ConnectionPointSecond = line.ConnectionPointSecond, Lenght = line.Lenght, LineCenterX = line.LineCenterX };
                        new_element.StartPoint = Point.Parse(line.StartPoint);
                        new_element.EndPoint = Point.Parse(line.EndPoint);
                        foreach (AbstractElement fig in figures)
                        {
                            if (fig is AbstractGrid grd)
                            {
                                if (fig.ID == line.FirstGridID)
                                {
                                    new_element.FirstGrid = grd;
                                    break;
                                }
                            }
                        }
                        foreach (AbstractElement fig in figures)
                        {
                            if (fig is AbstractGrid grd)
                            {
                                if (fig.ID == line.SecondGridID)
                                {
                                    new_element.SecondGrid = grd;
                                    break;
                                }
                            }
                        }
                        figures.Add(new_element);

                    }

                }
            }
            return figures;
        }

    }
}
