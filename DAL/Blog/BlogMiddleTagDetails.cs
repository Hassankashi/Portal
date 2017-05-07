using System;
using System.Linq;

namespace Pine.Dal.Blog
{
    /// <summary>
    /// کلاسی برای نگهداری جدول میانی بلاگ و برچسب
    /// </summary>
    public class BlogMiddleTagDetails
    {

        #region Constructors (1)
        /// <summary>
        /// سازنده اصلی کلاس جزئیات جدول میانی بلاگ و برچسب
        /// </summary>
        public BlogMiddleTagDetails(Guid blogId, Guid blogTagId)
        {
            BlogId = blogId;
            BlogTagId = blogTagId;
        }

        /// <summary>
        /// سازنده پیش فرض کلاس جزئیات جدول میانی بلاگ و برچسب
        /// </summary>
        public BlogMiddleTagDetails() { }

        #endregion Constructors

        #region Properties (2)


        /// <summary>
        /// کد بلاگ
        /// </summary>
        public Guid BlogId { get; set; }

        /// <summary>
        ///  کد برچسب بلاگ
        /// </summary>
        public Guid BlogTagId { get; set; }


     
     
        #endregion Properties

    }
}
