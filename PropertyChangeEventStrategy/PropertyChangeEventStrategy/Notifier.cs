using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PropertyChangeEventStrategy
{
    public class Notifier : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual bool SetProperty<T>(ref T field, T value, String propName)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
            {
                return false;
            }

            field = value;
            OnPropertyChanged(propName);
            return true;
        }

        protected virtual void OnPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
            }
        }
    }
    
    public static class NotifyPropertyChangedEx
    {
        public static void AddPropertyChanged<TObj, TProp>(
            this TObj _this,
            Expression<Func<TObj,TProp>> propertyName,
            Action handler)
            where TObj: INotifyPropertyChanged 
        {
            var name = ((MemberExpression)propertyName.Body).Member.Name;

            _this.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == name)
                {
                    handler();
                }
            };
        }
    }
    
}
