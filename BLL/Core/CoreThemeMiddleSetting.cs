using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pine.Dal.Core;
using Pine.Dal;

namespace Pine.Bll.Core
{
   public class CoreThemeMiddleSetting : BaseCore
    {
       #region Properties
       public Int32 MasterPageNameId { get; set; }
       public Int32 ThemeSettingId { get; set; }
       public Int32 DomainId { get; set; }
       public Int32 LanguageId { get; set; }
       #endregion


       #region constructor
       public CoreThemeMiddleSetting()
       {
           CacheDuration = Settings.CacheDuration;
           MasterCacheKey = "Core";
       }
       public CoreThemeMiddleSetting(Int32 masterPageNameId, Int32 themeSettingId, Int32 domainId, Int32 languageId) 
       {
           MasterPageNameId = masterPageNameId;
           ThemeSettingId = themeSettingId;
           DomainId = domainId;
           LanguageId = languageId;
       }
       #endregion

        #region Method
       public Int32 Insert()
       {
           return Insert(MasterPageNameId, ThemeSettingId, DomainId, LanguageId);
       }

       private Int32 Insert(Int32 masterPageNameId, Int32 themeSettingId, Int32 domainId, Int32 languageId)
       {
           CoreThemeMiddleSettingDetails coreThemeMiddleSettingDetails = new CoreThemeMiddleSettingDetails(masterPageNameId, themeSettingId, domainId, languageId);
           Int32 ret = SiteProvider.Core.InsertCoreThemeMiddleSetting(coreThemeMiddleSettingDetails);
           if (Settings.EnableCaching & ret > 0)
               InvalidateCache();
           return ret;
       }

       public bool Update()
       {
           return Update(MasterPageNameId, ThemeSettingId, DomainId, LanguageId);
       }

       private Boolean Update(Int32 masterPageNameId, Int32 themeSettingId, Int32 domainId, Int32 languageId)
       {
           CoreThemeMiddleSettingDetails coreThemeMiddleSettingDetails = new CoreThemeMiddleSettingDetails(masterPageNameId, themeSettingId, domainId, languageId);
           Boolean ret = SiteProvider.Core.UpdateCoreThemeMiddleSetting(coreThemeMiddleSettingDetails);
           if (Settings.EnableCaching & ret)
               InvalidateCache();
           return ret;
       }


       public bool Delete()
       {
           return Delete(MasterPageNameId, ThemeSettingId, DomainId, LanguageId);
       }

       private bool Delete(Int32 masterPageNameId, Int32 themeSettingId, Int32 domainId, Int32 languageId)
       {
           CoreThemeMiddleSettingDetails coreThemeMiddleSettingDetails = new CoreThemeMiddleSettingDetails(masterPageNameId, themeSettingId, domainId, languageId);
           bool ret = SiteProvider.Core.DeleteCoreThemeMiddleSetting(coreThemeMiddleSettingDetails.MasterPageNameId, coreThemeMiddleSettingDetails.ThemeSettingId);
           if (Settings.EnableCaching & ret)
               InvalidateCache();
           return ret;
       }
        #endregion 

    }
}
