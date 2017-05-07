using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pine.Dal;
using Pine.Dal.Core;

namespace Pine.Bll.Core
{
   public class CorePages : BaseCore
    {
        #region properties

      public Int32 PageId { get; set; }
      public Int32 MasterPageNameId { get; set; }
      public Boolean IsDefault { get; set; }
      public String PageName { get; set; }
      public Int32 DomainId { get; set; }
      public Int32 LanguageId { get; set; }

      #endregion

      #region constructor

      public CorePages()
      {
          CacheDuration = Settings.CacheDuration;
          MasterCacheKey = "Core";
      }

      public CorePages(Int32 pageId, Int32 masterPageNameId, Boolean isDefault, String pageName, Int32 domainId, Int32 languageId)
      {
          PageId = pageId;
          MasterPageNameId = masterPageNameId;
          IsDefault = isDefault;
          PageName = pageName;
          DomainId = domainId;
          LanguageId = languageId;
      
      }

      #endregion

        #region Method
      public Int32 Insert()
      {
          return Insert(PageId, MasterPageNameId, IsDefault, PageName, DomainId, LanguageId);
      }

      private Int32 Insert(Int32 pageId, Int32 masterPageNameId, Boolean isDefault, String pageName, Int32 domainId, Int32 languageId)
      {
          CorePagesDetails corePagesDetails = new CorePagesDetails(pageId, masterPageNameId, isDefault, pageName, domainId, languageId);
          Int32 ret = SiteProvider.Core.InsertCorePages(corePagesDetails);
          if (Settings.EnableCaching & ret > 0)
              InvalidateCache();
          return ret;
      }

      public bool Update()
      {
          return Update(PageId, MasterPageNameId, IsDefault, PageName, DomainId, LanguageId);
      }

      private Boolean Update(Int32 pageId, Int32 masterPageNameId, Boolean isDefault, String pageName, Int32 domainId, Int32 languageId)
      {
          CorePagesDetails corePagesDetails = new CorePagesDetails(pageId, masterPageNameId, isDefault, pageName, domainId, languageId);
          Boolean ret = SiteProvider.Core.UpdateCorePages(corePagesDetails);
          if (Settings.EnableCaching & ret)
              InvalidateCache();
          return ret;
      }


      public bool Delete()
      {
          return Delete(PageId, MasterPageNameId, IsDefault, PageName, DomainId, LanguageId);
      }

      private bool Delete(Int32 pageId, Int32 masterPageNameId, Boolean isDefault, String pageName, Int32 domainId, Int32 languageId)
      {
          CorePagesDetails corePagesDetails = new CorePagesDetails(pageId, masterPageNameId, isDefault, pageName, domainId, languageId);
          bool ret = SiteProvider.Core.DeleteCorePages(corePagesDetails.PageId);
          if (Settings.EnableCaching & ret)
              InvalidateCache();
          return ret;
      }


      public static List<CorePages> GetCorePages()
      {

          SetCache();
          List<CorePages> item;

          String key = "CorePages";

          if (Settings.EnableCaching)
          {
              item = GetCacheItem(key) as List<CorePages>;
              if (item == null)
              {
                  List<CorePagesDetails> recordSet = SiteProvider.Core.GetCorePages();
                  item = GetCorePagesCollectionFromOrderDal(recordSet);
                  AddCacheItem(key, item);
              }
          }
          else
          {
              List<CorePagesDetails> recordSet = SiteProvider.Core.GetCorePages();
              item = GetCorePagesCollectionFromOrderDal(recordSet);
          }
          return item;
      }

      private static List<CorePages> GetCorePagesCollectionFromOrderDal(List<CorePagesDetails> recordSet)
      {
          List<CorePages> items = new List<CorePages>();
          foreach (CorePagesDetails item in recordSet)
              items.Add(GetCorePagesFromOrderDal(item));
          return items;
      }

      private static CorePages GetCorePagesFromOrderDal(CorePagesDetails item)
      {
          if (item != null)
              return new CorePages(item.PageId, item.MasterPageNameId, item.IsDefault, item.PageName, item.DomainId,
                                   item.LanguageId);
          return null;
      }
        #endregion 
    }
}
