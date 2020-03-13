using System;

namespace Daktyl.Core.Discord
{
	public readonly struct Snowflake : IEquatable<Snowflake>
	{
		public ulong FullSnowflake { get; }
		public short Id { get; }
		public byte ProcessId { get; }
		public byte WorkerId { get; }
		public DateTimeOffset Date { get; }

		public Snowflake(ulong snowflake)
		{
			FullSnowflake = snowflake;
			Id = (short) (snowflake & 0xFFF);
			ProcessId = (byte) ((snowflake >> 12) & 31);
			WorkerId = (byte) ((snowflake >> 17) & 31);
			Date = DateTimeOffset.FromUnixTimeMilliseconds((long) (snowflake >> 22) + 1420070400000);
		}

		public bool Equals(Snowflake other)
		{
			return FullSnowflake == other.FullSnowflake;
		}

		public override bool Equals(object obj)
		{
			return obj is Snowflake other && Equals(other);
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(FullSnowflake);
		}

		public static bool operator ==(Snowflake left, Snowflake right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(Snowflake left, Snowflake right)
		{
			return !left.Equals(right);
		}
	}
}