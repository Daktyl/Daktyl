using System;
using System.Runtime.InteropServices;
using Daktyl.Core.Bass.Enums;

// ReSharper disable MemberCanBePrivate.Global

namespace Daktyl.Core.Bass.Structures
{
	[StructLayout(LayoutKind.Sequential)]
	internal readonly struct Info : IEquatable<Info>
	{
		/// <summary>
		///     Device capabilities.
		/// </summary>
		public readonly DscCaps flags;

		/// <summary>
		///     Size of total device hardware memory.
		/// </summary>
		public readonly uint hwsize;

		/// <summary>
		///     Size of free device hardware memory.
		/// </summary>
		public readonly uint hwfree;

		/// <summary>
		///     Number of free sample slots in the hardware.
		/// </summary>
		public readonly uint freesam;

		/// <summary>
		///     Number of free 3D sample slots in the hardware.
		/// </summary>
		public readonly uint free3d;

		/// <summary>
		///     Min sample rate supported by the hardware.
		/// </summary>
		public readonly uint minrate;

		/// <summary>
		///     Max sample rate supported by the hardware.
		/// </summary>
		public readonly uint maxrate;

		/// <summary>
		///     Device supports EAX? (always FALSE if BASS_DEVICE_3D was not used).
		/// </summary>
		public readonly bool eax;

		/// <summary>
		///     Recommended minimum buffer length in ms (requires BASS_DEVICE_LATENCY).
		/// </summary>
		public readonly uint minbuf;

		/// <summary>
		///     DirectSound version.
		/// </summary>
		public readonly uint dsver;

		/// <summary>
		///     Delay (in ms) before start of playback (requires BASS_DEVICE_LATENCY).
		/// </summary>
		public readonly uint latency;

		/// <summary>
		///     BASS_Init "flags" parameter.
		/// </summary>
		public readonly uint initflags;

		/// <summary>
		///     Number of speakers available.
		/// </summary>
		public readonly uint speakers;

		/// <summary>
		///     Current output rate.
		/// </summary>
		public readonly uint freq;

		#region IEquatable

		public bool Equals(Info other)
		{
			return flags == other.flags && hwsize == other.hwsize && hwfree == other.hwfree &&
					freesam == other.freesam && free3d == other.free3d && minrate == other.minrate &&
					maxrate == other.maxrate && eax == other.eax && minbuf == other.minbuf && dsver == other.dsver &&
					latency == other.latency && initflags == other.initflags && speakers == other.speakers &&
					freq == other.freq;
		}

		public override bool Equals(object obj)
		{
			return obj is Info other && Equals(other);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = (int) flags;
				hashCode = (hashCode * 397) ^ (int) hwsize;
				hashCode = (hashCode * 397) ^ (int) hwfree;
				hashCode = (hashCode * 397) ^ (int) freesam;
				hashCode = (hashCode * 397) ^ (int) free3d;
				hashCode = (hashCode * 397) ^ (int) minrate;
				hashCode = (hashCode * 397) ^ (int) maxrate;
				hashCode = (hashCode * 397) ^ eax.GetHashCode();
				hashCode = (hashCode * 397) ^ (int) minbuf;
				hashCode = (hashCode * 397) ^ (int) dsver;
				hashCode = (hashCode * 397) ^ (int) latency;
				hashCode = (hashCode * 397) ^ (int) initflags;
				hashCode = (hashCode * 397) ^ (int) speakers;
				hashCode = (hashCode * 397) ^ (int) freq;
				return hashCode;
			}
		}

		public static bool operator ==(Info left, Info right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(Info left, Info right)
		{
			return !left.Equals(right);
		}

		#endregion
	}
}