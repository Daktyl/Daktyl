using System.Collections;
using System.Collections.Generic;
using BassWrapper.Enums;
using Daktyl.Core.Bass.Structures;

// ReSharper disable HeapView.BoxingAllocation

namespace BassWrapper
{
	internal struct OutputEnumerator : IEnumerator<AudioDevice>
	{
		internal int Index;
		public AudioDevice Current { get; private set; }

		object IEnumerator.Current => Current;

		public bool MoveNext()
		{
			DeviceInfo device = default;
			while (!device.flags.HasFlagFast(Device.Enabled) & BassNative.GetDevice(Index, out device)) Index++;

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
}