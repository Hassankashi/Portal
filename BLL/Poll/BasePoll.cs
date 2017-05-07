using System;
using Pine.Dal.Poll;

namespace Pine.Bll.Poll
{
    /// <summary>
    /// کلاس پایه برای منوها
    /// </summary>
    public class BasePoll : PineObject
    {
		#region Properties (2) 

        public BasePoll()
        {

        }
                  
            
        /// <summary>
        /// شماره آیتم مورد نظر
        /// </summary>
       // public Int32 PollId{ get; set;}

        /// <summary>
        /// تنظیمات سرویس هسته
        /// </summary>
        protected static PollElement Settings
        {
            get { return Globals.Settings.Poll; }
        }

        protected static void SetCache()
        {
            CacheDuration = Settings.CacheDuration;
            MasterCacheKey = "Poll";
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

