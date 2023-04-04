using Avalonia;
using ChartEditor.Models.Grids;
using DynamicData.Binding;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartEditor.Models.Lines
{
    public abstract class AbstractLine : AbstractElement, IDisposable
    {
        private double lenght;
        private double angle;
        private Point startPoint;
        private Point endPoint;
        private AbstractGrid firstGrid;
        private AbstractGrid secondGrid;
        private double lineCenterX;
        private int connectionPointFirst;
        private int connectionPointSecond;

        public double Lenght
        {
            get => lenght;
            set => SetAndRaise(ref lenght, value);
        }

        public double Angle
        {
            get => angle;
            set => SetAndRaise(ref angle, value);
        }

        public double LineCenterX
        {
            get => lineCenterX;
            set => SetAndRaise(ref lineCenterX, value);
        }

        public Point StartPoint
        {
            get => startPoint;
            set
            {
                SetAndRaise(ref startPoint, value);
                Calc();
            }
        }

        public Point EndPoint
        {
            get => endPoint;
            set 
            { 
                SetAndRaise(ref endPoint, value);
                Calc();
            }
        }

        public AbstractGrid FirstGrid
        {
            get => firstGrid;
            set
            {
                firstGrid = value;
                if (firstGrid != null)
                {
                    firstGrid.ChangeStartPoint += OnFirstGridPositionChanged;
                    firstGrid.ChangeHeight += OnFirstGridHeightChanged;
                    firstGrid.ChangeWidth += OnFirstGridWidthChanged;
                }
            }
        }

        public AbstractGrid SecondGrid
        {
            get => secondGrid;
            set
            {
                secondGrid = value;
                if (secondGrid != null)
                {
                    secondGrid.ChangeStartPoint += OnSecondGridPositionChanged;
                    secondGrid.ChangeHeight += OnSecondGridHeightChanged;
                    secondGrid.ChangeWidth += OnSecondGridWidthChanged;
                }
            }
        }

        public int ConnectionPointFirst
        {
            get => connectionPointFirst;
            set => SetAndRaise(ref connectionPointFirst, value);
        }
        public int ConnectionPointSecond
        {
            get => connectionPointSecond;
            set => SetAndRaise(ref connectionPointSecond, value);
        }

        private void OnFirstGridPositionChanged(object? sender, ChangeStartPointEventArgs e)
        {
            StartPoint += e.NewStartPoint - e.OldStartPoint;
        }
        private void OnFirstGridHeightChanged(object? sender, ChangeSizeEventArgs e)
        {
            if (connectionPointFirst == 3) StartPoint = new Point(StartPoint.X, StartPoint.Y + (e.NewSize - e.OldSize) / 2);
            if (connectionPointFirst == 4) StartPoint = new Point(StartPoint.X, StartPoint.Y + (e.NewSize - e.OldSize) / 2);
            if (connectionPointFirst == 5) StartPoint = new Point(StartPoint.X, StartPoint.Y + e.NewSize - e.OldSize);
            if (connectionPointFirst == 6) StartPoint = new Point(StartPoint.X, StartPoint.Y + e.NewSize - e.OldSize);
            if (connectionPointFirst == 7) StartPoint = new Point(StartPoint.X, StartPoint.Y + e.NewSize - e.OldSize);
        }
        private void OnFirstGridWidthChanged(object? sender, ChangeSizeEventArgs e)
        {
            if (connectionPointFirst == 1) StartPoint = new Point(StartPoint.X + (e.NewSize - e.OldSize) / 2, StartPoint.Y);
            if (connectionPointFirst == 2) StartPoint = new Point(StartPoint.X + e.NewSize - e.OldSize, StartPoint.Y);
            if (connectionPointFirst == 4) StartPoint = new Point(StartPoint.X + e.NewSize - e.OldSize, StartPoint.Y);
            if (connectionPointFirst == 6) StartPoint = new Point(StartPoint.X + (e.NewSize - e.OldSize) / 2, StartPoint.Y);
            if (connectionPointFirst == 7) StartPoint = new Point(StartPoint.X + e.NewSize - e.OldSize, StartPoint.Y);
        }

        private void OnSecondGridPositionChanged(object? sender, ChangeStartPointEventArgs e)
        {
            EndPoint += e.NewStartPoint - e.OldStartPoint;
        } 
        private void OnSecondGridHeightChanged(object? sender, ChangeSizeEventArgs e)
        {
            if (connectionPointSecond == 3) EndPoint = new Point(EndPoint.X, EndPoint.Y + (e.NewSize - e.OldSize)/2);
            if (connectionPointSecond == 4) EndPoint = new Point(EndPoint.X, EndPoint.Y + (e.NewSize - e.OldSize)/2);
            if (connectionPointSecond == 5) EndPoint = new Point(EndPoint.X, EndPoint.Y + e.NewSize - e.OldSize);
            if (connectionPointSecond == 6) EndPoint = new Point(EndPoint.X, EndPoint.Y + e.NewSize - e.OldSize);
            if (connectionPointSecond == 7) EndPoint = new Point(EndPoint.X, EndPoint.Y + e.NewSize - e.OldSize);
        } 
        private void OnSecondGridWidthChanged(object? sender, ChangeSizeEventArgs e)
        {
            if (connectionPointSecond == 1) EndPoint = new Point(EndPoint.X + (e.NewSize - e.OldSize) / 2, EndPoint.Y);
            if (connectionPointSecond == 2) EndPoint = new Point(EndPoint.X + e.NewSize - e.OldSize, EndPoint.Y);
            if (connectionPointSecond == 4) EndPoint = new Point(EndPoint.X + e.NewSize - e.OldSize, EndPoint.Y);
            if (connectionPointSecond == 6) EndPoint = new Point(EndPoint.X + (e.NewSize - e.OldSize) / 2, EndPoint.Y);
            if (connectionPointSecond == 7) EndPoint = new Point(EndPoint.X + e.NewSize - e.OldSize, EndPoint.Y);
        }


        private void Calc()
        {
            var len = Math.Sqrt(Math.Pow(endPoint.X - startPoint.X, 2) + Math.Pow(endPoint.Y - startPoint.Y, 2));
            if (len == 0)
            {
                Lenght = 1;
            }
            else
            {
                Lenght = len;
            }
            LineCenterX = startPoint.X - (lenght / 2);
            double dx = endPoint.X - startPoint.X;
            if (startPoint.Y > endPoint.Y)
            {
                Angle = -Math.Acos(dx / lenght) * 180 / Math.PI;
            }
            else
            {
                Angle = Math.Acos(dx / lenght) * 180 / Math.PI;
            }
        }

        public void Dispose()
        {
            if (FirstGrid != null)
            {
                FirstGrid.ChangeStartPoint -= OnFirstGridPositionChanged;
            }
            if (SecondGrid != null)
            {
                SecondGrid.ChangeStartPoint -= OnSecondGridPositionChanged;
            }
        }
    }
}
