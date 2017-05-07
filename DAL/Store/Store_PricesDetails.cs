using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pine.Dal.Store
{
   public class Store_PricesDetails
    {
        #region Constructors (2)


       public Store_PricesDetails(Guid priceId, Guid? productId, Guid? priceDescriptionId, Decimal price, DateTime enterDate, Boolean status, Int32 domainId, Int32 languageId, String namePriceDes, String nameProduct) 
        {

            PriceId = priceId;
            ProductId = productId;
            PriceDescriptionId = priceDescriptionId;
            Price = price;
            EnterDate = enterDate;
            Status = status;
            DomainId = domainId;
            LanguageId = languageId;
            NamePriceDes = namePriceDes;

            NameProduct = nameProduct; 


        }

       public Store_PricesDetails()
        {
        }

        #endregion Constructors

        #region Properties (8)

       public Guid PriceId { get; set; }

       public Guid? ProductId { get; set; }

       public Guid? PriceDescriptionId { get; set; }

       public Decimal Price { get; set; }

       public DateTime EnterDate { get; set; }


        public Boolean Status { get; set; }

        public Int32 DomainId { get; set; }

        public Int32 LanguageId { get; set; }

        public String NamePriceDes { get; set; }

        public String NameProduct { get; set; } 

        #endregion Properties
    }
}
