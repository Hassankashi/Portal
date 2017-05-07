using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pine.Dal.Store
{
   public class Store_UserScoreTitlesDetails
    {
     
        #region Constructors (2)


       public Store_UserScoreTitlesDetails(Guid userScoreTitleId, Guid productId, String name, String description, Int32 domainId, Int32 languageId)
        {

            UserScoreTitleId = userScoreTitleId;
            ProductId = productId;
            Name = name;
            Description = description;
            DomainId = domainId;
            LanguageId = languageId;

        }

       public Store_UserScoreTitlesDetails()
        {
        }

        #endregion Constructors

        #region Properties (9)

       public Guid UserScoreTitleId { get; set; }

        public Guid ProductId { get; set; }

        public String Name { get; set; }

        public String Description { get; set; }

        public Int32 DomainId { get; set; }

        public Int32 LanguageId { get; set; }

        #endregion Properties


    }
}
