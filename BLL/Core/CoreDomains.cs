using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pine.Dal;
using Pine.Dal.Core;

namespace Pine.Bll.Core
{
   public class CoreDomains : BaseCore
    {
        #region Properties
       public Int32 DomainId {get; set;}
       public String DomainName { get; set; }
       public String DomainTheme { get; set; }
       public DateTime? EnterDate { get; set; }
       public Int32 LanguageId { get; set; }

       #endregion 


       #region Constructor
       public CoreDomains()
       {
           CacheDuration = Settings.CacheDuration;
           MasterCacheKey = "Core";
       }

       public CoreDomains(Int32 domainId, String domainName, String domainTheme, DateTime? enterDate, Int32 languageId)
       {
           DomainId = domainId;
           DomainName = domainName;
           DomainTheme = domainTheme;
           EnterDate = enterDate;
           LanguageId = languageId;
       
       }
       #endregion 

        #region Method
       public Int32 Insert()
       {
           return Insert(DomainId, DomainName, DomainTheme, EnterDate, LanguageId);
       }

       private Int32 Insert(Int32 domainId, String domainName, String domainTheme, DateTime? enterDate, Int32 languageId)
       {
           CoreDomainsDetails coreDoaminsDetails = new CoreDomainsDetails(domainId, domainName, domainTheme, enterDate, languageId);
           Int32 ret = SiteProvider.Core.InsertCoreDomains(coreDoaminsDetails);
           if (Settings.EnableCaching & ret > 0)
               InvalidateCache();
           return ret;
       }

       public bool Update()
       {
           return Update(DomainId, DomainName, DomainTheme, EnterDate, LanguageId);
       }

       private Boolean Update(Int32 domainId, String domainName, String domainTheme, DateTime? enterDate, Int32 languageId)
       {
           CoreDomainsDetails coreDoaminsDetails = new CoreDomainsDetails(domainId, domainName, domainTheme, enterDate, languageId);
           Boolean ret = SiteProvider.Core.UpdateCoreDomains(coreDoaminsDetails);
           if (Settings.EnableCaching & ret)
               InvalidateCache();
           return ret;
       }


       public bool Delete()
       {
           return Delete(DomainId, DomainName, DomainTheme, EnterDate, LanguageId);
       }

       private bool Delete(Int32 domainId, String domainName, String domainTheme, DateTime? enterDate, Int32 languageId)
       {
           CoreDomainsDetails coreDoaminsDetails = new CoreDomainsDetails(domainId, domainName, domainTheme, enterDate, languageId);
           bool ret = SiteProvider.Core.DeleteCoreDomains(coreDoaminsDetails.DomainId);
           if (Settings.EnableCaching & ret)
               InvalidateCache();
           return ret;
       }

        #endregion

    }
}
