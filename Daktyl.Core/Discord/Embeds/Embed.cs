using System;

namespace Daktyl.Core.Discord.Embeds
{
	// https://discordapp.com/developers/docs/resources/channel#embed-object
	public readonly struct Embed : IEquatable<Embed>
	{
		public string? Title { get; }
		public string? Type { get; }
		public string? Description { get; }
		public string? Url { get; }
		public DateTime? Timestamp { get; }
		public int? Color { get; }
		public EmbedFooter? Footer { get; }
		public EmbedImage? Image { get; }
		public EmbedImage? Thumbnail { get; }
		public EmbedVideo? Video { get; }
		public EmbedProvider? Provider { get; }
		public EmbedAuthor? Author { get; }
		public EmbedField[] Fields { get; }

		public Embed(string? title, string? type, string? description, string? url, DateTime? timestamp, int? color,
			EmbedFooter? footer, EmbedImage? image, EmbedImage? thumbnail, EmbedVideo? video, EmbedProvider? provider,
			EmbedAuthor? author, EmbedField[] fields)
		{
			Title = title;
			Type = type;
			Description = description;
			Url = url;
			Timestamp = timestamp;
			Color = color;
			Footer = footer;
			Image = image;
			Thumbnail = thumbnail;
			Video = video;
			Provider = provider;
			Author = author;
			Fields = fields;
		}

		public bool Equals(Embed other)
		{
			return Title == other.Title && Type == other.Type && Description == other.Description && Url == other.Url &&
					Nullable.Equals(Timestamp, other.Timestamp) && Color == other.Color &&
					Nullable.Equals(Footer, other.Footer) && Nullable.Equals(Image, other.Image) &&
					Nullable.Equals(Thumbnail, other.Thumbnail) && Nullable.Equals(Video, other.Video) &&
					Nullable.Equals(Provider, other.Provider) && Nullable.Equals(Author, other.Author) &&
					Equals(Fields, other.Fields);
		}

		public override bool Equals(object obj)
		{
			return obj is Embed other && Equals(other);
		}

		public override int GetHashCode()
		{
			var hashCode = new HashCode();
			hashCode.Add(Title);
			hashCode.Add(Type);
			hashCode.Add(Description);
			hashCode.Add(Url);
			hashCode.Add(Timestamp);
			hashCode.Add(Color);
			hashCode.Add(Footer);
			hashCode.Add(Image);
			hashCode.Add(Thumbnail);
			hashCode.Add(Video);
			hashCode.Add(Provider);
			hashCode.Add(Author);
			hashCode.Add(Fields);
			return hashCode.ToHashCode();
		}

		public static bool operator ==(Embed left, Embed right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(Embed left, Embed right)
		{
			return !left.Equals(right);
		}
	}
}