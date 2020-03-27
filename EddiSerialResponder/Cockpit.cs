using System.Collections.Generic;
using Newtonsoft.Json;

namespace EddiSerialResponder
{
    public class Cockpit
    {
        [JsonProperty("name")]
        public string Name { get; private set; }

        [JsonProperty("description")]
        public string Description { get; private set; }

        [JsonProperty("commands")]
        public Dictionary<string, CockpitCommand> Commands { get; private set; }

        public Cockpit(string name, string description, Dictionary<string, CockpitCommand> commands)
        {
            //TODO: Verify name validity
            Name = name;
            Description = description;
            Commands = commands;
        }

        //TODO: Add a FromFile cockpit constructor
        //TODO: Create a default cockpit
    }
}