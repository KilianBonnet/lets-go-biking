using System;
using System.Collections.Generic;
using System.Runtime.Caching;

namespace proxy_cache_server.Implementation.Generic_proxy_cache
{
    public class GenericProxyCache<T>
    {
        private readonly DateTimeOffset dt_default = ObjectCache.InfiniteAbsoluteExpiration;
        private readonly ObjectCache cache = MemoryCache.Default;

        public T Get(string CacheItemName)
        {
            return cache[CacheItemName] is T fileContents ?
                  fileContents : Put(CacheItemName, dt_default);
        }
        
        public T Get(string CacheItemName, double dt_seconds)
        {
            return cache[CacheItemName] is T fileContents ?
                fileContents : Put(CacheItemName, DateTimeOffset.Now.AddSeconds(dt_seconds));
        }

        public T Get(string CacheItemName, DateTimeOffset dt)
        {
            return cache[CacheItemName] is T fileContents ?
                fileContents : Put(CacheItemName, dt);
        }
        
        private T Put(string CacheItemName, DateTimeOffset dt)
        {
            CacheItemPolicy policy = new CacheItemPolicy {
                AbsoluteExpiration = dt
            };

            T obj = (T)Activator.CreateInstance(typeof(T), args:CacheItemName);
                
            cache.Set(CacheItemName, obj, policy);

            return obj;
        }
    }
}