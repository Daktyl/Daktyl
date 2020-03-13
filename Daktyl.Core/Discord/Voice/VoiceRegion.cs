using System;

namespace Daktyl.Core.Discord.Voice
{
	// https://discordapp.com/developers/docs/resources/voice#voice-region-object-voice-region-structure
	public readonly struct VoiceRegion : IEquatable<VoiceRegion>
	{
		public string Id { get; }
		public string Name { get; }
		public bool VIP { get; }
		public bool Optimal { get; }
		public bool Deprecated { get; }
		public bool Custom { get; }

		public VoiceRegion(string id, string name, bool vip, bool optimal, bool deprecated, bool custom)
		{
			Id = id;
			Name = name;
			VIP = vip;
			Optimal = optimal;
			Deprecated = deprecated;
			Custom = custom;
		}

		public bool Equals(VoiceRegion other)
		{
			return Id == other.Id && Name == other.Name && VIP == other.VIP && Optimal == other.Optimal &&
					Deprecated == other.Deprecated && Custom == other.Custom;
		}

		public override bool Equals(object obj)
		{
			return obj is VoiceRegion other && Equals(other);
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(Id, Name, VIP, Optimal, Deprecated, Custom);
		}

		public static bool operator ==(VoiceRegion left, VoiceRegion right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(VoiceRegion left, VoiceRegion right)
		{
			return !left.Equals(right);
		}
	}
}