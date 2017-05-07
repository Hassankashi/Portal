using System;
using Pine.Dal.Link;

namespace Pine.Bll.Link
{
    /// <summary>
    /// کلاس پایه برای لینکها
    /// </summary>
    public class BaseLink : PineObject
    {
		#region Properties (2) 

        public BaseLink()
        {

        }
                  
            
        /// <summary>
        /// شماره آیتم مورد نظر
        /// </summary>
        public Int32 Id{ get; set;}

        /// <summary>
        /// تنظیمات سرویس هسته
        /// </summary>
        protected static LinkElement Settings
        {
            get { return Globals.Settings.Link; }
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

