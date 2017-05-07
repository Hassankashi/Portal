using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pine.Dal;
using Pine.Dal.Core;

namespace Pine.Bll.Core
{
   public class CoreMasterPageGroupName :BaseCore 
    {
        #region Properties
       public Int32 MasterPageGroupNameId { get; set; }
       public String Name { get; set; }
       public Int32 DomainId { get; set; }
       public Int32 LanguageId { get; set; }

       #endregion

       #region constructor 
       public CoreMasterPageGroupName()
       {
           CacheDuration = Settings.CacheDuration;
           MasterCacheKey = "Core";
       }

       public CoreMasterPageGroupName(Int32 masterPageGroupNameId, String name, Int32 domainId, Int32 languageId)
       {
           MasterPageGroupNameId = masterPageGroupNameId;
           Name = name;
           DomainId = domainId;
           LanguageId = languageId;
       }
       #endregion 

        #region Method
       public Int32 Insert()
       {
           return Insert(MasterPageGroupNameId, Name, DomainId, LanguageId);
       }

       private Int32 Insert(Int32 masterPageGroupNameId, String name, Int32 domainId, Int32 languageId)
       {
           CoreMasterPageGroupNameDetails coreMasterPageGroupNameDetails = new CoreMasterPageGroupNameDetails(masterPageGroupNameId, name, domainId, languageId);
           Int32 ret = SiteProvider.Core.InsertCoreMasterPageGroupName(coreMasterPageGroupNameDetails);
           if (Settings.EnableCaching & ret > 0)
               InvalidateCache();
           return ret;
       }

       public bool Update()
       {
           return Update(MasterPageGroupNameId, Name, DomainId, LanguageId);
       }

       private Boolean Update(Int32 masterPageGroupNameId, String name, Int32 domainId, Int32 languageId)
       {
           CoreMasterPageGroupNameDetails coreMasterPageGroupNameDetails = new CoreMasterPageGroupNameDetails(masterPageGroupNameId, name, domainId, languageId);
           Boolean ret = SiteProvider.Core.UpdateCoreMasterPageGroupName(coreMasterPageGroupNameDetails);
           if (Settings.EnableCaching & ret)
               InvalidateCache();
           return ret;
       }


       public bool Delete()
       {
           return Delete(MasterPageGroupNameId, Name, DomainId, LanguageId);
       }

       private bool Delete(Int32 masterPageGroupNameId, String name, Int32 domainId, Int32 languageId)
       {
           CoreMasterPageGroupNameDetails coreMasterPageGroupNameDetails = new CoreMasterPageGroupNameDetails(masterPageGroupNameId, name, domainId, languageId);
           bool ret = SiteProvider.Core.DeleteCoreMasterPageGroupName(coreMasterPageGroupNameDetails.MasterPageGroupNameId);
           if (Settings.EnableCaching & ret)
               InvalidateCache();
           return ret;
       }
        #endregion
    }
}
