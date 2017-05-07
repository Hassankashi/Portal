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
    public class Store_TagGroups : BaseStore
    { 
        
        #region Constructors (2)

          public Store_TagGroups(Guid tagGroupId, String name, String description, Int32 domainId, Int32 languageId)
        {

           
            TagGroupId = tagGroupId;
            Name = name;
            Description = description;
            DomainId = domainId;
            LanguageId = languageId;

        }
     
        /// <summary>
        /// سازنده پیش فرض کلاس جزئیات تنظیمات طرح
        /// </summary>
          public Store_TagGroups() 
        {
            CacheDuration = Settings.CacheDuration;
            MasterCacheKey = "Store";
        }
         
       #endregion Constructors

        #region Properties (4)

          public Guid TagGroupId { get; set; }


          public String Name { get; set; }

          public String Description { get; set; }

          public Int32 DomainId { get; set; }

          public Int32 LanguageId { get; set; }
        #endregion Properties

        #region Methods(4)

          public List<Store_TagGroups> GetTagGroupsById(Guid id) 
        {
            List<Store_TagGroups> item;

            String key = "Store_TagGroupsId_" + id;

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as List<Store_TagGroups>;
                if (item == null)
                {
                    List<Store_TagGroupsDetails> recordSet = SiteProvider.Store.GetTagGroupsById(id);
                    item = GetStore_TagGroupsCollectionFromOrderDal(recordSet);
                    AddCacheItem(key, item);
                }
            }
            else
            {
                List<Store_TagGroupsDetails> recordSet = SiteProvider.Store.GetTagGroupsById(id);
                item = GetStore_TagGroupsCollectionFromOrderDal(recordSet);
            }
            return item;
        }

          public Int32 insertTagGroups()
          {
              return insertTagGroups(TagGroupId, Name, Description, DomainId, LanguageId);
          }

          private Int32 insertTagGroups(Guid tagGroupId, String name, String description, Int32 domainId, Int32 languageId)
          {
              Store_TagGroupsDetails Store_TagGroups = new Store_TagGroupsDetails(TagGroupId, Name, Description, DomainId,LanguageId);
              Int32 ret = SiteProvider.Store.insertTagGroups(Store_TagGroups);
              if (Settings.EnableCaching & ret > 0)
                  InvalidateCache();
              return ret;
          }

          public Boolean UpdateTabDescriptions()
          {
              return UpdateTabDescriptions(TagGroupId, Name, Description, DomainId, LanguageId);
          }

          private Boolean UpdateTabDescriptions(Guid tagGroupId, String name, String description, Int32 domainId, Int32 languageId)
          {
              Store_TagGroupsDetails Store_TagGroups = new Store_TagGroupsDetails(TagGroupId, Name, Description, DomainId, LanguageId);
              Boolean ret = SiteProvider.Store.UpdateTagGroups(Store_TagGroups);
              if (Settings.EnableCaching & ret)
                  InvalidateCache();
              return ret;
          }

          public bool DeleteTagGroups(Guid Id)
          {


              Boolean ret = SiteProvider.Store.DeleteTagGroups(Id); 
              if (Settings.EnableCaching & ret)
                  InvalidateCache();
              return ret;
          } 





        //    /// <summary>
        //    /// تبدیل داده های لایه دیتا به داده های لایه تجاری 
        //    /// </summary>
        //    /// <param name="records">رکوردهای ورودی حاوی داده های لایه دیتا</param>
        //    /// <returns></returns>
          private static List<Store_TagGroups> GetStore_TagGroupsCollectionFromOrderDal(List<Store_TagGroupsDetails> records)
        {
            List<Store_TagGroups> items = new List<Store_TagGroups>();
            foreach (Store_TagGroupsDetails item in records)
                items.Add(GetStore_TagGroupsFromOrderDal(item)); 
            return items;
        }

        /// <summary>
        /// تبدیل داده لایه دیتا به داده لایه تجاری
        /// </summary>
        /// <param name="record">رکورد ورودی حاوی داده لایه دیتا</param>
        /// <returns></returns>
          private static Store_TagGroups GetStore_TagGroupsFromOrderDal(Store_TagGroupsDetails record)
        {
            if (record != null)
                return new Store_TagGroups(record.TagGroupId,record.Name,record.Description,record.DomainId,record.LanguageId);
            return null;
        }

        #endregion
    }
}
