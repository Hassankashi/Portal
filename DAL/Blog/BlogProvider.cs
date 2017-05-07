using System;
using System.Collections.Generic;
using System.Data;

namespace Pine.Dal.Blog
{
    public abstract class BlogProvider : DataAccess
    {
        #region Fields (1)

        static private BlogProvider _instance;

        #endregion Fields 

        #region Constructors (1)

        /// <summary>
        /// سازنده اصلی کلاس
        /// </summary>
        protected BlogProvider()
        {
            ConnectionString = Globals.Settings.Blog.ConnectionString;
            EnableCaching = Globals.Settings.Blog.EnableCaching;
            CacheDuration = Globals.Settings.Blog.CacheDuration;
        }

        #endregion Constructors

        #region Properties (1)

        /// <summary>
        /// Returns an instance of the provider type specified in the config file
        /// </summary>
        static public BlogProvider Instance
        {
            get
            {
                return _instance ?? (_instance = (BlogProvider)Activator.CreateInstance(
                    Type.GetType(Globals.Settings.Blog.ProviderType)));
            }
        }

        #endregion Properties

        #region Blog (4)
        /// <summary>
        /// گرفتن بلاگ با کد
        /// </summary>
        public abstract BlogDetails  GetBlogByBlogId(Guid blogId);

        /// <summary>
        ///  گرفتن بلاگ با کد گروه بلاگ
        /// </summary>
        public abstract List<BlogDetails> GetBlogByBlogGoupId(Int32 blogGroupId);

        /// <summary>
        /// وارد کردن نام بلاگ
        /// </summary>
        public abstract Int32 InsertBlog(BlogDetails blog);

        /// <summary>
        /// ویرایش بلاگ
        /// </summary>
        public abstract Boolean UpdateBlog(BlogDetails blog);


        public abstract List<BlogDetails> GetAllBlogs();

        public abstract List<BlogDetails> GetBlogsByAuthor(Guid author);

        public abstract List<BlogDetails> GetBlogsByTagId(Guid tagId);


        #endregion

        #region BlogComment (4)
        /// <summary>
        /// گرفتن توضیحات بلاگ با کد
        /// </summary>
        public abstract BlogCommentDetails GetBlogCommentByBlogCommentId(Guid blogCommentId);

        /// <summary>
        /// وارد کردن توضیحات
        /// /// </summary>
        public abstract Int32 InsertBlogComment(BlogCommentDetails blogComment);

        /// <summary>
        /// ویرایش توضیحات
        /// </summary>
        public abstract Boolean UpdateBlogComment(BlogCommentDetails blogComment);


        public abstract List<BlogCommentDetails> GetBlogCommentByBlogId(Guid blogId);

        

        #endregion

        #region BlogGroup (3)

        /// <summary>
        /// گرفتن گروه بلاگ 
        /// </summary>
        public abstract List<BlogGroupDetails> GetBlogGroup();

        /// <summary>
        /// گرفتن گروه بلاگ با کد
        /// </summary>
        public abstract BlogGroupDetails GetBlogGroupByBlogGroupId(Int32 blogGroupId);

        /// <summary>
        /// وارد کردن گروه بلاگ
        /// /// </summary>
        public abstract Int32 InsertBlogGroup(BlogGroupDetails blogGroup);

        /// <summary>
        /// ویرایش گروه بلاگ
        /// </summary>
        public abstract Boolean UpdateBlogGroup(BlogGroupDetails blogGroup);

        #endregion

        #region BlogTag (3)
        /// <summary>
        /// گرفتن برچسب بلاگ با کد
        /// </summary>
        public abstract BlogTagDetails GetBlogTagByBlogTagId(Guid blogTagId);

        public abstract List<BlogTagDetails> GetAllTags();

        /// <summary>
        /// گرفتن برچسب بلاگ با گروه
        /// </summary>
        public abstract List<BlogTagDetails> GetBlogTagByBlogTagGroupId(Int32 blogTagGroupId);

        /// <summary>
        /// وارد برچسب بلاگ
        /// /// </summary>
        public abstract Int32 InsertBlogTag(BlogTagDetails blogTag);

        /// <summary>
        /// ویرایش برچسب بلاگ
        /// </summary>
        public abstract Boolean UpdateBlogTag(BlogTagDetails blogTag);

