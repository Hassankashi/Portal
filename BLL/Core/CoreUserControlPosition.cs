using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pine.Dal.Core;
using Pine.Dal;

namespace Pine.Bll.Core
{
  public  class CoreUserControlPosition : BaseCore
    {

       #region properties
       public Int32 UserControlpositionId { get; set; }
       public Int32 ContentNameId { get; set; }
       public Int32 UserControlPathId { get; set; }
       public Int32 DomainId { get; set; }
       public Int32 LanguageId { get; set; }
      
       #endregion

       #region constructor
       public CoreUserControlPosition()
       {
           CacheDuration = Settings.CacheDuration;
           MasterCacheKey = "Core";
       }

       public CoreUserControlPosition(Int32 userControlpositionId, Int32 contentNameId, Int32 userControlPathId, Int32 domainId, Int32 languageId)
       {
           UserControlpositionId = userControlpositionId;
           ContentNameId = contentNameId;
           UserControlPathId = userControlPathId;
           DomainId  = domainId;
           LanguageId = languageId;
       
       }
       #endregion 

        #region Method
        public Int32 Insert()
      {
          return Insert(UserControlpositionId, ContentNameId, UserControlPathId, DomainId, LanguageId);
      }

        private Int32 Insert(Int32 userControlpositionId, Int32 contentNameId, Int32 userControlPathId, Int32 domainId, Int32 languageId)
      {
          CoreUserControlPositionDetails coreUserControlPositionDetails = new CoreUserControlPositionDetails(userControlpositionId, contentNameId, userControlPathId, domainId, languageId);
          Int32 ret = SiteProvider.Core.InsertCoreUserControlPosition(coreUserControlPositionDetails);
              
          if (Settings.EnableCaching & ret > 0)
              InvalidateCache();
          return ret;
      }

      public bool Update()
      {
          return Update(UserControlpositionId, ContentNameId, UserControlPathId, DomainId, LanguageId);
      }

      private Boolean Update(Int32 userControlpositionId, Int32 contentNameId, Int32 userControlPathId, Int32 domainId, Int32 languageId)
      {
          CoreUserControlPositionDetails coreUserControlPositionDetails = new CoreUserControlPositionDetails(userControlpositionId, contentNameId, userControlPathId, domainId, languageId);
          Boolean ret = SiteProvider.Core.UpdateCoreUserControlPosition(coreUserControlPositionDetails);
          if (Settings.EnableCaching & ret)
              InvalidateCache();
          return ret;
      }


      public bool Delete()
      {
          return Delete(UserControlpositionId, ContentNameId, UserControlPathId, DomainId, LanguageId);
      }

      private bool Delete(Int32 userControlpositionId, Int32 contentNameId, Int32 userControlPathId, Int32 domainId, Int32 languageId)
      {
          CoreUserControlPositionDetails coreUserControlPositionDetails = new CoreUserControlPositionDetails(userControlpositionId, contentNameId, userControlPathId, domainId, languageId);
          bool ret = SiteProvider.Core.DeleteCoreUserControlPosition(coreUserControlPositionDetails.UserControlpositionId);
          if (Settings.EnableCaching & ret)
              InvalidateCache();
          return ret;
      }

    
        #endregion
    }
}
