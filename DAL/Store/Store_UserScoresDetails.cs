using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pine.Dal.Store
{
  public   class Store_UserScoresDetails
    {
        #region Constructors (2)


      public Store_UserScoresDetails(Guid userScoreId, Guid userScoreTitleId, String username, Byte score , Int32 domainId, Int32 languageId)
        {

            UserScoreId = userScoreId;
            UserScoreTitleId = userScoreTitleId;
            Username = username;
            Score = score; 
            DomainId = domainId;
            LanguageId = languageId;

        }

       public Store_UserScoresDetails()
        {
        }

        #endregion Constructors

        #region Properties (9)

       public Guid UserScoreId { get; set; }

       public Guid UserScoreTitleId { get; set; }

       public String Username { get; set; }

       public Byte Score { get; set; }

        public Int32 DomainId { get; set; }

        public Int32 LanguageId { get; set; }

        #endregion Properties


    }
}
