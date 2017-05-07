using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pine.Dal.Core
{
   public class CoreThemeSettingTypeDetails
   {

       #region properties
       public Int32 ThemeSettingTypeId { get; set; }
       public String Parameter { get; set; }
       public String Name { get; set; }
       public Int32 DomainId { get; set; }
       public Int32 LanguageId { get; set; }

       #endregion 

       #region constructor
       public CoreThemeSettingTypeDetails() { }

       public CoreThemeSettingTypeDetails(Int32 themeSettingTypeId, String parameter, String name, Int32 domainId, Int32 languageId) 
       {
           ThemeSettingTypeId = themeSettingTypeId;
           Parameter = parameter;
           Name = name;
           DomainId = domainId;
           LanguageId = languageId;
       
       }
       #endregion 
   }
}
