using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Daktyl.Core
{
    public class Cache : IDisposable
    {
        public Cache(int defaultLifetime)
        {
            DefaultLifetime = defaultLifetime;

            WorkerTask = Task.Run(
                async () =>
                {
                    while(!_disposeTask)
                    {
                        foreach(var pair in _elements)
                        {
                            var element = pair.Value;

                            if(element.Lifetime >= 0 && --element.Lifetime <= 0)
                            {
                                _elements.Remove(pair.Key);
                            }
                        }

                        await Task.Delay(1000);
                    }
                }
            );
        }

        public int DefaultLifetime { get; }

        private readonly IDictionary<string, CacheElement> _elements = new Dictionary<string, CacheElement>();

        protected readonly Task WorkerTask;
        private bool _disposeTask;

        public void Set<T>(string name, T value, int? lifetime = null)
        {
            _elements[name] = new CacheElement(value, lifetime ?? DefaultLifetime);
        }

        public T GetOrDefault<T>(string name)
        {
            return Has(name) ? Get<T>(name) : default;
        }

        public T Get<T>(string name)
        {
            if(_elements.TryGetValue(name, out var value))
            {
                return value.Data is T data
                    ? data
                    : throw new InvalidCastException($"Fetched data cannot be cast to {typeof(T).Name}.");
            }
            
            throw new KeyNotFoundException("Couldn't find specified element in cache.");
        }

        public bool Has(string name)
        {
            return _elements.ContainsKey(name);
        }

        public void Dispose()
        {
            _disposeTask = true;
        }
    }
}