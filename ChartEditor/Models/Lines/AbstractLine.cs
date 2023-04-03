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
                }
            }
        }

        private void OnFirstGridPositionChanged(object? sender, ChangeStartPointEventArgs e)
        {
            StartPoint += e.NewStartPoint - e.OldStartPoint;
        }

        private void OnSecondGridPositionChanged(object? sender, ChangeStartPointEventArgs e)
        {
            EndPoint += e.NewStartPoint - e.OldStartPoint;
        }

        private void Calc()
        {
            Lenght = Math.Sqrt(Math.Pow(endPoint.X - startPoint.X, 2) + Math.Pow(endPoint.Y - startPoint.Y, 2));
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
