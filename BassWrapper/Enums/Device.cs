using System;

namespace BassWrapper.Enums
{
	[Flags]
	internal enum Device : uint
	{
		Enabled = 0x1,
		Default = 0x2,
		Init = 0x4,
		Loopback = 0x8,
		TypeMask = 0xff000000,
		TypeNetwork = 0x01000000,
		TypeSpeakers = 0x02000000,
		TypeLine = 0x03000000,
		TypeHeadphones = 0x04000000,
		TypeMicrophone = 0x05000000,
		TypeHeadset = 0x06000000,
		TypeHandset = 0x07000000,
		TypeDigital = 0x08000000,
		TypeSpdif = 0x09000000,
		TypeHdmi = 0x0a000000,
		TypeDisplayport = 0x40000000
	}

	internal static class DeviceExtensions
	{
		public static bool HasFlagFast(this Device value, Device flag)
		{
			return (value & flag) != 0;
		}
	}
}