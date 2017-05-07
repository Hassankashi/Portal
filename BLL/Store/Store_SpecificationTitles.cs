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
    public class Store_SpecificationTitles : BaseStore
    { 
        
        #region Constructors (2)

        public Store_SpecificationTitles(Guid specificationTitleId, Guid specificationGroupId, String name, String description, Int32 domainId, Int32 languageId)
        {

            SpecificationTitleId = specificationTitleId;
            SpecificationGroupId = specificationGroupId;
            Name = name;
            Description = description;
            DomainId = domainId;
            LanguageId = languageId;

        }
     
        /// <summary>
        /// سازنده پیش فرض کلاس جزئیات تنظیمات طرح
        /// </summary>
        public Store_SpecificationTitles() 
        {
            CacheDuration = Settings.CacheDuration;
            MasterCacheKey = "Store";
        }

       #endregion Constructors

        #region Properties (4)

         public Guid SpecificationTitleId  { get; set; }

       public Guid SpecificationGroupId { get; set; }

       public String Name { get; set; }

       public String Description { get; set; }

        public Int32 DomainId { get; set; }

        public Int32 LanguageId { get; set; }
        #endregion Properties

        #region Methods(4)

        public static Store_SpecificationTitles GetSpecificationTitlesById(Guid id)
        {
            Store_SpecificationTitles item;

            String key = "Store_SpecificationTitleId_" + id;

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as Store_SpecificationTitles;
                if (item == null)
                {
                    Store_SpecificationTitlesDetails recordSet = SiteProvider.Store.GetSpecificationTitlesById(id);
                    item = GetStore_SpecificationTitlesFromOrderDal(recordSet);
                    AddCacheItem(key, item);
                }
            }
            else
            {
               Store_SpecificationTitlesDetails recordSet = SiteProvider.Store.GetSpecificationTitlesById(id);
                item = GetStore_SpecificationTitlesFromOrderDal(recordSet);
            }
            return item;
        }



        public static List<Store_SpecificationTitles> GetAllSpecificationTitles()
        {
            List<Store_SpecificationTitles> item;

            String key = "Store_SpecificationTitle_GetAll" ;

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as List<Store_SpecificationTitles>;
                if (item == null)
                {
                    List<Store_SpecificationTitlesDetails> recordSet = SiteProvider.Store.GetAllSpecificationTitles();
                    item = GetStore_SpecificationTitlesCollectionFromOrderDal(recordSet);
                    AddCacheItem(key, item);
                }
            }
            else
            {
                List<Store_SpecificationTitlesDetails> recordSet = SiteProvider.Store.GetAllSpecificationTitles();
                item = GetStore_SpecificationTitlesCollectionFromOrderDal(recordSet);
            }
            return item;
        }



        public static List<Store_SpecificationTitles> GetBySpecificationGroupId(Guid specificationGroupId)
        {
            List<Store_SpecificationTitles> item;

            String key = "Store_SpecificationTitle_specificationGroupId" + specificationGroupId;

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as List<Store_SpecificationTitles>;
                if (item == null)
                {
                    List<Store_SpecificationTitlesDetails> recordSet = SiteProvider.Store.GetSpecificationTitlesBySpecificationGroupId(specificationGroupId);
                    item = GetStore_SpecificationTitlesCollectionFromOrderDal(recordSet);
                    AddCacheItem(key, item);
                }
            }
            else
            {
                List<Store_SpecificationTitlesDetails> recordSet = SiteProvider.Store.GetSpecificationTitlesBySpecificationGroupId(specificationGroupId);
                item = GetStore_SpecificationTitlesCollectionFromOrderDal(recordSet);
            }
            return item;
        }
        public Int32 insertSpecificationTitles()
        {
            return insertSpecificationTitles(SpecificationTitleId, SpecificationGroupId, Name, Description, DomainId, LanguageId);
        }

        private Int32 insertSpecificationTitles(Guid specificationTitleId, Guid specificationGroupId, String name, String description, Int32 domainId, Int32 languageId)
        {
            Store_SpecificationTitlesDetails Store_SpecificationTitles = new Store_SpecificationTitlesDetails(SpecificationTitleId, SpecificationGroupId, Name, Description, DomainId, LanguageId);
            Int32 ret = SiteProvider.Store.insertSpecificationTitles(Store_SpecificationTitles);
            if (Settings.EnableCaching & ret > 0)
                InvalidateCache();
            return ret;
        }

        public Boolean UpdateSpecificationTitles()
        {
            return UpdateSpecificationTitles(SpecificationTitleId, SpecificationGroupId, Name, Description, DomainId, LanguageId);
        }

        private Boolean UpdateSpecificationTitles(Guid specificationTitleId, Guid specificationGroupId, String name, String description, Int32 domainId, Int32 languageId)  
        {
            Store_SpecificationTitlesDetails Store_SpecificationTitles = new Store_SpecificationTitlesDetails(SpecificationTitleId, SpecificationGroupId, Name, Description, DomainId, LanguageId);
            Boolean ret = SiteProvider.Store.UpdateSpecificationTitles(Store_SpecificationTitles);
            if (Settings.EnableCaching & ret)
                InvalidateCache();
            return ret;
        }

        public bool DeleteSpecificationTitles(Guid Id)
        {


            Boolean ret = SiteProvider.Store.DeleteSpecificationTitles(Id); 
            if (Settings.EnableCaching & ret)
                InvalidateCache();
            return ret;
        }





        //    /// <summary>
        //    /// تبدیل داده های لایه دیتا به داده های لایه تجاری 
        //    /// </summary>
        //    /// <param name="records">رکوردهای ورودی حاوی داده های لایه دیتا</param>
        //    /// <returns></returns>
        private static List<Store_SpecificationTitles> GetStore_SpecificationTitlesCollectionFromOrderDal(List<Store_SpecificationTitlesDetails> records)
        {
            List<Store_SpecificationTitles> items = new List<Store_SpecificationTitles>();
            foreach (Store_SpecificationTitlesDetails item in records)
                items.Add(GetStore_SpecificationTitlesFromOrderDal(item)); 
            return items;
        }

        /// <summary>
        /// تبدیل داده لایه دیتا به داده لایه تجاری
        /// </summary>
        /// <param name="record">رکورد ورودی حاوی داده لایه دیتا</param>
        /// <returns></returns>
        private static Store_SpecificationTitles GetStore_SpecificationTitlesFromOrderDal(Store_SpecificationTitlesDetails record)
        {
            if (record != null)
                return new Store_SpecificationTitles(record.SpecificationTitleId,record.SpecificationGroupId,record.Name,record.Description,record.DomainId,record.LanguageId);
            return null;
        }

        #endregion
    }
}
