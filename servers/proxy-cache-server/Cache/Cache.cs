using System;

namespace proxy_cache_server.Cache
{
    internal class Cache
    {
        private readonly TimeSpan lifeSpan;
        protected DateTime lastUpdate;
        public string cachedJson;

        protected Cache(TimeSpan lifeSpan)
        {
            this.lifeSpan = lifeSpan;
            lastUpdate = DateTime.MinValue;
            cachedJson = "{\"Error\":\"Bad Request\"}";
        }

        public bool IsOutdated()
        {
            return DateTime.Now - lastUpdate > lifeSpan;
        }
    }

}
