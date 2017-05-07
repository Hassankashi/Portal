using System;
using System.Data;
using System.Collections.Generic;
using Pine.Dal;
using Pine.Dal.Core;

namespace Pine.Bll.Core
{
    /// <summary>
    /// کلاس پایه برای هسته سایت
    /// </summary>
    public class BaseCore : PineObject
    {
		#region Properties (2) 

        public BaseCore()
        {

        }

        protected static void SetCache()
        {
            CacheDuration = Settings.CacheDuration;
            MasterCacheKey = "Core";
        }   
        /// <summary>
        /// شماره آیتم مورد نظر
        /// </summary>
        public Int32 Id{ get; set;}

        /// <summary>
        /// تنظیمات سرویس هسته
        /// </summary>
        protected static CoreElement Settings
        {
            get { return Globals.Settings.Core; }
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

