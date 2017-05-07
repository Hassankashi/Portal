using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pine.Dal.Core
{
   public class CoreUserControlPathDetails
   {
       #region properties
       public Int32 UserControlPathId { get; set; }
       public Int32 UserControlNameId { get; set; }
       public String Path { get; set; }
       public String Name { get; set; }
       public Boolean IsQueryString { get; set; }
       public String QueryString { get; set; }
       public Boolean IsGroups { get; set; }
       public String Parameter { get; set; }
       public String AdminSetting { get; set; }
       public String AdminInsert { get; set; }
       public Int32? DefaltValue { get; set; }
       public Int32? OrderBy { get; set; }
       public Boolean Visible { get; set; }
       public String LocationName { get; set; }
       public Int32 DomainId { get; set; }
       public Int32 LanguageId { get; set; }
     
       #endregion

       #region Constructor
       public CoreUserControlPathDetails()
       {
           
       }

       public CoreUserControlPathDetails(Int32 userControlPathId, Int32 userControlNameId, String path, String name, Boolean isQueryString, String queryString,
          Boolean isGroups, String parameter, String adminSetting, String adminInsert, Int32? defaltValue, Int32? orderBy, Boolean visible, String locationName, Int32 domainId, Int32 languageId)
       {
           UserControlPathId = userControlPathId;
           UserControlNameId = userControlNameId;
           Path = path;
           Name = name;
           IsQueryString = isQueryString;
           QueryString = queryString;
           IsGroups = isGroups;
           Parameter = parameter;
           AdminSetting = adminSetting;
           AdminInsert = adminInsert;
           DefaltValue = defaltValue;
           OrderBy = orderBy;
           Visible = visible;
           LocationName = locationName;
           DomainId = domainId;
           LanguageId = languageId;
       }
       #endregion
   }
}
