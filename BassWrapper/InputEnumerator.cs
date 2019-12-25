using System.Collections;
using System.Collections.Generic;
using BassWrapper.Enums;
using Daktyl.Core.Bass.Structures;

// ReSharper disable HeapView.BoxingAllocation

namespace BassWrapper
{
	internal struct InputEnumerator : IEnumerator<AudioDevice>
	{
		internal int Index;
		public AudioDevice Current { get; private set; }

		object IEnumerator.Current => Current;

		public bool MoveNext()
		{
			DeviceInfo device = default;
			while ((!device.flags.HasFlagFast(Device.Enabled) || !device.flags.HasFlagFast(Device.TypeMicrophone)) &
					BassNative.GetRecordDevice(Index, out device)) Index++;

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