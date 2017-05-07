using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pine.Dal.Core
{
  public  class CoreUserControlNamesDetails
  {
      #region properties
      public Int32 UserControlNameId { get; set; }
      public String UserControlName { get; set; }
      public Int32 DomainId { get; set; }
      public Int32 LanguageId { get; set; }
      #endregion 

      #region Constructor

      public CoreUserControlNamesDetails()
      { }

      public CoreUserControlNamesDetails(Int32 userControlNameId, String userControlName, Int32 domainId, Int32 languageId)
      {
          UserControlNameId = userControlNameId;
          UserControlName = userControlName;
          DomainId = domainId;
          LanguageId = languageId;
           
      }

      #endregion
  }
}
