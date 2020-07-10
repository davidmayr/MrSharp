using System;
using System.IO;
using System.Text;
using MrSharp.Config.Elements;
using Newtonsoft.Json;

namespace MrSharp.Config
{
    public class ConfigManager
    {

        public BaseConfig BaseConfig;

        public void Load()
        {
            
            var json = string.Empty;

            using (var fs = File.OpenRead("config.json"))
            using (var sr = new StreamReader(fs, new UTF8Encoding(false)))
                json = sr.ReadToEnd();
            
            BaseConfig = JsonConvert.DeserializeObject<BaseConfig>(json);
        }
        
    }
}