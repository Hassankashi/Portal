using System;
using Pine.Dal.Menu;

namespace Pine.Bll.Menu
{
    /// <summary>
    /// کلاس پایه برای منوها
    /// </summary>
    public class BaseMenu : PineObject
    {
		#region Properties (2) 

        public BaseMenu()
        {

        }
                  
            
        /// <summary>
        /// شماره آیتم مورد نظر
        /// </summary>
        public Int32 Id{ get; set;}

        /// <summary>
        /// تنظیمات سرویس هسته
        /// </summary>
        protected static MenuElement Settings
        {
            get { return Globals.Settings.Menu; }
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

