using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pine.Dal;
using Pine.Dal.Core;

namespace Pine.Bll.Core
{
   public class CoreUserControlNames : BaseCore
    {
        #region properties
      public Int32 UserControlNameId { get; set; }
      public String UserControlName { get; set; }
      public Int32 DomainId { get; set; }
      public Int32 LanguageId { get; set; }
      #endregion 

      #region Constructor

      public CoreUserControlNames()
      {
          CacheDuration = Settings.CacheDuration;
          MasterCacheKey = "Core";
      }

      public CoreUserControlNames(Int32 userControlNameId, String userControlName, Int32 domainId, Int32 languageId)
      {
          UserControlNameId = userControlNameId;
          UserControlName = userControlName;
          DomainId = domainId;
          LanguageId = languageId;
           
      }

      #endregion

        #region Method

      public Int32 Insert()
      {
          return Insert(UserControlNameId, UserControlName, DomainId, LanguageId);
      }

      private Int32 Insert(Int32 userControlNameId, String userControlName, Int32 domainId, Int32 languageId)
      {
          CoreUserControlNamesDetails coreUserControlNamesDetails = new CoreUserControlNamesDetails(userControlNameId, userControlName, domainId, languageId);
          Int32 ret = SiteProvider.Core.InsertCoreUserControlNames(coreUserControlNamesDetails);
          if (Settings.EnableCaching & ret > 0)
              InvalidateCache();
          return ret;
      }

      public bool Update()
      {
          return Update(UserControlNameId, UserControlName, DomainId, LanguageId);
      }

      private Boolean Update(Int32 userControlNameId, String userControlName, Int32 domainId, Int32 languageId)
      {
          CoreUserControlNamesDetails coreUserControlNamesDetails = new CoreUserControlNamesDetails(userControlNameId, userControlName, domainId, languageId);
          Boolean ret = SiteProvider.Core.UpdateCoreUserControlNames(coreUserControlNamesDetails);
          if (Settings.EnableCaching & ret)
              InvalidateCache();
          return ret;
      }


      public bool Delete()
      {
          return Delete(UserControlNameId, UserControlName, DomainId, LanguageId);
      }

      private bool Delete(Int32 userControlNameId, String userControlName, Int32 domainId, Int32 languageId)
      {
          CoreUserControlNamesDetails coreUserControlNamesDetails = new CoreUserControlNamesDetails(userControlNameId, userControlName, domainId, languageId);
          bool ret = SiteProvider.Core.DeleteCoreUserControlNames(coreUserControlNamesDetails.UserControlNameId);
          if (Settings.EnableCaching & ret)
              InvalidateCache();
          return ret;
      }

        #endregion

    }
}
