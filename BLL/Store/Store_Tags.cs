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
    public class Store_Tags : BaseStore
    { 
        
        #region Constructors (2)

         public Store_Tags(Guid tagId, Guid tagGroupId, String name,  Int32 domainId, Int32 languageId)
        {

            TagId = tagId;
            TagGroupId = tagGroupId;
            Name = name;
             
            DomainId = domainId;
            LanguageId = languageId;

        }

     
        /// <summary>
        /// سازنده پیش فرض کلاس جزئیات تنظیمات طرح
        /// </summary>
         public Store_Tags() 
        {
            CacheDuration = Settings.CacheDuration;
            MasterCacheKey = "Store";
        }
         
       #endregion Constructors

        #region Properties (4)


         public Guid TagId { get; set; }

         public Guid TagGroupId { get; set; }

         public String Name { get; set; }


         public Int32 DomainId { get; set; }

         public Int32 LanguageId { get; set; }
        #endregion Properties

        #region Methods(4)

         public List<Store_Tags> GetTagsById(Guid id) 
        {
            List<Store_Tags> item;

            String key = "Store_TagsId_" + id;

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as List<Store_Tags>;
                if (item == null)
                {
                    List<Store_TagsDetails> recordSet = SiteProvider.Store.GetTagsById(id);
                    item = GetStore_TagsCollectionFromOrderDal(recordSet);
                    AddCacheItem(key, item);
                }
            }
            else
            {
                List<Store_TagsDetails> recordSet = SiteProvider.Store.GetTagsById(id);
                item = GetStore_TagsCollectionFromOrderDal(recordSet);
            }
            return item;
        }

         public Int32 insertTags()
          {
              return insertTags(TagId, TagGroupId, Name, DomainId, LanguageId);
          }

         private Int32 insertTags(Guid tagId, Guid tagGroupId, String name, Int32 domainId, Int32 languageId)
          {
              Store_TagsDetails Store_Tags = new Store_TagsDetails(tagId, TagGroupId, Name, DomainId, LanguageId);
              Int32 ret = SiteProvider.Store.insertTags(Store_Tags);
              if (Settings.EnableCaching & ret > 0)
                  InvalidateCache();
              return ret;
          }

         public Boolean UpdateTags()
          {
              return UpdateTags(TagId, TagGroupId, Name, DomainId, LanguageId);
          }

         private Boolean UpdateTags(Guid tagId, Guid tagGroupId, String name, Int32 domainId, Int32 languageId)
          {
              Store_TagsDetails Store_Tags = new Store_TagsDetails(TagId, TagGroupId, Name, DomainId, LanguageId);
              Boolean ret = SiteProvider.Store.UpdateTags(Store_Tags);
              if (Settings.EnableCaching & ret)
                  InvalidateCache();
              return ret;
          }

          public bool DeleteTags(Guid Id)
          {


              Boolean ret = SiteProvider.Store.DeleteTags(Id); 
              if (Settings.EnableCaching & ret)
                  InvalidateCache();
              return ret;
          } 





        //    /// <summary>
        //    /// تبدیل داده های لایه دیتا به داده های لایه تجاری 
        //    /// </summary>
        //    /// <param name="records">رکوردهای ورودی حاوی داده های لایه دیتا</param>
        //    /// <returns></returns>
          private static List<Store_Tags> GetStore_TagsCollectionFromOrderDal(List<Store_TagsDetails> records)
        {
            List<Store_Tags> items = new List<Store_Tags>();
            foreach (Store_TagsDetails item in records)
                items.Add(GetStore_TagsFromOrderDal(item)); 
            return items;
        }

        /// <summary>
        /// تبدیل داده لایه دیتا به داده لایه تجاری
        /// </summary>
        /// <param name="record">رکورد ورودی حاوی داده لایه دیتا</param>
        /// <returns></returns>
          private static Store_Tags GetStore_TagsFromOrderDal(Store_TagsDetails record)
        {
            if (record != null)
                return new Store_Tags(record.TagId,record.TagGroupId,record.Name,record.DomainId,record.LanguageId);
            return null;
        }

        #endregion
    }
}
