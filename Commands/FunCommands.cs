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
            await ctx.RespondAsync(embed: new DiscordEmbedBuilder
            {
                Color = DiscordColor.Blue,
                Title = "A Cat for you!",
                ImageUrl = GeneratePetUrl("https://aws.random.cat/meow", "file"),
                Footer = new DiscordEmbedBuilder.EmbedFooter
                {
                    Text = "Powered by https://random.cat"
                },
                Timestamp = DateTimeOffset.Now
            });
        }

        [Command("dog")]
        [Description("Gives you a random dog 😍")]
        public async Task ExecuteDog(CommandContext ctx)
        {
            await ctx.RespondAsync(embed: new DiscordEmbedBuilder
            {
                Color = DiscordColor.Blue,
                Title = "A Dog for you!",
                ImageUrl = GeneratePetUrl("https://random.dog/woof.json", "url"),
                Footer = new DiscordEmbedBuilder.EmbedFooter
                {
                    Text = "Powered by https://random.dog"
                },
                Timestamp = DateTimeOffset.Now
            });
        }
        
        private String GeneratePetUrl(string jsonUrl, string jsonType)
        {
            using WebClient webClient = new WebClient();
            var json = webClient.DownloadString(jsonUrl);
            return JObject.Parse(json)[jsonType].ToString();
        }
        
    }
}