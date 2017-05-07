using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pine.Dal.Store
{
   public class Store_ProductsDetails
    {
        #region Constructors (2)


       public Store_ProductsDetails(Guid productId, String name, String description, String mainImage, String condition, Byte? score,  Boolean status, DateTime enterDate, DateTime? lastUpdateDate, String username, Int32 domainId, Int32 languageId)
        {

            ProductId = productId;
             Name     = name;
             Description = description;
             MainImage = mainImage;
             Condition = condition;
             Score = score;
             Status = status;
             EnterDate = enterDate;
             LastUpdateDate = lastUpdateDate;
            Username = username;
            DomainId = domainId;
            LanguageId = languageId;

        }

       public Store_ProductsDetails()
        {
        }

        #endregion Constructors

        #region Properties (9)

       public Guid ProductId { get; set; }

       public String Name { get; set; }

       public String Description { get; set; }

       public String MainImage { get; set; }

       public String Condition { get; set; }

       public Byte?    Score { get; set; }

       public Boolean Status { get; set; }

       public DateTime EnterDate { get; set; }

       public DateTime? LastUpdateDate { get; set; }

       public String Username { get; set; }

        public Int32 DomainId { get; set; }

        public Int32 LanguageId { get; set; }

        #endregion Properties

    }
}
