using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pine.Dal.Store
{
   public   class Store_SpecificationTextsDetails
    {

         #region Constructors (2)


       public Store_SpecificationTextsDetails(Guid specificationTextId, Guid specificationTitleId, Guid productId, String text, String description, Int32 domainId, Int32 languageId,String name, String expr1) 
        {


            SpecificationTextId = specificationTextId;
            SpecificationTitleId = specificationTitleId;
            ProductId = productId;
            Text = text;
            Description = description;
            DomainId = domainId;
            LanguageId = languageId;
           Name = name;
           Expr1 = expr1;
        }

      public Store_SpecificationTextsDetails()
        {
        }

        #endregion Constructors

        #region Properties (9)

      public Guid SpecificationTextId { get; set; }

      public Guid SpecificationTitleId { get; set; }

      public Guid ProductId { get; set; }

      public String Text { get; set; }

      public String Description { get; set; }


        public Int32 DomainId { get; set; }

        public Int32 LanguageId { get; set; }

        public String Name { get; set; }

        public String Expr1 { get; set; }

        #endregion Properties
    }
}
