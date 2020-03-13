using System;
using Daktyl.Core.Discord.Users;

namespace Daktyl.Core.Discord.Guilds
{
	// https://discordapp.com/developers/docs/resources/guild#guild-member-object
	public readonly struct GuildMember : IEquatable<GuildMember>
	{
		public User User { get; }
		public string? Nick { get; }
		public Snowflake[] Roles { get; }
		public DateTime JoinedAt { get; }
		public DateTime PremiumSince { get; }
		public bool Deaf { get; }
		public bool Mute { get; }

		public GuildMember(User user, string? nick, Snowflake[] roles, DateTime joinedAt, DateTime premiumSince,
			bool deaf, bool mute)
		{
			User = user;
			Nick = nick;
			Roles = roles;
			JoinedAt = joinedAt;
			PremiumSince = premiumSince;
			Deaf = deaf;
			Mute = mute;
		}

		public bool Equals(GuildMember other)
		{
			return User.Equals(other.User) && Nick == other.Nick && Equals(Roles, other.Roles) &&
					JoinedAt.Equals(other.JoinedAt) && PremiumSince.Equals(other.PremiumSince) && Deaf == other.Deaf &&
					Mute == other.Mute;
		}

		public override bool Equals(object obj)
		{
			return obj is GuildMember other && Equals(other);
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(User, Nick, Roles, JoinedAt, PremiumSince, Deaf, Mute);
		}

		public static bool operator ==(GuildMember left, GuildMember right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(GuildMember left, GuildMember right)
		{
			return !left.Equals(right);
		}
	}
}