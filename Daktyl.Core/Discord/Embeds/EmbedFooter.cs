using System;

namespace Daktyl.Core.Discord.Embeds
{
	// https://discordapp.com/developers/docs/resources/channel#embed-object-embed-footer-structure
	public readonly struct EmbedFooter : IEquatable<EmbedFooter>
	{
		public string Text { get; }
		public string? IconUrl { get; }
		public string? ProxyIconUrl { get; }

		public EmbedFooter(string text, string? iconUrl, string? proxyIconUrl)
		{
			Text = text;
			IconUrl = iconUrl;
			ProxyIconUrl = proxyIconUrl;
		}

		public bool Equals(EmbedFooter other)
		{
			return Text == other.Text && IconUrl == other.IconUrl && ProxyIconUrl == other.ProxyIconUrl;
		}

		public override bool Equals(object obj)
		{
			return obj is EmbedFooter other && Equals(other);
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(Text, IconUrl, ProxyIconUrl);
		}

		public static bool operator ==(EmbedFooter left, EmbedFooter right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(EmbedFooter left, EmbedFooter right)
		{
			return !left.Equals(right);
		}
	}
}