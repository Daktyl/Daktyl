using System;
using System.IO;
using System.Runtime.InteropServices;

namespace Daktyl.Core.Bass
{
	public static class InputManager
	{
		private static Stream _inputStream;
		private static uint _channel;
		private static bool _recording;
		private static byte[] _buffer = new byte[0];

		private static readonly BassNative.RecordCallback RecordCallback;

		static InputManager()
		{
			RecordCallback = RecordProcess;
			BassNative.RecordInit(-1);
			AppDomain.CurrentDomain.ProcessExit += OnProcessExit;
		}

		private static void OnProcessExit(object sender, EventArgs e)
		{
			BassNative.RecordFree();
		}

		public static void Start(Stream stream, int device)
		{
			BassNative.RecordSetDevice(device);
			_channel = BassNative.RecordStart(0, 1, 0, RecordCallback, IntPtr.Zero);
			_inputStream = stream;
			_recording = true;
		}

		public static void Stop()
		{
			BassNative.ChannelStop(_channel);
			_inputStream = null;
			_recording = false;
		}

		public static void Pause()
		{
			BassNative.ChannelPause(_channel);
		}

		public static void Unpause()
		{
			BassNative.ChannelPlay(_channel, false);
		}

		[MonoPInvokeCallback(typeof(BassNative.RecordCallback))]
		private static bool RecordProcess(uint handle, IntPtr buffer, uint length, IntPtr user)
		{
			var count = (int)length;
			if (_buffer.Length < count)
			{
				_buffer = new byte[count];
			}
			Marshal.Copy(buffer, _buffer, 0, count);
			_inputStream.Write(_buffer, 0, count);
			return _recording;
		}
	}
}
