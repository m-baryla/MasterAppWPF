using System.ComponentModel;

namespace Helper
{
    public class VMBase : INotifyPropertyChanged
    {
        public void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
        }
        protected virtual void RaisePropertyChanged(PropertyChangedEventArgs e)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
