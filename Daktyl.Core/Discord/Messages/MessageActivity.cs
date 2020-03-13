using System;

namespace Daktyl.Core.Discord.Messages
{
	// https://discordapp.com/developers/docs/resources/channel#message-object-message-activity-structure
	public readonly struct MessageActivity : IEquatable<MessageActivity>
	{
		public MessageType Type { get; }
		public string PartyId { get; }

		public MessageActivity(MessageType type, string partyId)
		{
			Type = type;
			PartyId = partyId;
		}

		public bool Equals(MessageActivity other)
		{
			return Type == other.Type && string.Equals(PartyId, other.PartyId, StringComparison.InvariantCulture);
		}

		public override bool Equals(object obj)
		{
			return obj is MessageActivity other && Equals(other);
		}

		public override int GetHashCode()
		{
			var hashCode = new HashCode();
			hashCode.Add((int) Type);
			hashCode.Add(PartyId, StringComparer.InvariantCulture);
			return hashCode.ToHashCode();
		}

		public static bool operator ==(MessageActivity left, MessageActivity right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(MessageActivity left, MessageActivity right)
		{
			return !left.Equals(right);
		}
	}
}