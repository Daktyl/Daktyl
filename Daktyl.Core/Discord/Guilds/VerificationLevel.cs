namespace Daktyl.Core.Discord.Guilds
{
	// https://discordapp.com/developers/docs/resources/guild#guild-object-verification-level
	public enum VerificationLevel
	{
		None = 0, // unrestricted
		Low = 1, // must have verified email on account
		Medium = 2, // must be registered on Discord for longer than 5 minutes
		High = 3, // (╯°□°）╯︵ ┻━┻ - must be a member of the server for longer than 10 minutes
		VeryHigh = 4 // ┻━┻ ミヽ(ಠ 益 ಠ)ﾉ彡 ┻━┻ - must have a verified phone number
	}
}