using System;
using System.Linq;

namespace Pine.Dal.Blog
{
    /// <summary>
    /// کلاسی برای نگهداری رتبه بلاگ
    /// </summary>
    public class BlogRateDetails
    {
        #region Constructors (1)
        /// <summary>
        /// سازنده اصلی کلاس جزئیات رتبه بلاگ
        /// </summary>
        public BlogRateDetails(Guid blogRateId, Guid blogId, String userNmae, Byte rate, Int32 domainId, Int32 languageId)
        {
            BlogRateId = blogRateId;
            BlogId = blogId;
            UserNmae = userNmae;
            Rate = rate;

            DomainId = domainId;

            LanguageId = languageId;
        }

        /// <summary>
        /// سازنده پیش فرض کلاس جزئیات رتبه بلاگ
        /// </summary>
        public BlogRateDetails() { }

        #endregion Constructors

        #region Properties (8)

        /// <summary>
        /// کد رتبه بلاگ
        /// </summary>
        public Guid BlogRateId { get; set; }

        /// <summary>
        /// کد بلاگ
        /// </summary>
        public Guid BlogId { get; set; }

        /// <summary>
        /// نام کاربری
        /// </summary>
        public String UserNmae { get; set; }

        /// <summary>
        /// رتبه
        /// </summary>
        public Byte Rate { get; set; }

        public Int32 DomainId { get; set; }

        public Int32 LanguageId { get; set; } 
     
        #endregion Properties

    }
}
