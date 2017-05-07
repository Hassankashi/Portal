using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pine.Dal.Advertisement
{
  public class AdvertisementDetails
    {
#region Constructor
      public AdvertisementDetails()
      {
      }

      public AdvertisementDetails(Int32 adId, Int32? parentId, String title, String description, Boolean isActive, Int32 languageId, Int32 domainId , Byte orderBy)
      {
          AdId = adId;
          ParentId = parentId;
          Title = title;
          Description = description;
          IsActive = isActive;
          LanguageId = languageId;
          DomainId = domainId;
          OrderBy = orderBy;
      }

      #endregion

#region Prooerties

      public Int32 AdId { get; set; }
      public Int32? ParentId { get; set; }
      public String Title { get; set; }
      public String Description { get; set; }
      public Boolean IsActive { get; set; }
      public Int32 LanguageId { get; set; }
      public Int32 DomainId { get; set; }
      public Byte OrderBy { get; set; }
      #endregion
    }
}
