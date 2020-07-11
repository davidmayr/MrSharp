using System;
using System.Net;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using Newtonsoft.Json.Linq;

namespace MrSharp.Commands
{
    [Description("Fun Commands to play with the bot")]
    public class FunCommands
    {

        [Command("ping")]
        [Description("The most basic Command in the world 😉")]
        public async Task ExecutePing(CommandContext ctx)
        {
            var dateTimeOffset = ctx.Message.Timestamp;
            await ctx.RespondAsync("👋 Pong! Took " + (DateTimeOffset.Now.Millisecond - dateTimeOffset.Millisecond) + "MS to respond!");
        }
        
        
        [Command("cat")]
        [Description("Gives you a random cat 😍")]
        public async Task ExecuteCat(CommandContext ctx)
        {
            using WebClient webClient = new WebClient();
            var json = webClient.DownloadString("https://aws.random.cat/meow");
            String url = JObject.Parse(json)["file"].ToString();

            DiscordEmbedBuilder discordEmbedBuilder = new DiscordEmbedBuilder
            {
                Color = DiscordColor.Blue,
                Title = "A Cat for you!",
                ImageUrl = url,
                Footer = new DiscordEmbedBuilder.EmbedFooter
                {
                    Text = "Powered by https://random.cat"
                },
                Timestamp = DateTimeOffset.Now
            };

            await ctx.RespondAsync(embed: discordEmbedBuilder);
        }

        
    }
}