using System;
// ReSharper disable InconsistentNaming

namespace BassWrapper.Enums
{
	[Flags]
	internal enum WaveFormat : uint
	{
		/// <summary>
		/// 11.025 kHz, Mono, 8-bit
		/// </summary>
		Mono8bit11kHz = 0x00000001,
		/// <summary>
		/// 11.025 kHz, Stereo, 8-bit
		/// </summary>
		Stereo8bit11kHz = 0x00000002,
		/// <summary>
		/// 11.025 kHz, Mono, 16-bit
		/// </summary>
		Mono16bit11kHz = 0x00000004,
		/// <summary>
		/// 11.025 kHz, Stereo, 16-bit
		/// </summary>
		Stereo16bit11kHz = 0x00000008,
		/// <summary>
		/// 22.05 kHz, Mono, 8-bit
		/// </summary>
		Mono8bit22kHz = 0x00000010,
		/// <summary>
		/// 22.05 kHz, Stereo, 8-bit
		/// </summary>
		Stereo8bit22kHz = 0x00000020,
		/// <summary>
		/// 22.05 kHz, Mono, 16-bit
		/// </summary>
		Mono16bit22kHz = 0x00000040,
		/// <summary>
		/// 22.05 kHz, Stereo, 16-bit
		/// </summary>
		Stereo16bit22kHz = 0x00000080,
		/// <summary>
		/// 44.1 kHz, Mono, 8-bit
		/// </summary>
		Mono8bit44kHz = 0x00000100,
		/// <summary>
		/// 44.1 kHz, Stereo, 8-bit
		/// </summary>
		Stereo8bit44kHz = 0x00000200,
		/// <summary>
		/// 44.1 kHz, Mono, 16-bit
		/// </summary>
		Mono16bit44kHz = 0x00000400,
		/// <summary>
		/// 44.1 kHz, Stereo, 16-bit
		/// </summary>
		Stereo16bit44kHz = 0x00000800
	}

	internal static class WaveFormatExtensions
	{
		public static bool HasFlagFast(this WaveFormat value, WaveFormat flag)
		{
			return (value & flag) != 0;
		}
	}
}
