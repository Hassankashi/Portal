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
    public class Store_PriceDescriptions : BaseStore
    {
        
        #region Constructors (2)

       public Store_PriceDescriptions(Guid priceDescriptionId, String name, Int32 priority, String roleName, Boolean status, Int32 domainId, Int32 languageId)
        {

            PriceDescriptionId = priceDescriptionId;
            Name = name;
            Priority = priority;
            RoleName = roleName;
            Status = status;
            DomainId = domainId;
            LanguageId = languageId;
 
        }

     
        /// <summary>
        /// سازنده پیش فرض کلاس جزئیات تنظیمات طرح
        /// </summary>
        public Store_PriceDescriptions()
        {
            CacheDuration = Settings.CacheDuration;
            MasterCacheKey = "Store";
        }

       #endregion Constructors

        #region Properties (4)

        public Guid PriceDescriptionId { get; set; }

        public String Name { get; set; }

        public Int32 Priority { get; set; }

        public String RoleName { get; set; }

        public Boolean Status { get; set; }

        public Int32 DomainId { get; set; }

        public Int32 LanguageId { get; set; }

        #endregion Properties

      #region Methods(4)

        public static Store_PriceDescriptions GetPriceDescriptionsById(Guid id) 
        {
            Store_PriceDescriptions item;

            String key = "Store_PriceDescriptions_Id_" + id;

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as Store_PriceDescriptions;
                if (item == null)
                {
                    Store_PriceDescriptionsDetails recordSet = SiteProvider.Store.GetPriceDescriptionsById(id);
                    item = GetStore_PriceDescriptionsFromOrderDal(recordSet);
                    AddCacheItem(key, item);
                }
            }
            else
            {
                Store_PriceDescriptionsDetails recordSet = SiteProvider.Store.GetPriceDescriptionsById(id);
                item = GetStore_PriceDescriptionsFromOrderDal(recordSet);
            }
            return item;
        }

        public static List<Store_PriceDescriptions> GetAllPriceDescriptions()
        {
            List<Store_PriceDescriptions> item;

            String key = "Store_PriceDescriptions_GetAll"; 

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as List<Store_PriceDescriptions>;
                if (item == null)
                {
                    List<Store_PriceDescriptionsDetails> recordSet = SiteProvider.Store.GetAllPriceDescriptions();
                    item = GetStore_PriceDescriptionsCollectionFromOrderDal(recordSet);
                    AddCacheItem(key, item);
                }
            }
            else
            {
                List<Store_PriceDescriptionsDetails> recordSet = SiteProvider.Store.GetAllPriceDescriptions();
                item = GetStore_PriceDescriptionsCollectionFromOrderDal(recordSet);
            }
            return item;
        }

        public Int32 insertPriceDescriptions()
        {
            return insertPriceDescriptions(PriceDescriptionId, Name, Priority, RoleName, Status, DomainId, LanguageId);
        }

        private Int32 insertPriceDescriptions(Guid priceDescriptionId, String name, Int32 priority, String roleName, Boolean status, Int32 domainId, Int32 languageId)
        {
            Store_PriceDescriptionsDetails Store_PriceDescriptions = new Store_PriceDescriptionsDetails(priceDescriptionId, name, priority, roleName, status, domainId, languageId);
            Int32 ret = SiteProvider.Store.insertPriceDescriptions(Store_PriceDescriptions);
            if (Settings.EnableCaching & ret > 0) 
                InvalidateCache();
            return ret;
        }

        public Boolean UpdatePriceDescriptions()
        {
            return UpdatePriceDescriptions(PriceDescriptionId, Name, Priority, RoleName, Status, DomainId, LanguageId);
        }

        private Boolean UpdatePriceDescriptions(Guid priceDescriptionId, String name, Int32 priority, String roleName, Boolean status, Int32 domainId, Int32 languageId)
        {
            Store_PriceDescriptionsDetails Store_PriceDescriptions = new Store_PriceDescriptionsDetails(PriceDescriptionId, Name, Priority, RoleName, Status, DomainId, LanguageId);
            Boolean ret = SiteProvider.Store.UpdatePriceDescriptions(Store_PriceDescriptions); 
            if (Settings.EnableCaching & ret)
                InvalidateCache();
            return ret;
        }

        public bool DeletePriceDescriptions(Guid Id)
        {


            Boolean ret = SiteProvider.Store.DeletePriceDescriptions(Id);
            if (Settings.EnableCaching & ret)
                InvalidateCache();
            return ret;
        }





        ////    /// <summary>
        ////    /// تبدیل داده های لایه دیتا به داده های لایه تجاری 
        ////    /// </summary>
        ////    /// <param name="records">رکوردهای ورودی حاوی داده های لایه دیتا</param>
        ////    /// <returns></returns>
        private static List<Store_PriceDescriptions> GetStore_PriceDescriptionsCollectionFromOrderDal(List<Store_PriceDescriptionsDetails> records)
        {
            List<Store_PriceDescriptions> items = new List<Store_PriceDescriptions>();
            foreach (Store_PriceDescriptionsDetails item in records)
                items.Add(GetStore_PriceDescriptionsFromOrderDal(item));
            return items;
        }

        /// <summary>
        /// تبدیل داده لایه دیتا به داده لایه تجاری
        /// </summary>
        /// <param name="record">رکورد ورودی حاوی داده لایه دیتا</param>
        /// <returns></returns>
        private static Store_PriceDescriptions GetStore_PriceDescriptionsFromOrderDal(Store_PriceDescriptionsDetails record)
        {
            if (record != null)
                return new Store_PriceDescriptions(record.PriceDescriptionId,record.Name, record.Priority,record.RoleName,record.Status,record.DomainId,record.LanguageId);
            return null;
        }

        #endregion
    }
}
