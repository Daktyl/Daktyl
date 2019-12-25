using BassWrapper.Enums;
using Daktyl.Core.Bass.Structures;

// ReSharper disable NotAccessedField.Global
// ReSharper disable MemberCanBePrivate.Global

namespace BassWrapper
{
	internal readonly struct AudioDevice
	{
		public readonly int Id;
		public readonly string Name;
		public readonly string Driver;
		public readonly Device Flags;

		public AudioDevice(int id, DeviceInfo device)
		{
			Id = id;
			Name = device.name;
			Driver = device.driver;
			Flags = device.flags;
		}
	}
}