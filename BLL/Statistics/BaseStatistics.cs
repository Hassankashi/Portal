using System;
using Pine.Dal.Statistics;

namespace Pine.Bll.Statistics
{
    /// <summary>
    /// کلاس پایه برای آمار سایت
    /// </summary>
    public class BaseStatistics : PineObject
    {
		#region Properties (2) 

        public BaseStatistics()
        {

        }
                  
            
        /// <summary>
        /// شماره آیتم مورد نظر
        /// </summary>
        public Int32 Id{ get; set;}

        /// <summary>
        /// تنظیمات آمار
        /// </summary>
        protected static StatisticsElement Settings
        {
            get { return Globals.Settings.Statistics; }
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

