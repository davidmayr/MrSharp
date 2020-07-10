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
        private DiscordClient DiscordClient { get; set; }

        private CommandsNextModule CommandsNextModule { get; set;  }

        private ConfigManager ConfigManager { get; set;  }

        public MrSharp()
        {
            ConfigManager = new ConfigManager();
            ConfigManager.Load();
        }

        public async Task Run()
        {
            DiscordConfiguration configuration = new DiscordConfiguration
            {
                TokenType = TokenType.Bot,
                Token = ConfigManager.BaseConfig.DiscordConfig.Token,
                AutoReconnect = ConfigManager.BaseConfig.DiscordConfig.AutoReconnect,
                LogLevel = LogLevel.Debug,
                UseInternalLogHandler = true
            };

            DiscordClient = new DiscordClient(configuration);
            DiscordClient.Ready += HandleReady;
            
            CommandsNextConfiguration commandsConfiguration = new CommandsNextConfiguration
            {
                StringPrefix = ConfigManager.BaseConfig.SystemConfig.Prefix,
                EnableDms = false,
                EnableMentionPrefix = true
            };

            CommandsNextModule = DiscordClient.UseCommandsNext(commandsConfiguration);
            
            await DiscordClient.ConnectAsync();
            await Task.Delay(-1);
        }
        
        private Task HandleReady(ReadyEventArgs args)
        {
            return Task.CompletedTask;
        }
    }
}