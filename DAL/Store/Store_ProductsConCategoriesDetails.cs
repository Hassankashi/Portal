using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pine.Dal.Store
{
  public  class Store_ProductsConCategoriesDetails
    {
        #region Constructors (2)


      public Store_ProductsConCategoriesDetails(Guid categoryId, Guid productId)
        {

            CategoryId = categoryId; 
            ProductId = productId;


        }

        public Store_ProductsConCategoriesDetails()
        {
        }

        #endregion Constructors

        #region Properties (9)

        public Guid CategoryId { get; set; }

      public Guid ProductId { get; set; }



        #endregion Properties
    }
}
