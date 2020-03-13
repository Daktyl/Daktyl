using System;
using Daktyl.Core.Discord.Activities;
using Daktyl.Core.Discord.Users;

namespace Daktyl.Core.Discord
{
	public struct Presence
	{
		public User User { get; }
		public Snowflake[] Roles { get; }
		public Activity? Game { get; }
		public Snowflake GuildId { get; }
		public string Status { get; }
		public Activity[] Activities { get; }
		public ClientStatus ClientStatus { get; }
		public DateTime? PremiumSince { get; }
		public string? Nick { get; }
	}
}