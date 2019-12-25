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
}
