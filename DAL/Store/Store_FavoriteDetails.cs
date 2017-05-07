using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pine.Dal.Store
{
   public  class Store_FavoriteDetails
    {
         #region Constructors (2)


       public Store_FavoriteDetails(Guid favoriteId, Int32 favoriteGroupId, Guid productId, DateTime enterDate,  Int32 domainId, Int32 languageId, String name )
        {

            FavoriteId = favoriteId;
            FavoriteGroupId = favoriteGroupId;
            ProductId = productId;
             EnterDate = enterDate;
            DomainId = domainId;
            LanguageId = languageId;
            Name = name;

        }

       public Store_FavoriteDetails()
        {
        }

        #endregion Constructors

        #region Properties (9)

       public Guid FavoriteId { get; set; } 

        public Int32 FavoriteGroupId { get; set; }

        public Guid ProductId { get; set; }

        public DateTime EnterDate { get; set; }

        public Int32 DomainId { get; set; }

        public Int32 LanguageId { get; set; }

        public String Name { get; set; } 

        #endregion Properties


    }
}
