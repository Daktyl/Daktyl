using System;
using Daktyl.Core.Discord.Users;

namespace Daktyl.Core.Discord.Guilds
{
	// https://discordapp.com/developers/docs/resources/guild#integration-object
	public readonly struct Integration : IEquatable<Integration>
	{
		public Snowflake Id { get; }
		public string Name { get; }
		public string Type { get; }
		public bool Enabled { get; }
		public bool Syncing { get; }
		public Snowflake RoleId { get; }
		public bool? EnableEmoticons { get; }
		public IntegrationExpireBehavior ExpireBehavior { get; }
		public int ExpireGracePeriod { get; }
		public User User { get; }
		public IntegrationAccount Account { get; }
		public DateTime SyncedAt { get; }

		public Integration(Snowflake id, string name, string type, bool enabled, bool syncing, Snowflake roleId,
			bool? enableEmoticons, IntegrationExpireBehavior expireBehavior, int expireGracePeriod, User user,
			IntegrationAccount account, DateTime syncedAt)
		{
			Id = id;
			Name = name;
			Type = type;
			Enabled = enabled;
			Syncing = syncing;
			RoleId = roleId;
			EnableEmoticons = enableEmoticons;
			ExpireBehavior = expireBehavior;
			ExpireGracePeriod = expireGracePeriod;
			User = user;
			Account = account;
			SyncedAt = syncedAt;
		}

		public bool Equals(Integration other)
		{
			return Id.Equals(other.Id) && Name == other.Name && Type == other.Type && Enabled == other.Enabled &&
					Syncing == other.Syncing && RoleId.Equals(other.RoleId) &&
					EnableEmoticons == other.EnableEmoticons && ExpireBehavior == other.ExpireBehavior &&
					ExpireGracePeriod == other.ExpireGracePeriod && User.Equals(other.User) &&
					Account.Equals(other.Account) && SyncedAt.Equals(other.SyncedAt);
		}

		public override bool Equals(object obj)
		{
			return obj is Integration other && Equals(other);
		}

		public override int GetHashCode()
		{
			var hashCode = new HashCode();
			hashCode.Add(Id);
			hashCode.Add(Name);
			hashCode.Add(Type);
			hashCode.Add(Enabled);
			hashCode.Add(Syncing);
			hashCode.Add(RoleId);
			hashCode.Add(EnableEmoticons);
			hashCode.Add((int) ExpireBehavior);
			hashCode.Add(ExpireGracePeriod);
			hashCode.Add(User);
			hashCode.Add(Account);
			hashCode.Add(SyncedAt);
			return hashCode.ToHashCode();
		}

		public static bool operator ==(Integration left, Integration right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(Integration left, Integration right)
		{
			return !left.Equals(right);
		}
	}
}