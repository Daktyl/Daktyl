using System;

namespace Daktyl.Core.Discord
{
	// https://discordapp.com/developers/docs/resources/channel#attachment-object-attachment-structure
	public readonly struct Attachment : IEquatable<Attachment>
	{
		public Snowflake Id { get; }
		public string FileName { get; }
		public int Size { get; }
		public string Url { get; }
		public string ProxyUrl { get; }
		public int? Height { get; }
		public int? Width { get; }

		public Attachment(Snowflake id, string fileName, int size, string url, string proxyUrl, int? height, int? width)
		{
			Id = id;
			FileName = fileName;
			Size = size;
			Url = url;
			ProxyUrl = proxyUrl;
			Height = height;
			Width = width;
		}

		public bool Equals(Attachment other)
		{
			return Id.Equals(other.Id) && FileName == other.FileName && Size == other.Size && Url == other.Url &&
					ProxyUrl == other.ProxyUrl && Height == other.Height && Width == other.Width;
		}

		public override bool Equals(object obj)
		{
			return obj is Attachment other && Equals(other);
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(Id, FileName, Size, Url, ProxyUrl, Height, Width);
		}

		public static bool operator ==(Attachment left, Attachment right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(Attachment left, Attachment right)
		{
			return !left.Equals(right);
		}
	}
}