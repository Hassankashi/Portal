using System;
using System.Linq;
using System.Collections.Generic;
using Pine.Dal;
using Pine.Dal.Core;

namespace Pine.Bll.Core
{
    /// <summary>
    /// کلاسی برای نگهداری طرح مسترپیج
    /// </summary>
    public class CoreUserControlPaths_PageContents : BaseCore
    {
        #region Constructors (2)

        /// <summary>
        /// سازنده اصلی کلاس جزئیات تنظیمات طرح
        /// </summary>

        public CoreUserControlPaths_PageContents(String path, Int32 userControlPathId, Int32? coreParameterId)
        {
            Path = path;
            UserControlPathId = userControlPathId;
            CoreParameterId = coreParameterId;
        }

        /// <summary>
        /// سازنده پیش فرض کلاس جزئیات تنظیمات طرح
        /// </summary>
        public CoreUserControlPaths_PageContents()
        {
            CacheDuration = Settings.CacheDuration;
            MasterCacheKey = "Core";
        }

        #endregion Constructors

        #region Properties (3)


        public String Path { get; set; }


        public Int32 UserControlPathId { get; set; }


        public Int32? CoreParameterId { get; set; }

        #endregion Properties

        #region Methods(3)

        public List<CoreUserControlPaths_PageContents> GetCoreUserControlPaths_PageContentsByPageContentId(Int32 PageContentId)
        {
            List<CoreUserControlPaths_PageContents> item;

            String key = "GetCoreUserControlPaths_PageContents_PageContentId" + PageContentId;

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as List<CoreUserControlPaths_PageContents>;
                if (item == null)
                {
                    List<CoreUserControlPaths_PageContentsDetails> recordSet = SiteProvider.Core.GetCoreUserControlPaths_PageContentsDetailsByPageContentId(PageContentId);
                    item = GetCoreUserControlPaths_PageContentsCollectionFromOrderDal(recordSet);
                    AddCacheItem(key, item);
                }
            }
            else
            {

                List<CoreUserControlPaths_PageContentsDetails> recordSet = SiteProvider.Core.GetCoreUserControlPaths_PageContentsDetailsByPageContentId(PageContentId);
                item = GetCoreUserControlPaths_PageContentsCollectionFromOrderDal(recordSet);
            }
            return item;
        }

       

        //public Int32 Insert()
        //{
        //    return Insert(Id, MenuNameId, ParentMenuId,Text, NavigateUrl, ImageUrl, Priority, UserControl);
        //}

        //private Int32 Insert(Int32 id, Int32  menuNameId, Int32? parentMenuId, String text, String navigateUrl, String imageUrl, Int16 priority, String userControl)
        //{
        //    MenuDetails menu = new MenuDetails(id, menuNameId, parentMenuId, text, navigateUrl, imageUrl, priority, userControl);
        //    Int32 ret = SiteProvider.Menu.InsertMenu(menu);
        //    if (Settings.EnableCaching & ret > 0)
        //        InvalidateCache();
        //    return ret;
        //}

        //public bool UpdateMenuNavigateUrl()
        //{
        //    return UpdateMenuNavigateUrl(Id, MenuNameId, ParentMenuId, Text, NavigateUrl, ImageUrl, Priority, UserControl);
        //}

        //private Boolean UpdateMenuNavigateUrl(Int32 id, Int32 menuNameId, Int32? parentMenuId, String text, String navigateUrl, String imageUrl, Int16 priority, String userControl)
        //{
        //    MenuDetails menu = new MenuDetails(id, menuNameId, parentMenuId, text, navigateUrl, imageUrl, priority, userControl);
        //    Boolean ret = SiteProvider.Menu.UpdateMenuNavigateUrl(menu.MenuId,menu.NavigateUrl,menu.UserControl);
        //    if (Settings.EnableCaching & ret)
        //        InvalidateCache();
        //    return ret;
        //}

    

       

        /// <summary>
        /// تبدیل داده های لایه دیتا به داده های لایه تجاری 
        /// </summary>
        /// <param name="records">رکوردهای ورودی حاوی داده های لایه دیتا</param>
        /// <returns></returns>
        private static List<CoreUserControlPaths_PageContents> GetCoreUserControlPaths_PageContentsCollectionFromOrderDal(List<CoreUserControlPaths_PageContentsDetails> records)
        {
            List<CoreUserControlPaths_PageContents> items = new List<CoreUserControlPaths_PageContents>();
            foreach (CoreUserControlPaths_PageContentsDetails item in records)
                items.Add(GetCoreUserControlPaths_PageContentsFromOrderDal(item));
            return items;
        }

        /// <summary>
        /// تبدیل داده لایه دیتا به داده لایه تجاری
        /// </summary>
        /// <param name="record">رکورد ورودی حاوی داده لایه دیتا</param>
        /// <returns></returns>
        private static CoreUserControlPaths_PageContents GetCoreUserControlPaths_PageContentsFromOrderDal(CoreUserControlPaths_PageContentsDetails record)
        {
            if (record != null)
                return new CoreUserControlPaths_PageContents(record.Path , record.UserControlPathId, record.CoreParameterId);
            return null;
        }

        #endregion
    }
}
