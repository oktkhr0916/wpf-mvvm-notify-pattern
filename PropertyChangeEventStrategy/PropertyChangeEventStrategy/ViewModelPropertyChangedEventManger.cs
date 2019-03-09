using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyChangeEventStrategy
{
    public class ViewModelPropertyChangedEventManger
    {
        public ViewModel VM { get; set; }

        public ViewModelPropertyChangedEventManger(ViewModel vM)
        {
            VM = vM;
            VM.AddPropertyChanged(o => o.SampleTextBox, this.SampleTextBoxChanged);
        }
        
        public void SampleTextBoxChanged()
        {
            this.VM.SampleTextBlock = this.VM.SampleTextBox;
        }
        
    }
}
