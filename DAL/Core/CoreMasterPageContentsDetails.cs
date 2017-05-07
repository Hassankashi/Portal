using System;
using System.Linq;

namespace Pine.Dal.Core
{
    /// <summary>
    /// کلاسی برای نگهداری جزئیات 
    /// </summary>
    public class CoreMasterPageContentsDetails
    {

        #region Constructors (2)


        public CoreMasterPageContentsDetails(Int32 masterPageContentId, Int32 masterPageNameId, Int32 contentNameId, String masterPageContentName, Int32 domainId, Int32 languageId)
        {
            MasterPageContentId = masterPageContentId;
            MasterPageNameId = masterPageNameId;
            ContentNameId = contentNameId;
            MasterPageContentName = masterPageContentName;
            DomainId = domainId;
            LanguageId = languageId;
        }
        
        public CoreMasterPageContentsDetails()
        {
        }

        #endregion Constructors

        #region Properties (4)

        public Int32 MasterPageContentId { get; set; }

        public Int32 MasterPageNameId { get; set; }
        
        public Int32 ContentNameId { get; set; }

        public String MasterPageContentName { get; set; }

        public Int32 DomainId { get; set; }

        public Int32 LanguageId { get; set; }

        #endregion Properties

    }
}
