using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Daktyl.Core
{
	public class Cache : IDisposable
	{
		public int DefaultLifetime { get; }

		private readonly Dictionary<string, CacheElement> _elements = new Dictionary<string, CacheElement>();

		private bool _disposeTask;

		public Cache(int defaultLifetime)
		{
			DefaultLifetime = defaultLifetime;

			Task.Run(async () =>
				{
					while (!_disposeTask)
					{
						foreach (var pair in _elements)
						{
							var element = pair.Value;

							if (element.Lifetime >= 0 && --element.Lifetime <= 0)
							{
								_elements.Remove(pair.Key);
							}
						}

						await Task.Delay(1000);
					}
				}
			);
		}

		public void Set<T>(string name, T value) => Set(name, value, DefaultLifetime);

		public void Set<T>(string name, T value, int lifetime)
		{
			_elements[name] = new CacheElement<T>(value, lifetime);
		}

		public bool TryGet<T>(string name, out T value)
		{
			if (_elements.TryGetValue(name, out var element))
			{
				value = element is CacheElement<T> genericElement
					? genericElement.Data
					: throw new InvalidCastException($"Fetched data is not of type {typeof(T).Name}.");
				return true;
			}

			value = default;
			return false;
		}

		public T Get<T>(string name)
		{
			return TryGet(name, out T result)
				? result
				: throw new KeyNotFoundException("Couldn't find specified element in cache.");
		}

		public T GetOrDefault<T>(string name)
		{
			return TryGet(name, out T result) ? result : default;
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