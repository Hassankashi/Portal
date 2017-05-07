using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pine.Dal.Core
{
   public class CoreLocationPageContentDetails
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
       public CoreLocationPageContentDetails() { }

       public CoreLocationPageContentDetails(int coreLocationPageContentId, int userControlPathId, int contentNameId, int? coreParameterId, Byte priority, int domainId, int languageId)
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
   }
}
