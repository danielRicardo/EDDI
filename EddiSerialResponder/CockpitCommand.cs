using System.ComponentModel;
using System.Windows.Interop;
using Newtonsoft.Json;

namespace EddiSerialResponder
{
    public class CockpitCommand : INotifyPropertyChanged
    {
         [JsonProperty("name")]
         public string Name { get; private set; }

         [JsonProperty("description")]
         public string Description { get; private set; }

         [JsonProperty("enabled")]
         private bool enabled;

         [JsonProperty("command")]
         private string command;
         
         public event PropertyChangedEventHandler PropertyChanged;

         [JsonIgnore]
         public bool Enabled
         {
             get { return enabled;  }
             set { enabled = value; OnPropertyChanged("Enabled"); }
         }

         [JsonIgnore]
         public string Value
         {
             get { return command; }
             set { command = value; OnPropertyChanged("Value"); }
         }

         [JsonProperty("defaultValue")]
         public string defaultValue { get; set; }

         public CockpitCommand(string name, string description, string command, string defaultValue = null)
         {
             Name = name;
             Description = description;
             enabled = true;
             this.command = command;
             this.defaultValue = defaultValue;
         }

         protected void OnPropertyChanged(string name)
         {
             PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
         }
    }
}