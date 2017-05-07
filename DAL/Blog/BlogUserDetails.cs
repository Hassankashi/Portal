using System;
using System.Linq;

namespace Pine.Dal.Blog
{
    /// <summary>
    /// کلاسی برای نگهداری کاربران بلاگ
    /// </summary>
    public class BlogUserDetails
    {
        #region Constructors (1)
        /// <summary>
        /// سازنده اصلی کلاس جزئیات کاربران بلاگ
        /// </summary>
        public BlogUserDetails(Guid userGuid, String userName, Int32 posts, Boolean isActive, DateTime enterDate, Int32 domainId, Int32 languageId)
        {
            UserGuid = userGuid;
            UserName = userName;
            Posts = posts;
            IsActive = isActive;
            EnterDate = enterDate;

            DomainId = domainId;

            LanguageId = languageId;
        }

        /// <summary>
        /// سازنده پیش فرض کلاس جزئیات کاربران بلاگ
        /// </summary>
        public BlogUserDetails() { }

        #endregion Constructors

        #region Properties (5)

        /// <summary>
        /// کد کاربری 
        /// </summary>
        public Guid UserGuid { get; set; }

        /// <summary>
        /// نام کاربری
        /// </summary>
        public String UserName { get; set; }

        /// <summary>
        /// تعداد پستها
        /// </summary>
        public Int32 Posts { get; set; }

        /// <summary>
        /// فعال بودن
        /// </summary>
        public Boolean IsActive { get; set; }

        /// <summary>
        /// تاریخ ورود
        /// </summary>
        public DateTime EnterDate { get; set; }

        public Int32 DomainId { get; set; }

        public Int32 LanguageId { get; set; } 
     
     

      
        #endregion Properties

    }
}
