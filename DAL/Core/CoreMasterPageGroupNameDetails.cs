using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pine.Dal.Core
{
   public class CoreMasterPageGroupNameDetails
   {
      
       public Int32 MasterPageGroupNameId { get; set; }
       public String Name { get; set; }
       public Int32 DomainId { get; set; }
       public Int32 LanguageId { get; set; }
           

       public CoreMasterPageGroupNameDetails()
       { }

       public CoreMasterPageGroupNameDetails(Int32 masterPageGroupNameId, String name, Int32 domainId, Int32 languageId)
       {
           MasterPageGroupNameId = masterPageGroupNameId;
           Name = name;
           DomainId = domainId;
           LanguageId = languageId;
       }

   



   }
}
