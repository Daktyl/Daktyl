using System;
using Daktyl.Core.Discord.Guilds;

namespace Daktyl.Core.Discord.Voice
{
	// https://discordapp.com/developers/docs/resources/voice#voice-state-object-voice-state-structure
	public readonly struct VoiceState : IEquatable<VoiceState>
	{
		public Snowflake? GuildId { get; }
		public Snowflake? ChannelId { get; }
		public Snowflake UserId { get; }
		public GuildMember? Member { get; }
		public string SessionId { get; }
		public bool Deaf { get; }
		public bool Mute { get; }
		public bool SelfDeaf { get; }
		public bool SelfMute { get; }
		public bool SelfStream { get; }
		public bool Suppress { get; }

		public VoiceState(Snowflake? guildId, Snowflake? channelId, Snowflake userId, GuildMember? member,
			string sessionId, bool deaf, bool mute, bool selfDeaf, bool selfMute, bool selfStream, bool suppress)
		{
			GuildId = guildId;
			ChannelId = channelId;
			UserId = userId;
			Member = member;
			SessionId = sessionId;
			Deaf = deaf;
			Mute = mute;
			SelfDeaf = selfDeaf;
			SelfMute = selfMute;
			SelfStream = selfStream;
			Suppress = suppress;
		}

		public bool Equals(VoiceState other)
		{
			return Nullable.Equals(GuildId, other.GuildId) && Nullable.Equals(ChannelId, other.ChannelId) &&
					UserId.Equals(other.UserId) && Nullable.Equals(Member, other.Member) &&
					SessionId == other.SessionId && Deaf == other.Deaf && Mute == other.Mute &&
					SelfDeaf == other.SelfDeaf && SelfMute == other.SelfMute && SelfStream == other.SelfStream &&
					Suppress == other.Suppress;
		}

		public override bool Equals(object obj)
		{
			return obj is VoiceState other && Equals(other);
		}

		public override int GetHashCode()
		{
			var hashCode = new HashCode();
			hashCode.Add(GuildId);
			hashCode.Add(ChannelId);
			hashCode.Add(UserId);
			hashCode.Add(Member);
			hashCode.Add(SessionId);
			hashCode.Add(Deaf);
			hashCode.Add(Mute);
			hashCode.Add(SelfDeaf);
			hashCode.Add(SelfMute);
			hashCode.Add(SelfStream);
			hashCode.Add(Suppress);
			return hashCode.ToHashCode();
		}

		public static bool operator ==(VoiceState left, VoiceState right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(VoiceState left, VoiceState right)
		{
			return !left.Equals(right);
		}
	}
}