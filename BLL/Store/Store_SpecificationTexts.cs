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
    public class Store_SpecificationTexts : BaseStore
    {
        
        #region Constructors (2)

        public Store_SpecificationTexts(Guid specificationTextId, Guid specificationTitleId, String text, String description, Int32 domainId, Int32 languageId, String name)
        {


            SpecificationTextId = specificationTextId;
            SpecificationTitleId = specificationTitleId;
           // ProductId = productId;
            Text = text;
            Description = description;
            DomainId = domainId;
            LanguageId = languageId;
            Name = name;
           
        }
     
        /// <summary>
        /// سازنده پیش فرض کلاس جزئیات تنظیمات طرح
        /// </summary>
        public Store_SpecificationTexts() 
        {
            CacheDuration = Settings.CacheDuration;
            MasterCacheKey = "Store";
        }

       #endregion Constructors

        #region Properties (4)

        public Guid SpecificationTextId { get; set; }

        public Guid SpecificationTitleId { get; set; }

      //  public Guid ProductId { get; set; }

        public String Text { get; set; }

        public String Description { get; set; }


        public Int32 DomainId { get; set; }

        public Int32 LanguageId { get; set; }

        public String Name { get; set; }

        


        #endregion Properties

        #region Methods(4)

        public static Store_SpecificationTexts GetSpecificationTextsById(Guid id)
        {
            Store_SpecificationTexts item;

            String key = "Store_SpecificationText_Id_" + id;

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as Store_SpecificationTexts;
                if (item == null)
                {
                    Store_SpecificationTextsDetails recordSet = SiteProvider.Store.GetSpecificationTextsById(id);
                    item = GetStore_SpecificationTextsFromOrderDal(recordSet);
                    AddCacheItem(key, item);
                }
            }
            else
            {
                Store_SpecificationTextsDetails recordSet = SiteProvider.Store.GetSpecificationTextsById(id);
                item = GetStore_SpecificationTextsFromOrderDal(recordSet);
            }
            return item;
        }

        public static List<Store_SpecificationTexts> GetSpecificationTextsBySpecificationTextIdAndSpecificationTitleId(Guid specificationTextId, Guid specificationTitleId)
        {
            List<Store_SpecificationTexts> item;

            String key = "Store_SpecificationText_TextIdAndTitleId" + specificationTextId + specificationTitleId;

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as List<Store_SpecificationTexts>;
                if (item == null)
                {
                    List<Store_SpecificationTextsDetails> recordSet = SiteProvider.Store.GetSpecificationTextsBySpecificationTextIdAndSpecificationTitleId(specificationTextId,specificationTitleId);
                    item = GetStore_SpecificationTextsCollectionFromOrderDal(recordSet);
                    AddCacheItem(key, item);
                }
            }
            else
            {
                List<Store_SpecificationTextsDetails> recordSet = SiteProvider.Store.GetSpecificationTextsBySpecificationTextIdAndSpecificationTitleId(specificationTextId, specificationTitleId);
                item = GetStore_SpecificationTextsCollectionFromOrderDal(recordSet);
            }
            return item;
        }
        public static List<Store_SpecificationTexts> GetSpecificationTextsByGroups(Guid groupId)
        {
            List<Store_SpecificationTexts> item;

            String key = "Store_SpecificationText_GroupId"+ groupId ;

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as List<Store_SpecificationTexts>;
                if (item == null)
                {
                    List<Store_SpecificationTextsDetails> recordSet = SiteProvider.Store.GetSpecificationTextsByGroups(groupId);
                    item = GetStore_SpecificationTextsCollectionFromOrderDal(recordSet);
                    AddCacheItem(key, item);
                }
            }
            else
            {
                List<Store_SpecificationTextsDetails> recordSet = SiteProvider.Store.GetSpecificationTextsByGroups(groupId);
                item = GetStore_SpecificationTextsCollectionFromOrderDal(recordSet);
            }
            return item;
        }
        public static List<Store_SpecificationTexts> GetAllSpecificationTexts()
        {
            List<Store_SpecificationTexts> item;

            String key = "Store_SpecificationText_GetSAll" ;

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as List<Store_SpecificationTexts>;
                if (item == null)
                {
                    List<Store_SpecificationTextsDetails> recordSet = SiteProvider.Store.GetAllSpecificationTexts();
                    item = GetStore_SpecificationTextsCollectionFromOrderDal(recordSet);
                    AddCacheItem(key, item);
                }
            }
            else
            {
                List<Store_SpecificationTextsDetails> recordSet = SiteProvider.Store.GetAllSpecificationTexts();
                item = GetStore_SpecificationTextsCollectionFromOrderDal(recordSet);
            }
            return item;
        }

        public Int32 insertSpecificationTexts()
        {
            return insertSpecificationTexts(SpecificationTextId, SpecificationTitleId, Text, Description, DomainId,LanguageId,Name);
        }

        private Int32 insertSpecificationTexts(Guid specificationTextId, Guid specificationTitleId, String text, String description, Int32 domainId, Int32 languageId, String name)
        {
            Store_SpecificationTextsDetails Store_SpecificationTexts = new Store_SpecificationTextsDetails();
            Int32 ret = SiteProvider.Store.insertSpecificationTexts(Store_SpecificationTexts); 
            if (Settings.EnableCaching & ret > 0)
                InvalidateCache();
            return ret;
        }

        public Boolean UpdateSpecificationTexts()
        {
            return UpdateSpecificationTexts(SpecificationTextId, SpecificationTitleId, Text, Description, DomainId,LanguageId,Name);
        }

        private Boolean UpdateSpecificationTexts(Guid specificationTextId, Guid specificationTitleId, String text, String description, Int32 domainId, Int32 languageId, String name)
        {
            Store_SpecificationTextsDetails Store_SpecificationTexts = new Store_SpecificationTextsDetails();
            Boolean ret = SiteProvider.Store.UpdateSpecificationTexts(Store_SpecificationTexts);
            if (Settings.EnableCaching & ret)
                InvalidateCache();
            return ret;
        }

        public bool DeleteSpecificationTexts(Guid Id) 
        {


            Boolean ret = SiteProvider.Store.DeleteSpecificationTexts(Id);
            if (Settings.EnableCaching & ret)
                InvalidateCache();
            return ret;
        }





        //    /// <summary>
        //    /// تبدیل داده های لایه دیتا به داده های لایه تجاری 
        //    /// </summary>
        //    /// <param name="records">رکوردهای ورودی حاوی داده های لایه دیتا</param>
        //    /// <returns></returns>
        private static List<Store_SpecificationTexts> GetStore_SpecificationTextsCollectionFromOrderDal(List<Store_SpecificationTextsDetails> records)
        {
            List<Store_SpecificationTexts> items = new List<Store_SpecificationTexts>();
            foreach (Store_SpecificationTextsDetails item in records)
                items.Add(GetStore_SpecificationTextsFromOrderDal(item)); 
            return items;
        }

        /// <summary>
        /// تبدیل داده لایه دیتا به داده لایه تجاری
        /// </summary>
        /// <param name="record">رکورد ورودی حاوی داده لایه دیتا</param>
        /// <returns></returns>
        private static Store_SpecificationTexts GetStore_SpecificationTextsFromOrderDal(Store_SpecificationTextsDetails record)
        {
            if (record != null)
                return new Store_SpecificationTexts(record.SpecificationTextId,record.SpecificationTitleId,record.Text,record.Description,record.DomainId,record.LanguageId,record.Name);
            return null;
        }

        #endregion
    }
}
