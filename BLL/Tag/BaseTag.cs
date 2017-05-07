using System;
using Pine.Dal.Tag;

namespace Pine.Bll.Tag

{
    /// <summary>
    /// کلاس پایه برای منوها
    /// </summary>
    public class BaseTag : PineObject
    {
		#region Properties (2) 
        public BaseTag()
        {

        }
     /// <summary>
        /// تنظیمات سرویس هسته
        /// </summary>
        protected static TagElement Settings
        {
            get { return Globals.Settings.Tag; }
        }

        protected static void SetCache()
        {
            CacheDuration = Settings.CacheDuration;
            MasterCacheKey = "Tag";
        }
		#endregion Properties 

		#region Methods (1) 
        
		// Protected Methods (1) 

        ///// <summary>
        ///// ثبت کردن یک داده خاص در حافظه کش
        ///// </summary>
        ///// <param name="key">نام داده</param>
        ///// <param name="data">محتوای داده</param>
        //protected static void CacheData(String key, object data)
        //{
        //    if (Settings.EnableCaching && data != null)
        //    {
        //        Cache.Insert(key, data, null, DateTime.Now.AddSeconds(Settings.CacheDuration), TimeSpan.Zero);
        //    }
        //}

		#endregion Methods 


      
    }
}

