using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pine.Dal.Chat
{
   public  class Chat_PartDetails
    {
         #region Constructors (2)


        public Chat_PartDetails(Int32 partId, String name, Int32 domainId, Int32 languageId) 
        {
           PartId = partId;
            Name  = name;
            DomainId = domainId;
            LanguageId = languageId;

        }

        public Chat_PartDetails()
        {
        }

        #endregion Constructors

        #region Properties (7)

        public Int32 PartId { get; set; }

        public String Name { get; set; }

        public Int32 DomainId { get; set; }

        public Int32 LanguageId { get; set; }

        #endregion Properties
    }
}
