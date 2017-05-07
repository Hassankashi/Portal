using System;
using System.Collections.Generic;
using System.Linq;
using Pine.Dal;
using Pine.Dal.Blog;

namespace Pine.Bll.Blog
{
    /// <summary>
    /// سازنده اصلی کلاس جزئیات رتبه بلاگ
    /// </summary>
    public class BlogRate : BaseBlog
    {

        #region Constructors (2)
  /// <summary>
        /// سازنده اصلی کلاس جزئیات رتبه بلاگ
        /// </summary>
        public BlogRate(Guid blogRateId, Guid blogId, String userNmae, Byte rate, Int32 domainId , Int32 languageId )
        {
            BlogRateId = blogRateId;
            BlogId = blogId;
            UserNmae = userNmae;
            Rate = rate;

            DomainId = domainId;

            LanguageId = languageId;
        }

        /// <summary>
        /// سازنده اصلی کلاس جزئیات رتبه بلاگ
        /// </summary>
        public BlogRate()
        {
            CacheDuration = Settings.CacheDuration;
            MasterCacheKey = "Blog";

        }

        #endregion Constructors

        #region Properties (4)


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

        #region Methods(7)

        public BlogRate GetBlogRateByBlogRateId(Guid blogRateId)
        {
            BlogRate item;

            String key = "BlogRate_BlogRateId_" + blogRateId;

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as BlogRate;
                if (item == null)
                {
                    BlogRateDetails rerecordSet = SiteProvider.Blog.GetBlogRateByBlogRateId(blogRateId);
                    item = GetBlogRateFromOrderDal(rerecordSet);
                    AddCacheItem(key, item);
                }
            }
            else
            {
                BlogRateDetails rerecordSet = SiteProvider.Blog.GetBlogRateByBlogRateId(blogRateId);
                item = GetBlogRateFromOrderDal(rerecordSet);
                AddCacheItem(key, item);
            }

            return item;
        }

        public Int32 Insert()
        {
            return Insert(BlogRateId ,BlogId,UserNmae,Rate,DomainId,LanguageId);
        }

        private Int32 Insert(Guid blogRateId, Guid blogId, String userNmae, Byte rate, Int32 domainId , Int32 languageId )
        {
            BlogRateDetails blogRateDetails = new BlogRateDetails(blogRateId, blogId, userNmae, rate,domainId,languageId);
            Int32 ret = SiteProvider.Blog.InsertBlogRate(blogRateDetails);
            if (Settings.EnableCaching & ret > 0)
                InvalidateCache();
            return ret;
        }

        public bool Update()
        {
            return Update(BlogRateId, BlogId, UserNmae, Rate, DomainId, LanguageId);
        }

        private Boolean Update(Guid blogRateId, Guid blogId, String userNmae, Byte rate,Int32 domainId , Int32 languageId )
        {
            BlogRateDetails blogRateDetails = new BlogRateDetails(blogRateId, blogId, userNmae, rate, domainId, languageId);
            Boolean ret = SiteProvider.Blog.UpdateBlogRate(blogRateDetails);
            if (Settings.EnableCaching & ret)
                InvalidateCache();
            return ret;
        }


        /// <summary>
        /// تبدیل داده های لایه دیتا به داده های لایه تجاری 
        /// </summary>
        /// <param name="records">رکوردهای ورودی حاوی داده های لایه دیتا</param>
        /// <returns></returns>
        private static List<BlogRate> GetBlogRateCollectionFromOrderDal(List<BlogRateDetails> records)
        {
            List<BlogRate> items = new List<BlogRate>();
            foreach (BlogRateDetails item in records)
                items.Add(GetBlogRateFromOrderDal(item));
            return items;
        }


        /// <summary>
        /// تبدیل داده لایه دیتا به داده لایه تجاری
        /// </summary>
        /// <param name="record">رکورد ورودی حاوی داده لایه دیتا</param>
        /// <returns></returns>
        private static BlogRate GetBlogRateFromOrderDal(BlogRateDetails record)
        {
            if (record != null)
                return new BlogRate(record.BlogRateId , record.BlogId,record.UserNmae,record.Rate,record.DomainId,record.LanguageId);
            return null;
        }
        #endregion
    }
}
