using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pine.Dal.Advertisement
{
  public class AdvertisementRateDetails
    {
#region constructor
      public AdvertisementRateDetails()
      {
      }
      public AdvertisementRateDetails(Int32 adRateId, Byte rate, Int32 userId)
      {
          AdRateId = adRateId;
          Rate = rate;
          UserId = userId;
      }
      #endregion

#region Properties

      public Int32 AdRateId { get; set; }
      public Byte Rate { get; set; }
      public Int32 UserId { get; set; }

      #endregion
    }
}
