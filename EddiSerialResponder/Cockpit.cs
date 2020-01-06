using Newtonsoft.Json;

namespace EddiSerialResponder
{
    public class Cockpit
    {
        [JsonProperty("name")]
        public string Name { get; private set; }

        [JsonProperty("description")]
        public string Description { get; private set; }
        

    }
}