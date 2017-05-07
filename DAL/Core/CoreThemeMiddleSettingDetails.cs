using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pine.Dal.Core
{
   public class CoreThemeMiddleSettingDetails
   {

       #region Properties
       public Int32 MasterPageNameId { get; set; }
       public Int32 ThemeSettingId { get; set; }
       public Int32 DomainId { get; set; }
       public Int32 LanguageId { get; set; }
       #endregion


       #region constructor
       public CoreThemeMiddleSettingDetails() { }
       public CoreThemeMiddleSettingDetails(Int32 masterPageNameId, Int32 themeSettingId, Int32 domainId, Int32 languageId) 
       {
           MasterPageNameId = masterPageNameId;
           ThemeSettingId = themeSettingId;
           DomainId = domainId;
           LanguageId = languageId;
       }
       #endregion
   }
}
