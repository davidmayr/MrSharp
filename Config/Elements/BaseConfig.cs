using Newtonsoft.Json;

namespace MrSharp.Config.Elements
{
    public struct BaseConfig
    {
        
        [JsonProperty("discord")]
        public DiscordConfig DiscordConfig { get; private set; }
        
        [JsonProperty("system")]
        public SystemConfig SystemConfig { get; private set; }
        
    }
}