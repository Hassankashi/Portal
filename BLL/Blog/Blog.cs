using System;
using System.Collections.Generic;
using System.Linq;
using Pine.Dal;
using Pine.Dal.Blog;

namespace Pine.Bll.Blog
{
    /// <summary>
    /// کلاسی برای نگهداری جزئیات بلاگ
    /// </summary>
    public class Blog : BaseBlog
    {

        #region Constructors (2)

        /// <summary>
        /// سازنده اصلی کلاس جزئیات گروه منو
        /// </summary>
        public Blog(Guid blogId, Int32 groupId, String title, String text, String shortText, DateTime enterDate, Guid author, String authorUserName, Boolean isActive, Int32? commentCount, Int32? viewCount, Byte? rate, DateTime? updateDate, Int32 domainId, Int32 languageId)
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
        /// سازنده اصلی کلاس جزئیات گروه منو
        /// </summary>
        public Blog()
        {
            CacheDuration = Settings.CacheDuration;
            MasterCacheKey = "Blog";

        }

        #endregion Constructors

        #region Properties (12)


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

        #region Methods(6)

        public static Blog GetBlogByBlogId(Guid blogId) 
        {
            SetCache();
            Blog item;

            String key = "Blog_BlogId_" + blogId;

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as Blog;
                if (item == null)
                {
                    BlogDetails rerecordSet = SiteProvider.Blog.GetBlogByBlogId(blogId);
                    item = GetBlogFromOrderDal(rerecordSet);
                    AddCacheItem(key, item);
                }
            }
            else
            {
                BlogDetails rerecordSet = SiteProvider.Blog.GetBlogByBlogId(blogId);
                item = GetBlogFromOrderDal(rerecordSet);
                AddCacheItem(key, item);
            }

            return item;
        }



        public static List<Blog> GetBlogByBlogGroupId(Int32 blogGroupId)
        {
            SetCache();
            List<Blog> item;

            String key = "Blog_BlogGroupId_" + blogGroupId;

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as List<Blog>;
                if (item == null)
                {
                    List<BlogDetails> rerecordSet = SiteProvider.Blog.GetBlogByBlogGoupId(blogGroupId);
                    item = GetBlogCollectionFromOrderDal(rerecordSet);
                    AddCacheItem(key, item);
                }
            }
            else
            {
                List<BlogDetails> rerecordSet = SiteProvider.Blog.GetBlogByBlogGoupId(blogGroupId);
                item = GetBlogCollectionFromOrderDal(rerecordSet);
                AddCacheItem(key, item);
            }

