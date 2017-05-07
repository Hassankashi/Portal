using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pine.Dal.Core
{
   public class CoreAccessPageDetails
   {
       #region Properties (6)
       public Int32 AccessPageId { get; set; }
       public Int32? MasterPageNameId { get; set; }
       public String Username { get; set; }
       public Boolean UseManager { get; set; }
       public Int32 DomainId { get; set; }
       public Int32 LanguageId { get; set; }
       #endregion

       #region constructor
       public CoreAccessPageDetails()
       { }

       public CoreAccessPageDetails(Int32 accessPageId, Int32? masterPageNameId, String username, Boolean useManager, Int32 domainId, Int32 languageId)
       {

          AccessPageId = accessPageId;
          MasterPageNameId = masterPageNameId;
          Username = username;
          UseManager = useManager;
          DomainId = domainId;
          LanguageId = languageId;
  
       }

       #endregion

   }
}
