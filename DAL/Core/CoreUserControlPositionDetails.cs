using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pine.Dal.Core
{
   public class CoreUserControlPositionDetails
   {

       #region properties
       public Int32 UserControlpositionId { get; set; }
       public Int32 ContentNameId { get; set; }
       public Int32 UserControlPathId { get; set; }
       public Int32 DomainId { get; set; }
       public Int32 LanguageId { get; set; }
      
       #endregion

       #region constructor
       public CoreUserControlPositionDetails() { }

       public CoreUserControlPositionDetails(Int32 userControlpositionId, Int32 contentNameId, Int32 userControlPathId, Int32 domainId, Int32 languageId)
       {
           UserControlpositionId = userControlpositionId;
           ContentNameId = contentNameId;
           UserControlPathId = userControlPathId;
           DomainId  = domainId;
           LanguageId = languageId;
       
       }
       #endregion 
   }
}
