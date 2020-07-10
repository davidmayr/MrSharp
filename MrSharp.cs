using DSharpPlus;
using DSharpPlus.EventArgs;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.CommandsNext.Converters;
using DSharpPlus.CommandsNext;

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MrSharp.Config;

namespace MrSharp
{
    class MrSharp
    {
        public DiscordClient DiscordClient { get; private set; }

        public CommandsNextModule CommandsNextModule { get; private set;  }
        
        public ConfigManager ConfigManager { get; private set;  }
        
        public async void Start()
        {
            
            this.ConfigManager = new ConfigManager();
            this.ConfigManager.load();
            
            DiscordConfiguration configuration = new DiscordConfiguration
            {
                TokenType = TokenType.Bot,
                Token = this.ConfigManager.BaseConfig.DiscordConfig.Token,
                AutoReconnect = this.ConfigManager.BaseConfig.DiscordConfig.AutoReconnect
            };

            DiscordClient = new DiscordClient(configuration);
            DiscordClient.Ready += HandleReady;

            CommandsNextConfiguration commandsConfiguration = new CommandsNextConfiguration
            {
                
            };

            CommandsNextModule = DiscordClient.UseCommandsNext(commandsConfiguration);
            
            await DiscordClient.ConnectAsync();
            
        }

        private Task HandleReady(ReadyEventArgs args)
        {
            return null;
        }
    }
}