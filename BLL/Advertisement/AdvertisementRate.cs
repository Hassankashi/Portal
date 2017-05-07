using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using  Pine.Dal;
using Pine.Dal.Advertisement;

namespace Pine.Bll.Advertisement
{
    public class AdvertisementRate : BaseAdvertisement
    {

       public AdvertisementRate()
      {
      }

      public AdvertisementRate(Int32 adRateId, Byte rate, Int32 userId)
      {
          AdRateId = adRateId;
          Rate = rate;
          UserId = userId;
      }
   

#region Properties

      public Int32 AdRateId { get; set; }
      public Byte Rate { get; set; }
      public Int32 UserId { get; set; }

      #endregion
    
#region Method
      public static AdvertisementRate GetAdvertisementRateByAdRateId(Int32 adRateId)
      {
          AdvertisementRate item;
          SetCache();
          String key = "AdvertisementRateByAdRate_AdRateId_" + adRateId;

          if (Settings.EnableCaching)
          {
              item = GetCacheItem(key) as AdvertisementRate;
              if (item == null)
              {
                  AdvertisementRateDetails record = SiteProvider.Advertisement.GetAdvertisementRateByAdRateId(adRateId);
                  item = GetAdvertisementRateFromOrderDal(record);
                  AddCacheItem(key, item);
              }
          }
          else
          {
              AdvertisementRateDetails recordSet = SiteProvider.Advertisement.GetAdvertisementRateByAdRateId(adRateId);
              item = GetAdvertisementRateFromOrderDal(recordSet);
          }

          return item;
      }

      private static AdvertisementRate GetAdvertisementRateFromOrderDal(AdvertisementRateDetails record)
      {
          if (record != null)
              return new AdvertisementRate(record.AdRateId, record.Rate, record.UserId);
                  return null;
      }

      public Int32 InsertAdvertisementRate()
      {
          return InsertAdvertisementRate(AdRateId, Rate, UserId);

      }

      private Int32 InsertAdvertisementRate(Int32 adRateId, Byte rate, Int32 userId)
      {
          AdvertisementRateDetails advertisementRateDetails = new AdvertisementRateDetails(adRateId, rate, userId);
          Int32 ret = SiteProvider.Advertisement.InsertAdvertisementRate(advertisementRateDetails);
          if (Settings.EnableCaching & ret > 0)
          {
              SetCache();
              InvalidateCache();
          }

          return ret;
      }





#endregion

    }
}
