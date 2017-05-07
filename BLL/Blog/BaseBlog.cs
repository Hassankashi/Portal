using System;
using Pine.Dal.Blog;


namespace Pine.Bll.Blog
{
    /// <summary>
    /// کلاس پایه برای بلاگ
    /// </summary>
    public class BaseBlog : PineObject
    {
		#region Properties (2) 

        public BaseBlog()
        {

        }

        protected static void SetCache()
        {
            CacheDuration = Settings.CacheDuration;
            MasterCacheKey = "Blog";
        }
            
        ///// <summary>
        ///// کد
        ///// </summary>
        //public Guid Id{ get; set;}

        /// <summary>
        /// تنظیمات سرویس هسته
        /// </summary>
        protected static BlogElement Settings
        {
            get { return Globals.Settings.Blog; }
        }

		#endregion Properties 

		#region Methods (1) 
        


		#endregion Methods 


      
    }
}

