using System;
using System.Linq;
using System.Collections.Generic;
using Pine.Dal;
using Pine.Dal.Menu;

namespace Pine.Bll.Menu
{
    /// <summary>
    /// کلاسی برای نگهداری منو
    /// </summary>
    public class MenuUser : BaseMenu
    {
        #region Constructors (1)
        /// <summary>
        /// سازنده اصلی کلاس جزئیات منو
        /// </summary>
        /// <param name="menuId">کد منو</param>
        /// <param name="menuNameId">کد گروه منو</param>
        /// <param name="parentMenuId">کد پدر منو</param>
        /// <param name="text">عنوان</param>
        /// <param name="navigateUrl">رفتن به آدرس</param>
        /// <param name="imageUrl">آدرس عکس</param>
        /// <param name="priority">اولویت</param>
        /// <param name="userControl">عنوان ماژولی که وصل شده</param>
        public MenuUser(Int32 menuId, Int32 menuGroupId, Int32? parentMenuId, String text, String navigateUrl, String imageUrl, Int16 priority, String userControl)
        {
            Id = menuId;
            MenuNameId = menuGroupId;
            ParentMenuId = parentMenuId;
            Text = text;
            NavigateUrl = navigateUrl;
            ImageUrl = imageUrl;
            Priority = priority;
            UserControl = userControl;
        }

        /// <summary>
        /// سازنده پیش فرض کلاس جزئیات منو
        /// </summary>
        public MenuUser()
        {
            CacheDuration = Settings.CacheDuration;
            MasterCacheKey = "Menu";
        }

        #endregion Constructors

        #region Properties (7)

        /// <summary>
        /// کد گروه منو
        /// </summary>
        public Int32 MenuNameId { get; set; }

        /// <summary>
        /// کد پدر منو
        /// </summary>
        public Int32? ParentMenuId { get; set; }

        /// <summary>
        /// عنوان
        /// </summary>
        public String Text { get; set; }

        /// <summary>
        /// رفتن به آدرس
        /// </summary>
        public String NavigateUrl { get; set; }

        /// <summary>
        /// آدرس عکس
        /// </summary>
        public String ImageUrl { get; set; }

        /// <summary>
        /// اولویت
        /// </summary>
        public Int16 Priority { get; set; }

        /// <summary>
        /// عنوان ماژولی که وصل شده
        /// </summary>
        public String UserControl { get; set; }

        #endregion Properties

        #region Methods(3)

        public List<MenuUser> GetMenuByGroupId(Int32 id)
        {
            List<MenuUser> item;

            String key = "Menu_GroupId_" + id;

            if (Settings.EnableCaching)
            {

                item = GetCacheItem(key) as List<MenuUser>;
                if (item == null)
                {
                    List<MenuDetails> recordSet = SiteProvider.Menu.GetMenuByMenuNameId(id);
                    item = GetMenuCollectionFromOrderDal(recordSet);
                    AddCacheItem(key, item);
                }
            }
            else
            {
                List<MenuDetails> recordSet = SiteProvider.Menu.GetMenuByMenuNameId(id);
                item = GetMenuCollectionFromOrderDal(recordSet);
            }
            return item;
        }

        public MenuUser GetMenuById(Int32 id)
        {
            MenuUser item;

            String key = "Menu_Id_" + id;

            if (Settings.EnableCaching)
            {

                item = GetCacheItem(key) as MenuUser;
                if (item == null)
                {
                    MenuDetails recordSet = SiteProvider.Menu.GetMenuById(id);
                    item = GetMenuFromOrderDal(recordSet);
                    AddCacheItem(key, item);
                }
            }
            else
            {
                MenuDetails recordSet = SiteProvider.Menu.GetMenuById(id);
                item = GetMenuFromOrderDal(recordSet);
            }
            return item;
        }

        public Int32 Insert()
        {
            return Insert(Id, MenuNameId, ParentMenuId,Text, NavigateUrl, ImageUrl, Priority, UserControl);
        }

        private Int32 Insert(Int32 id, Int32  menuNameId, Int32? parentMenuId, String text, String navigateUrl, String imageUrl, Int16 priority, String userControl)
        {
            MenuDetails menu = new MenuDetails(id, menuNameId, parentMenuId, text, navigateUrl, imageUrl, priority, userControl);
            Int32 ret = SiteProvider.Menu.InsertMenu(menu);
            if (Settings.EnableCaching & ret > 0)
                InvalidateCache();
            return ret;
        }

        public bool UpdateMenuNavigateUrl()
        {
            return UpdateMenuNavigateUrl(Id, MenuNameId, ParentMenuId, Text, NavigateUrl, ImageUrl, Priority, UserControl);
        }

        private Boolean UpdateMenuNavigateUrl(Int32 id, Int32 menuNameId, Int32? parentMenuId, String text, String navigateUrl, String imageUrl, Int16 priority, String userControl)
        {
            MenuDetails menu = new MenuDetails(id, menuNameId, parentMenuId, text, navigateUrl, imageUrl, priority, userControl);
            Boolean ret = SiteProvider.Menu.UpdateMenuNavigateUrl(menu.MenuId,menu.NavigateUrl,menu.UserControl);
            if (Settings.EnableCaching & ret)
                InvalidateCache();
            return ret;
        }

        public bool UpdateMenu()
        {
            return UpdateMenu(Id, MenuNameId, ParentMenuId, Text, NavigateUrl, ImageUrl, Priority, UserControl);
        }

        private Boolean UpdateMenu(Int32 id, Int32 menuNameId, Int32? parentMenuId, String text, String navigateUrl, String imageUrl, Int16 priority, String userControl)
        {
            MenuDetails menu = new MenuDetails(id, menuNameId, parentMenuId, text, navigateUrl, imageUrl, priority, userControl);
            Boolean ret = SiteProvider.Menu.UpdateMenu(menu);
            if (Settings.EnableCaching & ret)
                InvalidateCache();
            return ret;
        }



        /// <summary>
        /// تبدیل داده لایه دیتا به داده لایه تجاری
        /// </summary>
        /// <param name="record">رکورد ورودی حاوی داده لایه دیتا</param>
        /// <returns></returns>
        private static MenuUser GetMenuFromOrderDal(MenuDetails record)
        {
            if (record != null)
                return new MenuUser(record.MenuId, record.MenuNameId, record.ParentMenuId, record.Text, record.NavigateUrl, record.ImageUrl, record.Priority, record.UserControl);
            return null;
        }

        /// <summary>
        /// تبدیل داده های لایه دیتا به داده های لایه تجاری 
        /// </summary>
        /// <param name="records">رکوردهای ورودی حاوی داده های لایه دیتا</param>
        /// <returns></returns>
        private static List<MenuUser> GetMenuCollectionFromOrderDal(List<MenuDetails> records)
        {
            List<MenuUser> items = new List<MenuUser>();
            foreach (MenuDetails item in records)
                items.Add(GetMenuFromOrderDal(item));
            return items;
        }

        #endregion
    }
}
