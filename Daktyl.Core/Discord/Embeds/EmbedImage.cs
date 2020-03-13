using System;

namespace Daktyl.Core.Discord.Embeds
{
	// https://discordapp.com/developers/docs/resources/channel#embed-object-embed-image-structure
	public readonly struct EmbedImage : IEquatable<EmbedImage>
	{
		public string? Url { get; }
		public string? ProxyUrl { get; }
		public int? Height { get; }
		public int? Width { get; }

		public EmbedImage(string? url, string? proxyUrl, int? height, int? width)
		{
			Url = url;
			ProxyUrl = proxyUrl;
			Height = height;
			Width = width;
		}

		public bool Equals(EmbedImage other)
		{
			return Url == other.Url && ProxyUrl == other.ProxyUrl && Height == other.Height && Width == other.Width;
		}

		public override bool Equals(object obj)
		{
			return obj is EmbedImage other && Equals(other);
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(Url, ProxyUrl, Height, Width);
		}

		public static bool operator ==(EmbedImage left, EmbedImage right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(EmbedImage left, EmbedImage right)
		{
			return !left.Equals(right);
		}
	}
}