using DNet.Structures.Guilds;
using Newtonsoft.Json;

namespace DNet.Structures.Channels
{
    public class GuildChannel : Channel
    {
        [JsonProperty("guild_id")]
        public string GuildId { get; set; }

        [JsonProperty("permission_overwrites")]
        public PermissionOverwrite[] PermissionOverwrites { get; set; }

        [JsonProperty("position")]
        public int Position { get; set; }

        [JsonProperty("nsfw")]
        public bool NSFW { get; set; }

        [JsonProperty("parent_id")]
        public string ParentId { get; set; }

        // Resolvables
        public Guild Guild => this.Client.guilds[this.GuildId];
    }
}
