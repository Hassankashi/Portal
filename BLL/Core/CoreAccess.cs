using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pine.Dal.Core;
using Pine.Dal;

namespace Pine.Bll.Core
{
    public class CoreAccess : BaseCore
   {
       #region Constructor
       public CoreAccess()
        {
            CacheDuration = Settings.CacheDuration;
            MasterCacheKey = "Core";
        }

       public CoreAccess(Int32 accessId, Int32 userControlPathId, String userName, Boolean useManager, Int32 languageId, Int32 domainId)
       {
           AccessId = accessId;
           UserControlPathId = userControlPathId;
           UserName = userName;
           UseManager = useManager;
           LanguageId = languageId;
           DomainId = domainId;
       }
      #endregion

       #region Properties
       public Int32 AccessId { get; set;}
       public Int32 UserControlPathId { get; set; }
       public String UserName { get; set; }
       public Boolean UseManager { get; set; }
       public Int32 LanguageId { get; set; }
       public Int32 DomainId { get; set; }
       #endregion

       #region Method
       public Int32 Insert()
       {
           return Insert(AccessId, UserControlPathId, UserName, UseManager, LanguageId, DomainId);
       }

       private Int32 Insert(Int32 accessId, Int32 userControlPathId, String userName, Boolean useManager, Int32 languageId, Int32 domainId)
       {
           CoreAccessDetails coreAccessDetails = new CoreAccessDetails(accessId, userControlPathId, userName, useManager, languageId, domainId);
           Int32 ret = SiteProvider.Core.InsertCoreAccess(coreAccessDetails);
           if (Settings.EnableCaching & ret > 0)
               InvalidateCache();
           return ret;
       }

       public bool Update()
       {
           return Update(AccessId, UserControlPathId, UserName, UseManager, LanguageId, DomainId);
       }

       private Boolean Update(Int32 accessId, Int32 userControlPathId, String userName, Boolean useManager, Int32 languageId, Int32 domainId)
       {
           CoreAccessDetails coreAccessDetails = new CoreAccessDetails(accessId, userControlPathId, userName, useManager, languageId, domainId);
           Boolean ret = SiteProvider.Core.UpdateCoreAccess(coreAccessDetails);
           if (Settings.EnableCaching & ret)
               InvalidateCache();
           return ret;
       }


       public bool Delete()
       {
           return Delete(AccessId, UserControlPathId, UserName, UseManager, LanguageId, DomainId);
       }

       private bool Delete(Int32 accessId, Int32 userControlPathId, String userName, Boolean useManager, Int32 languageId, Int32 domainId)
       {
           CoreAccessDetails coreAccessDetails = new CoreAccessDetails(accessId, userControlPathId, userName, useManager, languageId, domainId);
           bool ret = SiteProvider.Core.DeleteCoreAccess(coreAccessDetails.AccessId);
           if (Settings.EnableCaching & ret)
               InvalidateCache();
           return ret;
       }

       #endregion

   }
}
