using System;
using Daktyl.Core.Discord.Guilds;

namespace Daktyl.Core.Discord.Users
{
	// https://discordapp.com/developers/docs/resources/user#connection-object-connection-structure
	public readonly struct Connection : IEquatable<Connection>
	{
		public string Id { get; }
		public string Name { get; }
		public string Type { get; }
		public bool Revoked { get; }
		public Integration[] Integrations { get; }
		public bool Verified { get; }
		public bool FriendSync { get; }
		public bool ShowActivity { get; }
		public Visibility Visibility { get; }

		public Connection(string id, string name, string type, bool revoked, Integration[] integrations, bool verified,
			bool friendSync, bool showActivity, Visibility visibility)
		{
			Id = id;
			Name = name;
			Type = type;
			Revoked = revoked;
			Integrations = integrations;
			Verified = verified;
			FriendSync = friendSync;
			ShowActivity = showActivity;
			Visibility = visibility;
		}

		public bool Equals(Connection other)
		{
			return Id == other.Id && Name == other.Name && Type == other.Type && Revoked == other.Revoked &&
					Equals(Integrations, other.Integrations) && Verified == other.Verified &&
					FriendSync == other.FriendSync && ShowActivity == other.ShowActivity &&
					Visibility == other.Visibility;
		}

		public override bool Equals(object obj)
		{
			return obj is Connection other && Equals(other);
		}

		public override int GetHashCode()
		{
			var hashCode = new HashCode();
			hashCode.Add(Id);
			hashCode.Add(Name);
			hashCode.Add(Type);
			hashCode.Add(Revoked);
			hashCode.Add(Integrations);
			hashCode.Add(Verified);
			hashCode.Add(FriendSync);
			hashCode.Add(ShowActivity);
			hashCode.Add((int) Visibility);
			return hashCode.ToHashCode();
		}

		public static bool operator ==(Connection left, Connection right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(Connection left, Connection right)
		{
			return !left.Equals(right);
		}
	}
}