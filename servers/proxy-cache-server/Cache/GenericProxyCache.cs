using System;

namespace proxy_cache_server.Cache
{
    internal class GenericProxyCache
    {
        private readonly TimeSpan lifeSpan;
        protected DateTime lastUpdate;

        protected GenericProxyCache(TimeSpan lifeSpan)
        {
            this.lifeSpan = lifeSpan;
            lastUpdate = DateTime.MinValue;
        }

        public bool IsOutdated()
        {
            return DateTime.Now - lastUpdate > lifeSpan;
        }
    }

}
