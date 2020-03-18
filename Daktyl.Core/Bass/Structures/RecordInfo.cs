using System;
using System.Runtime.InteropServices;
using Daktyl.Core.Bass.Enums;

// ReSharper disable MemberCanBePrivate.Global

namespace Daktyl.Core.Bass.Structures
{
	[StructLayout(LayoutKind.Sequential)]
	internal readonly struct RecordInfo : IEquatable<RecordInfo>
	{
		/// <summary>
		///     Device capabilities.
		/// </summary>
		public readonly DscCaps flags;

		/// <summary>
		///     Supported standard formats.
		/// </summary>
		public readonly WaveFormat formats;

		/// <summary>
		///     Number of inputs.
		/// </summary>
		public readonly uint inputs;

		/// <summary>
		///     If true, only 1 input can be set at a time.
		/// </summary>
		public readonly bool singlein;

		/// <summary>
		///     Current input rate.
		/// </summary>
		public readonly uint freq;

		#region IEquatable

		public bool Equals(RecordInfo other)
		{
			return flags == other.flags && formats == other.formats && inputs == other.inputs &&
					singlein == other.singlein && freq == other.freq;
		}

		public override bool Equals(object obj)
		{
			return obj is RecordInfo other && Equals(other);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = (int) flags;
				hashCode = (hashCode * 397) ^ (int) formats;
				hashCode = (hashCode * 397) ^ (int) inputs;
				hashCode = (hashCode * 397) ^ singlein.GetHashCode();
				hashCode = (hashCode * 397) ^ (int) freq;
				return hashCode;
			}
		}

		public static bool operator ==(RecordInfo left, RecordInfo right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(RecordInfo left, RecordInfo right)
		{
			return !left.Equals(right);
		}

		#endregion
	}
}