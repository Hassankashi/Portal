using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pine.Dal;
using Pine.Dal.Core;

namespace Pine.Bll.Core
{
   public class CoreMasterPageNameCoreAccessPage : BaseCore
    {

        #region Properties

       public int MasterPageNameId { get; set; }
       public String PathSmallImage { get; set; }
       public String PathImage { get; set; }
       public String NameImage { get; set; }
       public String Username { get; set; }
      
       #endregion

       #region constructor
       public CoreMasterPageNameCoreAccessPage(int masterPageNameId, String pathSmallImage, String pathImage, String nameImage, String username)
       {
           MasterPageNameId = masterPageNameId;
           PathSmallImage = pathSmallImage;
           PathImage = pathImage;
           NameImage = nameImage;
           Username = username;
       }

       public CoreMasterPageNameCoreAccessPage( )
       {
           CacheDuration = Settings.CacheDuration;
           MasterCacheKey = "Core";
       }

#endregion

        #region Method
       public static List<CoreMasterPageNameCoreAccessPage> GetCoreMasterPageNameCoreAccessPage(String userName)
       {

           SetCache();
           List<CoreMasterPageNameCoreAccessPage> item;

           String key = "CoreMasterPageNameCoreAccessPage_userName_" + userName;

           if (Settings.EnableCaching)
           {
               item = GetCacheItem(key) as List<CoreMasterPageNameCoreAccessPage>;
               if (item == null)
               {
                   List<CoreMasterPageNameCoreAccessPageDetails> recordSet = SiteProvider.Core.GetCoreMasterPageNameCoreAccessPage(userName);
                   item = GetCoreMasterPageNameCoreAccessPageCollectionFromOrderDal(recordSet);
                   AddCacheItem(key, item);
               }
           }
           else
           {
               List<CoreMasterPageNameCoreAccessPageDetails> recordSet = SiteProvider.Core.GetCoreMasterPageNameCoreAccessPage(userName);
               item = GetCoreMasterPageNameCoreAccessPageCollectionFromOrderDal(recordSet);
           }
           return item;
       }

 public static List<CoreMasterPageNameCoreAccessPage> GetCoreMasterPageNameCoreAccessPage(string userName, int masterPageNameId)
       {

           SetCache();
           List<CoreMasterPageNameCoreAccessPage> item;

           String key = "CoreMasterPageNameCoreAccessPage_userName_masterPageNameId_" + userName + "_" + masterPageNameId;

           if (Settings.EnableCaching)
           {
               item = GetCacheItem(key) as List<CoreMasterPageNameCoreAccessPage>;
               if (item == null)
               {
                   List<CoreMasterPageNameCoreAccessPageDetails> recordSet = SiteProvider.Core.GetCoreMasterPageNameCoreAccessPage( userName, masterPageNameId);
                   item = GetCoreMasterPageNameCoreAccessPageCollectionFromOrderDal(recordSet);
                   AddCacheItem(key, item);
               }
           }
           else
           {
               List<CoreMasterPageNameCoreAccessPageDetails> recordSet = SiteProvider.Core.GetCoreMasterPageNameCoreAccessPage( userName, masterPageNameId);
               item = GetCoreMasterPageNameCoreAccessPageCollectionFromOrderDal(recordSet);
           }
           return item;
       }

       private static List<CoreMasterPageNameCoreAccessPage> GetCoreMasterPageNameCoreAccessPageCollectionFromOrderDal(List<CoreMasterPageNameCoreAccessPageDetails> recordSet)
       {
           List<CoreMasterPageNameCoreAccessPage> items = new List<CoreMasterPageNameCoreAccessPage>();
           foreach (CoreMasterPageNameCoreAccessPageDetails item in recordSet)
               items.Add(GetCoreMasterPageNameCoreAccessPageFromOrderDal(item));
           return items;
       }

       private static CoreMasterPageNameCoreAccessPage GetCoreMasterPageNameCoreAccessPageFromOrderDal(CoreMasterPageNameCoreAccessPageDetails item)
       {
           if (item != null)
               return new CoreMasterPageNameCoreAccessPage(item.MasterPageNameId,item.PathSmallImage,item.PathImage,item.NameImage,item.Username);
           return null;
       }
        #endregion
    }
}
