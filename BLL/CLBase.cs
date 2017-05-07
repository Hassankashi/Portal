using System;
using System.Linq;
using System.Web;

namespace Pine.Bll
{
    public class CLBase
    {

        protected string MasterCacheKey { get; set; }
        protected double CacheDuration { get; set; }

        protected string GetCacheKey(string cacheKey)
        {
            return string.Concat(MasterCacheKey, "-", cacheKey);
        }
        protected object GetCacheItem(string rawKey)
        {
            return HttpRuntime.Cache[GetCacheKey(rawKey)];
        }
        protected void AddCacheItem(string rawKey, object value)
        {
            System.Web.Caching.Cache dataCache = HttpRuntime.Cache;

            // Make sure MasterCacheKeyArray[0] is in the cache - if not, add it
            if (dataCache[MasterCacheKey] == null)
                dataCache[MasterCacheKey] = DateTime.Now;

            // Add a CacheDependency
            System.Web.Caching.CacheDependency dependency = new System.Web.Caching.CacheDependency(null, new string[] { MasterCacheKey });
            dataCache.Insert(GetCacheKey(rawKey), value, dependency, DateTime.Now.AddMinutes(CacheDuration), System.Web.Caching.Cache.NoSlidingExpiration);
        }
        public void InvalidateCache()
        {
            // Remove the cache dependency
            HttpRuntime.Cache.Remove(MasterCacheKey);
        }

        public void InvalidateCache(string masterCacheKeyName)
        {
            // Remove the cache dependency
            HttpRuntime.Cache.Remove(masterCacheKeyName);
        }
    }
}
