using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pine.Dal;
using Pine.Dal.Core;

namespace Pine.Bll.Core
{
   public class CoreUserControlPathsCoreAccess : BaseCore
    {
       public  CoreUserControlPathsCoreAccess()
       {
           CacheDuration = Settings.CacheDuration;
           MasterCacheKey = "Core";
       }

       public CoreUserControlPathsCoreAccess(Int32 userControlNameId, String name, Int32 userControlPathId, String username, Boolean isQueryString, String path)
       {
           UserControlNameId = userControlNameId;
           Name = name;
           UserControlPathId = userControlPathId;
           Username = username;
           IsQueryString = isQueryString;
           Path = path;
       }

      
#region Properties

        public Int32 UserControlNameId { get; set; }
        public String Name   { get; set; }
        public Int32 UserControlPathId { get; set; }
        public String Username { get; set; }
        public Boolean IsQueryString { get; set; }
        public String Path { get; set; }
     
       #endregion


        public static List<CoreUserControlPathsCoreAccess> GetCoreUserControlPathsCoreAccess(Int32 userControlNameId)
        {

            SetCache();
            List<CoreUserControlPathsCoreAccess> item;

            String key = "CoreUserControlPathsCoreAccess_userControlNameId_" + userControlNameId;

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as List<CoreUserControlPathsCoreAccess>;
                if (item == null)
                {
                    List<CoreUserControlPathsCoreAccessDetails> recordSet = SiteProvider.Core.GetCoreUserControlPaths_CoreAccess(userControlNameId);
                    item = GetCoreUserControlPathsCoreAccessCollectionFromOrderDal(recordSet);
                    AddCacheItem(key, item);
                }
            }
            else
            {
                List<CoreUserControlPathsCoreAccessDetails> recordSet = SiteProvider.Core.GetCoreUserControlPaths_CoreAccess(userControlNameId);
                item = GetCoreUserControlPathsCoreAccessCollectionFromOrderDal(recordSet);
            }
            return item;
        }


        public static List<CoreUserControlPathsCoreAccess> GetCoreUserControlPathsCoreAccessByPath(String userName, String path)
        {

            SetCache();
            List<CoreUserControlPathsCoreAccess> item;

            String key = "CoreUserControlPathsCoreAccess_userName_path_" + userName + "_" + path;

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as List<CoreUserControlPathsCoreAccess>;
                if (item == null)
                {
                    List<CoreUserControlPathsCoreAccessDetails> recordSet = SiteProvider.Core.GetCoreUserControlPathsCoreAccessByPath(userName,path);
                    item = GetCoreUserControlPathsCoreAccessCollectionFromOrderDal(recordSet);
                    AddCacheItem(key, item);
                }
            }
            else
            {
                List<CoreUserControlPathsCoreAccessDetails> recordSet = SiteProvider.Core.GetCoreUserControlPathsCoreAccessByPath(userName, path);
                item = GetCoreUserControlPathsCoreAccessCollectionFromOrderDal(recordSet);
            }
            return item;
        }

        private static List<CoreUserControlPathsCoreAccess> GetCoreUserControlPathsCoreAccessCollectionFromOrderDal(List<CoreUserControlPathsCoreAccessDetails> recordSet)
        {
            List<CoreUserControlPathsCoreAccess> items = new List<CoreUserControlPathsCoreAccess>();
            foreach (CoreUserControlPathsCoreAccessDetails item in recordSet)
                items.Add(GetCoreUserControlPathsCoreAccessFromOrderDal(item));
            return items;
        }

        private static CoreUserControlPathsCoreAccess GetCoreUserControlPathsCoreAccessFromOrderDal(CoreUserControlPathsCoreAccessDetails item)
        {
            if (item != null)
                return new CoreUserControlPathsCoreAccess(item.UserControlNameId, item.Name, item.UserControlPathId,
                                                          item.Username, item.IsQueryString,item.Path);
            return null;
        }

    }
}
