using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Controls;
using BaseClassApp.Helper;
using BaseClassApp.Interface;
using BaseClassApp.LogService;

namespace BaseClassApp
{
    public abstract class ViewModelBaseService : INotifyPropertyChanged
    {
        /// <summary>
        /// 
        /// </summary>
        private object _currentWorkspace;
        public object CurrentWorkspace
        {
            get { return this._currentWorkspace; }
            set { this._currentWorkspace = value; OnPropertyChanged("CurrentWorkspace"); }
        }
        /// <summary>
        /// 
        /// </summary>
        public List<Button> buttonsList;
        public List<Button> ButtonsList
        {
            get { return buttonsList; }
            set { if (buttonsList == value) return; buttonsList = value; OnPropertyChanged("ButtonsList"); }
        }
        /// <summary>
        /// 
        /// </summary>
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
        /// <summary>
        /// 
        /// </summary>
        public static ObservableCollection<LogMessage> ExampleMessages { get; set; }
        private LogMessage[] _top4LogMessages;
        public LogMessage[] Top4LogMessages
        {
            get { return _top4LogMessages; }
            set
            {
                _top4LogMessages = value;
                OnPropertyChanged("Top4LogMessages");
            }
        }
        public void LogMessages_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Top4LogMessages = ExampleMessages.Reverse().Take(4).ToArray();
        }
    }
}
