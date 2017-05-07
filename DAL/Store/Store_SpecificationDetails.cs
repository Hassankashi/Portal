using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pine.Dal;
using Pine.Dal.Store;
namespace Pine.Dal.Store
{
     public  class Store_SpecificationDetails
    {
          #region Constructors (2)


         public Store_SpecificationDetails(String name, String text, String description)
        {

            Name = name;
            Text = text;
            Description = description;


        }

        public Store_SpecificationDetails()
        {
        }

        #endregion Constructors

           #region Properties (2)

        public String Name { get; set; }

        public String Text { get; set; }  

          public String Description { get; set; }   

        #endregion Properties


    }
}
