using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pine.Dal.Store
{
   public class Store_TagGroupsDetails
    {
          #region Constructors (2)


       public Store_TagGroupsDetails(Guid tagGroupId, String name, String description, Int32 domainId, Int32 languageId)
        {

           
            TagGroupId = tagGroupId;
            Name = name;
            Description = description;
            DomainId = domainId;
            LanguageId = languageId;

        }

       public Store_TagGroupsDetails()
        {
        }

        #endregion Constructors

        #region Properties (9)

       public Guid TagGroupId { get; set; }


       public String Name { get; set; }

       public String Description { get; set; }

        public Int32 DomainId { get; set; }

        public Int32 LanguageId { get; set; }

        #endregion Properties
    }
}
