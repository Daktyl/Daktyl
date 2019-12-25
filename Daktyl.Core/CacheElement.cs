using System;

namespace Daktyl.Core
{
    public class CacheElement
    {
        public CacheElement(object data, int lifetime)
        {
            Data = data;
            Lifetime = lifetime;
        }
        
        public object Data { get; }
        public int Lifetime { get; set; }
    }
}