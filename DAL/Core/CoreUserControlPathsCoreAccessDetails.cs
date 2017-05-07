using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pine.Dal.Core
{
   public class CoreUserControlPathsCoreAccessDetails
    {
       public  CoreUserControlPathsCoreAccessDetails()
       {
       }

       public CoreUserControlPathsCoreAccessDetails(Int32 userControlNameId, String name, Int32 userControlPathId, String username, Boolean isQueryString , String path)
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
    }
}
