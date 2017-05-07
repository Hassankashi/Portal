using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pine.Dal.Store
{
   public  class Store_PriceDescriptionsDetails
    {
         #region Constructors (2)


       public Store_PriceDescriptionsDetails(Guid priceDescriptionId, String name, Int32 priority, String roleName, Boolean status, Int32 domainId, Int32 languageId)
        {

            PriceDescriptionId = priceDescriptionId;
            Name = name;
            Priority = priority;
            RoleName = roleName;
            Status = status;
            DomainId = domainId;
            LanguageId = languageId;
 
        }

       public Store_PriceDescriptionsDetails()
        {
        }

        #endregion Constructors

        #region Properties (9)

       public Guid PriceDescriptionId { get; set; }

       public String Name { get; set; }

       public Int32 Priority { get; set; }

       public String RoleName { get; set; }

       public Boolean Status { get; set; } 

        public Int32 DomainId { get; set; }

        public Int32 LanguageId { get; set; }

        #endregion Properties

    }
}
