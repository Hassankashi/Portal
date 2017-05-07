using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pine.Dal;
using Pine.Dal.Core;

namespace Pine.Bll.Core
{
   public class CoreUserControlNamesAccessUserControlPaths : BaseCore
    {
        public CoreUserControlNamesAccessUserControlPaths()
       {

       }

       public CoreUserControlNamesAccessUserControlPaths(Int32 userControlNameId, Int32 userControlPathId, String userControlName, String username, Boolean isQueryString)
       {
           UserControlNameId = userControlNameId;
           UserControlPathId = userControlPathId;
           UserControlName = userControlName;
           Username = username;
           IsQueryString = isQueryString;
       }

     #region properties

        public Int32 UserControlNameId { get; set; }
        public Int32 UserControlPathId { get; set; }
        public String UserControlName { get; set; }
        public String Username { get; set; }
        public Boolean IsQueryString { get; set; } 

#endregion

#region Method

        public static List<CoreUserControlNamesAccessUserControlPaths> GetCoreUserControlNamesAccessUserControlPaths(String username)
        {

            SetCache();
            List<CoreUserControlNamesAccessUserControlPaths> item;

            String key = "CoreUserControlNamesAccessUserControlPaths_username_" + username;

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as List<CoreUserControlNamesAccessUserControlPaths>;
                if (item == null)
                {
                    List<CoreUserControlNamesAccessUserControlPathsDetails> recordSet = SiteProvider.Core.GetCoreUserControlNames_Access_UserControlPaths(username);
                    item = GetCoreUserControlNamesAccessUserControlPathsCollectionFromOrderDal(recordSet);
                    AddCacheItem(key, item);
                }
            }
            else
            {
                List<CoreUserControlNamesAccessUserControlPathsDetails> recordSet = SiteProvider.Core.GetCoreUserControlNames_Access_UserControlPaths(username);
                item = GetCoreUserControlNamesAccessUserControlPathsCollectionFromOrderDal(recordSet);
            }
            return item;
        }

        private static List<CoreUserControlNamesAccessUserControlPaths> GetCoreUserControlNamesAccessUserControlPathsCollectionFromOrderDal(List<CoreUserControlNamesAccessUserControlPathsDetails> recordSet)
        {
            List<CoreUserControlNamesAccessUserControlPaths> items = new List<CoreUserControlNamesAccessUserControlPaths>();
            foreach (CoreUserControlNamesAccessUserControlPathsDetails item in recordSet)
                items.Add(GetCoreUserControlNamesAccessUserControlPathsFromOrderDal(item));
            return items;
        }

        private static CoreUserControlNamesAccessUserControlPaths GetCoreUserControlNamesAccessUserControlPathsFromOrderDal(CoreUserControlNamesAccessUserControlPathsDetails item)
        {
            if (item != null)
                return new CoreUserControlNamesAccessUserControlPaths(item.UserControlNameId, item.UserControlPathId,
                                                                      item.UserControlName, item.Username,
                                                                      item.IsQueryString);
            return null;
        }

#endregion
    }
}
