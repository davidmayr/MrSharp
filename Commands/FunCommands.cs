using System;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

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
        
    }
}