using System;

namespace Daktyl.Core.Discord.Users
{
	// https://discordapp.com/developers/docs/resources/user#user-object-user-structure
	public struct User : IEquatable<User>
	{
		public string Id { get; }
		public string Username { get; }
		public string Discriminator { get; }
		public string Avatar { get; }
		public bool? Bot { get; }
		public bool? System { get; }
		public bool? MFAEnabled { get; }
		public string? Locale { get; }
		public bool? Verified { get; }
		public string? Email { get; }
		public UserFlags? Flags { get; }
		public PremiumType? PremiumType { get; }

		public User(string id, string username, string discriminator, string avatar, bool? bot, bool? system,
			bool? mfaEnabled, string? locale, bool? verified, string? email, UserFlags? flags, PremiumType? premiumType)
		{
			Id = id;
			Username = username;
			Discriminator = discriminator;
			Avatar = avatar;
			Bot = bot;
			System = system;
			MFAEnabled = mfaEnabled;
			Locale = locale;
			Verified = verified;
			Email = email;
			Flags = flags;
			PremiumType = premiumType;
		}

		public bool Equals(User other)
		{
			return Id == other.Id && Username == other.Username && Discriminator == other.Discriminator &&
					Avatar == other.Avatar && Bot == other.Bot && System == other.System &&
					MFAEnabled == other.MFAEnabled && Locale == other.Locale && Verified == other.Verified &&
					Email == other.Email && Flags == other.Flags && PremiumType == other.PremiumType;
		}

		public override bool Equals(object obj)
		{
			return obj is User other && Equals(other);
		}

		public override int GetHashCode()
		{
			var hashCode = new HashCode();
			hashCode.Add(Id);
			hashCode.Add(Username);
			hashCode.Add(Discriminator);
			hashCode.Add(Avatar);
			hashCode.Add(Bot);
			hashCode.Add(System);
			hashCode.Add(MFAEnabled);
			hashCode.Add(Locale);
			hashCode.Add(Verified);
			hashCode.Add(Email);
			hashCode.Add(Flags);
			hashCode.Add(PremiumType);
			return hashCode.ToHashCode();
		}

		public static bool operator ==(User left, User right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(User left, User right)
		{
			return !left.Equals(right);
		}
	}
}