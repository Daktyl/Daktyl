using System.Collections.Generic;
using System.Threading.Tasks;

using Xunit;

namespace Daktyl.Core.Tests
{
    public class CacheTests
    {
        [Fact]
        public async void CacheTest()
        {
            var cache = new Cache(2);
            
            cache.Set("element1", 123);
            cache.Set("element2", 456, 2);

            Assert.True(cache.Has("element1"));
            Assert.True(cache.Has("element2"));
            
            Assert.Equal(123, cache.Get<int>("element1"));
            Assert.Equal(456, cache.Get<int>("element2"));

            await Task.Delay(3000);

            Assert.False(cache.Has("element1"));
            Assert.False(cache.Has("element2"));

            Assert.Throws<KeyNotFoundException>(() => cache.Get<int>("element1"));
            Assert.Throws<KeyNotFoundException>(() => cache.Get<int>("element2"));

            Assert.Equal(0, cache.GetOrDefault<int>("element1"));
            Assert.Equal(0, cache.GetOrDefault<int>("element2"));
        }
    }
}