using System;

namespace Daktyl.Core.Discord.Messages
{
	// https://discordapp.com/developers/docs/resources/channel#message-object-message-application-structure
	public readonly struct MessageApplication : IEquatable<MessageApplication>
	{
		public Snowflake Id { get; }
		public string? CoverImage { get; }
		public string Description { get; }
		public string? Icon { get; }
		public string Name { get; }

		public MessageApplication(Snowflake id, string? coverImage, string description, string? icon, string name)
		{
			Id = id;
			CoverImage = coverImage;
			Description = description;
			Icon = icon;
			Name = name;
		}

		public bool Equals(MessageApplication other)
		{
			return Id.Equals(other.Id) && CoverImage == other.CoverImage && Description == other.Description &&
					Icon == other.Icon && Name == other.Name;
		}

		public override bool Equals(object obj)
		{
			return obj is MessageApplication other && Equals(other);
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(Id, CoverImage, Description, Icon, Name);
		}

		public static bool operator ==(MessageApplication left, MessageApplication right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(MessageApplication left, MessageApplication right)
		{
			return !left.Equals(right);
		}
	}
}