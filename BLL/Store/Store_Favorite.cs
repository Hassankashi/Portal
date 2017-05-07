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
    public class Store_Favorite : BaseStore 
    {
        
        #region Constructors (2)

        public Store_Favorite(Guid favoriteId, Int32 favoriteGroupId, Guid productId, DateTime enterDate, Int32 domainId, Int32 languageId, String name)
        {

            FavoriteId = favoriteId;
            FavoriteGroupId = favoriteGroupId;
            ProductId = productId;
             EnterDate = enterDate;
            DomainId = domainId;
            LanguageId = languageId;
            Name = name;
        }

     
        /// <summary>
        /// سازنده پیش فرض کلاس جزئیات تنظیمات طرح
        /// </summary>
        public Store_Favorite()
        {
            CacheDuration = Settings.CacheDuration;
            MasterCacheKey = "Store";
        }

       #endregion Constructors

        #region Properties (4)

        public Guid FavoriteId { get; set; }

        public Int32 FavoriteGroupId { get; set; }

        public Guid ProductId { get; set; }

        public DateTime EnterDate { get; set; }

        public Int32 DomainId { get; set; }

        public Int32 LanguageId { get; set; }

        public String Name { get; set; } 





        #endregion Properties

        #region Methods(4)

        public List<Store_Favorite> GetFavoriteById(Guid id) 
        {
            List<Store_Favorite> item;

            String key = "Store_Favorite_Id_" + id;  

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as List<Store_Favorite>;
                if (item == null)
                {
                    List<Store_FavoriteDetails> recordSet = SiteProvider.Store.GetFavoriteById(id);
                    item = GetStore_FavoriteCollectionFromOrderDal(recordSet);
                    AddCacheItem(key, item);
                }
            }
            else
            {
                List<Store_FavoriteDetails> recordSet = SiteProvider.Store.GetFavoriteById(id);
                item = GetStore_FavoriteCollectionFromOrderDal(recordSet);
            }
            return item;
        }



        public List<Store_Favorite> GetAllFavorite() 
        {
            List<Store_Favorite> item;

            String key = "Store_Favorite_GetAll" ;  

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as List<Store_Favorite>;
                if (item == null)
                {
                    List<Store_FavoriteDetails> recordSet = SiteProvider.Store.GetAllFavorite();
                    item = GetStore_FavoriteCollectionFromOrderDal(recordSet);
                    AddCacheItem(key, item);
                }
            }
            else
            {
                List<Store_FavoriteDetails> recordSet = SiteProvider.Store.GetAllFavorite();
                item = GetStore_FavoriteCollectionFromOrderDal(recordSet);
            }
            return item;
        }
        public Int32 insertFavorite()
        {
            return insertFavorite(FavoriteId, FavoriteGroupId, ProductId, EnterDate, DomainId, LanguageId, Name);
        }

        private Int32 insertFavorite(Guid favoriteId, Int32 favoriteGroupId, Guid productId, DateTime enterDate, Int32 domainId, Int32 languageId, String name)
        {
            Store_FavoriteDetails Store_favorite  = new Store_FavoriteDetails(favoriteId, favoriteGroupId, productId, enterDate, domainId, languageId, name );
            Int32 ret = SiteProvider.Store.insertFavorite(Store_favorite);
            if (Settings.EnableCaching & ret > 0)
                InvalidateCache();
            return ret;
        }

        public Boolean UpdateFavorite()
        {
            return UpdateFavorite(FavoriteId, FavoriteGroupId, ProductId, EnterDate, DomainId, LanguageId, Name); 
        }

        private Boolean UpdateFavorite(Guid favoriteId, Int32 favoriteGroupId, Guid productId, DateTime enterDate, Int32 domainId, Int32 languageId, String name)
        {
            Store_FavoriteDetails Store_favorite = new Store_FavoriteDetails(FavoriteId, FavoriteGroupId, ProductId, EnterDate, DomainId, LanguageId, name);
            Boolean ret = SiteProvider.Store.UpdateFavorite(Store_favorite);
            if (Settings.EnableCaching & ret)
                InvalidateCache();
            return ret;
        }

        public bool DeleteFavorite(Guid Id)
        {


            Boolean ret = SiteProvider.Store.DeleteFavorite(Id);
            if (Settings.EnableCaching & ret)
                InvalidateCache();
            return ret;
        }





        //    /// <summary>
        //    /// تبدیل داده های لایه دیتا به داده های لایه تجاری 
        //    /// </summary>
        //    /// <param name="records">رکوردهای ورودی حاوی داده های لایه دیتا</param>
        //    /// <returns></returns>
        private static List<Store_Favorite> GetStore_FavoriteCollectionFromOrderDal(List<Store_FavoriteDetails> records)
        {
            List<Store_Favorite> items = new List<Store_Favorite>();
            foreach (Store_FavoriteDetails item in records)
                items.Add(GetStore_FavoriteFromOrderDal(item));
            return items;
        }

        /// <summary>
        /// تبدیل داده لایه دیتا به داده لایه تجاری
        /// </summary>
        /// <param name="record">رکورد ورودی حاوی داده لایه دیتا</param>
        /// <returns></returns>
        private static Store_Favorite GetStore_FavoriteFromOrderDal(Store_FavoriteDetails record) 
        {
            if (record != null)
                return new Store_Favorite(record.FavoriteId, record.FavoriteGroupId, record.ProductId, record.EnterDate, record.DomainId, record.LanguageId, record.Name);
            return null;
        }

        #endregion
    }
}
