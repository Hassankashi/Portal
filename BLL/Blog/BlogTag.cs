using System;
using System.Collections.Generic;
using System.Linq;
using Pine.Dal;
using Pine.Dal.Blog;

namespace Pine.Bll.Blog
{
    /// <summary>
    /// کلاسی برای نگهداری برچسب بلاگ
    /// </summary>
    public class BlogTag : BaseBlog
    {

        #region Constructors (2)
        /// <summary>
        /// سازنده اصلی کلاس جزئیات برچسب
        /// </summary>
        public BlogTag(Guid blogTagId, Int32 blogTagGroupId, String tagName, Int32 domainId, Int32 languageId)
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
        public BlogTag()
        {
            CacheDuration = Settings.CacheDuration;
            MasterCacheKey = "Blog";

        }

        #endregion Constructors

        #region Properties (4)

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

        #region Methods(8)

        public BlogTag GetBlogTagByBlogTagId(Guid blogTagId)
        {
            BlogTag item;

            String key = "BlogTag_BlogTagId_" + blogTagId;

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as BlogTag;
                if (item == null)
                {
                    BlogTagDetails rerecordSet = SiteProvider.Blog.GetBlogTagByBlogTagId (blogTagId);
                    item = GetBlogTagFromOrderDal(rerecordSet);
                    AddCacheItem(key, item);
                }
            }
            else
            {
                BlogTagDetails rerecordSet = SiteProvider.Blog.GetBlogTagByBlogTagId(blogTagId);
                item = GetBlogTagFromOrderDal(rerecordSet);
                AddCacheItem(key, item);
            }

            return item;
        }


        public List<BlogTag> GetTagByBlogId( Guid blogId)
        {
            List<BlogTag> item;

            String key = "BlogTag_GetTag_blogId"+  blogId;

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as List<BlogTag>;
                if (item == null)
                {
                    List<BlogTagDetails> rerecordSet = SiteProvider.Blog.GetTagByBlogId(blogId);
                    item = GetBlogTagCollectionFromOrderDal(rerecordSet);
                    AddCacheItem(key, item);
                }
            }
            else
            {
                List<BlogTagDetails> rerecordSet = SiteProvider.Blog.GetTagByBlogId(blogId);
                item = GetBlogTagCollectionFromOrderDal(rerecordSet);
                AddCacheItem(key, item);
            }

            return item;
        }
        public List<BlogTag> GetAllTags()
        {
            List<BlogTag> item;

            String key = "BlogTag_GetAll";

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as List<BlogTag>;
                if (item == null)
                {
                    List<BlogTagDetails> rerecordSet = SiteProvider.Blog.GetAllTags();
                    item = GetBlogTagCollectionFromOrderDal(rerecordSet);
                    AddCacheItem(key, item);
                }
            }
            else
            {
                List<BlogTagDetails> rerecordSet = SiteProvider.Blog.GetAllTags();
                item = GetBlogTagCollectionFromOrderDal(rerecordSet);
                AddCacheItem(key, item);
            }

            return item;
        }
        public List<BlogTag> GetBlogTagByBlogTagGroupId(Int32 blogTagGroupId)
        {
            List<BlogTag> item;

            String key = "BlogTag_BlogTagGroupId_" + blogTagGroupId;

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as List<BlogTag>;
                if (item == null)
                {
                    List<BlogTagDetails> rerecordSet = SiteProvider.Blog.GetBlogTagByBlogTagGroupId(blogTagGroupId);
                    item = GetBlogTagCollectionFromOrderDal(rerecordSet);
                    AddCacheItem(key, item);
                }
            }
            else
            {
                List<BlogTagDetails> rerecordSet = SiteProvider.Blog.GetBlogTagByBlogTagGroupId(blogTagGroupId);
                item = GetBlogTagCollectionFromOrderDal(rerecordSet);
                AddCacheItem(key, item);
            }

            return item;
        }

        public Int32 Insert()
        {
            return Insert(BlogTagId, BlogTagGroupId, TagName, DomainId, LanguageId);
        }

        private Int32 Insert(Guid blogTagId, Int32 blogTagGroupId, String tagName, Int32 domainId, Int32 languageId)
        {
            BlogTagDetails blogTagDetails = new BlogTagDetails(blogTagId, blogTagGroupId, tagName, domainId, languageId);
            Int32 ret = SiteProvider.Blog.InsertBlogTag(blogTagDetails);
            if (Settings.EnableCaching & ret > 0)
                InvalidateCache();
            return ret;
        }

        public bool Update()
        {
            return Update(BlogTagId, BlogTagGroupId, TagName,DomainId,LanguageId);
        }

        private Boolean Update(Guid blogTagId, Int32 blogTagGroupId, String tagName, Int32 domainId, Int32 languageId)
        {
            BlogTagDetails blogTagDetails = new BlogTagDetails(blogTagId, blogTagGroupId, tagName,domainId,languageId);
            Boolean ret = SiteProvider.Blog.UpdateBlogTag(blogTagDetails);
            if (Settings.EnableCaching & ret)
                InvalidateCache();
            return ret;
        }


        /// <summary>
        /// تبدیل داده های لایه دیتا به داده های لایه تجاری 
        /// </summary>
        /// <param name="records">رکوردهای ورودی حاوی داده های لایه دیتا</param>
        /// <returns></returns>
        private static List<BlogTag> GetBlogTagCollectionFromOrderDal(List<BlogTagDetails> records)
        {
            List<BlogTag> items = new List<BlogTag>();
            foreach (BlogTagDetails item in records)
                items.Add(GetBlogTagFromOrderDal(item));
            return items;
        }

        /// <summary>
        /// تبدیل داده لایه دیتا به داده لایه تجاری
        /// </summary>
        /// <param name="record">رکورد ورودی حاوی داده لایه دیتا</param>
        /// <returns></returns>
        private static BlogTag GetBlogTagFromOrderDal(BlogTagDetails record)
        {
            if (record != null)
                return new BlogTag(record.BlogTagId , record.BlogTagGroupId,record.TagName,record.DomainId,record.LanguageId);
            return null;
        }

        #endregion
    }
}
