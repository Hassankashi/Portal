using System;
using System.Linq;
using System.Collections.Generic;
using Pine.Dal;
using Pine.Dal.Core;

namespace Pine.Bll.Core
{

    public class CoreMasterPageNamesCorePages : BaseCore
    {
        #region Constructors (2)


        public CoreMasterPageNamesCorePages(Int32 masterPageNameId, Int32 pageId, String themeName, String path, String pathSmallImage, String nameImage)
        {
            MasterPageNameId = masterPageNameId;
            PageId = pageId;
            ThemeName = themeName;
            Path = path;
            PathSmallImage = pathSmallImage;
            NameImage = nameImage;
        }


        public CoreMasterPageNamesCorePages()
        {
            CacheDuration = Settings.CacheDuration;
            MasterCacheKey = "Core";
        }

        #endregion Constructors

        #region Properties (3)

        public Int32 MasterPageNameId { get; set; }

        public Int32 PageId { get; set; }


        public String ThemeName { get; set; }


        public String Path { get; set; }

        public String PathSmallImage { get; set; }

        public String NameImage { get; set; }

        #endregion Properties

        #region Methods(3)

        public CoreMasterPageNamesCorePages GetCoreMasterPageNamesCorePagesByIsDefault()
        {
            CoreMasterPageNamesCorePages item;

            String key = "CoreMasterPageNamesCorePages" ;

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as CoreMasterPageNamesCorePages;
                if (item == null)
                {
                    CoreMasterPageNamesCorePagesDetails recordSet = SiteProvider.Core.GetCoreMasterPageNamesCorePagesByIsDefault();
                    item = GetCoreMasterPageNamesCorePagesFromOrderDal(recordSet);
                    AddCacheItem(key, item);
                }
            }
            else
            {

                CoreMasterPageNamesCorePagesDetails recordSet = SiteProvider.Core.GetCoreMasterPageNamesCorePagesByIsDefault();
                item = GetCoreMasterPageNamesCorePagesFromOrderDal(recordSet);
            }
            return item;
        }


        public List<CoreMasterPageNamesCorePages> GetCoreMasterPageNamesCorePagesByPageId(Int32 pageId)
        {
            List<CoreMasterPageNamesCorePages> item;

            String key = "CoreMasterPageNamesCorePages_PageId_" + pageId;

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as List<CoreMasterPageNamesCorePages>;
                if (item == null)
                {
                    List<CoreMasterPageNamesCorePagesDetails> recordSet = SiteProvider.Core.GetCoreMasterPageNamesCorePagesByPageId(pageId);
                    item = GetCoreMasterPageNamesCorePagesCollectionFromOrderDal(recordSet);
                    AddCacheItem(key, item);
                }
            }
            else
            {
                List<CoreMasterPageNamesCorePagesDetails> recordSet = SiteProvider.Core.GetCoreMasterPageNamesCorePagesByPageId(pageId);
                item = GetCoreMasterPageNamesCorePagesCollectionFromOrderDal(recordSet);
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
        private static List<CoreMasterPageNamesCorePages> GetCoreMasterPageNamesCorePagesCollectionFromOrderDal(List<CoreMasterPageNamesCorePagesDetails> records)
        {
            List<CoreMasterPageNamesCorePages> items = new List<CoreMasterPageNamesCorePages>();
            foreach (CoreMasterPageNamesCorePagesDetails item in records)
                items.Add(GetCoreMasterPageNamesCorePagesFromOrderDal(item));
            return items;
        }

        /// <summary>
        /// تبدیل داده لایه دیتا به داده لایه تجاری
        /// </summary>
        /// <param name="record">رکورد ورودی حاوی داده لایه دیتا</param>
        /// <returns></returns>
        private static CoreMasterPageNamesCorePages GetCoreMasterPageNamesCorePagesFromOrderDal(CoreMasterPageNamesCorePagesDetails record)
        {
            if (record != null)
                return new CoreMasterPageNamesCorePages(record.MasterPageNameId, record.PageId, record.ThemeName,record.Path,record.PathSmallImage,record.NameImage);
            return null;
        }

        #endregion
    }
}
