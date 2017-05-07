using System;
using System.Linq;

namespace Pine.Dal.Core
{

    public class CorePageContentsDetails
    {

        #region Constructors (2)


        public CorePageContentsDetails(Int32 pageContentId, Int32 pageId, Int32 userControlPathId, Int32 contentNameId, Int32? coreParameterId, Int16 priority, Boolean isStaticCantent, Int32 domainId, Int32 languageId)
        {
            PageContentId = pageContentId;
            PageId = pageId;
            UserControlPathId = userControlPathId;
            ContentNameId = contentNameId;
            CoreParameterId = coreParameterId;
            Priority = priority;
            IsStaticCantent = isStaticCantent;
            DomainId = domainId;
            LanguageId = languageId;
        }



        public CorePageContentsDetails()
        {
        }

        #endregion Constructors

        #region Properties (9)

        public Int32 PageContentId { get; set; }

        public Int32  PageId { get; set; }

        public Int32 UserControlPathId { get; set; }

        public Int32 ContentNameId { get; set; }

        public Int32? CoreParameterId { get; set; }

        public Int16 Priority { get; set; }

        public Boolean IsStaticCantent { get; set; }

        public Int32 DomainId { get; set; }

        public Int32 LanguageId { get; set; }

        #endregion Properties

    }
}
