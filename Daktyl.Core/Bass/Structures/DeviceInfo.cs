using System;
using System.Runtime.InteropServices;
using Daktyl.Core.Bass.Enums;

// ReSharper disable MemberCanBePrivate.Global

namespace Daktyl.Core.Bass.Structures
{
	[StructLayout(LayoutKind.Sequential)]
	internal readonly struct DeviceInfo : IEquatable<DeviceInfo>
	{
		[MarshalAs(UnmanagedType.LPUTF8Str)] public readonly string name;
		[MarshalAs(UnmanagedType.LPUTF8Str)] public readonly string driver;

		public readonly Device flags;

		#region IEquatable

		public bool Equals(DeviceInfo other)
		{
			return name == other.name && driver == other.driver && flags == other.flags;
		}

		public override bool Equals(object obj)
		{
			return obj is DeviceInfo other && Equals(other);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = name != null ? name.GetHashCode() : 0;
				hashCode = (hashCode * 397) ^ (driver != null ? driver.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (int) flags;
				return hashCode;
			}
		}

		public static bool operator ==(DeviceInfo left, DeviceInfo right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(DeviceInfo left, DeviceInfo right)
		{
			return !left.Equals(right);
		}

		#endregion
	}
}