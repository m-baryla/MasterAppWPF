using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Controls;

namespace BaseAppClass
{
    public abstract class ViewModelBaseService : INotifyPropertyChanged
    {
        private object _currentWorkspace;
        public object CurrentWorkspace
        {
            get { return this._currentWorkspace; }
            set { this._currentWorkspace = value; OnPropertyChanged("CurrentWorkspace"); }
        }

        public List<Button> buttonsList;
        public List<Button> ButtonsList
        {
            get { return buttonsList; }
            set { if (buttonsList == value) return; buttonsList = value; OnPropertyChanged("ButtonsList"); }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            this.OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
}
