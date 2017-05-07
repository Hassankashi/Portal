using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pine.Dal.Core;
using Pine.Dal;

namespace Pine.Bll.Core
{
   public class CoreContentNames : BaseCore
    {
        #region properties
      public Int32 ContentNameId { get; set; }
      public String Position { get; set; }
      public String NameFarsi { get; set; }
      public Int32 DomainId { get; set; }
      public Int32 LanguageId { get; set; }
        #endregion

    #region Constructor
      public CoreContentNames()
      {
          CacheDuration = Settings.CacheDuration;
          MasterCacheKey = "Core";
      }
      public CoreContentNames(Int32 contentNameId, String position, String nameFarsi, Int32 domainId, Int32 languageId)
      {
          ContentNameId = contentNameId;
          Position = position;
          NameFarsi = nameFarsi;
          DomainId = domainId;
          LanguageId = languageId;
      }
    #endregion

        #region Method
      public Int32 Insert()
      {
          return Insert(ContentNameId, Position, NameFarsi, LanguageId, DomainId);
      }

      private Int32 Insert(Int32 contentNameId, String position, String nameFarsi, Int32 domainId, Int32 languageId)
      {
          CoreContentNamesDetails coreContentNamesDetails = new CoreContentNamesDetails(contentNameId, position, nameFarsi, languageId, domainId);
          Int32 ret = SiteProvider.Core.InsertCoreContentNames(coreContentNamesDetails);
          if (Settings.EnableCaching & ret > 0)
              InvalidateCache();
          return ret;
      }

      public bool Update()
      {
          return Update(ContentNameId, Position, NameFarsi, LanguageId, DomainId);
      }

      private Boolean Update(Int32 contentNameId, String position, String nameFarsi, Int32 domainId, Int32 languageId)
      {
          CoreContentNamesDetails coreContentNamesDetails = new CoreContentNamesDetails(contentNameId, position, nameFarsi, languageId, domainId);
          Boolean ret = SiteProvider.Core.UpdateCoreContentNames(coreContentNamesDetails);
          if (Settings.EnableCaching & ret)
              InvalidateCache();
          return ret;
      }

      public bool Delete()
      {
          return Delete(ContentNameId, Position, NameFarsi, LanguageId, DomainId);
      }

      private bool Delete(Int32 contentNameId, String position, String nameFarsi, Int32 domainId, Int32 languageId)
      {
          CoreContentNamesDetails coreContentNamesDetails = new CoreContentNamesDetails(contentNameId, position, nameFarsi, languageId, domainId);
          bool ret = SiteProvider.Core.DeleteCoreContentNames(coreContentNamesDetails.ContentNameId);
          if (Settings.EnableCaching & ret)
              InvalidateCache();
          return ret;
      }

        #endregion 
    }
}
