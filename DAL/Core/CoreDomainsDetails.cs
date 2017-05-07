using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pine.Dal.Core
{
   public class CoreDomainsDetails
   {
       #region Properties
       public Int32 DomainId {get; set;}
       public String DomainName { get; set; }
       public String DomainTheme { get; set; }
       public DateTime? EnterDate { get; set; }
       public Int32 LanguageId { get; set; }

       #endregion 


       #region Constructor
       public CoreDomainsDetails()
       { }

       public CoreDomainsDetails(Int32 domainId, String domainName, String domainTheme, DateTime? enterDate, Int32 languageId)
       {
           DomainId = domainId;
           DomainName = domainName;
           DomainTheme = domainTheme;
           EnterDate = enterDate;
           LanguageId = languageId;
       
       }
       #endregion 

   }
}
