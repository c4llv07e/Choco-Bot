using System;
using System.Linq;
using System.Collections.Generic;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using ChocoLogging;
using Microsoft.Extensions.Configuration;

namespace ConfigChannels
{
    public class ConfigChannelId
    {
        private static readonly Dictionary<string, ulong> ChannelIds = new();
        public static readonly Dictionary<ulong, string> ChannelEmojies = new();

        static ConfigChannelId()
        {
            var configuration = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .Build();

            ChannelIds["IdChannelGameLogs"] = configuration.GetValue<ulong>("ID_CHANNEL_GAME_LOGS");
            ChannelIds["IdChannelGameUpdateMenu"] = configuration.GetValue<ulong>("ID_CHANNEL_GAME_UPDATE_MENU");
            ChannelIds["IdChannelSendEmoji"] = configuration.GetValue<ulong>("ID_CHANNEL_SEND_EMOJI");
            ChannelIds["IdChannelSendAchievement"] = configuration.GetValue<ulong>("ID_CHANNEL_SEND_ACHIEVEMENT");

            var emojiChannels = configuration.GetValue<string>("ID_CHANNELS_SEND_REACTION").Split(",").Select(x => x.Split(":"));
            ChannelEmojies = emojiChannels.ToDictionary(x => Convert.ToUInt64(x[0]), x => $":{x[1]}:");
        }

        public static ulong GetChannelId(string key)
        {
            if (ChannelIds.TryGetValue(key, out ulong id))
                return id;
            else
                throw new KeyNotFoundException($"Key {key} not found in Channel IDs.");
        }
    }
}
