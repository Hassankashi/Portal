using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pine.Dal.Store
{
  public  class Store_SpecificationTitlesDetails
    {
      
      
         #region Constructors (2)


      public Store_SpecificationTitlesDetails(Guid specificationTitleId, Guid specificationGroupId, String name, String description, Int32 domainId, Int32 languageId)
        {

            SpecificationTitleId = specificationTitleId;
            SpecificationGroupId = specificationGroupId;
            Name = name;
            Description = description;
            DomainId = domainId;
            LanguageId = languageId;

        }

       public Store_SpecificationTitlesDetails()
        {
        }

        #endregion Constructors

        #region Properties (9)

       public Guid SpecificationTitleId  { get; set; }

       public Guid SpecificationGroupId { get; set; }

       public String Name { get; set; }

       public String Description { get; set; }

        public Int32 DomainId { get; set; }

        public Int32 LanguageId { get; set; }

        #endregion Properties


    }
}
