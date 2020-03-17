using System;
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable NotAccessedField.Global

namespace BassWrapper
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
