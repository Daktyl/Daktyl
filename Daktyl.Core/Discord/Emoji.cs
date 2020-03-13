using System;
using Daktyl.Core.Discord.Users;

namespace Daktyl.Core.Discord
{
	// https://discordapp.com/developers/docs/resources/emoji#emoji-object-emoji-structure
	public readonly struct Emoji : IEquatable<Emoji>
	{
		public Snowflake? Id { get; }
		public string? Name { get; }
		public ulong[]? Roles { get; }
		public User? User { get; }
		public bool? RequireColons { get; }
		public bool? Managed { get; }
		public bool? Animated { get; }

		public Emoji(Snowflake? id, string? name, ulong[]? roles, User? user, bool? requireColons, bool? managed,
			bool? animated)
		{
			Id = id;
			Name = name;
			Roles = roles;
			User = user;
			RequireColons = requireColons;
			Managed = managed;
			Animated = animated;
		}

		public bool Equals(Emoji other)
		{
			return Nullable.Equals(Id, other.Id) && Name == other.Name && Equals(Roles, other.Roles) &&
					Nullable.Equals(User, other.User) && RequireColons == other.RequireColons &&
					Managed == other.Managed && Animated == other.Animated;
		}

		public override bool Equals(object obj)
		{
			return obj is Emoji other && Equals(other);
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(Id, Name, Roles, User, RequireColons, Managed, Animated);
		}

		public static bool operator ==(Emoji left, Emoji right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(Emoji left, Emoji right)
		{
			return !left.Equals(right);
		}
	}
}