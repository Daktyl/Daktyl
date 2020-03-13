using System;

namespace Daktyl.Core.Discord.Messages
{
	// https://discordapp.com/developers/docs/resources/channel#message-object-message-reference-structure
	public readonly struct MessageReference : IEquatable<MessageReference>
	{
		public Snowflake? MessageId { get; }
		public Snowflake? ChannelId { get; }
		public Snowflake? GuildId { get; }

		public MessageReference(Snowflake? messageId, Snowflake? channelId, Snowflake? guildId)
		{
			MessageId = messageId;
			ChannelId = channelId;
			GuildId = guildId;
		}

		public bool Equals(MessageReference other)
		{
			return Nullable.Equals(MessageId, other.MessageId) && Nullable.Equals(ChannelId, other.ChannelId) &&
					Nullable.Equals(GuildId, other.GuildId);
		}

		public override bool Equals(object obj)
		{
			return obj is MessageReference other && Equals(other);
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(MessageId, ChannelId, GuildId);
		}

		public static bool operator ==(MessageReference left, MessageReference right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(MessageReference left, MessageReference right)
		{
			return !left.Equals(right);
		}
	}
}