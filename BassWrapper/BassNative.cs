using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using BassWrapper.Enums;
using Daktyl.Core.Bass.Structures;

// ReSharper disable MemberCanBePrivate.Global

namespace BassWrapper
{
	internal static class BassNative
	{
		private const string Bass = "bass";

		private static readonly Platform CurrentPlatform;
		private static readonly List<uint> Plugins = new List<uint>();

		static BassNative()
		{
#if NETCOREAPP3_1
			if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
			{
				CurrentPlatform = Platform.Windows;
			}
			else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
			{
				CurrentPlatform = Platform.Linux;
			}
			else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
			{
				CurrentPlatform = Platform.Mac;
			}
#elif MONOANDROID90
			CurrentPlatform = Platform.Android;
#elif XAMARIN_IOS
			CurrentPlatform = Platform.Ios;
#endif
		}

		[DllImport(Bass, EntryPoint = "BASS_Init")]
		private static extern bool Init(int device, uint freq, uint flags, IntPtr win, IntPtr clsid);

		internal static bool Init(int device, uint freq, uint flags)
		{
			const uint unicode = 0x80000000;
			var filter = CurrentPlatform switch
			{
				Platform.Windows => "bass*.dll",
				Platform.Android => "libbass*.so",
				Platform.Linux => "libbass*.so",
				Platform.Mac => "libbass*.dylib",
				Platform.Ios => "libbass*.a",
				_ => throw new PlatformNotSupportedException()
			};
			foreach (var file in Directory.GetFiles("bassplugins", filter))
			{
				var plugin = LoadPlugin(file, unicode);
				if (plugin != 0) Plugins.Add(plugin);
			}

			return Init(device, freq, flags, Process.GetCurrentProcess().MainWindowHandle, IntPtr.Zero);
		}

		[DllImport(Bass, EntryPoint = "BASS_Free")]
		private static extern bool Free();

		internal static bool Deinit()
		{
			foreach (var plugin in Plugins) UnloadPlugin(plugin);
			Plugins.Clear();
			return Free();
		}

		[DllImport(Bass, EntryPoint = "BASS_Init")]
		private static extern uint LoadPlugin([MarshalAs(UnmanagedType.LPWStr)] string file, uint flags);

		[DllImport(Bass, EntryPoint = "BASS_PluginFree")]
		private static extern bool UnloadPlugin(uint handle);

		[DllImport(Bass, EntryPoint = "BASS_ErrorGetCode")]
		internal static extern ErrorCode GetLastError();

		[DllImport(Bass, EntryPoint = "BASS_GetDeviceInfo")]
		internal static extern bool GetDevice(int device, out DeviceInfo info);

		[DllImport(Bass, EntryPoint = "BASS_RecordGetDeviceInfo")]
		internal static extern bool GetRecordDevice(int device, out DeviceInfo info);

		[DllImport(Bass, EntryPoint = "BASS_SetConfig")]
		internal static extern bool SetConfig(int device, int info);

		[DllImport(Bass, EntryPoint = "BASS_SetConfig")]
		internal static extern bool SetConfig(int device, bool info);

		[DllImport(Bass, EntryPoint = "BASS_SetConfigPtr")]
		internal static extern bool SetConfig(int device, IntPtr info);

		[DllImport(Bass, EntryPoint = "BASS_SetConfigPtr")]
		private static extern bool SetConfigUtf8(int device, [MarshalAs(UnmanagedType.LPUTF8Str)] string info);

		[DllImport(Bass, EntryPoint = "BASS_SetConfigPtr")]
		private static extern bool SetConfigUtf16(int device, [MarshalAs(UnmanagedType.LPWStr)] string info);

		internal static bool SetConfig(int device, string info)
		{
			return CurrentPlatform == Platform.Windows ? SetConfigUtf16(device, info) : SetConfigUtf8(device, info);
		}

		[DllImport(Bass, EntryPoint = "BASS_GetConfig")]
		internal static extern uint GetConfigInt(uint device);

		internal static bool GetConfigBool(uint device)
		{
			var config = GetConfigInt(device);
			if (config == unchecked((uint) -1)) throw new Exception();
			return config == 1;
		}

		[DllImport(Bass, EntryPoint = "BASS_GetConfigPtr")]
		internal static extern IntPtr GetConfigPointer(int device);

		[DllImport(Bass, EntryPoint = "BASS_GetConfigPtr")]
		[return: MarshalAs(UnmanagedType.LPUTF8Str)]
		private static extern string GetConfigUtf8(int device);

		[DllImport(Bass, EntryPoint = "BASS_GetConfigPtr")]
		[return: MarshalAs(UnmanagedType.LPWStr)]
		private static extern string GetConfigUtf16(int device);

		internal static string GetConfigString(int device)
		{
			return CurrentPlatform == Platform.Windows ? GetConfigUtf16(device) : GetConfigUtf8(device);
		}

		private enum Platform : byte
		{
			Windows,
			Linux,
			Mac,
			Android,
			Ios
		}
	}
}