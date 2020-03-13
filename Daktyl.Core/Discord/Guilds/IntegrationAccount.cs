using System;

namespace Daktyl.Core.Discord.Guilds
{
	// https://discordapp.com/developers/docs/resources/guild#integration-account-object-integration-account-structure
	public readonly struct IntegrationAccount : IEquatable<IntegrationAccount>
	{
		public string Id { get; }
		public string Name { get; }

		public IntegrationAccount(string id, string name)
		{
			Id = id;
			Name = name;
		}

		public bool Equals(IntegrationAccount other)
		{
			return Id == other.Id && Name == other.Name;
		}

		public override bool Equals(object obj)
		{
			return obj is IntegrationAccount other && Equals(other);
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(Id, Name);
		}

		public static bool operator ==(IntegrationAccount left, IntegrationAccount right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(IntegrationAccount left, IntegrationAccount right)
		{
			return !left.Equals(right);
		}
	}
}