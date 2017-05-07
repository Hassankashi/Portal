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
    public class Store_SpecificationGroup : BaseStore
    {
        
        #region Constructors (2)

        public Store_SpecificationGroup(Guid specificationGroupId, String name, Int32 domainId, Int32 languageId)
        {


            SpecificationGroupId = specificationGroupId;
            Name = name;
          
            DomainId = domainId;
            LanguageId = languageId;

        }
     
        /// <summary>
        /// سازنده پیش فرض کلاس جزئیات تنظیمات طرح
        /// </summary>
        public Store_SpecificationGroup() 
        {
            CacheDuration = Settings.CacheDuration;
            MasterCacheKey = "Store";
        }

       #endregion Constructors

        #region Properties (4)

        public Guid SpecificationGroupId { get; set; }


        public String Name { get; set; }


        public Int32 DomainId { get; set; }

        public Int32 LanguageId { get; set; }

        #endregion Properties

        #region Methods(4)

        public static Store_SpecificationGroup GetSpecificationGroupsById(Guid id)
        {
            Store_SpecificationGroup item;

            String key = "Store_SpecificationGroup_Id_" + id;

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as Store_SpecificationGroup;
                if (item == null)
                {
                    Store_SpecificationGroupsDetails recordSet = SiteProvider.Store.GetSpecificationGroupsById(id);
                    item = GetStore_SpecificationGroupFromOrderDal(recordSet);
                    AddCacheItem(key, item);
                }
            }
            else
            {
                Store_SpecificationGroupsDetails recordSet = SiteProvider.Store.GetSpecificationGroupsById(id);
                item = GetStore_SpecificationGroupFromOrderDal(recordSet);
            }
            return item;
        }


        public static List<Store_SpecificationGroup> GetAllSpecificationGroups()
        {
            List<Store_SpecificationGroup> item;

            String key = "Store_SpecificationGroup_GetAll";

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as List<Store_SpecificationGroup>;
                if (item == null)
                {
                    List<Store_SpecificationGroupsDetails> recordSet = SiteProvider.Store.GetAllSpecificationGroups();
                    item = GetStore_SpecificationGroupCollectionFromOrderDal(recordSet);
                    AddCacheItem(key, item);
                }
            }
            else
            {
                List<Store_SpecificationGroupsDetails> recordSet = SiteProvider.Store.GetAllSpecificationGroups();
                item = GetStore_SpecificationGroupCollectionFromOrderDal(recordSet);
            }
            return item;
        }

        public Int32 insertSpecificationGroups()
        {
            return insertSpecificationGroups(SpecificationGroupId, Name, DomainId, LanguageId);
        }

        private Int32 insertSpecificationGroups(Guid specificationGroupId, String name, Int32 domainId, Int32 languageId)
        {
            Store_SpecificationGroupsDetails Store_SpecificationGroups = new Store_SpecificationGroupsDetails( specificationGroupId,  name,  domainId,  languageId);
            Int32 ret = SiteProvider.Store.insertSpecificationGroups(Store_SpecificationGroups);
            if (Settings.EnableCaching & ret > 0)
                InvalidateCache();
            return ret;
        }

        public Boolean UpdateSpecificationGroups()
        {
            return UpdateSpecificationGroups(SpecificationGroupId, Name, DomainId, LanguageId);
        }

        private Boolean UpdateSpecificationGroups(Guid specificationGroupId, String name, Int32 domainId, Int32 languageId)
        {
            Store_SpecificationGroupsDetails Store_SpecificationGroups = new Store_SpecificationGroupsDetails(SpecificationGroupId, Name, DomainId, LanguageId);
            Boolean ret = SiteProvider.Store.UpdateSpecificationGroups(Store_SpecificationGroups);
            if (Settings.EnableCaching & ret)
                InvalidateCache();
            return ret;
        }

        public bool DeleteSpecificationGroups(Guid Id) 
        {


            Boolean ret = SiteProvider.Store.DeleteSpecificationGroups(Id); 
            if (Settings.EnableCaching & ret)
                InvalidateCache();
            return ret;
        }





        //    /// <summary>
        //    /// تبدیل داده های لایه دیتا به داده های لایه تجاری 
        //    /// </summary>
        //    /// <param name="records">رکوردهای ورودی حاوی داده های لایه دیتا</param>
        //    /// <returns></returns>
        private static List<Store_SpecificationGroup> GetStore_SpecificationGroupCollectionFromOrderDal(List<Store_SpecificationGroupsDetails> records)
        {
            List<Store_SpecificationGroup> items = new List<Store_SpecificationGroup>();
            foreach (Store_SpecificationGroupsDetails item in records)
                items.Add(GetStore_SpecificationGroupFromOrderDal(item)); 
            return items;
        }

        /// <summary>
        /// تبدیل داده لایه دیتا به داده لایه تجاری
        /// </summary>
        /// <param name="record">رکورد ورودی حاوی داده لایه دیتا</param>
        /// <returns></returns>
        private static Store_SpecificationGroup GetStore_SpecificationGroupFromOrderDal(Store_SpecificationGroupsDetails record)
        {
            if (record != null)
                return new Store_SpecificationGroup(record.SpecificationGroupId,record.Name,record.DomainId,record.LanguageId);
            return null;
        }

        #endregion
    }
}
