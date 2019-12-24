using BassWrapper.Enums;
using Daktyl.Core.Bass.Structures;
using System.Collections;
using System.Collections.Generic;

// ReSharper disable HeapView.BoxingAllocation
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable NotAccessedField.Global

namespace BassWrapper
{
	internal static class DeviceManager
	{
		public static OutputEnumerator GetOutputDevices()
		{
			return new OutputEnumerator {Index = 1};
		}

		public static InputEnumerator GetInputDevices()
		{
			return new InputEnumerator {Index = 0};
		}
	}

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

	internal struct OutputEnumerator : IEnumerator<AudioDevice>
	{
		internal int Index;
		public AudioDevice Current { get; private set; }

		object IEnumerator.Current => Current;

		public bool MoveNext()
		{
			DeviceInfo device = default;
			while (!device.flags.HasFlagFast(Device.Enabled) & BassNative.GetDevice(Index, out device))
			{
				Index++;
			}

			Current = new AudioDevice(Index, device);

			return device.flags.HasFlagFast(Device.Enabled);
		}

		public void Reset()
		{
			Index = 1;
		}

		public void Dispose()
		{
		}
	}

	internal struct InputEnumerator : IEnumerator<AudioDevice>
	{
		internal int Index;
		public AudioDevice Current { get; private set; }

		object IEnumerator.Current => Current;

		public bool MoveNext()
		{
			DeviceInfo device = default;
			while ((!device.flags.HasFlagFast(Device.Enabled) || !device.flags.HasFlagFast(Device.TypeMicrophone)) & BassNative.GetRecordDevice(Index, out device))
			{
				Index++;
			}

			Current = new AudioDevice(Index, device);

			return device.flags.HasFlagFast(Device.Enabled) && device.flags.HasFlagFast(Device.TypeMicrophone);
		}

		public void Reset()
		{
			Index = 0;
		}

		public void Dispose()
		{
		}
	}
}
