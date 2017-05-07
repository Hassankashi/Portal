using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pine.Dal.Advertisement
{
  public  class AdvertisementItemsDetails
    {
#region constructor
      public AdvertisementItemsDetails()
      {

      }

      public AdvertisementItemsDetails(Guid adItemId, Int32 adId, String title, String description, String bigPicture, String smallPicture,
          DateTime enterDate, DateTime? expireDate, String googleMap, String address, String tel, String mobile, String webUrl, String email,
          Int32 visitCount, Int32 languageId, Int32 domainId)
      {
          AdItemId = adItemId;
          AdId = adId;
          Title = title;
          Description = description;
          BigPicture = bigPicture;
          SmallPicture = smallPicture;
          EnterDate = enterDate;
          ExpireDate = expireDate;
          GoogleMap = googleMap;
          Address = address;
          Tel = tel;
          Mobile = mobile;
          WebUrl = webUrl;
          Email = email;
          VisitCount = visitCount;
          LanguageId = languageId;
          DomainId = domainId;
      }

      #endregion

#region Properties

      public Guid AdItemId { get; set; }
      public Int32 AdId { get; set; }
      public String Title { get; set; }
      public String Description { get; set; }
      public String BigPicture { get; set; }
      public String SmallPicture { get; set; }
      public DateTime EnterDate { get; set; }
      public DateTime? ExpireDate { get; set; }
      public String GoogleMap { get; set; }
      public String Address { get; set; }
      public String Tel { get; set; }
      public String Mobile { get; set; }
      public String WebUrl { get; set; }
      public String Email { get; set; }
      public Int32 VisitCount { get; set; }
      public Int32 LanguageId { get; set; }
      public Int32 DomainId { get; set; }

      #endregion
    }
}
