using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using DSharpPlus;
using ChocoLogging;
using System.Reflection;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Choco.Services.ServicesMessage
{
    public class HandlerMessageCreated
    {
        public static async Task ServiceMessageServiceReaction(DiscordClient sender, MessageCreateEventArgs args)
        {
            LogMessage.LogService();

            if (ConfigChannels.ConfigChannelId.ChannelEmojies.TryGetValue(args.Channel.Id, out var emojiName) &&
                DiscordEmoji.TryFromName(Program.Client, emojiName, out var emoji))
            {
                await args.Message.CreateReactionAsync(emoji);
            }
        }
    }
}
