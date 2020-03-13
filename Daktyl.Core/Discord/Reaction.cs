using System;

namespace Daktyl.Core.Discord
{
	// https://discordapp.com/developers/docs/resources/channel#reaction-object
	public readonly struct Reaction : IEquatable<Reaction>
	{
		public int Count { get; }
		public bool Me { get; }
		public Emoji Emoji { get; }

		public Reaction(int count, bool me, Emoji emoji)
		{
			Count = count;
			Me = me;
			Emoji = emoji;
		}

		public bool Equals(Reaction other)
		{
			return Count == other.Count && Me == other.Me && Emoji.Equals(other.Emoji);
		}

		public override bool Equals(object obj)
		{
			return obj is Reaction other && Equals(other);
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(Count, Me, Emoji);
		}

		public static bool operator ==(Reaction left, Reaction right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(Reaction left, Reaction right)
		{
			return !left.Equals(right);
		}
	}
}