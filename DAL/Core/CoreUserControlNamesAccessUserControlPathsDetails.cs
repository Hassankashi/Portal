using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pine.Dal.Core
{
   public class CoreUserControlNamesAccessUserControlPathsDetails
    {
       public CoreUserControlNamesAccessUserControlPathsDetails()
       {

       }

       public CoreUserControlNamesAccessUserControlPathsDetails(Int32 userControlNameId, Int32 userControlPathId, String userControlName, String username, Boolean isQueryString)
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
    }
}
