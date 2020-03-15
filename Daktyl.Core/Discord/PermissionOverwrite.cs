using System;

namespace Daktyl.Core.Discord
{
	public readonly struct PermissionOverwrite : IEquatable<PermissionOverwrite>
	{
		public Snowflake Id { get; }
		public string Type { get; }
		public PermissionFlags DenyFlags { get; }
		public PermissionFlags AllowFlags { get; }
		
		public PermissionOverwrite(Snowflake id, string type, PermissionFlags allowFlags, PermissionFlags denyFlags)
		{
			Id = id;
			Type = type;
			AllowFlags = allowFlags;
			DenyFlags = denyFlags;
		}

		public bool Equals(PermissionOverwrite other)
		{
			return Id.Equals(other.Id) && Type == other.Type && AllowFlags == other.AllowFlags &&
					DenyFlags == other.DenyFlags;
		}

		public override bool Equals(object obj)
		{
			return obj is PermissionOverwrite other && Equals(other);
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(Id, Type, AllowFlags, DenyFlags);
		}

		public static bool operator ==(PermissionOverwrite left, PermissionOverwrite right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(PermissionOverwrite left, PermissionOverwrite right)
		{
			return !left.Equals(right);
		}
	}
}