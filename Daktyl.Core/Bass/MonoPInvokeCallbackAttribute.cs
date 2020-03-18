using System;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable NotAccessedField.Global

namespace Daktyl.Core.Bass
{
	internal class MonoPInvokeCallbackAttribute : Attribute
	{
		public Type Type;

		public MonoPInvokeCallbackAttribute(Type type)
		{
			Type = type;
		}
	}
}
