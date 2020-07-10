using System;
using Newtonsoft.Json;

namespace MrSharp.Config.Elements
{
    public struct SystemConfig
    {
        
        [JsonProperty("prefix")]
        public String Prefix { get; private set; }
        
        [JsonProperty("listenToName")]
        public String ListenToName { get; private set; }
        
    }
}