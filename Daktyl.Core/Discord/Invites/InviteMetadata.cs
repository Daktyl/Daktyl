using System;

namespace Daktyl.Core.Discord.Invites
{
	// https://discordapp.com/developers/docs/resources/invite#invite-metadata-object-invite-metadata-structure
	public readonly struct InviteMetadata : IEquatable<InviteMetadata>
	{
		public int Uses { get; }
		public int MaxUses { get; }
		public int MaxAge { get; }
		public bool Temporary { get; }
		public DateTime CreatedAt { get; }

		public InviteMetadata(int uses, int maxUses, int maxAge, bool temporary, DateTime createdAt)
		{
			Uses = uses;
			MaxUses = maxUses;
			MaxAge = maxAge;
			Temporary = temporary;
			CreatedAt = createdAt;
		}

		public bool Equals(InviteMetadata other)
		{
			return Uses == other.Uses && MaxUses == other.MaxUses && MaxAge == other.MaxAge &&
					Temporary == other.Temporary && CreatedAt.Equals(other.CreatedAt);
		}

		public override bool Equals(object obj)
		{
			return obj is InviteMetadata other && Equals(other);
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(Uses, MaxUses, MaxAge, Temporary, CreatedAt);
		}

		public static bool operator ==(InviteMetadata left, InviteMetadata right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(InviteMetadata left, InviteMetadata right)
		{
			return !left.Equals(right);
		}
	}
}