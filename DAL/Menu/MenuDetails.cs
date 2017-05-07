using System;
using System.Linq;

namespace Pine.Dal.Menu
{
    /// <summary>
    /// کلاسی برای نگهداری منو
    /// </summary>
    public class MenuDetails
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
        public MenuDetails(Int32 menuId, Int32 menuNameId, Int32? parentMenuId, String text, String navigateUrl, String imageUrl, Int16 priority, String userControl)
        {
            MenuId = menuId;
            MenuNameId = menuNameId;
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
        public MenuDetails() { }

        #endregion Constructors

        #region Properties (8)

        /// <summary>
        /// کد منو
        /// </summary>
        public Int32 MenuId { get; set; }

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

        //private static List<Menu> GetMenuByIdInDal(int id)
        //{
        //    return GetMenuUserCollectionFromDataReader(SiteProvider.Menu.GetMenuByMenuNameId(id));
        //}
    }
}
