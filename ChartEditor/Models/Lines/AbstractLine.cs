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
            set => SetAndRaise(ref startPoint, value);
        }

        public Point EndPoint
        {
            get => endPoint;
            set 
            { 
                SetAndRaise(ref endPoint, value);
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
        }

        public void CalcLenght()
        {
            Lenght = Math.Sqrt(Math.Pow(endPoint.X - startPoint.X, 2) + Math.Pow(endPoint.Y - startPoint.Y, 2));
        }

        public void CalcAngle()
        {
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
            throw new NotImplementedException();
        }
    }
}
