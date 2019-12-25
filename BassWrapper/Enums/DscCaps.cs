using System;

namespace BassWrapper.Enums
{
	[Flags]
	internal enum DscCaps : uint
	{
		ContinuousRate = 0x00000010,
		Emuldriver = 0x00000020,
		Certified = 0x00000040,
		SecondaryMono = 0x00000100,
		SecondaryStereo = 0x00000200,
		Secondary8Bit = 0x00000400,
		Secondary16Bit = 0x00000800
	}

	internal static class DscCapsExtensions
	{
		public static bool HasFlagFast(this DscCaps value, DscCaps flag)
		{
			return (value & flag) != 0;
		}
	}
}