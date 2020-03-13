using System;
using Daktyl.Core.Discord.Users;

namespace Daktyl.Core.Discord.Guilds
{
	// https://discordapp.com/developers/docs/resources/guild#ban-object-ban-structure
	public struct Ban : IEquatable<Ban>
	{
		public string? Reason { get; }
		public User User { get; }

		public Ban(string? reason, User user)
		{
			Reason = reason;
			User = user;
		}

		public bool Equals(Ban other)
		{
			return Reason == other.Reason && User.Equals(other.User);
		}

		public override bool Equals(object obj)
		{
			return obj is Ban other && Equals(other);
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(Reason, User);
		}

		public static bool operator ==(Ban left, Ban right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(Ban left, Ban right)
		{
			return !left.Equals(right);
		}
	}
}