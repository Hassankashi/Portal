using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pine.Dal.Store
{
    public class Store_ProductsConTagsDetails
    {

         #region Constructors (2)


        public Store_ProductsConTagsDetails(Guid tagId, Guid productId)
        {

            TagId = tagId;
            ProductId = productId;


        }

      public Store_ProductsConTagsDetails()
        {
        }

        #endregion Constructors

        #region Properties (9)

      public Guid TagId { get; set; }

      public Guid ProductId { get; set; }



        #endregion Properties
    }
}
