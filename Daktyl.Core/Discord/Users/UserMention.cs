using Daktyl.Core.Discord.Channels;

namespace Daktyl.Core.Discord.Users
{
	public struct UserMention
	{
		public string Name { get; }
		public Snowflake Id { get; }
		public Snowflake GuildId { get; }
		public ChannelType Type { get; }
	}
}