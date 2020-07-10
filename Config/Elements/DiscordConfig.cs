using System;
using Newtonsoft.Json;

namespace MrSharp.Config.Elements
{
    public struct DiscordConfig
    {
        
        [JsonProperty("token")]
        public String Token { get; private set; }
        
    }
}