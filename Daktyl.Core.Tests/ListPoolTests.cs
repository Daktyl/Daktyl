using Daktyl.Core.Pools;
using System.Linq;
using Xunit;

namespace Daktyl.Core.Tests
{
	public class ListPoolTests
	{
		[Fact]
		public void EmptyTest()
		{
			var list = ListPool<int>.Rent();
			Assert.Empty(list);
			list.AddRange(new []{432, 5435, 54343, 45234, 423534, 3123});
			ListPool<int>.Return(list);
			var list2 = ListPool<int>.Rent();
			Assert.Empty(list2);
			ListPool<int>.Return(list2);
		}

		[Fact]
		public void CapacityTest()
		{
			var list = ListPool<int>.Rent(byte.MaxValue);
			Assert.True(list.Capacity >= byte.MaxValue);
			ListPool<int>.Return(list);
		}

		[Fact]
		public void SequenceTest()
		{
			int[] array = {432, 5435, 54343, 45234, 423534, 3123};
			var list = ListPool<int>.Rent(array);
			Assert.True(list.SequenceEqual(array));
			ListPool<int>.Return(list);
		}
	}
}
