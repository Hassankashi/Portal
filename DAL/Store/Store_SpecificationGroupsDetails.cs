using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pine.Dal.Store
{
  public  class Store_SpecificationGroupsDetails
    {
         #region Constructors (2)


      public Store_SpecificationGroupsDetails(Guid specificationGroupId, String name, Int32 domainId, Int32 languageId)
        {


            SpecificationGroupId = specificationGroupId;
            Name = name;
          
            DomainId = domainId;
            LanguageId = languageId;

        }

       public Store_SpecificationGroupsDetails()
        {
        }

        #endregion Constructors

        #region Properties (9)

       public Guid SpecificationGroupId { get; set; }


       public String Name { get; set; }


        public Int32 DomainId { get; set; }

        public Int32 LanguageId { get; set; }

        #endregion Properties
    }
}
