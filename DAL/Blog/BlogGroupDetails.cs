using System;
using System.Linq;

namespace Pine.Dal.Blog
{
    /// <summary>
    /// کلاسی برای نگهداری گروه بلاگ
    /// </summary>
    public class BlogGroupDetails
    {
        #region Constructors (1)
        /// <summary>
        /// سازنده اصلی کلاس جزئیات گروه بلاگ
        /// </summary>
        public BlogGroupDetails(Int32 blogGroupId, String groupName, Boolean isShow, Int32 domainId, Int32 languageId)
        {
            BlogGroupId = blogGroupId;
            GroupName = groupName;
            IsShow = isShow;

            DomainId = domainId;

            LanguageId = languageId;
        }

        /// <summary>
        /// سازنده پیش فرض کلاس جزئیات گروه بلاگ
        /// </summary>
        public BlogGroupDetails() { }

        #endregion Constructors

        #region Properties (8)

        /// <summary>
        /// کد گروه بلاگ
        /// </summary>
        public Int32 BlogGroupId { get; set; }

        /// <summary>
        /// نام گروه
        /// </summary>
        public String GroupName { get; set; }

        /// <summary>
        /// نمایش دادن
        /// </summary>
        public Boolean IsShow { get; set; }

        public Int32 DomainId { get; set; }

        public Int32 LanguageId { get; set; } 
    
     
        #endregion Properties

    }
}
