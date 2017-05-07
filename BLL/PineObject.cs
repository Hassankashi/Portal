using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Caching;


namespace Pine.Bll
{
    public abstract class PineObject
    {
        protected const Int32 MAXROWS = Int32.MaxValue;

        //protected static Cache Cache
        //{
        //    get { return HttpContext.Current.Cache; }
        //}

        //protected static String CurrentUserName
        //{
        //    get
        //    {
        //        String userName = "";
        //        if (HttpContext.Current.User.Identity.IsAuthenticated)
        //            userName = HttpContext.Current.User.Identity.Name;
        //        return userName;
        //    }
        //}

        //protected static String CurrentUserIP
        //{
        //    get { return HttpContext.Current.Request.UserHostAddress; }
        //}

        //protected static String ConvertNullToEmptyString(String input)
        //{
        //    return (input ?? "");
        //}

        ///// <summary>
        ///// Remove from the ASP.NET cache all items whose key starts with the input prefix
        ///// </summary>
        //protected static void PurgeCacheItems(String prefix)
        //{
        //    prefix = prefix.ToLower();
        //    List<String> itemsToRemove = new List<String>();

        //    IDictionaryEnumerator enumerator = Cache.GetEnumerator();
        //    while (enumerator.MoveNext())
        //    {
        //        if (enumerator.Key.ToString().ToLower().StartsWith(prefix))
        //            itemsToRemove.Add(enumerator.Key.ToString());
        //    }

        //    foreach (String itemToRemove in itemsToRemove)
        //        Cache.Remove(itemToRemove);
        //}

        protected static string MasterCacheKey { get; set; }
        protected static double CacheDuration { get; set; }

        protected static string GetCacheKey(string cacheKey)
        {
            return string.Concat(MasterCacheKey, "-", cacheKey);
        }
        protected static object GetCacheItem(string rawKey)
        {
            return HttpRuntime.Cache[GetCacheKey(rawKey)];
        }
        protected static void AddCacheItem(string rawKey, object value)
        {
            System.Web.Caching.Cache dataCache = HttpRuntime.Cache;
            try
            {
                // Make sure MasterCacheKeyArray[0] is in the cache - if not, add it
                if (dataCache[MasterCacheKey] == null)
                    dataCache[MasterCacheKey] = DateTime.Now;

                // Add a CacheDependency
                System.Web.Caching.CacheDependency dependency = new System.Web.Caching.CacheDependency(null, new string[] { MasterCacheKey });
                dataCache.Insert(GetCacheKey(rawKey), value, dependency, DateTime.Now.AddMinutes(CacheDuration), System.Web.Caching.Cache.NoSlidingExpiration);
            }
            catch
            { }
        }

        public static void InvalidateCache()
        {
            // Remove the cache dependency
            HttpRuntime.Cache.Remove(MasterCacheKey);
        }

        public void InvalidateCache(String masterCacheKey)
        {
            // Remove the cache dependency
            HttpRuntime.Cache.Remove(masterCacheKey);
        }
    }
}
