using System;
using Daktyl.Core.Discord.Channels;
using Daktyl.Core.Discord.Voice;

namespace Daktyl.Core.Discord.Guilds
{
	// https://discordapp.com/developers/docs/resources/guild#guild-object
	public readonly struct Guild : IEquatable<Guild>
	{
		public Snowflake Id { get; }
		public string Name { get; }
		public string? Icon { get; }
		public string? Splash { get; }
		public string? DiscoverySplash { get; }
		public bool? Owner { get; }
		public Snowflake OwnerId { get; }
		public int? Permissions { get; }
		public string Region { get; }
		public Snowflake? AfkChannelId { get; }
		public int AfkTimeout { get; }
		public bool? EmbedEnabled { get; }
		public Snowflake? EmbedChannelId { get; }
		public VerificationLevel VerificationLevel { get; }
		public MessageNotificationLevel DefaultMessageNotifictations { get; }
		public ExplicitContentFilterLevel ExplicitContentFilter { get; }
		public Role[] Roles { get; }
		public Emoji[] Emojis { get; }
		public string[] Features { get; }
		public MFALevel MFALevel { get; }
		public Snowflake? ApplicationId { get; }
		public bool? WidgedEnabled { get; }
		public Snowflake? WidgedChnanelId { get; }
		public Snowflake? SystemChannelId { get; }
		public SystemChannelFlags SystemChannelFlags { get; }
		public Snowflake? RulesChannelId { get; }
		public DateTime? JoinedAt { get; }
		public bool? Large { get; }
		public bool? Unavailable { get; }
		public int? MemberCount { get; }
		public VoiceState[] VoiceStates { get; }
		public GuildMember[] Members { get; }
		public Channel[] Channels { get; }
		public Presence[] Presences { get; }
		public int? MaxPresences { get; }
		public int? MaxMembers { get; }
		public string? VanityUrlCode { get; }
		public string? Description { get; }
		public string? Banner { get; }
		public PremiumTier PremiumTier { get; }
		public int? PremiumSubscriptionCount { get; }
		public string PrefferedLocale { get; }
		public Snowflake? PublicUpdatesChannelId { get; }

		public Guild(Snowflake id, string name, string? icon, string? splash, string? discoverySplash, bool? owner,
			Snowflake ownerId, int? permissions, string region, Snowflake? afkChannelId, int afkTimeout,
			bool? embedEnabled, Snowflake? embedChannelId, VerificationLevel verificationLevel,
			MessageNotificationLevel defaultMessageNotifictations, ExplicitContentFilterLevel explicitContentFilter,
			Role[] roles, Emoji[] emojis, string[] features, MFALevel mfaLevel, Snowflake? applicationId,
			bool? widgedEnabled, Snowflake? widgedChnanelId, Snowflake? systemChannelId,
			SystemChannelFlags systemChannelFlags, Snowflake? rulesChannelId, DateTime? joinedAt, bool? large,
			bool? unavailable, int? memberCount, VoiceState[] voiceStates, GuildMember[] members, Channel[] channels,
			Presence[] presences, int? maxPresences, int? maxMembers, string? vanityUrlCode, string? description,
			string? banner, PremiumTier premiumTier, int? premiumSubscriptionCount, string prefferedLocale,
			Snowflake? publicUpdatesChannelId)
		{
			Id = id;
			Name = name;
			Icon = icon;
			Splash = splash;
			DiscoverySplash = discoverySplash;
			Owner = owner;
			OwnerId = ownerId;
			Permissions = permissions;
			Region = region;
			AfkChannelId = afkChannelId;
			AfkTimeout = afkTimeout;
			EmbedEnabled = embedEnabled;
			EmbedChannelId = embedChannelId;
			VerificationLevel = verificationLevel;
			DefaultMessageNotifictations = defaultMessageNotifictations;
			ExplicitContentFilter = explicitContentFilter;
			Roles = roles;
			Emojis = emojis;
			Features = features;
			MFALevel = mfaLevel;
			ApplicationId = applicationId;
			WidgedEnabled = widgedEnabled;
			WidgedChnanelId = widgedChnanelId;
			SystemChannelId = systemChannelId;
			SystemChannelFlags = systemChannelFlags;
			RulesChannelId = rulesChannelId;
			JoinedAt = joinedAt;
			Large = large;
			Unavailable = unavailable;
			MemberCount = memberCount;
			VoiceStates = voiceStates;
			Members = members;
			Channels = channels;
			Presences = presences;
			MaxPresences = maxPresences;
			MaxMembers = maxMembers;
			VanityUrlCode = vanityUrlCode;
			Description = description;
			Banner = banner;
			PremiumTier = premiumTier;
			PremiumSubscriptionCount = premiumSubscriptionCount;
			PrefferedLocale = prefferedLocale;
			PublicUpdatesChannelId = publicUpdatesChannelId;
		}

		public bool Equals(Guild other)
		{
			return Id.Equals(other.Id) && Name == other.Name && Icon == other.Icon && Splash == other.Splash &&
					DiscoverySplash == other.DiscoverySplash && Owner == other.Owner && OwnerId.Equals(other.OwnerId) &&
					Permissions == other.Permissions && Region == other.Region &&
					Nullable.Equals(AfkChannelId, other.AfkChannelId) && AfkTimeout == other.AfkTimeout &&
					EmbedEnabled == other.EmbedEnabled && Nullable.Equals(EmbedChannelId, other.EmbedChannelId) &&
					VerificationLevel == other.VerificationLevel &&
					DefaultMessageNotifictations == other.DefaultMessageNotifictations &&
					ExplicitContentFilter == other.ExplicitContentFilter && Equals(Roles, other.Roles) &&
					Equals(Emojis, other.Emojis) && Equals(Features, other.Features) && MFALevel == other.MFALevel &&
					Nullable.Equals(ApplicationId, other.ApplicationId) && WidgedEnabled == other.WidgedEnabled &&
					Nullable.Equals(WidgedChnanelId, other.WidgedChnanelId) &&
					Nullable.Equals(SystemChannelId, other.SystemChannelId) &&
					SystemChannelFlags == other.SystemChannelFlags &&
					Nullable.Equals(RulesChannelId, other.RulesChannelId) &&
					Nullable.Equals(JoinedAt, other.JoinedAt) && Large == other.Large &&
					Unavailable == other.Unavailable && MemberCount == other.MemberCount &&
					Equals(VoiceStates, other.VoiceStates) && Equals(Members, other.Members) &&
					Equals(Channels, other.Channels) && Equals(Presences, other.Presences) &&
					MaxPresences == other.MaxPresences && MaxMembers == other.MaxMembers &&
					VanityUrlCode == other.VanityUrlCode && Description == other.Description &&
					Banner == other.Banner && PremiumTier == other.PremiumTier &&
					PremiumSubscriptionCount == other.PremiumSubscriptionCount &&
					PrefferedLocale == other.PrefferedLocale &&
					Nullable.Equals(PublicUpdatesChannelId, other.PublicUpdatesChannelId);
		}

		public override bool Equals(object obj)
		{
			return obj is Guild other && Equals(other);
		}

		public override int GetHashCode()
		{
			var hashCode = new HashCode();
			hashCode.Add(Id);
			hashCode.Add(Name);
			hashCode.Add(Icon);
			hashCode.Add(Splash);
			hashCode.Add(DiscoverySplash);
			hashCode.Add(Owner);
			hashCode.Add(OwnerId);
			hashCode.Add(Permissions);
			hashCode.Add(Region);
			hashCode.Add(AfkChannelId);
			hashCode.Add(AfkTimeout);
			hashCode.Add(EmbedEnabled);
			hashCode.Add(EmbedChannelId);
			hashCode.Add((int) VerificationLevel);
			hashCode.Add((int) DefaultMessageNotifictations);
			hashCode.Add((int) ExplicitContentFilter);
			hashCode.Add(Roles);
			hashCode.Add(Emojis);
			hashCode.Add(Features);
			hashCode.Add((int) MFALevel);
			hashCode.Add(ApplicationId);
			hashCode.Add(WidgedEnabled);
			hashCode.Add(WidgedChnanelId);
			hashCode.Add(SystemChannelId);
			hashCode.Add((int) SystemChannelFlags);
			hashCode.Add(RulesChannelId);
			hashCode.Add(JoinedAt);
			hashCode.Add(Large);
			hashCode.Add(Unavailable);
			hashCode.Add(MemberCount);
			hashCode.Add(VoiceStates);
			hashCode.Add(Members);
			hashCode.Add(Channels);
			hashCode.Add(Presences);
			hashCode.Add(MaxPresences);
			hashCode.Add(MaxMembers);
			hashCode.Add(VanityUrlCode);
			hashCode.Add(Description);
			hashCode.Add(Banner);
			hashCode.Add((int) PremiumTier);
			hashCode.Add(PremiumSubscriptionCount);
			hashCode.Add(PrefferedLocale);
			hashCode.Add(PublicUpdatesChannelId);
			return hashCode.ToHashCode();
		}

		public static bool operator ==(Guild left, Guild right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(Guild left, Guild right)
		{
			return !left.Equals(right);
		}
	}
}