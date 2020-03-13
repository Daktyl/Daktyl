using System;
using Daktyl.Core.Discord.Channels;
using Daktyl.Core.Discord.Guilds;
using Daktyl.Core.Discord.Users;

namespace Daktyl.Core.Discord.Invites
{
	// https://discordapp.com/developers/docs/resources/invite#invite-object-invite-structure
	public readonly struct Invite : IEquatable<Invite>
	{
		public string Code { get; }
		public Guild? Guild { get; }
		public Channel? Channel { get; }
		public User? Inviter { get; }
		public User? TargerUser { get; }
		public TargetUserType? TargetUserType { get; }
		public int? ApproximatePresenceCount { get; }
		public int ApproximateMemberCount { get; }

		public Invite(string code, Guild? guild, Channel? channel, User? inviter, User? targerUser,
			TargetUserType? targetUserType, int? approximatePresenceCount, int approximateMemberCount)
		{
			Code = code;
			Guild = guild;
			Channel = channel;
			Inviter = inviter;
			TargerUser = targerUser;
			TargetUserType = targetUserType;
			ApproximatePresenceCount = approximatePresenceCount;
			ApproximateMemberCount = approximateMemberCount;
		}

		public bool Equals(Invite other)
		{
			return Code == other.Code && Nullable.Equals(Guild, other.Guild) &&
					Nullable.Equals(Channel, other.Channel) && Nullable.Equals(Inviter, other.Inviter) &&
					Nullable.Equals(TargerUser, other.TargerUser) && TargetUserType == other.TargetUserType &&
					ApproximatePresenceCount == other.ApproximatePresenceCount &&
					ApproximateMemberCount == other.ApproximateMemberCount;
		}

		public override bool Equals(object obj)
		{
			return obj is Invite other && Equals(other);
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(Code, Guild, Channel, Inviter, TargerUser, TargetUserType, ApproximatePresenceCount,
									ApproximateMemberCount);
		}

		public static bool operator ==(Invite left, Invite right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(Invite left, Invite right)
		{
			return !left.Equals(right);
		}
	}
}