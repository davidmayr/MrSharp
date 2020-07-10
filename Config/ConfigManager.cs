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

        public async void load()
        {
            String jsonConfig = String.Empty;
            await using var stream = File.OpenRead("config.json");
            using var streamReader = new StreamReader(stream, new UTF8Encoding(false));
            
            jsonConfig = await streamReader.ReadToEndAsync().ConfigureAwait(false);

            this.BaseConfig = JsonConvert.DeserializeObject<BaseConfig>(jsonConfig);

        }
        
    }
}