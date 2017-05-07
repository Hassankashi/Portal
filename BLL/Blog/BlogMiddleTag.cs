using System;
using System.Collections.Generic;
using System.Linq;
using Pine.Dal;
using Pine.Dal.Blog;

namespace Pine.Bll.Blog
{
    /// <summary>
    /// کلاسی برای نگهداری جزئیات جدول میانی بلاگ و برچسب
    /// </summary>
    public class BlogMiddleTag : BaseBlog
    {

        #region Constructors (2)

        /// <summary>
        /// سازنده اصلی کلاس جزئیات جدول میانی بلاگ و برچسب
        /// </summary>
        public BlogMiddleTag(Guid blogId, Guid blogTagId)
        {
            BlogId = blogId;
            BlogTagId = blogTagId;
        }

        /// <summary>
        /// سازنده اصلی کلاس جزئیات گروه بلاگ
        /// </summary>
        public BlogMiddleTag()
        {
            CacheDuration = Settings.CacheDuration;
            MasterCacheKey = "Blog";

        }

        #endregion Constructors

        #region Properties (4)


        /// <summary>
        /// کد بلاگ
        /// </summary>
        public Guid BlogId { get; set; }

        /// <summary>
        ///  کد برچسب بلاگ
        /// </summary>
        public Guid BlogTagId { get; set; }



        #endregion Properties

        #region Methods(7)

        //public String GetNameMenuGroupById(Int32 id)
        //{
        //    String item;

        //    String key = "Menu_Group_Id_" + id;

        //    if (Settings.EnableCaching)
        //    {
        //        item = GetCacheItem(key) as String;
        //        if (item == null)
        //        {
        //            item = SiteProvider.Menu.GetNameMenuById(id);
        //            AddCacheItem(key, item);
        //        }
        //    }
        //    else
        //    {
        //        item = SiteProvider.Menu.GetNameMenuById(id);
        //    }

        //    return item;
        //}

        public Int32 Insert()
        {
            return Insert(BlogId, BlogTagId);
        }

        private Int32 Insert(Guid blogId, Guid blogTagId)
        {
            BlogMiddleTagDetails blogMiddleTagDetails = new BlogMiddleTagDetails(blogId, blogTagId);
            Int32 ret = SiteProvider.Blog.InsertBlogMiddleTag(blogMiddleTagDetails);
            if (Settings.EnableCaching & ret > 0)
                InvalidateCache();
            return ret;
        }

        //public bool Update()
        //{
        //    return Update(Id, MenuName);
        //}

        //private Boolean Update(Int32 id, String menuName)
        //{
        //    MenuGroupDetails menuGroup = new MenuGroupDetails(id, menuName);
        //    Boolean ret = SiteProvider.Menu.UpdateGroupName(menuGroup);
        //    if (Settings.EnableCaching & ret)
        //        InvalidateCache();
        //    return ret;
        //}


        ///// <summary>
        ///// تبدیل داده لایه دیتا به داده لایه تجاری
        ///// </summary>
        ///// <param name="record">رکورد ورودی حاوی داده لایه دیتا</param>
        ///// <returns></returns>
        //private static MenuGroup GetMenuGroupFromOrderDal(MenuGroupDetails record)
        //{
        //    if (record != null)
        //        return new MenuGroup(record.MenuNameId, record.MenuName);
        //    return null;
        //}

        ///// <summary>
        ///// تبدیل داده های لایه دیتا به داده های لایه تجاری 
        ///// </summary>
        ///// <param name="records">رکوردهای ورودی حاوی داده های لایه دیتا</param>
        ///// <returns></returns>
        //private static List<MenuGroup> GetMenuGroupCollectionFromOrderDal(List<MenuGroupDetails> records)
        //{
        //    List<MenuGroup> items = new List<MenuGroup>();
        //    foreach (MenuGroupDetails item in records)
        //        items.Add(GetMenuGroupFromOrderDal(item));
        //    return items;
        //}

        #endregion
    }
}
