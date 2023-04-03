using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Input;
using Avalonia.VisualTree;
using ChartEditor.Models.Grids;
using ChartEditor.ViewModels;
using System.Linq;

namespace ChartEditor.Views
{
    public partial class MainWindow : Window
    {
        private Point pointPointerPressed;
        private Point pointerPositionIntoShape;
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
                                pointerPositionIntoShape = pointerPressedEventArgs.GetPosition(control.Parent);
                                this.PointerMoved += PointerMoveResizeShape;
                                this.PointerReleased += PointerPressedReleasedResizeShape;
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

                        }
                    }
                }
                if (control.DataContext is InterfaceElement inter)
                {
                    inter.StartPoint = new Point(
                        currentPointerPosition.X - pointerPositionIntoShape.X,
                        currentPointerPosition.Y - pointerPositionIntoShape.Y);
                }
            }
        }

        private void PointerPressedReleasedResizeShape(object? sender,
            PointerReleasedEventArgs pointerReleasedEventArgs)
        {
            this.PointerMoved -= PointerMoveResizeShape;
            this.PointerReleased -= PointerPressedReleasedResizeShape;
        }
    }
}
