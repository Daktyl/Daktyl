using System;

namespace Daktyl.Core.Discord.Embeds
{
	// https://discordapp.com/developers/docs/resources/channel#embed-object-embed-author-structure
	public readonly struct EmbedAuthor : IEquatable<EmbedAuthor>
	{
		public string? Name { get; }
		public string? Url { get; }
		public string? IconUrl { get; }
		public string? ProxyIconUrl { get; }

		public EmbedAuthor(string? name, string? url, string? iconUrl, string? proxyIconUrl)
		{
			Name = name;
			Url = url;
			IconUrl = iconUrl;
			ProxyIconUrl = proxyIconUrl;
		}

		public bool Equals(EmbedAuthor other)
		{
			return Name == other.Name && Url == other.Url && IconUrl == other.IconUrl &&
					ProxyIconUrl == other.ProxyIconUrl;
		}

		public override bool Equals(object obj)
		{
			return obj is EmbedAuthor other && Equals(other);
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(Name, Url, IconUrl, ProxyIconUrl);
		}

		public static bool operator ==(EmbedAuthor left, EmbedAuthor right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(EmbedAuthor left, EmbedAuthor right)
		{
			return !left.Equals(right);
		}
	}
}