using System;
using System.Linq;

namespace Pine.Dal.Blog
{
    /// <summary>
    /// کلاسی برای نگهداری گروه برچسب بلاگ
    /// </summary>
    public class BlogTagGroupDetails
    {

        #region Constructors (1)
        /// <summary>
        /// سازنده اصلی کلاس جزئیات گروه برچسب
        /// </summary>
        public BlogTagGroupDetails(Int32 blogTagGroupId, String tagGroupName, Int32 domainId, Int32 languageId)
        {
            BlogTagGroupId = blogTagGroupId;
            TagGroupName = tagGroupName;

             DomainId = domainId;

            LanguageId = languageId;
        }

        /// <summary>
        /// سازنده پیش فرض کلاس جزئیات گروه برچسب بلاگ
        /// </summary>
        public BlogTagGroupDetails() { }

        #endregion Constructors

        #region Properties (2)


        /// <summary>
        /// کد گروه برچسب
        /// </summary>
        public Int32 BlogTagGroupId { get; set; }

        /// <summary>
        ///  نام برچسب گروه
        /// </summary>
        public String TagGroupName { get; set; }

         public Int32 DomainId { get; set; }

        public Int32 LanguageId { get; set; } 
     




     
     
        #endregion Properties

    }
}
