using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pine.Dal.Store
{
   public  class Store_TagsDetails
    {

          #region Constructors (2)


       public Store_TagsDetails(Guid tagId, Guid tagGroupId, String name,  Int32 domainId, Int32 languageId)
        {

            TagId = tagId;
            TagGroupId = tagGroupId;
            Name = name;
             
            DomainId = domainId;
            LanguageId = languageId;

        }

       public Store_TagsDetails()
        {
        }

        #endregion Constructors

        #region Properties (9)

       public Guid TagId { get; set; }

       public Guid TagGroupId { get; set; }

       public String Name { get; set; }


        public Int32 DomainId { get; set; }

        public Int32 LanguageId { get; set; }

        #endregion Properties
    }
}
