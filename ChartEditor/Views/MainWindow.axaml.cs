using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
using Avalonia.VisualTree;
using ChartEditor.Models;
using ChartEditor.Models.Grids;
using ChartEditor.Models.Lines;
using ChartEditor.Models.Serializers;
using ChartEditor.ViewModels;
using DynamicData;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace ChartEditor.Views
{
    public partial class MainWindow : Window
    {
        private Point pointPointerPressed;
        private Point pointerPositionIntoShape;
        private Point pointerStartPositionToResize;
        public MainWindow()
        {
            InitializeComponent();
            AddHandler(DragDrop.DropEvent, DropShapes);
        }
        private async void OnExportMenuClickPNG(object sender, RoutedEventArgs routedEventArgs)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filters.Add(
                new FileDialogFilter
                {
                    Name = "PNG files",
                    Extensions = new string[] { "png" }.ToList()
                });

            string? path = await saveFileDialog.ShowAsync(this);

            var canvas = this.GetVisualDescendants().OfType<Canvas>().Where(canvas => canvas.Name.Equals("mainCanvas")).FirstOrDefault();
            if (path != null)
            {
                var pixelSize = new PixelSize((int)canvas.Bounds.Width, (int)canvas.Bounds.Height);
                var size = new Size(canvas.Bounds.Width, canvas.Bounds.Height);
                using (RenderTargetBitmap bitmap = new RenderTargetBitmap(pixelSize, new Avalonia.Vector(96, 96)))
                {
                    canvas.Measure(size);
                    canvas.Arrange(new Rect(size));
                    bitmap.Render(canvas);
                    bitmap.Save(path);
                }
            }
        }
        private async void OnExportMenuClickJSON(object sender, RoutedEventArgs eventArgs)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filters.Add(
                new FileDialogFilter
                {
                    Name = "JSON files",
                    Extensions = new string[] { "json" }.ToList()
                });

            string? path = await saveFileDialog.ShowAsync(this);

            if (path != null)
            {
                if (this.DataContext is MainWindowViewModel dataContext)
                {
                    dataContext.SaveFigures(path);
                }
            }
        }
        private async void OnImportMenuClickJSON(object sender, RoutedEventArgs eventArgs)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filters.Add(
                new FileDialogFilter
                {
                    Name = "JSON files",
                    Extensions = new string[] { "json" }.ToList()
                });

            string[]? path = await openFileDialog.ShowAsync(this);

            if (path != null)
            {
                if (this.DataContext is MainWindowViewModel dataContext)
                {
                    dataContext.LoadFigures(path[0]);
                }
            }
        }

        private async void OnExportMenuClickXML(object sender, RoutedEventArgs eventArgs)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filters.Add(
                new FileDialogFilter
                {
                    Name = "Xml files",
                    Extensions = new string[] { "xml" }.ToList()
                });

            string? path = await saveFileDialog.ShowAsync(this);

            if (path != null)
            {
                if (this.DataContext is MainWindowViewModel dataContext)
                {
                    dataContext.SaveFigures(path);
                }
            }
        }
        private async void OnImportMenuClickXML(object sender, RoutedEventArgs eventArgs)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filters.Add(
                new FileDialogFilter
                {
                    Name = "Xml files",
                    Extensions = new string[] { "xml" }.ToList()
                });

            string[]? path = await openFileDialog.ShowAsync(this);

            if (path != null)
            {
                if (this.DataContext is MainWindowViewModel dataContext)
                {
                    dataContext.LoadFigures(path[0]);
                }
            }
        }

        private async void OnExportMenuClickYAML(object sender, RoutedEventArgs eventArgs)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filters.Add(
                new FileDialogFilter
                {
                    Name = "Yaml files",
                    Extensions = new string[] { "yaml" }.ToList()
                });

            string? path = await saveFileDialog.ShowAsync(this);

            if (path != null)
            {
                if (this.DataContext is MainWindowViewModel dataContext)
                {
                    dataContext.SaveFigures(path);
                }
            }
        }
        private async void OnImportMenuClickYAML(object sender, RoutedEventArgs eventArgs)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filters.Add(
                new FileDialogFilter
                {
                    Name = "Yaml files",
                    Extensions = new string[] { "yaml" }.ToList()
                });

            string[]? path = await openFileDialog.ShowAsync(this);

            if (path != null)
            {
                if (this.DataContext is MainWindowViewModel dataContext)
                {
                    dataContext.LoadFigures(path[0]);
                }
            }
        }

        public async void OpenParameterDialogWindow(object sender, RoutedEventArgs routedEventArgs)
        {
            if (routedEventArgs.Source is Avalonia.Controls.Control control)
            {
                if (control.DataContext is AbstractGrid grd)
                {
                    ParameterWindow parameterWindow = new ParameterWindow();
                    //parameterWindow.DataContext = new ParameterWindowViewModel();
                    if (parameterWindow.DataContext is ParameterWindowViewModel parameters)
                    {
                        parameters.Strings = grd.GridText;
                        await parameterWindow.ShowDialog(this);
                    }
                }
            }
        }

        private void PointerPressedOnMainCanvas(object sender, PointerPressedEventArgs pointerPressedEventArgs)
        {
            if (pointerPressedEventArgs.Source is Avalonia.Controls.Control control)
            {
                pointPointerPressed = pointerPressedEventArgs
                        .GetPosition(
                        this.GetVisualDescendants()
                        .OfType<Canvas>()
                        .FirstOrDefault(canvas => string.IsNullOrEmpty(canvas.Name) == false &&
                        canvas.Name.Equals("mainCanvas")));
                if (control.DataContext is MainWindowViewModel mainWindow)
                {
                    if (mainWindow.IsClass) mainWindow.Shapes.Add(new ClassElement { StartPoint = pointPointerPressed, Height=100, Width=100 });
                    if (mainWindow.IsInterface) mainWindow.Shapes.Add(new InterfaceElement { StartPoint = pointPointerPressed, Height = 100, Width = 100 });
                }
                if (control.DataContext is AbstractLine line)
                {
                    if (this.DataContext is MainWindowViewModel window)
                    {
                        if (window.IsDelete)
                        {
                            window.Shapes.Remove(line);
                        }
                    }
                }
                if (control.DataContext is AbstractGrid clas)
                {
                    if (this.DataContext is MainWindowViewModel window)
                    {
                        if (window.IsMove)
                        {
                            pointerPositionIntoShape = pointerPressedEventArgs.GetPosition(control.Parent);
                            this.PointerMoved += PointerMoveDragShape;
                            this.PointerReleased += PointerPressedReleasedDragShape;
                        }
                        if (window.IsResize)
                        {
                            if (control is Ellipse el)
                            {
                                pointerStartPositionToResize = pointPointerPressed;
                                this.PointerMoved += PointerMoveResizeShape;
                                this.PointerReleased += PointerPressedReleasedResizeShape;
                            }
                        }
                        if (window.IsDelete)
                        {
                            for (int i = 0; i < window.Shapes.Count;)
                            {
                                if (window.Shapes[i] is AbstractLine ln)
                                {
                                    if (ln.FirstGrid == clas || ln.SecondGrid == clas) window.Shapes.Remove(ln);
                                    else ++i;
                                }
                                else ++i;
                            }
                            window.Shapes.Remove(clas);
                        }
                        if (control is Ellipse ellipse)
                        {
                            int ellipseNum = 0;
                            if (ellipse.Name == "UpLeftEl") ellipseNum = 0;
                            if (ellipse.Name == "UpEl") ellipseNum = 1;
                            if (ellipse.Name == "UpRightEl") ellipseNum = 2;
                            if (ellipse.Name == "LeftEl") ellipseNum = 3;
                            if (ellipse.Name == "RightEl") ellipseNum = 4;
                            if (ellipse.Name == "DownLeftEl") ellipseNum = 5;
                            if (ellipse.Name == "DownEl") ellipseNum = 6;
                            if (ellipse.Name == "DownRightEl") ellipseNum = 7;

                            if (window.IsAggregation)
                            {
                                window.Shapes.Add(new AggregationLine
                                {
                                    StartPoint = pointPointerPressed,
                                    EndPoint = pointPointerPressed,
                                    FirstGrid = clas,
                                    ConnectionPointFirst = ellipseNum
                                });
                                this.PointerMoved += PointerMoveDrawLine;
                                this.PointerReleased += PointerPressedReleasedDrawLine;
                            }
                            if (window.IsAssociation)
                            {
                                window.Shapes.Add(new AssociationLine
                                {
                                    StartPoint = pointPointerPressed,
                                    EndPoint = pointPointerPressed,
                                    FirstGrid = clas,
                                    ConnectionPointFirst = ellipseNum
                                });
                                this.PointerMoved += PointerMoveDrawLine;
                                this.PointerReleased += PointerPressedReleasedDrawLine;
                            }
                            if (window.IsComposition)
                            {
                                window.Shapes.Add(new CompositionLine
                                {
                                    StartPoint = pointPointerPressed,
                                    EndPoint = pointPointerPressed,
                                    FirstGrid = clas,
                                    ConnectionPointFirst = ellipseNum
                                });
                                this.PointerMoved += PointerMoveDrawLine;
                                this.PointerReleased += PointerPressedReleasedDrawLine;
                            }
                            if (window.IsDependency)
                            {
                                window.Shapes.Add(new DependencyLine
                                {
                                    StartPoint = pointPointerPressed,
                                    EndPoint = pointPointerPressed,
                                    FirstGrid = clas,
                                    ConnectionPointFirst = ellipseNum
                                });
                                this.PointerMoved += PointerMoveDrawLine;
                                this.PointerReleased += PointerPressedReleasedDrawLine;
                            }
                            if (window.IsImplementation)
                            {
                                window.Shapes.Add(new ImplementationLine
                                {
                                    StartPoint = pointPointerPressed,
                                    EndPoint = pointPointerPressed,
                                    FirstGrid = clas,
                                    ConnectionPointFirst = ellipseNum
                                });
                                this.PointerMoved += PointerMoveDrawLine;
                                this.PointerReleased += PointerPressedReleasedDrawLine;
                            }
                            if (window.IsInheritance)
                            {
                                window.Shapes.Add(new InheritanceLine
                                {
                                    StartPoint = pointPointerPressed,
                                    EndPoint = pointPointerPressed,
                                    FirstGrid = clas,
                                    ConnectionPointFirst = ellipseNum
                                });
                                this.PointerMoved += PointerMoveDrawLine;
                                this.PointerReleased += PointerPressedReleasedDrawLine;
                            }
                        }
                    }
                }

            }
        }
        private void PointerMoveDragShape(object? sender, PointerEventArgs pointerEventArgs)
        {
            if (pointerEventArgs.Source is Avalonia.Controls.Control control)
            {
                Point currentPointerPosition = pointerEventArgs
                    .GetPosition(
                    this.GetVisualDescendants()
                    .OfType<Canvas>()
                    .FirstOrDefault(canvas => string.IsNullOrEmpty(canvas.Name) == false &&
                        canvas.Name.Equals("mainCanvas")));
                if (control.DataContext is AbstractGrid clas)
                {
                    clas.StartPoint = new Point(
                        currentPointerPosition.X - pointerPositionIntoShape.X,
                        currentPointerPosition.Y - pointerPositionIntoShape.Y);
                }
            }
        }

        private void PointerPressedReleasedDragShape(object? sender,
            PointerReleasedEventArgs pointerReleasedEventArgs)
        {
            this.PointerMoved -= PointerMoveDragShape;
            this.PointerReleased -= PointerPressedReleasedDragShape;
        }

        private void PointerMoveResizeShape(object? sender, PointerEventArgs pointerEventArgs)
        {
            if (pointerEventArgs.Source is Avalonia.Controls.Control control)
            {
                Point currentPointerPosition = pointerEventArgs
                    .GetPosition(
                    this.GetVisualDescendants()
                    .OfType<Canvas>()
                    .FirstOrDefault(canvas => string.IsNullOrEmpty(canvas.Name) == false &&
                        canvas.Name.Equals("mainCanvas")));
                if (control.DataContext is AbstractGrid clas)
                {
                    if (control is Ellipse el)
                    {
                        if (el.Name == "RightEl")
                        {
                            clas.Width += currentPointerPosition.X - pointerStartPositionToResize.X;
                            pointerStartPositionToResize = currentPointerPosition;
                        }
                        if (el.Name == "DownEl")
                        {
                            clas.Height += currentPointerPosition.Y - pointerStartPositionToResize.Y;
                            pointerStartPositionToResize = currentPointerPosition;
                        }
                        if (el.Name == "LeftEl")
                        {
                            double sdvig = currentPointerPosition.X - pointerStartPositionToResize.X;
                            clas.Width -= sdvig;
                            clas.StartPoint = new Point(clas.StartPoint.X+sdvig, clas.StartPoint.Y);
                            pointerStartPositionToResize = currentPointerPosition;
                        }
                        if (el.Name == "UpEl")
                        {
                            double sdvig = currentPointerPosition.Y - pointerStartPositionToResize.Y;
                            clas.Height -= sdvig;
                            clas.StartPoint = new Point(clas.StartPoint.X, clas.StartPoint.Y + sdvig);
                            pointerStartPositionToResize = currentPointerPosition;
                        }
                        if (el.Name == "DownRightEl")
                        {
                            clas.Width += currentPointerPosition.X - pointerStartPositionToResize.X;
                            clas.Height += currentPointerPosition.Y - pointerStartPositionToResize.Y;
                            pointerStartPositionToResize = currentPointerPosition;
                        }
                        if (el.Name == "DownLeftEl")
                        {
                            double sdvig = currentPointerPosition.X - pointerStartPositionToResize.X;
                            clas.Width -= sdvig;
                            clas.Height += currentPointerPosition.Y - pointerStartPositionToResize.Y;
                            clas.StartPoint = new Point(clas.StartPoint.X + sdvig, clas.StartPoint.Y);
                            pointerStartPositionToResize = currentPointerPosition;
                        }
                        if (el.Name == "UpRightEl")
                        {
                            double sdvig = currentPointerPosition.Y - pointerStartPositionToResize.Y;
                            clas.Height -= sdvig;
                            clas.Width += currentPointerPosition.X - pointerStartPositionToResize.X;
                            clas.StartPoint = new Point(clas.StartPoint.X, clas.StartPoint.Y + sdvig);
                            pointerStartPositionToResize = currentPointerPosition;
                        }
                        if (el.Name == "UpLeftEl")
                        {
                            double sdvigY = currentPointerPosition.Y - pointerStartPositionToResize.Y;
                            double sdvigX = currentPointerPosition.X - pointerStartPositionToResize.X;
                            clas.Height -= sdvigY;
                            clas.Width -= sdvigX;
                            clas.StartPoint = new Point(clas.StartPoint.X + sdvigX, clas.StartPoint.Y + sdvigY);
                            pointerStartPositionToResize = currentPointerPosition;
                        }
                    }
                }
                
            }
        }

        private void PointerPressedReleasedResizeShape(object? sender,
            PointerReleasedEventArgs pointerReleasedEventArgs)
        {
            this.PointerMoved -= PointerMoveResizeShape;
            this.PointerReleased -= PointerPressedReleasedResizeShape;
        }

        private void PointerMoveDrawLine(object? sender, PointerEventArgs pointerEventArgs)
        {
            if (this.DataContext is MainWindowViewModel viewModel)
            {
                if (viewModel.Shapes[viewModel.Shapes.Count - 1] is AbstractLine aggr)
                {
                    Point currentPointerPosition = pointerEventArgs
                    .GetPosition(
                    this.GetVisualDescendants()
                    .OfType<Canvas>()
                    .FirstOrDefault(canvas => string.IsNullOrEmpty(canvas.Name) == false &&
                        canvas.Name.Equals("mainCanvas")));
                    var x = currentPointerPosition.X > aggr.StartPoint.X ? -1 : 1;
                    var y = currentPointerPosition.Y > aggr.StartPoint.Y ? -1 : 1;
                    aggr.EndPoint = new Point(currentPointerPosition.X + x, currentPointerPosition.Y + y);
                }
            }
        }
        private void PointerPressedReleasedDrawLine(object? sender,
            PointerReleasedEventArgs pointerReleasedEventArgs)
        {
            this.PointerMoved -= PointerMoveDrawLine;
            this.PointerReleased -= PointerPressedReleasedDrawLine;

            var canvas = this.GetVisualDescendants()
                        .OfType<Canvas>()
                        .FirstOrDefault(canvas => string.IsNullOrEmpty(canvas.Name) == false &&
                        canvas.Name.Equals("mainCanvas"));

            var coords = pointerReleasedEventArgs.GetPosition(canvas);

            var element = canvas.InputHitTest(coords);
            MainWindowViewModel viewModel = this.DataContext as MainWindowViewModel;

            if (element is Ellipse ellipse)
            {
                if (ellipse.DataContext is AbstractGrid clas)
                {
                    int ellipseNum = 0;
                    if (ellipse.Name == "UpLeftEl") ellipseNum = 0;
                    if (ellipse.Name == "UpEl") ellipseNum = 1;
                    if (ellipse.Name == "UpRightEl") ellipseNum = 2;
                    if (ellipse.Name == "LeftEl") ellipseNum = 3;
                    if (ellipse.Name == "RightEl") ellipseNum = 4;
                    if (ellipse.Name == "DownLeftEl") ellipseNum = 5;
                    if (ellipse.Name == "DownEl") ellipseNum = 6;
                    if (ellipse.Name == "DownRightEl") ellipseNum = 7;
                    if (viewModel.Shapes[viewModel.Shapes.Count - 1] is AggregationLine aggr)
                    {
                        aggr.SecondGrid = clas;
                        aggr.ConnectionPointSecond = ellipseNum;
                    }
                    if (viewModel.Shapes[viewModel.Shapes.Count - 1] is AssociationLine asso)
                    {
                        asso.SecondGrid = clas;
                        asso.ConnectionPointSecond = ellipseNum;
                    }
                    if (viewModel.Shapes[viewModel.Shapes.Count - 1] is CompositionLine comp)
                    {
                        comp.SecondGrid = clas;
                        comp.ConnectionPointSecond = ellipseNum;
                    }
                    if (viewModel.Shapes[viewModel.Shapes.Count - 1] is DependencyLine dep)
                    {
                        dep.SecondGrid = clas;
                        dep.ConnectionPointSecond = ellipseNum;
                    }
                    if (viewModel.Shapes[viewModel.Shapes.Count - 1] is ImplementationLine imp)
                    {
                        imp.SecondGrid = clas;
                        imp.ConnectionPointSecond = ellipseNum;
                    }
                    if (viewModel.Shapes[viewModel.Shapes.Count - 1] is InheritanceLine inh)
                    {
                        inh.SecondGrid = clas;
                        inh.ConnectionPointSecond = ellipseNum;
                    }
                    return;
                }
            }

            viewModel.Shapes.RemoveAt(viewModel.Shapes.Count - 1);
        }
        private void DropShapes(object? sender, DragEventArgs dragEventArgs)
        {
            if (dragEventArgs.Data.Contains(DataFormats.FileNames) == true)
            {
                string? fileName = dragEventArgs.Data.GetFileNames()?.FirstOrDefault();

                if (fileName != null)
                {
                    if (this.DataContext is MainWindowViewModel mainWindow)
                    {
                        mainWindow.LoadFigures(fileName);
                        //if (fileName.EndsWith(".xml"))
                        //{
                        //    mainWindow.FigureList = new ObservableCollection<Figures>();
                        //    mainWindow.Shapes = new ObservableCollection<Shape>();
                        //    mainWindow.FigureList = Serializer<ObservableCollection<Figures>>.Load(fileName);
                        //    foreach (Figures f in mainWindow.FigureList)
                        //    {
                        //        mainWindow.Shapes.Add(mainWindow.ElementToShape(f));
                        //    }
                        //}
                        //if (fileName.EndsWith(".json"))
                        //{
                        //    mainWindow.FigureList = new ObservableCollection<Figures>();
                        //    mainWindow.Shapes = new ObservableCollection<Shape>();
                        //    mainWindow.FigureList = JsonSerializer<ObservableCollection<Figures>>.Load(fileName);
                        //    foreach (Figures f in mainWindow.FigureList)
                        //    {
                        //        mainWindow.Shapes.Add(mainWindow.ElementToShape(f));
                        //    }
                        //}
                    }
                }
            }
        }
    }
}