        public abstract List<BlogTagDetails> GetTagByBlogId(Guid blogId);

        #endregion

        #region BlogTagGroup (3)
        /// <summary>
        /// گرفتن گروه برچسب بلاگ با کد
        /// </summary>
        public abstract BlogTagGroupDetails GetBlogTagGroupByBlogTagGroupId(Int32 blogTagGroupId);


        /// <summary>
        /// گرفتن گروه برچسب بلاگ
        /// </summary>
        public abstract List<BlogTagGroupDetails> GetBlogTagGroup();

        /// <summary>
        /// وارد کردن گروه بلاگ
        /// /// </summary>
        public abstract Int32 InsertBlogTagGroup(BlogTagGroupDetails blogTagGroup);

        /// <summary>
        /// ویرایش گروه بلاگ
        /// </summary>
        public abstract Boolean UpdateBlogTagGroup(BlogTagGroupDetails blogTagGroup);

        #endregion

        #region BlogRate (3)
        /// <summary>
        /// گرفتن رتبه بلاگ با کد
        /// </summary>
        public abstract BlogRateDetails GetBlogRateByBlogRateId(Guid blogRateId);

        /// <summary>
        /// وارد کردن رتبه بلاگ
        /// /// </summary>
        public abstract Int32 InsertBlogRate(BlogRateDetails blogRate);

        /// <summary>
        /// ویرایش رتبه بلاگ
        /// </summary>
        public abstract Boolean UpdateBlogRate(BlogRateDetails blogRate);

        #endregion

        #region BlogMiddleTag (1)

        /// <summary>
        /// وارد کردن جدول میانی بلاگ و تک بلاگ
        /// /// </summary>
        public abstract Int32 InsertBlogMiddleTag(BlogMiddleTagDetails blogMiddleTag);

        #endregion

        #region BlogUser

        /// <summary>
        /// گرفتن کاربران بلاگ
        /// /// </summary>
        public abstract List<BlogUserDetails> GetBlogUser();

        /// <summary>
        /// گرفتن کاربر بلاگ با کد کاربر
        /// /// </summary>
        public abstract BlogUserDetails GetBlogUserByUserGuid(Guid userGuid);

        /// <summary>
        /// گرفتن کاربر بلاگ با کد کاربر
        /// /// </summary>
        public abstract BlogUserDetails GetBlogUserByUserGuidIsActive(Guid userGuid);

        /// <summary>
        /// وارد کردن کاربر برای بلاگ
        /// /// </summary>
        public abstract Int32 InsertBlogUser(BlogUserDetails blogUser);

        /// <summary>
        /// ویرایش کاربران بلاگ
        /// </summary>
        public abstract Boolean UpdateBlogUser(BlogUserDetails blogUser);

        #endregion

        #region Virtual Protected Methods (2)

        protected virtual List<BlogDetails> GetBlogCollectionFromDataReader(IDataReader reader)
        {
            List<BlogDetails> items = new List<BlogDetails>();
            while (reader.Read())
                items.Add(GetBlogFromDataReader(reader));
            return items;
        }

        protected virtual BlogDetails GetBlogFromDataReader(IDataReader reader)
        {
            return new BlogDetails
                (
                    (Guid)reader["BlogId"],
                    (Int32)reader["GroupId"],
                    (String)reader["title"],
                    (String)reader["Text"],
                    (String)reader["ShortText"],
                    (DateTime)reader["EnterDate"],
                    (Guid)reader["Author"],
                    reader["AuthorUserName"].ToString(),
                    (Boolean)reader["IsActive"],
                    reader["CommentCount"] as Int32?,
                    reader["ViewCount"] as Int32?,
                    reader["Rate"] as Byte?,
                    reader["ViewCount"] as DateTime?,
                     (Int32)reader["DomainId"],
                    (Int32)reader["LanguageId"]
                );
        }

     

        protected virtual List<BlogCommentDetails > GetBlogCommentCollectionFromDataReader(IDataReader reader)
        {
            List<BlogCommentDetails> items = new List<BlogCommentDetails>();
            while (reader.Read())
                items.Add(GetBlogCommentFromDataReader(reader));
            return items;
        }

