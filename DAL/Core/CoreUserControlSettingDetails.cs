using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pine.Dal.Core
{
  public  class CoreUserControlSettingDetails
  {
      #region Properties
      public Int32 UserControlSettingId { get; set; }
      public Int32 UserControlPathId { get; set; }
      public String UserControlParameter { get; set; }
      public String UserControlValue { get; set; }
      public Int32 DomainId { get; set; }
      public Int32 LanguageId { get; set; }
      #endregion

      #region constructor
      public CoreUserControlSettingDetails() { }

      public CoreUserControlSettingDetails(Int32 userControlSettingId, Int32 userControlPathId, String userControlParameter, String userControlValue, Int32 domainId, Int32 languageId)
      {
          UserControlSettingId = userControlSettingId;
          UserControlPathId = userControlPathId;
          UserControlParameter = userControlParameter;
          UserControlValue = userControlValue;
          DomainId = domainId;
          LanguageId = languageId;
      
      
      }

      #endregion


  }
}
