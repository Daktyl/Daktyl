using System;

namespace Daktyl.Core.Discord.Messages
{
	// https://discordapp.com/developers/docs/resources/channel#message-object-message-flags
	[Flags]
	public enum MessageFlags
	{
		Crossposted = 1 << 0, // this message has been published to subscribed channels (via Channel Following)
		IsCrosspost = 1 << 1, // this message originated from a message in another channel (via Channel Following)
		SuppressEmbeds = 1 << 2, // the source message for this crosspost has been deleted (via Channel Following)
		SourceMessageDeleted = 1 << 3, // the source message for this crosspost has been deleted (via Channel Following)
		Urgent = 1 << 4 // this message came from the urgent message system
	}
}