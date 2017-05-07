using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pine.Dal.Store
{
   public class Store_TabDescriptionsDetails
    {
         #region Constructors (2)


       public Store_TabDescriptionsDetails(Guid tabDescriptionId, Guid productId, String name, String description, Int32 domainId, Int32 languageId)
        {

            TabDescriptionId = tabDescriptionId;
            ProductId = productId;
            Name = name;
            Description = description;
            DomainId = domainId;
            LanguageId = languageId;

        }

       public Store_TabDescriptionsDetails()
        {
        }

        #endregion Constructors

        #region Properties (9)

       public Guid TabDescriptionId { get; set; }

       public Guid ProductId { get; set; }

       
       public String Name { get; set; }

       public String Description { get; set; }

      
        public Int32 DomainId { get; set; }

        public Int32 LanguageId { get; set; }

        #endregion Properties
    }
}
