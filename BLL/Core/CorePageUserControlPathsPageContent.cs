using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pine.Dal;
using Pine.Dal.Core;

namespace Pine.Bll.Core
{
  public  class CorePageUserControlPathsPageContent : BaseCore
    {

       public CorePageUserControlPathsPageContent()
      {

      }

      public CorePageUserControlPathsPageContent(Int32 pageId,Int32 userControlPathId,String queryString,String pageName,Boolean isQueryString,Boolean isDefault)
      {
          PageId = pageId;
          UserControlPathId = userControlPathId;
          QueryString = queryString;
          PageName = pageName;
          IsQueryString = isQueryString;
          IsDefault = isDefault;
      }

       public Int32 PageId { get; set; }
       public Int32 UserControlPathId { get; set; }
       public String QueryString { get; set; }
       public String PageName { get; set; }
       public Boolean IsQueryString { get; set; }
       public Boolean IsDefault { get; set; }

       public static List<CorePageUserControlPathsPageContent> GetCorePageUserControlPathsPageContent(string queryString)
       {

           SetCache();
           List<CorePageUserControlPathsPageContent> item;

           String key = "CorePageUserControlPathsPageContent_queryString_" + queryString ;

           if (Settings.EnableCaching)
           {
               item = GetCacheItem(key) as List<CorePageUserControlPathsPageContent>;
               if (item == null)
               {
                   List<CorePageUserControlPathsPageContentDetails> recordSet = SiteProvider.Core.GetCorePage_UserControlPaths_PageContent(queryString);
                   item = GetCorePageUserControlPathsPageContentCollectionFromOrderDal(recordSet);
                   AddCacheItem(key, item);
               }
           }
           else
           {
               List<CorePageUserControlPathsPageContentDetails> recordSet = SiteProvider.Core.GetCorePage_UserControlPaths_PageContent(queryString);
               item = GetCorePageUserControlPathsPageContentCollectionFromOrderDal(recordSet);
           }
           return item;
       }

       private static List<CorePageUserControlPathsPageContent> GetCorePageUserControlPathsPageContentCollectionFromOrderDal(List<CorePageUserControlPathsPageContentDetails> recordSet)
       {
           List<CorePageUserControlPathsPageContent> items = new List<CorePageUserControlPathsPageContent>();
           foreach (CorePageUserControlPathsPageContentDetails item in recordSet)
               items.Add(GetCorePageUserControlPathsPageContentFromOrderDal(item));
           return items;
       }

       private static CorePageUserControlPathsPageContent GetCorePageUserControlPathsPageContentFromOrderDal(CorePageUserControlPathsPageContentDetails item)
       {
           if (item != null)
               return new CorePageUserControlPathsPageContent(item.PageId, item.UserControlPathId, item.QueryString,
                                                              item.PageName, item.IsQueryString, item.IsDefault);
           return null;
       }

     
    }
}
