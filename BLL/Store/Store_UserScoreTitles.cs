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
    public class Store_UserScoreTitles : BaseStore
    { 
        
        #region Constructors (2)

      public Store_UserScoreTitles(Guid userScoreTitleId, Guid productId, String name, String description, Int32 domainId, Int32 languageId)
        {

            UserScoreTitleId = userScoreTitleId;
            ProductId = productId;
            Name = name;
            Description = description;
            DomainId = domainId;
            LanguageId = languageId;

        }



     
        /// <summary>
        /// سازنده پیش فرض کلاس جزئیات تنظیمات طرح
        /// </summary>
        public Store_UserScoreTitles() 
        {
            CacheDuration = Settings.CacheDuration;
            MasterCacheKey = "Store";
        }
         
       #endregion Constructors

        #region Properties (4)

        public Guid UserScoreTitleId { get; set; }

        public Guid ProductId { get; set; }

        public String Name { get; set; }

        public String Description { get; set; }

        public Int32 DomainId { get; set; }

        public Int32 LanguageId { get; set; }
        #endregion Properties

        #region Methods(4)

        public List<Store_UserScoreTitles> GetUserScoreTitlesById(Guid id)  
        {
            List<Store_UserScoreTitles> item;

            String key = "Store_UserScoreTitlesId_" + id; 
             
            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as List<Store_UserScoreTitles>;
                if (item == null)
                {
                    List<Store_UserScoreTitlesDetails> recordSet = SiteProvider.Store.GetUserScoreTitlesById(id);
                    item = GetStore_UserScoreTitlesCollectionFromOrderDal(recordSet);
                    AddCacheItem(key, item);
                }
            }
            else
            {
                List<Store_UserScoreTitlesDetails> recordSet = SiteProvider.Store.GetUserScoreTitlesById(id);
                item = GetStore_UserScoreTitlesCollectionFromOrderDal(recordSet);
            }
            return item;
        }

        public Int32 insertUserScoreTitles()
        {
            return insertUserScoreTitles(UserScoreTitleId, ProductId, Name, Description, DomainId, LanguageId);
        }

        private Int32 insertUserScoreTitles(Guid userScoreTitleId, Guid productId, String name, String description, Int32 domainId, Int32 languageId)
        {
            Store_UserScoreTitlesDetails Store_UserScoreTitles = new Store_UserScoreTitlesDetails(UserScoreTitleId, ProductId, Name, Description, DomainId, LanguageId);
            Int32 ret = SiteProvider.Store.insertUserScoreTitles(Store_UserScoreTitles);
            if (Settings.EnableCaching & ret > 0)
                InvalidateCache();
            return ret;
        }

        public Boolean UpdateUserScoreTitles()
        {
            return UpdateUserScoreTitles(UserScoreTitleId, ProductId, Name, Description, DomainId, LanguageId);
        }

        private Boolean UpdateUserScoreTitles(Guid userScoreTitleId, Guid productId, String name, String description, Int32 domainId, Int32 languageId)
        {
            Store_UserScoreTitlesDetails Store_UserScoreTitles = new Store_UserScoreTitlesDetails(UserScoreTitleId, ProductId, Name, Description, DomainId, LanguageId);
            Boolean ret = SiteProvider.Store.UpdateUserScoreTitles(Store_UserScoreTitles); 
            if (Settings.EnableCaching & ret)
                InvalidateCache();
            return ret;
        }

        public bool DeleteUserScoreTitles(Guid Id)
        {


            Boolean ret = SiteProvider.Store.DeleteUserScoreTitles(Id);
            if (Settings.EnableCaching & ret)
                InvalidateCache();
            return ret;
        } 





         //    /// <summary>
         //    /// تبدیل داده های لایه دیتا به داده های لایه تجاری 
         //    /// </summary>
         //    /// <param name="records">رکوردهای ورودی حاوی داده های لایه دیتا</param>
         //    /// <returns></returns>
        private static List<Store_UserScoreTitles> GetStore_UserScoreTitlesCollectionFromOrderDal(List<Store_UserScoreTitlesDetails> records)
         {
             List<Store_UserScoreTitles> items = new List<Store_UserScoreTitles>();
             foreach (Store_UserScoreTitlesDetails item in records)
                 items.Add(GetStore_UserScoreTitlesFromOrderDal(item));
             return items;
         }

        /// <summary>
        /// تبدیل داده لایه دیتا به داده لایه تجاری
        /// </summary>
        /// <param name="record">رکورد ورودی حاوی داده لایه دیتا</param>
        /// <returns></returns>
        private static Store_UserScoreTitles GetStore_UserScoreTitlesFromOrderDal(Store_UserScoreTitlesDetails record)
        {
            if (record != null)
                return new Store_UserScoreTitles(record.UserScoreTitleId,record.ProductId,record.Name,record.Description,record.DomainId,record.LanguageId);
            return null;
        }

        #endregion
    }
}
