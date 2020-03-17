using System.Collections.Concurrent;
using System.Text;

namespace Daktyl.Core.Pools
{
	public static class StringBuilderPool
	{
		private static readonly ConcurrentStack<StringBuilder> Pool = new ConcurrentStack<StringBuilder>();

		public static StringBuilder Rent()
		{
			return Pool.TryPop(out var stringBuilder) ? stringBuilder : new StringBuilder();
		}

		public static StringBuilder Rent(int capacity)
		{
			if (Pool.TryPop(out var stringBuilder))
			{
				if (stringBuilder.Capacity < capacity)
					stringBuilder.Capacity = capacity;
				return stringBuilder;
			}

			return new StringBuilder(capacity);
		}

		public static StringBuilder Rent(string text)
		{
			if (Pool.TryPop(out var stringBuilder))
			{
				stringBuilder.Append(text);
				return stringBuilder;
			}

			return new StringBuilder(text);
		}

		public static void Return(StringBuilder stringBuilder)
		{
			stringBuilder.Clear();
			Pool.Push(stringBuilder);
		}
	}
}
