using System;
using System.Linq;
using Pine.Dal;
using Pine.Dal.Blog;
using System.Collections.Generic;

namespace Pine.Bll.Blog
{
    /// <summary>
    /// کلاسی برای نگهداری گروه برچسب بلاگ
    /// </summary>
    public class BlogTagGroup : BaseBlog
    {

        #region Constructors (2)
        /// <summary>
        /// سازنده اصلی کلاس جزئیات گروه برچسب
        /// </summary>
        public BlogTagGroup(Int32 blogTagGroupId, String tagGroupName, Int32 domainId, Int32 languageId)
        {
            BlogTagGroupId = blogTagGroupId;
            TagGroupName = tagGroupName;

            DomainId = domainId;

            LanguageId = languageId;
        }

        /// <summary>
        /// سازنده پیش فرض کلاس جزئیات گروه برچسب بلاگ
        /// </summary>
        public BlogTagGroup()
        {
            CacheDuration = Settings.CacheDuration;
            MasterCacheKey = "Blog";

        }

        #endregion Constructors

        #region Properties (4)

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

        #region Methods(7)

        public BlogTagGroup GetBlogTagGroupByBlogTagGroupId(Int32 blogTagGroupId)
        {
            BlogTagGroup item;

            String key = "BlogTagGroup_BlogTagGroupId_" + BlogTagGroupId;

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as BlogTagGroup;
                if (item == null)
                {
                    BlogTagGroupDetails rerecordSet = SiteProvider.Blog.GetBlogTagGroupByBlogTagGroupId(blogTagGroupId);
                    item = GetBlogTagGroupFromOrderDal(rerecordSet);
                    AddCacheItem(key, item);
                }
            }
            else
            {
                BlogTagGroupDetails rerecordSet = SiteProvider.Blog.GetBlogTagGroupByBlogTagGroupId(blogTagGroupId);
                item = GetBlogTagGroupFromOrderDal(rerecordSet);
                AddCacheItem(key, item);
            }

            return item;
        }

        public List<BlogTagGroup> GetBlogTagGroup()
        {
            List<BlogTagGroup> item;

            String key = "BlogBlogTagGroup" ;

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as List<BlogTagGroup>;
                if (item == null)
                {
                    List<BlogTagGroupDetails> rerecordSet = SiteProvider.Blog.GetBlogTagGroup();
                    item = GetBlogTagGroupCollectionFromOrderDal(rerecordSet);
                    AddCacheItem(key, item);
                }
            }
            else
            {
                List<BlogTagGroupDetails> rerecordSet = SiteProvider.Blog.GetBlogTagGroup();
                item = GetBlogTagGroupCollectionFromOrderDal(rerecordSet);
                AddCacheItem(key, item);
            }

            return item;
        }

        public Int32 Insert()
        {
            return Insert(BlogTagGroupId, TagGroupName, DomainId, LanguageId);
        }

        private Int32 Insert(Int32 blogTagGroupId, String tagGroupName, Int32 domainId, Int32 languageId)
        {
            BlogTagGroupDetails blogTagGroupDetails = new BlogTagGroupDetails(blogTagGroupId, tagGroupName, domainId, languageId);
            Int32 ret = SiteProvider.Blog.InsertBlogTagGroup(blogTagGroupDetails);
            if (Settings.EnableCaching & ret > 0)
                InvalidateCache();
            return ret;
        }

        public bool Update()
        {
            return Update(BlogTagGroupId, TagGroupName,DomainId,LanguageId);
        }

        private Boolean Update(Int32 blogTagGroupId, String tagGroupName, Int32 domainId, Int32 languageId)
        {
            BlogTagGroupDetails blogTagGroupDetails = new BlogTagGroupDetails(blogTagGroupId, tagGroupName,domainId,languageId);
            Boolean ret = SiteProvider.Blog.UpdateBlogTagGroup(blogTagGroupDetails);
            if (Settings.EnableCaching & ret)
                InvalidateCache();
            return ret;
        }


        /// <summary>
        /// تبدیل داده های لایه دیتا به داده های لایه تجاری 
        /// </summary>
        /// <param name="records">رکوردهای ورودی حاوی داده های لایه دیتا</param>
        /// <returns></returns>
        private static List<BlogTagGroup> GetBlogTagGroupCollectionFromOrderDal(List<BlogTagGroupDetails> records)
        {
            List<BlogTagGroup> items = new List<BlogTagGroup>();
            foreach (BlogTagGroupDetails item in records)
                items.Add(GetBlogTagGroupFromOrderDal(item));
            return items;
        }


        /// <summary>
        /// تبدیل داده لایه دیتا به داده لایه تجاری
        /// </summary>
        /// <param name="record">رکورد ورودی حاوی داده لایه دیتا</param>
        /// <returns></returns>
        private static BlogTagGroup GetBlogTagGroupFromOrderDal(BlogTagGroupDetails record)
        {
            if (record != null)
                return new BlogTagGroup(record.BlogTagGroupId , record.TagGroupName,record.DomainId,record.LanguageId);
            return null;
        }

        #endregion
    }
}
