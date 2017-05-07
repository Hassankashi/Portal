using System;
using System.Collections.Generic;
using System.Data;

namespace Pine.Dal.Menu
{
    public abstract class MenuProvider : DataAccess
    {
        #region Fields (1)

        static private MenuProvider _instance;

        #endregion Fields

        #region Constructors (1)

        /// <summary>
        /// سازنده اصلی کلاس
        /// </summary>
        protected MenuProvider()
        {
            ConnectionString = Globals.Settings.Menu.ConnectionString;
            EnableCaching = Globals.Settings.Menu.EnableCaching;
            CacheDuration = Globals.Settings.Menu.CacheDuration;
        }

        #endregion Constructors

        #region Properties (1)

        /// <summary>
        /// Returns an instance of the provider type specified in the config file
        /// </summary>
        static public MenuProvider Instance
        {
            get
            {
                return _instance ?? (_instance = (MenuProvider)Activator.CreateInstance(
                    Type.GetType(Globals.Settings.Menu.ProviderType)));
            }
        }

        #endregion Properties

        #region MenuName (1)
        /// <summary>
        /// گرفتن نام گروه منو
        /// </summary>
        /// <param name="menuNameId">کد گروه منو</param>
        /// <returns>نام گروه</returns>
        public abstract String GetNameMenuById(Int32 menuNameId);

        /// <summary>
        /// وارد کردن نام گروه
        /// </summary>
        /// <param name="groupMenuId">کد گروه منو</param>
        /// <param name="name">نام گروه منو</param>
        /// <returns>کد گروه وارد شده</returns>
        public abstract Int32 InsertGroupName(MenuGroupDetails menuGroup);

        /// <summary>
        /// ویرایش نام گروه
        /// </summary>
        /// <param name="menuGroup"></param>
        /// <returns></returns>
        public abstract Boolean UpdateGroupName(MenuGroupDetails menuGroup);
        #endregion

        #region MenuUser (1)

        /// <summary>
        /// بازیابی اطلاعات یک منو
        /// </summary>
        /// <param name="menuNameId">کد گروه منو</param>
        /// <returns>کلاس منو</returns>
        public abstract List<MenuDetails> GetMenuByMenuNameId(Int32 menuNameId);

        /// <summary>
        /// بازیابی اطلاعات یک رکورد منو
        /// </summary>
        /// <param name="menuNameId">کد منو</param>
        /// <returns>کلاس منو</returns>
        public abstract MenuDetails GetMenuById(Int32 menuId);

        /// <summary>
        /// بروز رسانی عنوان یک گروه
        /// </summary>
        /// <param name="menu">کلاس منو</param>
        /// <returns>وضعیت آپدیت</returns>
        public abstract Boolean UpdateMenuNavigateUrl(Int32 menuId, String navigateUrl, String userControl);

        /// <summary>
        /// ویرایش نام گروه
        /// </summary>
        /// <param name="menuGroup"></param>
        /// <returns></returns>
        public abstract Boolean UpdateMenu(MenuDetails menuGroup);

        /// <summary>
        /// وارد کردن یک منو
        /// </summary>
        /// <param name="menu">کلاس منو</param>
        /// <returns>کد منو</returns>
        public abstract Int32 InsertMenu(MenuDetails menu);

        #endregion

        #region Virtual Protected Methods (2)

        protected virtual List<MenuDetails> GetMenuUserCollectionFromDataReader(IDataReader reader)
        {
            List<MenuDetails> items = new List<MenuDetails>();
            while (reader.Read())
                items.Add(GetMenuUserFromDataReader(reader));
            return items;
        }



        protected virtual MenuDetails GetMenuUserFromDataReader(IDataReader reader)
        {
            return new MenuDetails
                (
                    (Int32)reader["MenuId"],
                    (Int32)reader["MenuNameId"],
                    reader["ParentMenuId"] as Int32?,
                    reader["Text"].ToString(),
                    reader["NavigateUrl"].ToString(),
                    reader["ImageUrl"].ToString(),
                    Int16.Parse(reader["Priority"].ToString()),
                    reader["UserControl"].ToString()
                );
        }


        protected virtual MenuGroupDetails GetMenuGroupFromDataReader(IDataReader reader)
        {
            return new MenuGroupDetails
                (
                    Int32.Parse(reader["MenuNameId"].ToString()),
                    reader["MenuName"].ToString()
                );
        }
        #endregion
    }
}
