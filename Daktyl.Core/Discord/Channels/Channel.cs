using System;
using Daktyl.Core.Discord.Users;

namespace Daktyl.Core.Discord.Channels
{
	// https://discordapp.com/developers/docs/resources/channel#channel-object-channel-structure
	public struct Channel : IEquatable<Channel>
	{
		public Snowflake Id { get; }
		public ChannelType Type { get; }
		public Snowflake? GuildId { get; }
		public int? Position { get; }
		public PermissionOverwrite[]? PermissionOverwrites { get; }
		public string? Name { get; }
		public string? Topic { get; }
		public bool? Nsfw { get; }
		public Snowflake? LastMessageId { get; }
		public int? BitRate { get; }
		public int? UserLimit { get; }
		public int? RateLimitPerUser { get; }
		public User[]? Recipients { get; }
		public string? Icon { get; }
		public Snowflake? OwnerId { get; }
		public Snowflake? ApplicationId { get; }
		public Snowflake? ParentId { get; }
		public DateTime LastPinTimestamp { get; }

		public Channel(Snowflake id, ChannelType type, Snowflake? guildId, int? position,
			PermissionOverwrite[]? permissionOverwrites, string? name, string? topic, bool? nsfw,
			Snowflake? lastMessageId, int? bitRate, int? userLimit, int? rateLimitPerUser, User[]? recipients,
			string? icon, Snowflake? ownerId, Snowflake? applicationId, Snowflake? parentId, DateTime lastPinTimestamp)
		{
			Id = id;
			Type = type;
			GuildId = guildId;
			Position = position;
			PermissionOverwrites = permissionOverwrites;
			Name = name;
			Topic = topic;
			Nsfw = nsfw;
			LastMessageId = lastMessageId;
			BitRate = bitRate;
			UserLimit = userLimit;
			RateLimitPerUser = rateLimitPerUser;
			Recipients = recipients;
			Icon = icon;
			OwnerId = ownerId;
			ApplicationId = applicationId;
			ParentId = parentId;
			LastPinTimestamp = lastPinTimestamp;
		}

		public bool Equals(Channel other)
		{
			return Id.Equals(other.Id) && Type == other.Type && Nullable.Equals(GuildId, other.GuildId) &&
					Position == other.Position && Equals(PermissionOverwrites, other.PermissionOverwrites) &&
					Name == other.Name && Topic == other.Topic && Nsfw == other.Nsfw &&
					Nullable.Equals(LastMessageId, other.LastMessageId) && BitRate == other.BitRate &&
					UserLimit == other.UserLimit && RateLimitPerUser == other.RateLimitPerUser &&
					Equals(Recipients, other.Recipients) && Icon == other.Icon &&
					Nullable.Equals(OwnerId, other.OwnerId) && Nullable.Equals(ApplicationId, other.ApplicationId) &&
					Nullable.Equals(ParentId, other.ParentId) && LastPinTimestamp.Equals(other.LastPinTimestamp);
		}

		public override bool Equals(object obj)
		{
			return obj is Channel other && Equals(other);
		}

		public override int GetHashCode()
		{
			var hashCode = new HashCode();
			hashCode.Add(Id);
			hashCode.Add((int) Type);
			hashCode.Add(GuildId);
			hashCode.Add(Position);
			hashCode.Add(PermissionOverwrites);
			hashCode.Add(Name);
			hashCode.Add(Topic);
			hashCode.Add(Nsfw);
			hashCode.Add(LastMessageId);
			hashCode.Add(BitRate);
			hashCode.Add(UserLimit);
			hashCode.Add(RateLimitPerUser);
			hashCode.Add(Recipients);
			hashCode.Add(Icon);
			hashCode.Add(OwnerId);
			hashCode.Add(ApplicationId);
			hashCode.Add(ParentId);
			hashCode.Add(LastPinTimestamp);
			return hashCode.ToHashCode();
		}

		public static bool operator ==(Channel left, Channel right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(Channel left, Channel right)
		{
			return !left.Equals(right);
		}
	}
}