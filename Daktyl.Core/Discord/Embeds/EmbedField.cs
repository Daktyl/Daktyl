using System;

namespace Daktyl.Core.Discord.Embeds
{
	// https://discordapp.com/developers/docs/resources/channel#embed-object-embed-field-structure
	public readonly struct EmbedField : IEquatable<EmbedField>
	{
		public string Name { get; }
		public string Value { get; }
		public bool? Inline { get; }

		public EmbedField(string name, string value, bool? inline)
		{
			Name = name;
			Value = value;
			Inline = inline;
		}

		public bool Equals(EmbedField other)
		{
			return Name == other.Name && Value == other.Value && Inline == other.Inline;
		}

		public override bool Equals(object obj)
		{
			return obj is EmbedField other && Equals(other);
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(Name, Value, Inline);
		}

		public static bool operator ==(EmbedField left, EmbedField right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(EmbedField left, EmbedField right)
		{
			return !left.Equals(right);
		}
	}
}