using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Input;
using Avalonia.VisualTree;
using ChartEditor.Models.Grids;
using ChartEditor.Models.Lines;
using ChartEditor.ViewModels;
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
                if (control.DataContext is ClassElement clas)
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
                        }
                    }
                }
                if (control.DataContext is InterfaceElement inter)
                {
                    if (this.DataContext is MainWindowViewModel window)
                    {
                        if (window.IsMove)
                        {
                            var interCanvas = control.Parent;
                            pointerPositionIntoShape = pointerPressedEventArgs.GetPosition(interCanvas);
                            this.PointerMoved += PointerMoveDragShape;
                            this.PointerReleased += PointerPressedReleasedDragShape;
                        }
                        if (window.IsResize)
                        {
                            pointerStartPositionToResize = pointPointerPressed;
                            this.PointerMoved += PointerMoveResizeShape;
                            this.PointerReleased += PointerPressedReleasedResizeShape;
                        }
                        if (window.IsDelete)
                        {
                            window.Shapes.Remove(inter);
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
                if (control.DataContext is ClassElement clas)
                {
                    clas.StartPoint = new Point(
                        currentPointerPosition.X - pointerPositionIntoShape.X,
                        currentPointerPosition.Y - pointerPositionIntoShape.Y);
                }
                if (control.DataContext is InterfaceElement inter)
                {
                    inter.StartPoint = new Point(
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
                if (control.DataContext is ClassElement clas)
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
                if (control.DataContext is InterfaceElement inter)
                {
                    if (control is Ellipse el)
                    {
                        if (el.Name == "RightEl")
                        {
                            inter.Width += currentPointerPosition.X - pointerStartPositionToResize.X;
                            pointerStartPositionToResize = currentPointerPosition;
                        }
                        if (el.Name == "DownEl")
                        {
                            inter.Height += currentPointerPosition.Y - pointerStartPositionToResize.Y;
                            pointerStartPositionToResize = currentPointerPosition;
                        }
                        if (el.Name == "LeftEl")
                        {
                            double sdvig = currentPointerPosition.X - pointerStartPositionToResize.X;
                            inter.Width -= sdvig;
                            inter.StartPoint = new Point(inter.StartPoint.X + sdvig, inter.StartPoint.Y);
                            pointerStartPositionToResize = currentPointerPosition;
                        }
                        if (el.Name == "UpEl")
                        {
                            double sdvig = currentPointerPosition.Y - pointerStartPositionToResize.Y;
                            inter.Height -= sdvig;
                            inter.StartPoint = new Point(inter.StartPoint.X, inter.StartPoint.Y + sdvig);
                            pointerStartPositionToResize = currentPointerPosition;
                        }
                        if (el.Name == "DownRightEl")
                        {
                            inter.Width += currentPointerPosition.X - pointerStartPositionToResize.X;
                            inter.Height += currentPointerPosition.Y - pointerStartPositionToResize.Y;
                            pointerStartPositionToResize = currentPointerPosition;
                        }
                        if (el.Name == "DownLeftEl")
                        {
                            double sdvig = currentPointerPosition.X - pointerStartPositionToResize.X;
                            inter.Width -= sdvig;
                            inter.Height += currentPointerPosition.Y - pointerStartPositionToResize.Y;
                            inter.StartPoint = new Point(inter.StartPoint.X + sdvig, inter.StartPoint.Y);
                            pointerStartPositionToResize = currentPointerPosition;
                        }
                        if (el.Name == "UpRightEl")
                        {
                            double sdvig = currentPointerPosition.Y - pointerStartPositionToResize.Y;
                            inter.Height -= sdvig;
                            inter.Width += currentPointerPosition.X - pointerStartPositionToResize.X;
                            inter.StartPoint = new Point(inter.StartPoint.X, inter.StartPoint.Y + sdvig);
                            pointerStartPositionToResize = currentPointerPosition;
                        }
                        if (el.Name == "UpLeftEl")
                        {
                            double sdvigY = currentPointerPosition.Y - pointerStartPositionToResize.Y;
                            double sdvigX = currentPointerPosition.X - pointerStartPositionToResize.X;
                            inter.Height -= sdvigY;
                            inter.Width -= sdvigX;
                            inter.StartPoint = new Point(inter.StartPoint.X + sdvigX, inter.StartPoint.Y + sdvigY);
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
                if (viewModel.Shapes[viewModel.Shapes.Count - 1] is AggregationLine aggr)
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
                if (ellipse.DataContext is ClassElement clas)
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
                    return;
                }
            }

            viewModel.Shapes.RemoveAt(viewModel.Shapes.Count - 1);
        }
    }
}