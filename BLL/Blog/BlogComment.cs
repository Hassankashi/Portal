using System;
using System.Collections.Generic;
using System.Linq;
using Pine.Dal;
using Pine.Dal.Blog;

namespace Pine.Bll.Blog
{
    /// <summary>
    /// کلاسی برای نگهداری جزئیات کامنت بلاگ
    /// </summary>
    public class BlogComment : BaseBlog
    {

        #region Constructors (2)

       /// <summary>
        /// سازنده اصلی کلاس جزئیات کامنت
        /// </summary>
        public BlogComment(Guid blogCommentId, Guid blogId, String userName, String email, String webSite, Byte privateComment, Byte displayConfirmed, DateTime enterDate, Int32 domainId, Int32 languageId, String textComment) 
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
        public BlogComment()
        {
            CacheDuration = Settings.CacheDuration;
            MasterCacheKey = "Blog";

        }

        #endregion Constructors

        #region Properties (7)

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

        #region Methods(7)

        public List<BlogComment> GetBlogCommentByBlogId(Guid blogId)
        {
            List<BlogComment> item;

            String key = "BlogComment_BlogId_" + blogId;

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as List<BlogComment>;
                if (item == null)
                {
                   List< BlogCommentDetails> rerecordSet = SiteProvider.Blog.GetBlogCommentByBlogId(blogId);
                    item = GetBlogCommentCollectionFromOrderDal(rerecordSet);
                    AddCacheItem(key, item);
                }
            }
            else
            {
                List<BlogCommentDetails> rerecordSet = SiteProvider.Blog.GetBlogCommentByBlogId(blogId);
                item = GetBlogCommentCollectionFromOrderDal(rerecordSet);
                AddCacheItem(key, item);
            }

            return item;
        }

        public BlogComment GetBlogCommentByBlogCommentId(Guid blogCommentId)
        {
            BlogComment item;

            String key = "BlogComment_BlogCommentId_" + blogCommentId;

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as BlogComment;
                if (item == null)
                {
                    BlogCommentDetails rerecordSet = SiteProvider.Blog.GetBlogCommentByBlogCommentId(blogCommentId);
                    item = GetBlogCommentFromOrderDal(rerecordSet);
                    AddCacheItem(key, item);
                }
            }
            else
            {
                BlogCommentDetails rerecordSet = SiteProvider.Blog.GetBlogCommentByBlogCommentId(blogCommentId);
                item = GetBlogCommentFromOrderDal(rerecordSet);
                AddCacheItem(key, item);
            }

            return item;
        }

        public Int32 Insert()
        {
            return Insert(BlogCommentId, BlogId, UserName, Email, WebSite, PrivateComment, DisplayConfirmed, EnterDate, DomainId, LanguageId,TextComment);
        }

        private Int32 Insert(Guid blogCommentId, Guid blogId, String userName, String email, String webSite, Byte privateComment, Byte displayConfirmed, DateTime enterDate, Int32 domainId, Int32 languageId, String textComment)
        {
            BlogCommentDetails blogComment = new BlogCommentDetails(blogCommentId, blogId, userName, email, webSite, privateComment, displayConfirmed, enterDate, domainId, languageId,textComment);
            Int32 ret = SiteProvider.Blog.InsertBlogComment(blogComment);
            if (Settings.EnableCaching & ret > 0)
                InvalidateCache();
            return ret;
        }

        public bool Update()
        {
            return Update(BlogCommentId, BlogId, UserName, Email, WebSite, PrivateComment, DisplayConfirmed, EnterDate,DomainId,LanguageId,TextComment);
        }

        private Boolean Update(Guid blogCommentId, Guid blogId, String userName, String email, String webSite, Byte privateComment, Byte displayConfirmed, DateTime enterDate, Int32 domainId, Int32 languageId, String textComment)
        {
            BlogCommentDetails blogComment = new BlogCommentDetails(blogCommentId, blogId, userName, email, webSite, privateComment, displayConfirmed, enterDate,domainId,languageId,textComment);
            Boolean ret = SiteProvider.Blog.UpdateBlogComment(blogComment);
            if (Settings.EnableCaching & ret)
                InvalidateCache();
            return ret;
        }




        /// <summary>
        /// تبدیل داده های لایه دیتا به داده های لایه تجاری 
        /// </summary>
        /// <param name="records">رکوردهای ورودی حاوی داده های لایه دیتا</param>
        /// <returns></returns>
        private static List<BlogComment> GetBlogCommentCollectionFromOrderDal(List<BlogCommentDetails> records)
        {
            List<BlogComment> items = new List<BlogComment>();
            foreach (BlogCommentDetails item in records)
                items.Add(GetBlogCommentFromOrderDal(item));
            return items;
        }


        /// <summary>
        /// تبدیل داده لایه دیتا به داده لایه تجاری
        /// </summary>
        /// <param name="record">رکورد ورودی حاوی داده لایه دیتا</param>
        /// <returns></returns>
        private static BlogComment GetBlogCommentFromOrderDal(BlogCommentDetails record)
        {
            if (record != null)
                return new BlogComment(record.BlogCommentId , record.BlogId,record.UserName,record.Email,record.WebSite,record.PrivateComment,record.DisplayConfirmed,record.EnterDate,record.DomainId,record.LanguageId,record.TextComment);
            return null;
        }
        #endregion
    }
}
