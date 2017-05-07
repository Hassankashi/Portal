using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pine.Dal.Store
{
  public  class Store_FavoriteGroupDetails
    {
      #region Constructors (2)


      public Store_FavoriteGroupDetails(Int32 favoriteGroupId, String nameGroup,  Int32 domainId, Int32 languageId)
        {

            FavoriteGroupId = favoriteGroupId;
            NameGroup = nameGroup;

            DomainId = domainId;
            LanguageId = languageId;

        }

       public Store_FavoriteGroupDetails()
        {
        }

        #endregion Constructors

        #region Properties (9)

       public Int32 FavoriteGroupId { get; set; }

       public String NameGroup { get; set; }


       public Int32 DomainId { get; set; }

       public Int32 LanguageId { get; set; }

        #endregion Properties

    }
}