            return item;
        }


        public static List<Blog> GetAllBlogs()
        {
            SetCache();
            List<Blog> item;

            String key = "Blog_Blog_GetAll" ;

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as List<Blog>;
                if (item == null)
                {
                    List<BlogDetails> rerecordSet = SiteProvider.Blog.GetAllBlogs();
                    item = GetBlogCollectionFromOrderDal(rerecordSet);
                    AddCacheItem(key, item);
                }
            }
            else
            {
                List<BlogDetails> rerecordSet = SiteProvider.Blog.GetAllBlogs();
                item = GetBlogCollectionFromOrderDal(rerecordSet);
                AddCacheItem(key, item);
            }

            return item;
        }
        public static IList<Blog> GetAllBlogswithPaging(int page,int pageSize)
        {


            return GetAllBlogs().Paging(page, pageSize);
        
        
        }


        public static List<Blog> GetBlogsByAuthor(Guid author)
        {
            SetCache();
            List<Blog> item;

            String key = "Blog_Blog_GetByAuthor"+author ;

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as List<Blog>;
                if (item == null)
                {
                    List<BlogDetails> rerecordSet = SiteProvider.Blog.GetBlogsByAuthor(author);
                    item = GetBlogCollectionFromOrderDal(rerecordSet);
                    AddCacheItem(key, item);
                }
            }
            else
            {
                List<BlogDetails> rerecordSet = SiteProvider.Blog.GetBlogsByAuthor(author);
                item = GetBlogCollectionFromOrderDal(rerecordSet);
                AddCacheItem(key, item);
            }

            return item;
        }

        public static List<Blog> GetBlogsByTagId(Guid tagId) 
        {
            SetCache();
            List<Blog> item;

            String key = "Blog_Blog_GetBytagId" + tagId;

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as List<Blog>;
                if (item == null)
                {
                    List<BlogDetails> rerecordSet = SiteProvider.Blog.GetBlogsByTagId(tagId);
                    item = GetBlogCollectionFromOrderDal(rerecordSet);
                    AddCacheItem(key, item);
                }
            }
            else
            {
                List<BlogDetails> rerecordSet = SiteProvider.Blog.GetBlogsByTagId(tagId);
                item = GetBlogCollectionFromOrderDal(rerecordSet);
                AddCacheItem(key, item);
            }

            return item;
        }

        public static List<Blog> GetBlogByTitle(String title, Int32 blogGroupId)
        {
            //if (title == null)
            //{
            //    List<Blog> result1 = GetBlogByBlogGroupId(blogGroupId);
            //    return result1;
            //}

           
            
                List<Blog> result = GetBlogByBlogGroupId(blogGroupId);
                List<Blog> result2 = (from r in result where r.Title.Contains(title) select r).ToList();
                return result2;  // List<UserObject> result2 = result.FindAll(j => j.UserName.Contains(userName)).Where(i => i.UserId !=userNameId  && isExixtUserIsd);
            
            //if(!isExixtUserIsd) 
            //{
            //  return  result2.FindAll(j => j.UserId != userNameId);
            //}

        }
        public Int32 Insert()
        {
            return Insert(BlogId, GroupId, Title, Text, ShortText, EnterDate, Author, AuthorUserName, IsActive, CommentCount, ViewCount, Rate, UpdateDate, DomainId, LanguageId);
        }

        private Int32 Insert(Guid blogId, Int32 groupId, String title, String text, String shortText, DateTime enterDate, Guid author, String authorUserName, Boolean isActive, Int32? commentCount, Int32? viewCount, Byte? rate, DateTime? updateDate, Int32 domainId, Int32 languageId)
        {
            BlogDetails blog = new BlogDetails(blogId, groupId, title, text, shortText, enterDate, author, authorUserName, isActive, commentCount, viewCount, rate, updateDate,domainId,languageId);
            Int32 ret = SiteProvider.Blog.InsertBlog(blog);
            if (Settings.EnableCaching & ret > 0)
                InvalidateCache();
            return ret;
        }

        public bool Update()
        {
            return Update(BlogId, GroupId, Title, Text, ShortText, EnterDate, Author, AuthorUserName, IsActive, CommentCount, ViewCount, Rate, UpdateDate,DomainId,LanguageId);
        }

        private Boolean Update(Guid blogId, Int32 groupId, String title, String text, String shortText, DateTime enterDate, Guid author, String authorUserName, Boolean isActive, Int32? commentCount, Int32? viewCount, Byte? rate, DateTime? updateDate, Int32 domainId, Int32 languageId)
        {
            BlogDetails blog = new BlogDetails(blogId, groupId, title, text, shortText, enterDate, author, authorUserName, isActive, commentCount, viewCount, rate, updateDate,domainId,languageId);
            Boolean ret = SiteProvider.Blog.UpdateBlog(blog);
            if (Settings.EnableCaching & ret)
                InvalidateCache();
            return ret;
        }


        /// <summary>
        /// تبدیل داده های لایه دیتا به داده های لایه تجاری 
        /// </summary>
        /// <param name="records">رکوردهای ورودی حاوی داده های لایه دیتا</param>
        /// <returns></returns>
        private static List<Blog> GetBlogCollectionFromOrderDal(List<BlogDetails> records)
        {
            List<Blog> items = new List<Blog>();
            foreach (BlogDetails item in records)
                items.Add(GetBlogFromOrderDal(item));
            return items;
        }

        /// <summary>
        /// تبدیل داده لایه دیتا به داده لایه تجاری
        /// </summary>
        /// <param name="record">رکورد ورودی حاوی داده لایه دیتا</param>
        /// <returns></returns>
        private static Blog GetBlogFromOrderDal(BlogDetails record)
        {
            if (record != null)
                return new Blog(record.BlogId, record.GroupId,record.Title,record.Text,record.ShortText,record.EnterDate,record.Author,record.AuthorUserName,record.IsActive,record.CommentCount,record.ViewCount,record.Rate,record.UpdateDate,record.DomainId,record.LanguageId);
            return null;
        }

        #endregion
    }
}
