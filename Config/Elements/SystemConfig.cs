using System;
using Newtonsoft.Json;

namespace MrSharp.Config.Elements
{
    public struct SystemConfig
    {
        
        [JsonProperty("prefix")]
        public String Prefix { get; private set; }
        
        [JsonProperty("name")]
        public String Name { get; private set; }
        
    }
}