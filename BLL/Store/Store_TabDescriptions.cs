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
    public class Store_TabDescriptions : BaseStore
    { 
        
        #region Constructors (2)

         public Store_TabDescriptions(Guid tabDescriptionId, Guid productId, String name, String description, Int32 domainId, Int32 languageId)
        {

            TabDescriptionId = tabDescriptionId;
            ProductId = productId;
            Name = name;
            Description = description;
            DomainId = domainId;
            LanguageId = languageId;

        }

     
        /// <summary>
        /// سازنده پیش فرض کلاس جزئیات تنظیمات طرح
        /// </summary>
         public Store_TabDescriptions() 
        {
            CacheDuration = Settings.CacheDuration;
            MasterCacheKey = "Store";
        }
         
       #endregion Constructors

        #region Properties (4)
       
        public Guid TabDescriptionId { get; set; }

       public Guid ProductId { get; set; }

       
       public String Name { get; set; }

       public String Description { get; set; }

      
        public Int32 DomainId { get; set; }

        public Int32 LanguageId { get; set; }

        #endregion Properties

        #region Methods(4)
         
        public List<Store_TabDescriptions> GetTabDescriptionsById(Guid id) 
        {
            List<Store_TabDescriptions> item;

            String key = "Store_TabDescriptionId_" + id;

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as List<Store_TabDescriptions>;
                if (item == null)
                {
                    List<Store_TabDescriptionsDetails> recordSet = SiteProvider.Store.GetTabDescriptionsById(id);
                    item = GetStore_TabDescriptionsCollectionFromOrderDal(recordSet);
                    AddCacheItem(key, item);
                }
            }
            else
            {
                List<Store_TabDescriptionsDetails> recordSet = SiteProvider.Store.GetTabDescriptionsById(id);
                item = GetStore_TabDescriptionsCollectionFromOrderDal(recordSet);
            }
            return item;
        }

        public Int32 insertTabDescriptions()
        {
            return insertTabDescriptions(TabDescriptionId, ProductId, Name, Description,DomainId,LanguageId);
        }

        private Int32 insertTabDescriptions(Guid tabDescriptionId, Guid productId, String name, String description, Int32 domainId, Int32 languageId)
        {
            Store_TabDescriptionsDetails Store_TabDescriptions = new Store_TabDescriptionsDetails(TabDescriptionId, ProductId, Name, Description, DomainId, LanguageId);
            Int32 ret = SiteProvider.Store.insertTabDescriptions(Store_TabDescriptions); 
            if (Settings.EnableCaching & ret > 0)
                InvalidateCache();
            return ret;
        }

        public Boolean UpdateTabDescriptions()
        {
            return UpdateTabDescriptions(TabDescriptionId, ProductId, Name, Description, DomainId, LanguageId);
        }

        private Boolean UpdateTabDescriptions(Guid tabDescriptionId, Guid productId, String name, String description, Int32 domainId, Int32 languageId) 
        {
            Store_TabDescriptionsDetails Store_TabDescriptions = new Store_TabDescriptionsDetails(TabDescriptionId, ProductId, Name, Description, DomainId, LanguageId);
            Boolean ret = SiteProvider.Store.UpdateTabDescriptions(Store_TabDescriptions);
            if (Settings.EnableCaching & ret)
                InvalidateCache();
            return ret;
        }

        public bool DeleteTabDescriptions(Guid Id)
        {


            Boolean ret = SiteProvider.Store.DeleteTabDescriptions(Id);
            if (Settings.EnableCaching & ret)
                InvalidateCache();
            return ret;
        } 





        //    /// <summary>
        //    /// تبدیل داده های لایه دیتا به داده های لایه تجاری 
        //    /// </summary>
        //    /// <param name="records">رکوردهای ورودی حاوی داده های لایه دیتا</param>
        //    /// <returns></returns>
        private static List<Store_TabDescriptions> GetStore_TabDescriptionsCollectionFromOrderDal(List<Store_TabDescriptionsDetails> records)
        {
            List<Store_TabDescriptions> items = new List<Store_TabDescriptions>();
            foreach (Store_TabDescriptionsDetails item in records)
                items.Add(GetStore_SpecificationTitlesFromOrderDal(item)); 
            return items;
        }

        /// <summary>
        /// تبدیل داده لایه دیتا به داده لایه تجاری
        /// </summary>
        /// <param name="record">رکورد ورودی حاوی داده لایه دیتا</param>
        /// <returns></returns>
        private static Store_TabDescriptions GetStore_SpecificationTitlesFromOrderDal(Store_TabDescriptionsDetails record)
        {
            if (record != null)
                return new Store_TabDescriptions(record.TabDescriptionId,record.ProductId,record.Name,record.Description,record.DomainId,record.LanguageId);
            return null;
        }

        #endregion
    }
}
