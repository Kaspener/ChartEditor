using Avalonia;
using System;

namespace ChartEditor.Models
{
    public class ChangeStartPointEventArgs : EventArgs
    {
        public Point OldStartPoint { get; set; }
        public Point NewStartPoint { get; set; }
    }
}
