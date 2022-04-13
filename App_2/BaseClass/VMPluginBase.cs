using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using App_2.T_1.View;
using App_2.T_1.ViewModel;
using App_2.T_2.View;
using App_2.T_2.ViewModel;
using Interface;

namespace App_2.BaseClass
{
    public class VMPluginBase : ViewModelBaseService
    {
        public static ObservableCollection<LogMessage> ExampleMessages { get; set; }
        private LogMessage[] _top3LogMessages;
        public LogMessage[] Top3LogMessages
        {
            get { return _top3LogMessages; }
            set
            {
                _top3LogMessages = value;
                OnPropertyChanged("Top3LogMessages");
            }
        }
        public VMPluginBase(Style ButtonStyle, ISQL sql)
        {
            ExampleMessages = new ObservableCollection<LogMessage>();
            var T_1 = UserPermissions.IsAllowed(ApplicationRoles.T_1, sql);
            var T_2 = UserPermissions.IsAllowed(ApplicationRoles.T_2, sql);

            buttonsList = new List<Button>();
            if (T_1) buttonsList.Add(new Button() { Style = ButtonStyle, Content = "T_1", Command = new RelayCommandService(_ => CurrentWorkspace = new VT_1 { DataContext = new VMValueT1(sql) }) });
            if (T_1) buttonsList.Add(new Button() { Style = ButtonStyle, Content = "T_1", Command = new RelayCommandService(_ => CurrentWorkspace = new VT_1 { DataContext = new VMValueT1(sql) }) });
            if (T_1) buttonsList.Add(new Button() { Style = ButtonStyle, Content = "T_1", Command = new RelayCommandService(_ => CurrentWorkspace = new VT_1 { DataContext = new VMValueT1(sql) }) });
            if (T_2) buttonsList.Add(new Button() { Style = ButtonStyle, Content = "T_2", Command = new RelayCommandService(_ => CurrentWorkspace = new VT_2 { DataContext = new VMValueT2(sql) }) });
            if (T_2) buttonsList.Add(new Button() { Style = ButtonStyle, Content = "T_2", Command = new RelayCommandService(_ => CurrentWorkspace = new VT_2 { DataContext = new VMValueT2(sql) }) });
            if (T_2) buttonsList.Add(new Button() { Style = ButtonStyle, Content = "T_2", Command = new RelayCommandService(_ => CurrentWorkspace = new VT_2 { DataContext = new VMValueT2(sql) }) });
            if (T_2) buttonsList.Add(new Button() { Style = ButtonStyle, Content = "T_2", Command = new RelayCommandService(_ => CurrentWorkspace = new VT_2 { DataContext = new VMValueT2(sql) }) });

            ExampleMessages.CollectionChanged += LogMessages_CollectionChanged;
            Top3LogMessages = ExampleMessages.Reverse().Take(3).ToArray();
        }
        private void LogMessages_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Top3LogMessages = ExampleMessages.Reverse().Take(3).ToArray();
        }
    }
}
