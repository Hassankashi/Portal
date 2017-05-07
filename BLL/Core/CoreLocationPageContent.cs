using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pine.Dal;
using Pine.Dal.Core;

namespace Pine.Bll.Core
{
   public class CoreLocationPageContent : BaseCore
    {
         #region Properties
       public int CoreLocationPageContentId { get; set; }
       public int UserControlPathId { get; set; }
       public int ContentNameId { get; set; }
       public int? CoreParameterId { get; set; }
       public Byte Priority { get; set; }
       public int DomainId { get; set; }
       public int LanguageId { get; set; }
       #endregion

       #region constructor
       public CoreLocationPageContent()
       {
           CacheDuration = Settings.CacheDuration;
           MasterCacheKey = "Core";
       }

       public CoreLocationPageContent(int coreLocationPageContentId, int userControlPathId, int contentNameId, int? coreParameterId, Byte priority, int domainId, int languageId)
       {
           CoreLocationPageContentId = coreLocationPageContentId;
           UserControlPathId = userControlPathId;
           ContentNameId = contentNameId;
           CoreParameterId = coreParameterId;
           Priority = priority;
           DomainId = domainId;
           LanguageId = languageId;
       }

       #endregion


        #region Method
       public Int32 Insert()
       {
           return Insert(CoreLocationPageContentId, UserControlPathId, ContentNameId, CoreParameterId, Priority, DomainId, LanguageId);
       }

       private Int32 Insert(int coreLocationPageContentId, int userControlPathId, int contentNameId, int? coreParameterId, Byte priority, int domainId, int languageId)
       {
           CoreLocationPageContentDetails coreLocationPageContentDetails = new CoreLocationPageContentDetails(coreLocationPageContentId, userControlPathId, contentNameId, coreParameterId, priority, domainId, languageId);
           Int32 ret = SiteProvider.Core.InsertCoreLocationPageContent(coreLocationPageContentDetails);
           if (Settings.EnableCaching & ret > 0)
               InvalidateCache();
           return ret;
       }

       public bool Update()
       {
           return Update(CoreLocationPageContentId, UserControlPathId, ContentNameId, CoreParameterId, Priority, DomainId, LanguageId);
       }

       private Boolean Update(int coreLocationPageContentId, int userControlPathId, int contentNameId, int? coreParameterId, Byte priority, int domainId, int languageId)
       {
           CoreLocationPageContentDetails coreLocationPageContentDetails = new CoreLocationPageContentDetails(coreLocationPageContentId, userControlPathId, contentNameId, coreParameterId, priority, domainId, languageId);
           Boolean ret = SiteProvider.Core.UpdateCoreLocationPageContent(coreLocationPageContentDetails);
           if (Settings.EnableCaching & ret)
               InvalidateCache();
           return ret;
       }

       public bool Delete()
       {
           return Delete(CoreLocationPageContentId, UserControlPathId, ContentNameId, CoreParameterId, Priority, DomainId, LanguageId);
       }

       private bool Delete(int coreLocationPageContentId, int userControlPathId, int contentNameId, int? coreParameterId, Byte priority, int domainId, int languageId)
       {
           CoreLocationPageContentDetails coreLocationPageContentDetails = new CoreLocationPageContentDetails(coreLocationPageContentId, userControlPathId, contentNameId, coreParameterId, priority, domainId, languageId);
           bool ret = SiteProvider.Core.DeleteCoreLocationPageContent(coreLocationPageContentDetails.CoreLocationPageContentId);
           if (Settings.EnableCaching & ret)
               InvalidateCache();
           return ret;
       }

        #endregion

    }
}
