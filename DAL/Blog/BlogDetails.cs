using System;
using System.Linq;

namespace Pine.Dal.Blog
{
    /// <summary>
    /// کلاسی برای نگهداری بلاگ
    /// </summary>
    public class BlogDetails
    {
        #region Constructors (1)
        /// <summary>
        /// سازنده اصلی کلاس جزئیات بلاگ
        /// </summary>
        public BlogDetails(Guid blogId, Int32 groupId, String title, String text, String shortText, DateTime enterDate, Guid author, String authorUserName, Boolean isActive, Int32? commentCount, Int32? viewCount, Byte? rate, DateTime? updateDate, Int32 domainId, Int32 languageId)
        {
            BlogId = blogId;
            GroupId = groupId;
            Title = title;
            Text = text;
            ShortText = shortText;
            EnterDate = enterDate;
            Author = author;
            AuthorUserName = authorUserName;
            IsActive = isActive;
            CommentCount = commentCount;
            ViewCount = viewCount;
            Rate = rate;
            UpdateDate = updateDate;
            DomainId = domainId;

            LanguageId = languageId;
        }

        /// <summary>
        /// سازنده پیش فرض کلاس جزئیات بلاگ
        /// </summary>
        public BlogDetails() { }

        #endregion Constructors

        #region Properties (8)

        /// <summary>
        /// کد بلاگ
        /// </summary>
        public Guid BlogId { get; set; }

        /// <summary>
        /// کد گروه بلاگ
        /// </summary>
        public Int32 GroupId { get; set; }

        /// <summary>
        /// عنوان
        /// </summary>
        public String Title { get; set; }

        /// <summary>
        /// متن
        /// </summary>
        public String Text { get; set; }

        /// <summary>
        /// متن کوتاه
        /// </summary>
        public String ShortText { get; set; }

        /// <summary>
        /// تاریخ ورود
        /// </summary>
        public DateTime EnterDate { get; set; }

        /// <summary>
        /// نویسنده
        /// </summary>
        public Guid Author { get; set; }

        /// <summary>
        /// نویسنده
        /// </summary>
        public String AuthorUserName { get; set; }

        /// <summary>
        /// فعال بودن
        /// </summary>
        public Boolean IsActive { get; set; }

        /// <summary>
        /// تعداد کامنت ها
        /// </summary>
        public Int32? CommentCount { get; set; }

        /// <summary>
        /// نمایش تعداد
        /// </summary>
        public Int32? ViewCount { get; set; }

        /// <summary>
        /// رتبه
        /// </summary>
        public Byte? Rate { get; set; }

        /// <summary>
        /// تاریخ آپدیت
        /// </summary>
        public DateTime? UpdateDate { get; set; }

        public Int32 DomainId { get; set; }

        public Int32 LanguageId { get; set; } 

        #endregion Properties

    }
}
