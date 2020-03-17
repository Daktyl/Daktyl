using System.Collections.Concurrent;
using System.IO;

namespace Daktyl.Core.Pools
{
	public static class MemoryStreamPool
	{
		private static readonly ConcurrentStack<MemoryStream> Pool = new ConcurrentStack<MemoryStream>();

		public static MemoryStream Rent()
		{
			return Pool.TryPop(out var memoryStream) ? memoryStream : new MemoryStream();
		}

		public static MemoryStream Rent(int capacity)
		{
			if (Pool.TryPop(out var memoryStream))
			{
				if (memoryStream.Capacity < capacity)
					memoryStream.Capacity = capacity;
				return memoryStream;
			}

			return new MemoryStream(capacity);
		}

		public static void Return(MemoryStream memoryStream)
		{
			memoryStream.Position = 0;
			memoryStream.SetLength(0);
			Pool.Push(memoryStream);
		}
	}
}
