using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pine.Dal.Store
{
   public  class Store_ProductsConModulesDetails
   {
        #region Constructors (2)


       public Store_ProductsConModulesDetails(Guid productId, Int32 idModule, String description, String value1, String value2, String value3, String value4, String value5)
        {

            ProductId = productId;
            IdModule =idModule;
            Description = description;
            Value1 = value1;
            Value2 = value2;
            Value3 = value3;
            Value4 = value4;
            Value5 = value5;
          

        }

        public Store_ProductsConModulesDetails()
        {
        }

        #endregion Constructors

        #region Properties (9)

        public Guid ProductId { get; set; }

       public Int32 IdModule { get; set; }

       public String Description { get; set; }

       public String Value1 { get; set; }

       public String Value2 { get; set; }

       public String Value3 { get; set; }

       public String Value4 { get; set; }

       public String Value5 { get; set; }
  

        #endregion Properties
   }
}
