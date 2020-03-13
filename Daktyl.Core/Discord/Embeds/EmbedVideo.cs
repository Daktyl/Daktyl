using System;

namespace Daktyl.Core.Discord.Embeds
{
	// https://discordapp.com/developers/docs/resources/channel#embed-object-embed-video-structure
	public readonly struct EmbedVideo : IEquatable<EmbedVideo>
	{
		public string? Url { get; }
		public int? Height { get; }
		public int? Width { get; }

		public EmbedVideo(string? url, int? height, int? width)
		{
			Url = url;
			Height = height;
			Width = width;
		}

		public bool Equals(EmbedVideo other)
		{
			return Url == other.Url && Height == other.Height && Width == other.Width;
		}

		public override bool Equals(object obj)
		{
			return obj is EmbedVideo other && Equals(other);
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(Url, Height, Width);
		}

		public static bool operator ==(EmbedVideo left, EmbedVideo right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(EmbedVideo left, EmbedVideo right)
		{
			return !left.Equals(right);
		}
	}
}