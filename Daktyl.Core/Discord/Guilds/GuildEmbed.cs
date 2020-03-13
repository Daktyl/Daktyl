using System;

namespace Daktyl.Core.Discord.Guilds
{
	// https://discordapp.com/developers/docs/resources/guild#guild-embed-object
	public readonly struct GuildEmbed : IEquatable<GuildEmbed>
	{
		public bool Enabled { get; }
		public Snowflake? ChannelId { get; }

		public GuildEmbed(bool enabled, Snowflake? channelId)
		{
			Enabled = enabled;
			ChannelId = channelId;
		}

		public bool Equals(GuildEmbed other)
		{
			return Enabled == other.Enabled && Nullable.Equals(ChannelId, other.ChannelId);
		}

		public override bool Equals(object obj)
		{
			return obj is GuildEmbed other && Equals(other);
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(Enabled, ChannelId);
		}

		public static bool operator ==(GuildEmbed left, GuildEmbed right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(GuildEmbed left, GuildEmbed right)
		{
			return !left.Equals(right);
		}
	}
}