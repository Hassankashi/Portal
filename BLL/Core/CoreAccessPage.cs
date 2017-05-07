using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pine.Dal;
using Pine.Dal.Core;

namespace Pine.Bll.Core
{
   public class CoreAccessPage : BaseCore
    {
        #region Properties (6)
       public Int32 AccessPageId { get; set; }
       public Int32? MasterPageNameId { get; set; }
       public String Username { get; set; }
       public Boolean UseManager { get; set; }
       public Int32 DomainId { get; set; }
       public Int32 LanguageId { get; set; }
       #endregion

       #region constructor
       public CoreAccessPage()
       {
           CacheDuration = Settings.CacheDuration;
           MasterCacheKey = "Core";
       }

       public CoreAccessPage(Int32 accessPageId, Int32? masterPageNameId, String username, Boolean useManager, Int32 domainId, Int32 languageId)
       {

          AccessPageId = accessPageId;
          MasterPageNameId = masterPageNameId;
          Username = username;
          UseManager = useManager;
          DomainId = domainId;
          LanguageId = languageId;
  
       }
       #endregion
       #region Method
       public Int32 Insert()
       {
           return Insert(AccessPageId, MasterPageNameId, Username, UseManager, DomainId, LanguageId);
       }

       private Int32 Insert(Int32 accessPageId, Int32? masterPageNameId, String username, Boolean useManager, Int32 domainId, Int32 languageId)
       {
           CoreAccessPageDetails coreAccessPageDetails = new CoreAccessPageDetails(accessPageId, masterPageNameId, username, useManager, domainId, languageId);
           Int32 ret = SiteProvider.Core.InsertCoreAccessPage(coreAccessPageDetails);
           if (Settings.EnableCaching & ret > 0)
               InvalidateCache();
           return ret;
       }

       public bool Update()
       {
           return Update(AccessPageId, MasterPageNameId, Username, UseManager, DomainId, LanguageId);
       }

       private Boolean Update(Int32 accessPageId, Int32? masterPageNameId, String username, Boolean useManager, Int32 domainId, Int32 languageId)
       {
           CoreAccessPageDetails coreAccessPageDetails = new CoreAccessPageDetails(accessPageId, masterPageNameId, username, useManager, domainId, languageId);
           Boolean ret = SiteProvider.Core.UpdateCoreAccessPage(coreAccessPageDetails);
           if (Settings.EnableCaching & ret)
               InvalidateCache();
           return ret;
       }


       public bool Delete()
       {
           return Delete(AccessPageId, MasterPageNameId, Username, UseManager, DomainId, LanguageId);
       }

       private bool Delete(Int32 accessPageId, Int32? masterPageNameId, String username, Boolean useManager, Int32 domainId, Int32 languageId)
       {
           CoreAccessPageDetails coreAccessPageDetails = new CoreAccessPageDetails(accessPageId, masterPageNameId, username, useManager, domainId, languageId);
           bool ret = SiteProvider.Core.DeleteCoreAccessPage(coreAccessPageDetails.AccessPageId);
           if (Settings.EnableCaching & ret)
               InvalidateCache();
           return ret;
       }



       #endregion

    }
}
