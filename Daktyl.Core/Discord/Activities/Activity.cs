namespace Daktyl.Core.Discord.Activities
{
	public struct Activity
	{
		public string Name { get; }
		public ActivityType Type { get; }
		public string? Url { get; }
		public int CreatedAt { get; }
		public ActivityTimestamp Timestamps { get; }
		public Snowflake? ApplicationId { get; }
		public string? Details { get; }
		public string? State { get; }
		public Emoji? Emoji { get; }
		public ActivityParty? Party { get; }
		public ActivityAssets? Assets { get; }
		public ActivitySecrets? Secrets { get; }
		public bool? Instance { get; }
		public ActivityFlags? Flags { get; }
	}
}