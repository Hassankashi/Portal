using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pine.Dal;
using Pine.Dal.Core;

namespace Pine.Bll.Core
{
   public class CoreUserControlPaths : BaseCore
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
       public CoreUserControlPaths()
       {
           CacheDuration = Settings.CacheDuration;
           MasterCacheKey = "Core";
       }

       public CoreUserControlPaths(Int32 userControlPathId, Int32 userControlNameId, String path, String name, Boolean isQueryString, String queryString,
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
        #region Method

      public Int32 Insert()
      {
          return Insert(UserControlPathId, UserControlNameId, Path, Name, IsQueryString, QueryString,
           IsGroups, Parameter, AdminSetting, AdminInsert, DefaltValue, OrderBy, Visible, LocationName, DomainId, LanguageId);
      }

      private Int32 Insert(Int32 userControlPathId, Int32 userControlNameId, String path, String name, Boolean isQueryString, String queryString,
          Boolean isGroups, String parameter, String adminSetting, String adminInsert, Int32? defaltValue, Int32? orderBy, Boolean visible, String locationName, Int32 domainId, Int32 languageId)
      {
          CoreUserControlPathDetails coreUserControlPathDetails = new CoreUserControlPathDetails(userControlPathId, userControlNameId, path, name, isQueryString, queryString,
           isGroups, parameter, adminSetting, adminInsert, defaltValue, orderBy, visible, locationName, domainId, languageId);
          Int32 ret = SiteProvider.Core.InsertCoreUserControlPaths
              (coreUserControlPathDetails);
          if (Settings.EnableCaching & ret > 0)
              InvalidateCache();
          return ret;
      }

      public bool Update()
      {
          return Update(UserControlPathId, UserControlNameId, Path, Name, IsQueryString, QueryString,
           IsGroups, Parameter, AdminSetting, AdminInsert, DefaltValue, OrderBy, Visible, LocationName, DomainId, LanguageId);
      }

      private Boolean Update(Int32 userControlPathId, Int32 userControlNameId, String path, String name, Boolean isQueryString, String queryString,
          Boolean isGroups, String parameter, String adminSetting, String adminInsert, Int32? defaltValue, Int32? orderBy, Boolean visible, String locationName, Int32 domainId, Int32 languageId)
      {
          CoreUserControlPathDetails coreUserControlPathDetails = new CoreUserControlPathDetails(userControlPathId, userControlNameId, path, name, isQueryString, queryString,
          isGroups, parameter, adminSetting, adminInsert, defaltValue, orderBy, visible, locationName, domainId, languageId);
          Boolean ret = SiteProvider.Core.UpdateCoreUserControlPaths(coreUserControlPathDetails);
          if (Settings.EnableCaching & ret)
              InvalidateCache();
          return ret;
      }


      public bool Delete()
      {
          return Delete(UserControlPathId, UserControlNameId, Path, Name, IsQueryString, QueryString,
           IsGroups, Parameter, AdminSetting, AdminInsert, DefaltValue, OrderBy, Visible, LocationName, DomainId, LanguageId);
      }

      private bool Delete(Int32 userControlPathId, Int32 userControlNameId, String path, String name, Boolean isQueryString, String queryString,
          Boolean isGroups, String parameter, String adminSetting, String adminInsert, Int32? defaltValue, Int32? orderBy, Boolean visible, String locationName, Int32 domainId, Int32 languageId)
      {
          CoreUserControlPathDetails coreUserControlPathDetails = new CoreUserControlPathDetails(userControlPathId, userControlNameId, path, name, isQueryString, queryString,
          isGroups, parameter, adminSetting, adminInsert, defaltValue, orderBy, visible, locationName, domainId, languageId);
          bool ret = SiteProvider.Core.DeleteCoreUserControlPaths(coreUserControlPathDetails.UserControlPathId);
          if (Settings.EnableCaching & ret)
              InvalidateCache();
          return ret;
      }

        #endregion

    }
}
