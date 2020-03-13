namespace Daktyl.Core.Discord.Channels
{
	// https://discordapp.com/developers/docs/resources/channel#channel-object-channel-types
	public enum ChannelType
	{
		TextChannel = 0, // a text channel within a server
		DirectMessage = 1, // a direct message between users
		VoiceChannel = 2, // a direct message between multiple users
		GroupDirectMessage = 3, // a direct message between multiple users
		Category = 4, // an organizational category that contains up to 50 channels
		News = 5, // a channel that users can follow and crosspost into their own server
		Store = 6 // a channel in which game developers can sell their game on Discord
	}
}