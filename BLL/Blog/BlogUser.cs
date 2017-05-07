using System;
using System.Collections.Generic;
using System.Linq;
using Pine.Dal;
using Pine.Dal.Blog;

namespace Pine.Bll.Blog
{
    /// <summary>
    /// کلاسی برای نگهداری جزئیات کاربران بلاگ
    /// </summary>
    public class BlogUser : BaseBlog
    {

        #region Constructors (2)

        /// <summary>
        /// سازنده اصلی کلاس جزئیات کاربران بلاگ
        /// </summary>
        public BlogUser(Guid userGuid, String userName, Int32 posts, Boolean isActive, DateTime enterDate, Int32 domainId, Int32 languageId)
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
        /// سازنده اصلی کلاس جزئیات  کاربران بلاگ
        /// </summary>
        public BlogUser()
        {
            CacheDuration = Settings.CacheDuration;
            MasterCacheKey = "Blog";

        }

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

        #region Methods(6)

        public List<BlogUser> GetBlogUser()
        {
            List<BlogUser> item;

            String key = "BlogUser" ;

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as List<BlogUser>;
                if (item == null)
                {
                    List<BlogUserDetails> rerecordSet = SiteProvider.Blog.GetBlogUser();
                    item = GetBlogUserCollectionFromOrderDal(rerecordSet);
                    AddCacheItem(key, item);
                }
            }
            else
            {
                List<BlogUserDetails> rerecordSet = SiteProvider.Blog.GetBlogUser();
                item = GetBlogUserCollectionFromOrderDal(rerecordSet);
            }
            return item;
        }


        public BlogUser GetBlogUserByUserGuid(Guid userGuid)
        {
            BlogUser item;

            String key = "BlogUser_UserGuid_" + userGuid;

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as BlogUser;
                if (item == null)
                {
                    BlogUserDetails rerecordSet = SiteProvider.Blog.GetBlogUserByUserGuid(userGuid);
                    item = GetBlogUserFromOrderDal(rerecordSet);
                    AddCacheItem(key, item);
                }
            }
            else
            {
                BlogUserDetails rerecordSet = SiteProvider.Blog.GetBlogUserByUserGuid(userGuid);
                item = GetBlogUserFromOrderDal(rerecordSet);
            }
            return item;
        }

        public BlogUser GetBlogUserByUserGuidIsActive(Guid userGuid)
        {
            BlogUser item;

            String key = "BlogUser_UserGuid_" + userGuid;

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as BlogUser;
                if (item == null)
                {
                    BlogUserDetails rerecordSet = SiteProvider.Blog.GetBlogUserByUserGuidIsActive(userGuid);
                    item = GetBlogUserFromOrderDal(rerecordSet);
                    AddCacheItem(key, item);
                }
            }
            else
            {
                BlogUserDetails rerecordSet = SiteProvider.Blog.GetBlogUserByUserGuidIsActive(userGuid);
                item = GetBlogUserFromOrderDal(rerecordSet);
            }
            return item;
        }

        public Int32 Insert()
        {   
            return Insert(UserGuid, UserName, Posts, IsActive, EnterDate,DomainId,LanguageId);
        }

        private Int32 Insert(Guid userGuid, String userName, Int32 posts, Boolean isActive, DateTime enterDate, Int32 domainId, Int32 languageId)
        {
            BlogUserDetails blogUser = new BlogUserDetails(userGuid, userName, posts, isActive, enterDate, domainId, languageId);
            Int32 ret = SiteProvider.Blog.InsertBlogUser(blogUser);
            if (Settings.EnableCaching & ret > 0)
                InvalidateCache();
            return ret;
        }

        public bool Update()
        {
            return Update(UserGuid, UserName, Posts, IsActive, EnterDate, DomainId, LanguageId);
        }

        private Boolean Update(Guid userGuid, String userName, Int32 posts, Boolean isActive, DateTime enterDate, Int32 domainId, Int32 languageId)
        {
            BlogUserDetails blogUser = new BlogUserDetails(userGuid, userName, posts, isActive,enterDate,domainId,languageId );
            Boolean ret = SiteProvider.Blog.UpdateBlogUser(blogUser);
            if (Settings.EnableCaching & ret)
                InvalidateCache();
            return ret;
        }


        /// <summary>
        /// تبدیل داده های لایه دیتا به داده های لایه تجاری 
        /// </summary>
        /// <param name="records">رکوردهای ورودی حاوی داده های لایه دیتا</param>
        /// <returns></returns>
        private static List<BlogUser> GetBlogUserCollectionFromOrderDal(List<BlogUserDetails> records)
        {
            List<BlogUser> items = new List<BlogUser>();
            foreach (BlogUserDetails item in records)
                items.Add(GetBlogUserFromOrderDal(item));
            return items;
        }

        /// <summary>
        /// تبدیل داده لایه دیتا به داده لایه تجاری
        /// </summary>
        /// <param name="record">رکورد ورودی حاوی داده لایه دیتا</param>
        /// <returns></returns>
        private static BlogUser GetBlogUserFromOrderDal(BlogUserDetails record)
        {
            if (record != null)
                return new BlogUser(record.UserGuid, record.UserName ,record.Posts ,record.IsActive,record.EnterDate,record.DomainId,record.LanguageId); 
            return null;
        }

        #endregion
    }
}
