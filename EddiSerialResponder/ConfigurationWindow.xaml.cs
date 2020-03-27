using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Eddi;
using EddiSerialResponder.Annotations;

namespace EddiSerialResponder
{
    /// <summary>
    /// Interaction logic for ConfigurationWindow.xaml
    /// </summary>
    public partial class ConfigurationWindow : UserControl, INotifyPropertyChanged
    {
        private ObservableCollection<Cockpit> cockpits;

        public ObservableCollection<Cockpit> Cockpits
        {
            get { return cockpits; }
            set { cockpits = value; OnPropertyChanged(nameof(Cockpits)); }
        }

        private Cockpit cockpit;

        public Cockpit Cockpit
        {
            get { return cockpit; }
            set { cockpit = value; OnPropertyChanged(nameof(Cockpit)); }
        }

        public ConfigurationWindow()
        {
            InitializeComponent();
            DataContext = this;

            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void logsOnlyEnabled(object sender, RoutedEventArgs e)
        {
            if (sender is CheckBox checkBox)
            {
                if (checkBox.IsLoaded)
                {
                    //TODO: Set logs only in config
                    EDDI.Instance.Reload("Serial responder");
                }
            }
        }

        private void logsEnabled(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void logsDiabled(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void serialeResponderHelpHere(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void serialResponderScriptsEnabledUpdated(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void cockpitChagnged(object sender, SelectionChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void copyCockpitClicked(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void newScriptClicked(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void deleteCockpitClicked(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