        protected virtual BlogCommentDetails GetBlogCommentFromDataReader(IDataReader reader)
        {
            return new BlogCommentDetails
                (
                    (Guid)reader["BlogCommentId"],
                    (Guid)reader["BlogId"],
                    (String)reader["UserName"],
                    (String)reader["Email"],
                    (String)reader["WebSite"],
                    (Byte)reader["PrivateComment"],
                    (Byte)reader["DisplayConfirmed"],
                    (DateTime)reader["EnterDate"],
                    (Int32)reader["DomainId"],
                    (Int32)reader["LanguageId"],
                     (String)reader["TextComment"]
                );
        }

        protected virtual List<BlogGroupDetails> GetBlogGroupCollectionFromDataReader(IDataReader reader)
        {
            List<BlogGroupDetails> items = new List<BlogGroupDetails>();
            while (reader.Read())
                items.Add(GetBlogGroupFromDataReader(reader));
            return items;
        }

        protected virtual BlogGroupDetails GetBlogGroupFromDataReader(IDataReader reader)
        {
            return new BlogGroupDetails
                (
                    (Int32)reader["BlogGroupId"],
                    (String)reader["GroupName"],
                    (Boolean)reader["IsShow"],
                      (Int32)reader["DomainId"],
                    (Int32)reader["LanguageId"]
                );
        }

        protected virtual List<BlogTagDetails> GetBlogTagCollectionFromDataReader(IDataReader reader)
        {
            List<BlogTagDetails> items = new List<BlogTagDetails>();
            while (reader.Read())
                items.Add(GetBlogTagFromDataReader(reader));
            return items;
        }

        protected virtual BlogTagDetails GetBlogTagFromDataReader(IDataReader reader)
        {
            return new BlogTagDetails
                (
                    (Guid)reader["BlogTagId"],
                    (Int32)reader["BlogTagGroupId"],
                    (String)reader["TagName"],
                      (Int32)reader["DomainId"],
                    (Int32)reader["LanguageId"]
                );
        }

        protected virtual List<BlogTagGroupDetails> GetBlogTagGroupCollectionFromDataReader(IDataReader reader)
        {
            List<BlogTagGroupDetails> items = new List<BlogTagGroupDetails>();
            while (reader.Read())
                items.Add(GetBlogTagGroupFromDataReader(reader));
            return items;
        }

        protected virtual BlogTagGroupDetails GetBlogTagGroupFromDataReader(IDataReader reader)
        {
            return new BlogTagGroupDetails
                (
                    (Int32)reader["BlogTagGroupId"],
                    (String)reader["TagGroupName"],
                       (Int32)reader["DomainId"],
                    (Int32)reader["LanguageId"]
                );
        }

        protected virtual List<BlogRateDetails> GetBlogRateCollectionFromDataReader(IDataReader reader)
        {
            List<BlogRateDetails> items = new List<BlogRateDetails>();
            while (reader.Read())
                items.Add(GetBlogRateFromDataReader(reader));
            return items;
        }

        protected virtual BlogRateDetails GetBlogRateFromDataReader(IDataReader reader)
        {
            return new BlogRateDetails
                (
                    (Guid)reader["BlogRateId"],
                    (Guid)reader["BlogId"],
                    (String)reader["UserNmae"],
                    (Byte)reader["Rate"],
                       (Int32)reader["DomainId"],
                    (Int32)reader["LanguageId"]
                );
        }

        protected virtual List<BlogUserDetails> GetBlogUserCollectionFromDataReader(IDataReader reader)
        {
            List<BlogUserDetails> items = new List<BlogUserDetails>();
            while (reader.Read())
                items.Add(GetBlogUserFromDataReader(reader));
            return items;
        }

        protected virtual BlogUserDetails GetBlogUserFromDataReader(IDataReader reader)
        {
            return new BlogUserDetails
                (
                    (Guid)reader["UserGuid"],
                    (String)reader["UserName"],
                    (Int32)reader["Posts"],
                    (Boolean)reader["IsActive"],
                    (DateTime)reader["EnterDate"],
                      (Int32)reader["DomainId"],
                    (Int32)reader["LanguageId"]
                );
        }

        #endregion

    }
}
