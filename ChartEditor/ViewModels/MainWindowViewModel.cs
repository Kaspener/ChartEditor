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
using ChartEditor.Models;
using YamlDotNet.Serialization.NamingConventions;
using YamlDotNet.Serialization;
using ChartEditor.Models.Serializers;
using Avalonia;
using ChartEditor.Models.Lines;
using System.Drawing.Printing;
using System.Runtime.CompilerServices;

namespace ChartEditor.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ObservableCollection<AbstractElement> shapes;
        private bool isClass = false;
        private bool isInterface = false;
        private bool isAggregation = false;
        private bool isAssociation = false;
        private bool isComposition = false;
        private bool isDependency = false;
        private bool isImplementation = false;
        private bool isInheritance = false;
        private bool isResize = false;
        private bool isMove = false;
        private bool isDelete = false;
        public MainWindowViewModel()
        {
            IsMove = true;
            Shapes = new ObservableCollection<AbstractElement>();
        }

        public ObservableCollection<AbstractElement> Shapes
        {
            get => shapes;
            set => this.RaiseAndSetIfChanged(ref shapes, value);
        }
        public bool IsClass
        {
            get => isClass;
            set => this.RaiseAndSetIfChanged(ref isClass, value);
        }
        public bool IsInterface
        {
            get => isInterface;
            set => this.RaiseAndSetIfChanged(ref isInterface, value);
        }
        public bool IsAggregation
        {
            get => isAggregation;
            set => this.RaiseAndSetIfChanged(ref isAggregation, value);
        }
        public bool IsAssociation
        {
            get => isAssociation;
            set => this.RaiseAndSetIfChanged(ref isAssociation, value);
        }
        public bool IsComposition
        {
            get => isComposition;
            set => this.RaiseAndSetIfChanged(ref isComposition, value);
        }
        public bool IsDependency 
        {
            get => isDependency;
            set => this.RaiseAndSetIfChanged(ref isDependency, value);
        }
        public bool IsImplementation
        {
            get => isImplementation; 
            set => this.RaiseAndSetIfChanged(ref isImplementation, value);
        }
        public bool IsInheritance
        {
            get => isInheritance;
            set => this.RaiseAndSetIfChanged(ref isInheritance, value);
        }
        public bool IsResize
        {
            get => isResize;
            set => this.RaiseAndSetIfChanged(ref isResize, value);
        }
        public bool IsMove
        {
            get => isMove;
            set => this.RaiseAndSetIfChanged(ref isMove, value);
        }
        public bool IsDelete
        {
            get => isDelete;
            set => this.RaiseAndSetIfChanged(ref isDelete, value);
        }
    }
}
