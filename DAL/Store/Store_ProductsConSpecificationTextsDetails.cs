using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pine.Dal.Store
{
    public class Store_ProductsConSpecificationTextsDetails
    {
           #region Constructors (2)


        public Store_ProductsConSpecificationTextsDetails(Guid productId, Guid specificationTextId, String description)
        {

            SpecificationTextId = specificationTextId; 
            ProductId = productId;
          Description =description;


        }

        public Store_ProductsConSpecificationTextsDetails()
        {
        }

        #endregion Constructors

        #region Properties (2)

        public Guid ProductId { get; set; }

      public Guid SpecificationTextId { get; set; }  

          public String Description { get; set; }   

        #endregion Properties
    }

   
}
