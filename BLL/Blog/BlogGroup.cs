using System;
using System.Collections.Generic;
using System.Linq;
using Pine.Dal;
using Pine.Dal.Blog;

namespace Pine.Bll.Blog
{
    /// <summary>
    /// کلاسی برای نگهداری جزئیات گروه بلاگ
    /// </summary>
    public class BlogGroup : BaseBlog
    {

        #region Constructors (2)

        /// <summary>
        /// سازنده اصلی کلاس جزئیات گروه بلاگ
        /// </summary>
        public BlogGroup(Int32 blogGroupId, String groupName, Boolean isShow, Int32 domainId, Int32 languageId)
        {
            BlogGroupId = blogGroupId;
            GroupName = groupName;
            IsShow = isShow;

            DomainId = domainId;

            LanguageId = languageId;
        }

        /// <summary>
        /// سازنده اصلی کلاس جزئیات گروه بلاگ
        /// </summary>
        public BlogGroup()
        {
            CacheDuration = Settings.CacheDuration;
            MasterCacheKey = "Blog";

        }

        #endregion Constructors

        #region Properties (4)

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

        #region Methods(7)

        public List<BlogGroup> GetBlogGroup()
        {
            List<BlogGroup> item;

            String key = "BlogGroup" ;

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as List<BlogGroup>;
                if (item == null)
                {
                    List<BlogGroupDetails> rerecordSet = SiteProvider.Blog.GetBlogGroup();
                    item = GetBlogGroupCollectionFromOrderDal(rerecordSet);
                    AddCacheItem(key, item);
                }
            }
            else
            {
                List<BlogGroupDetails> rerecordSet = SiteProvider.Blog.GetBlogGroup();
                item = GetBlogGroupCollectionFromOrderDal(rerecordSet);
                AddCacheItem(key, item);
            }

            return item;
        }

        public BlogGroup GetBlogGroupByBlogGroupId(Int32 blogGroupId)
        {
            BlogGroup item;

            String key = "BlogGroup_BlogGroupId_" + blogGroupId;

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as BlogGroup;
                if (item == null)
                {
                    BlogGroupDetails rerecordSet = SiteProvider.Blog.GetBlogGroupByBlogGroupId(blogGroupId);
                    item = GetBlogGroupFromOrderDal(rerecordSet);
                    AddCacheItem(key, item);
                }
            }
            else
            {
                BlogGroupDetails rerecordSet = SiteProvider.Blog.GetBlogGroupByBlogGroupId(blogGroupId);
                item = GetBlogGroupFromOrderDal(rerecordSet);
                AddCacheItem(key, item);
            }

            return item;
        }

        public Int32 Insert()
        {
            return Insert(BlogGroupId, GroupName, IsShow, DomainId, LanguageId);
        }

        private Int32 Insert(Int32 blogGroupId, String groupName, Boolean isShow,Int32 domainId, Int32 languageId)
        {
            BlogGroupDetails blogGroup = new BlogGroupDetails(blogGroupId, groupName, isShow, DomainId, LanguageId);
            Int32 ret = SiteProvider.Blog.InsertBlogGroup(blogGroup);
            if (Settings.EnableCaching & ret > 0)
                InvalidateCache();
            return ret;
        }

        public bool Update()
        {
            return Update(BlogGroupId, GroupName, IsShow,DomainId,LanguageId);
        }

        private Boolean Update(Int32 blogGroupId, String groupName, Boolean isShow,Int32 domainId, Int32 languageId)
        {
            BlogGroupDetails blogGroup = new BlogGroupDetails(blogGroupId, groupName, isShow, DomainId, LanguageId);
            Boolean ret = SiteProvider.Blog.UpdateBlogGroup(blogGroup);
            if (Settings.EnableCaching & ret)
                InvalidateCache();
            return ret;
        }
        

        /// <summary>
        /// تبدیل داده های لایه دیتا به داده های لایه تجاری 
        /// </summary>
        /// <param name="records">رکوردهای ورودی حاوی داده های لایه دیتا</param>
        /// <returns></returns>
        private static List<BlogGroup> GetBlogGroupCollectionFromOrderDal(List<BlogGroupDetails> records)
        {
            List<BlogGroup> items = new List<BlogGroup>();
            foreach (BlogGroupDetails item in records)
                items.Add(GetBlogGroupFromOrderDal(item));
            return items;
        }


        /// <summary>
        /// تبدیل داده لایه دیتا به داده لایه تجاری
        /// </summary>
        /// <param name="record">رکورد ورودی حاوی داده لایه دیتا</param>
        /// <returns></returns>
        private static BlogGroup GetBlogGroupFromOrderDal(BlogGroupDetails record)
        {
            if (record != null)
                return new BlogGroup(record.BlogGroupId, record.GroupName,record.IsShow,record.DomainId,record.LanguageId);
            return null;
        }
        #endregion
    }
}
