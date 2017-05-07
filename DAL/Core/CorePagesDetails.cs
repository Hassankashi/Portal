using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pine.Dal.Core
{
  public class CorePagesDetails
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

      public CorePagesDetails() { }

      public CorePagesDetails(Int32 pageId, Int32 masterPageNameId, Boolean isDefault, String pageName, Int32 domainId, Int32 languageId)
      {
          PageId = pageId;
          MasterPageNameId = masterPageNameId;
          IsDefault = isDefault;
          PageName = pageName;
          DomainId = domainId;
          LanguageId = languageId;
      
      }

      #endregion
  }
}
