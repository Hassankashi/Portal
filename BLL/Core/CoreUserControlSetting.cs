using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pine.Dal.Core;
using Pine.Dal;

namespace Pine.Bll.Core
{
   public class CoreUserControlSetting : BaseCore
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
      public CoreUserControlSetting()
      {
          CacheDuration = Settings.CacheDuration;
          MasterCacheKey = "Core";
      }

      public CoreUserControlSetting(Int32 userControlSettingId, Int32 userControlPathId, String userControlParameter, String userControlValue, Int32 domainId, Int32 languageId)
      {
          UserControlSettingId = userControlSettingId;
          UserControlPathId = userControlPathId;
          UserControlParameter = userControlParameter;
          UserControlValue = userControlValue;
          DomainId = domainId;
          LanguageId = languageId;
      }

      #endregion
      #region Method
      public Int32 Insert()
      {
          return Insert(UserControlSettingId, UserControlPathId, UserControlParameter,UserControlValue, DomainId, LanguageId);
      }

      private Int32 Insert(Int32 userControlSettingId, Int32 userControlPathId, String userControlParameter, String userControlValue, Int32 domainId, Int32 languageId)
      {
          CoreUserControlSettingDetails coreUserControlSettingDetails = new CoreUserControlSettingDetails(userControlSettingId, userControlPathId, userControlParameter, userControlValue, domainId, languageId);
          Int32 ret = SiteProvider.Core.InsertCoreUserControlSetting(coreUserControlSettingDetails);

          if (Settings.EnableCaching & ret > 0)
              InvalidateCache();
          return ret;
      }

      public bool Update()
      {
          return Update(UserControlSettingId, UserControlPathId, UserControlParameter, UserControlValue, DomainId, LanguageId);
      }

      private Boolean Update(Int32 userControlSettingId, Int32 userControlPathId, String userControlParameter, String userControlValue, Int32 domainId, Int32 languageId)
      {
          CoreUserControlSettingDetails coreUserControlSettingDetails = new CoreUserControlSettingDetails(userControlSettingId, userControlPathId, userControlParameter, userControlValue, domainId, languageId);
          Boolean ret = SiteProvider.Core.UpdateCoreUserControlSetting(coreUserControlSettingDetails);
          if (Settings.EnableCaching & ret)
              InvalidateCache();
          return ret;
      }


      public bool Delete()
      {
          return Delete(UserControlSettingId, UserControlPathId, UserControlParameter, UserControlValue, DomainId, LanguageId);
      }

      private bool Delete(Int32 userControlSettingId, Int32 userControlPathId, String userControlParameter, String userControlValue, Int32 domainId, Int32 languageId)
      {
          CoreUserControlSettingDetails coreUserControlSettingDetails = new CoreUserControlSettingDetails(userControlSettingId, userControlPathId, userControlParameter, userControlValue, domainId, languageId);
          bool ret = SiteProvider.Core.DeleteCoreUserControlSetting(coreUserControlSettingDetails.UserControlSettingId);
          if (Settings.EnableCaching & ret)
              InvalidateCache();
          return ret;
      }


      #endregion

    }
}
