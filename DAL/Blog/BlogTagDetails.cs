using System;
using System.Linq;

namespace Pine.Dal.Blog
{
    /// <summary>
    /// کلاسی برای نگهداری برچسب بلاگ
    /// </summary>
    public class BlogTagDetails
    {

        #region Constructors (1)
        /// <summary>
        /// سازنده اصلی کلاس جزئیات برچسب
        /// </summary>
        public BlogTagDetails(Guid blogTagId, Int32 blogTagGroupId, String tagName, Int32 domainId, Int32 languageId)
        {
            BlogTagId = blogTagId;
            BlogTagGroupId = blogTagGroupId;
            TagName = tagName;

            DomainId = domainId;

            LanguageId = languageId;
        }

        /// <summary>
        /// سازنده پیش فرض کلاس جزئیات برچسب بلاگ
        /// </summary>
        public BlogTagDetails() { }

        #endregion Constructors

        #region Properties (8)

        /// <summary>
        /// کد برچسب
        /// </summary>
        public Guid BlogTagId { get; set; }

        /// <summary>
        /// کد گروه برچسب
        /// </summary>
        public Int32 BlogTagGroupId { get; set; }

        /// <summary>
        /// نام برچسب
        /// </summary>
        public String TagName { get; set; }

        public Int32 DomainId { get; set; }

        public Int32 LanguageId { get; set; } 
     
     
        #endregion Properties

    }
}
