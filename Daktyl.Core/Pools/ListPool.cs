using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Daktyl.Core.Pools
{
	public static class ListPool<T>
	{
		private static readonly ConcurrentStack<List<T>> Pool = new ConcurrentStack<List<T>>();

		public static List<T> Rent()
		{
			return Pool.TryPop(out var list) ? list : new List<T>();
		}

		public static List<T> Rent(int capacity)
		{
			if (Pool.TryPop(out var list))
			{
				if (list.Capacity < capacity)
					list.Capacity = capacity;
				return list;
			}

			return new List<T>(capacity);
		}

		public static List<T> Rent(IEnumerable<T> enumerable)
		{
			if (Pool.TryPop(out var list))
			{
				list.AddRange(enumerable);
				return list;
			}

			return new List<T>(enumerable);
		}

		public static void Return(List<T> list)
		{
			list.Clear();
			Pool.Push(list);
		}
	}
}
