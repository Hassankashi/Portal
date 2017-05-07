using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pine.Dal.Core
{
   public class CorePageUserControlPathsPageContentDetails
    {
      public CorePageUserControlPathsPageContentDetails()
      {
      }

      public CorePageUserControlPathsPageContentDetails(Int32 pageId,Int32 userControlPathId,String queryString,String pageName,Boolean isQueryString,Boolean isDefault)
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
      

    }
}
