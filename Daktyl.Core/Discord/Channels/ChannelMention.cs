using System;

namespace Daktyl.Core.Discord.Channels
{
	// https://discordapp.com/developers/docs/resources/channel#channel-mention-object-channel-mention-structure
	public readonly struct ChannelMention : IEquatable<ChannelMention>
	{
		public Snowflake Id { get; }
		public Snowflake GuildId { get; }
		public ChannelType Type { get; }
		public string Name { get; }

		public ChannelMention(Snowflake id, Snowflake guildId, ChannelType type, string name)
		{
			Id = id;
			GuildId = guildId;
			Type = type;
			Name = name;
		}

		public bool Equals(ChannelMention other)
		{
			return Id.Equals(other.Id) && GuildId.Equals(other.GuildId) && Type == other.Type && Name == other.Name;
		}

		public override bool Equals(object obj)
		{
			return obj is ChannelMention other && Equals(other);
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(Id, GuildId, (int) Type, Name);
		}

		public static bool operator ==(ChannelMention left, ChannelMention right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(ChannelMention left, ChannelMention right)
		{
			return !left.Equals(right);
		}
	}
}