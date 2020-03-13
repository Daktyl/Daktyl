using System;

namespace Daktyl.Core.Discord.Users
{
	// https://discordapp.com/developers/docs/resources/user#user-object-user-flags
	[Flags]
	public enum UserFlags
	{
		None = 0,
		Employee = 1 << 0,
		Partner = 1 << 1,
		HypeSquadEvent = 1 << 2,
		BugHunter1 = 1 << 3,
		BraveryHouse = 1 << 6,
		BrillianceHouse = 1 << 7,
		BalanceHouse = 1 << 8,
		EarlySupporter = 1 << 9,
		TeamUser = 1 << 10,
		System = 1 << 12,
		BugHunter2 = 1 << 14,
	}
}