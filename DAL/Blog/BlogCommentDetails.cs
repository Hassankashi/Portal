using System;
using System.Linq;

namespace Pine.Dal.Blog
{
    /// <summary>
    /// کلاسی برای نگهداری کامنت بلاگ
    /// </summary>
    public class BlogCommentDetails
    {
        #region Constructors (1)
        /// <summary>
        /// سازنده اصلی کلاس جزئیات کامنت
        /// </summary>
        public BlogCommentDetails(Guid blogCommentId, Guid blogId, String userName, String email, String webSite, Byte privateComment, Byte displayConfirmed, DateTime enterDate, Int32 domainId, Int32 languageId, String textComment) 
        {
            BlogCommentId = blogCommentId;
            BlogId = blogId;
            UserName = userName;
            Email = email;
            WebSite = webSite;
            PrivateComment = privateComment;
            DisplayConfirmed = displayConfirmed;
            EnterDate = enterDate;

            DomainId = domainId;

            LanguageId = languageId;

            TextComment = textComment;
        }

        /// <summary>
        /// سازنده پیش فرض کلاس جزئیات کامنت
        /// </summary>
        public BlogCommentDetails() { }

        #endregion Constructors

        #region Properties (8)

        /// <summary>
        /// کد توضیحات
        /// </summary>
        public Guid BlogCommentId { get; set; }

        /// <summary>
        /// کد بلاگ
        /// </summary>
        public Guid BlogId { get; set; }

        /// <summary>
        /// نام کاربری
        /// </summary>
        public String UserName { get; set; }

        /// <summary>
        /// ایمیل
        /// </summary>
        public String Email { get; set; }

        /// <summary>
        /// وب سایت
        /// </summary>
        public String WebSite { get; set; }

        /// <summary>
        /// پیغام خصوصی
        /// </summary>
        public Byte PrivateComment { get; set; }

        /// <summary>
        /// نمایش تایید
        /// </summary>
        public Byte DisplayConfirmed { get; set; }

        /// <summary>
        /// تاریخ ورود
        /// </summary>
        public DateTime EnterDate { get; set; }

        public Int32 DomainId { get; set; }

        public Int32 LanguageId { get; set; }

        public String TextComment { get; set; } 

        #endregion Properties

    }
}
