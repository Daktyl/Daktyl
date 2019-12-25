namespace Daktyl.Core
{
	public class CacheElement
	{
		public int Lifetime { get; set; }
	}

	public class CacheElement<T> : CacheElement
	{
		public CacheElement(T data, int lifetime)
		{
			Data = data;
			Lifetime = lifetime;
		}
		
		public T Data { get; }
	}
}