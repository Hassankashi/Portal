using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pine.Dal.Core
{
  public class CoreContentNamesDetails
  {
      #region properties
      public Int32 ContentNameId { get; set; }
      public String Position { get; set; }
      public String NameFarsi { get; set; }
      public Int32 DomainId { get; set; }
      public Int32 LanguageId { get; set; }
        #endregion

    #region Constructor
      public CoreContentNamesDetails() { }
      public CoreContentNamesDetails(Int32 contentNameId, String position, String nameFarsi, Int32 domainId, Int32 languageId)
      {
          ContentNameId = contentNameId;
          Position = position;
          NameFarsi = nameFarsi;
          DomainId = domainId;
          LanguageId = languageId;
      }
    #endregion
  }
}
