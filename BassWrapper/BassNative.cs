using Daktyl.Core.Bass.Structures;
using System.Runtime.InteropServices;

namespace BassWrapper
{
	internal static class BassNative
	{
		private const string Bass = "bass";

		[DllImport(Bass, EntryPoint = "BASS_GetDeviceInfo")]
		internal static extern bool GetDevice(int device, out DeviceInfo info);

		[DllImport(Bass, EntryPoint = "BASS_RecordGetDeviceInfo")]
		internal static extern bool GetRecordDevice(int device, out DeviceInfo info);
	}
}
