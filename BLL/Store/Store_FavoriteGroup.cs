using System;
using System.Linq;
using System.Collections.Generic;
using Pine.Dal;
using Pine.Dal.Store;
 
namespace Pine.Bll.Store
{
    /// <summary>
    /// کلاسی برای نگهداری منو
    /// </summary>
    public class Store_FavoriteGroup : BaseStore 
    {
        
        #region Constructors (2)

        public Store_FavoriteGroup(Int32 favoriteGroupId, String nameGroup, Int32 domainId, Int32 languageId)
        {

            FavoriteGroupId = favoriteGroupId;
            NameGroup = nameGroup;

            DomainId = domainId;
            LanguageId = languageId;

        }

     
        /// <summary>
        /// سازنده پیش فرض کلاس جزئیات تنظیمات طرح
        /// </summary>
        public Store_FavoriteGroup()
        {
            CacheDuration = Settings.CacheDuration;
            MasterCacheKey = "Store";
        }

       #endregion Constructors

        #region Properties (4)

        public Int32 FavoriteGroupId { get; set; }

        public String NameGroup { get; set; }


        public Int32 DomainId { get; set; }

        public Int32 LanguageId { get; set; }


        #endregion Properties

        #region Methods(4)

        public static Store_FavoriteGroup GetFavoriteGroupById(Int32 id) 
        {
            Store_FavoriteGroup item;

            String key = "Store_FavoriteGroup_Id_" + id; 

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as Store_FavoriteGroup;
                if (item == null)
                {
                    Store_FavoriteGroupDetails recordSet = SiteProvider.Store.GetFavoriteGroupById(id);
                    item = GetStore_FavoriteGroupFromOrderDal(recordSet);
                    AddCacheItem(key, item);
                }
            }
            else
            {
                Store_FavoriteGroupDetails recordSet = SiteProvider.Store.GetFavoriteGroupById(id);
                item = GetStore_FavoriteGroupFromOrderDal(recordSet);
            }
            return item;
        }



        public static List<Store_FavoriteGroup> GetAllFavoriteGroup()  
        {
            List<Store_FavoriteGroup> item;

            String key = "StoreFavoriteGroup_GetAll" ; 

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as List<Store_FavoriteGroup>;
                if (item == null)
                {
                    List<Store_FavoriteGroupDetails> recordSet = SiteProvider.Store.GetAllFavoriteGroup();
                    item = GetStore_FavoriteGroupCollectionFromOrderDal(recordSet);
                    AddCacheItem(key, item);
                }
            }
            else
            {
                List<Store_FavoriteGroupDetails> recordSet = SiteProvider.Store.GetAllFavoriteGroup();
                item = GetStore_FavoriteGroupCollectionFromOrderDal(recordSet);
            }
            return item;
        }

        public Int32 InsertFavoriteGroup() 
        {
            return InsertFavoriteGroup(FavoriteGroupId, NameGroup, DomainId, LanguageId);
        }

        private Int32 InsertFavoriteGroup(Int32 favoriteGroupId, String nameGroup, Int32 domainId, Int32 languageId)
        {
            Store_FavoriteGroupDetails store_favoriteGroup = new Store_FavoriteGroupDetails(favoriteGroupId, nameGroup,domainId, languageId);
            Int32 ret = SiteProvider.Store.insertFavoriteGroup(store_favoriteGroup);
            if (Settings.EnableCaching & ret > 0)
                InvalidateCache();
            return ret;
        }

        public Boolean UpdateFavoriteGroup()
        {
            return UpdateFavoriteGroup(FavoriteGroupId, NameGroup, DomainId, LanguageId); 
        }

        private Boolean UpdateFavoriteGroup(Int32 favoriteGroupId, String nameGroup, Int32 domainId, Int32 languageId)
        {
            Store_FavoriteGroupDetails favoriteGroup = new Store_FavoriteGroupDetails(FavoriteGroupId, NameGroup, DomainId, LanguageId);
            Boolean ret = SiteProvider.Store.UpdateFavoriteGroup(favoriteGroup); 
            if (Settings.EnableCaching & ret)
                InvalidateCache();
            return ret;
        }

        public Boolean DeleteFavoriteGroup(Int32 id) 
        {


            Boolean ret = SiteProvider.Store.DeleteFavoriteGroup(id); 
            if (Settings.EnableCaching & ret)
                InvalidateCache();
            return ret;
        }





        ////    /// <summary>
        ////    /// تبدیل داده های لایه دیتا به داده های لایه تجاری 
        ////    /// </summary>
        ////    /// <param name="records">رکوردهای ورودی حاوی داده های لایه دیتا</param>
        ////    /// <returns></returns>
        private static List<Store_FavoriteGroup> GetStore_FavoriteGroupCollectionFromOrderDal(List<Store_FavoriteGroupDetails> records)
        {
            List<Store_FavoriteGroup> items = new List<Store_FavoriteGroup>();
            foreach (Store_FavoriteGroupDetails item in records)
                items.Add(GetStore_FavoriteGroupFromOrderDal(item));
            return items;
        }

        /// <summary>
        /// تبدیل داده لایه دیتا به داده لایه تجاری
        /// </summary>
        /// <param name="record">رکورد ورودی حاوی داده لایه دیتا</param>
        /// <returns></returns>
        private static Store_FavoriteGroup GetStore_FavoriteGroupFromOrderDal(Store_FavoriteGroupDetails record) 
        {
            if (record != null)
                return new Store_FavoriteGroup(record.FavoriteGroupId,record.NameGroup,record.DomainId,record.LanguageId);
            return null;
        }

        #endregion
    }
}
