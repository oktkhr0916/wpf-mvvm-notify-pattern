using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PropertyChangeEventStrategy
{
    public class ViewModel : Notifier
    {
        public ViewModelPropertyChangedEventManger VmPropsChangedManager { get; set; }
        private string _sampleTextBox;
        private string _sampleTextBlock;

        public ViewModel()
        {
            this.VmPropsChangedManager = new ViewModelPropertyChangedEventManger(this);
        }

        public string SampleTextBox
        {
            get => _sampleTextBox;
            set => SetProperty(ref _sampleTextBox, value, nameof(SampleTextBox));


        }
        public string SampleTextBlock
        {
            get => _sampleTextBlock;
            set => SetProperty(ref _sampleTextBlock, value, nameof(SampleTextBlock));
        }

    }
    
}
