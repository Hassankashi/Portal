using System;
using Pine;
using Pine.Bll;
using Pine.Dal.Advertisement;

namespace Pine.Bll.Advertisement

{
    /// <summary>
    /// کلاس پایه برای منوها
    /// </summary>
    public class BaseAdvertisement : PineObject
    {
		#region Properties (2) 
        public BaseAdvertisement()
        {

        }
     /// <summary>
        /// تنظیمات سرویس هسته
        /// </summary>
        protected static AdvertisementElement Settings
        {
            get { return Globals.Settings.Advertisement; }
        }

        protected static void SetCache()
        {
            CacheDuration = Settings.CacheDuration;
            MasterCacheKey = "Advertisement";
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

