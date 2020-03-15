using Daktyl.Core.Discord;

namespace Daktyl.Core.Extensions
{
	public static class EnumExtensions
	{
		public static bool HasFlagFast(this PermissionFlags value, PermissionFlags flag)
		{
			return (value & flag) == flag;
		}
	}
}