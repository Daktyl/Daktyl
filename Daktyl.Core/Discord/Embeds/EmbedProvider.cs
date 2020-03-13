using System;

namespace Daktyl.Core.Discord.Embeds
{
	// https://discordapp.com/developers/docs/resources/channel#embed-object-embed-provider-structure
	public readonly struct EmbedProvider : IEquatable<EmbedProvider>
	{
		public string? Name { get; }
		public string? Url { get; }

		public EmbedProvider(string? name, string? url)
		{
			Name = name;
			Url = url;
		}

		public bool Equals(EmbedProvider other)
		{
			return Name == other.Name && Url == other.Url;
		}

		public override bool Equals(object obj)
		{
			return obj is EmbedProvider other && Equals(other);
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(Name, Url);
		}

		public static bool operator ==(EmbedProvider left, EmbedProvider right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(EmbedProvider left, EmbedProvider right)
		{
			return !left.Equals(right);
		}
	}
}