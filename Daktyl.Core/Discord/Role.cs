namespace Daktyl.Core.Discord
{
	public struct Role
	{
		public Snowflake Id { get; }
		public string Name { get; }
		public int Color { get; }
		public bool Hoist { get; }
		public int Position { get; }
		public int Permissions { get; }
		public bool Managed { get; }
		public bool Mentionable { get; }
	}
}