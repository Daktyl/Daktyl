using System;

namespace Daktyl.Core.Discord.Guilds
{
	// https://discordapp.com/developers/docs/resources/guild#guild-object-system-channel-flags
	[Flags]
	public enum SystemChannelFlags
	{
		SuppressJoinNotifications = 1 << 0, // 	Suppress member join notifications
		SuppressPremiumSubscriptions = 1 << 1 // Suppress server boost notifications
	}
}