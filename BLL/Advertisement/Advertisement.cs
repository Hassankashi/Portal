using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pine.Dal;
using Pine.Dal.Advertisement;
using Pine.Bll.Advertisement;

namespace Pine.Bll.Advertisement
{
  public class Advertisement :  BaseAdvertisement
  {
        public Advertisement()
      {
      }

      public Advertisement(Int32 adId, Int32? parentId, String title, String description, Boolean isActive, Int32 languageId, Int32 domainId , Byte orderBy)
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

    #region Properties

      public Int32 AdId { get; set; }
      public Int32? ParentId { get; set; }
      public String Title { get; set; }
      public String Description { get; set; }
      public Boolean IsActive { get; set; }
      public Int32 LanguageId { get; set; }
      public Int32 DomainId { get; set; }
      public Byte OrderBy { get; set; }
      #endregion


#region Method
      public static Advertisement GetAdvertisementByAdId(Int32 adId)
      {
          Advertisement item;
          SetCache();
          String key = "Advertisement_AdId_" + adId;

          if (Settings.EnableCaching)
          {
              item = GetCacheItem(key) as Advertisement;
              if (item == null)
              {
                  AdvertisementDetails record = SiteProvider.Advertisement.GetAdvertisementByAdId(adId);
                  item = GetAdvertisementFromOrderDal(record);
                  AddCacheItem(key, item);
              }
          }
          else
          {
              AdvertisementDetails recordSet = SiteProvider.Advertisement.GetAdvertisementByAdId(adId);
              item = GetAdvertisementFromOrderDal(recordSet);
          }

          return item;
      }

      public static List<Advertisement> GetAllAdvertisement(Int32 laguageId , Int32 domainId)
      {

          SetCache();
          List<Advertisement> item;

          String key = "Advertisement_laguageId_domainId" + laguageId + domainId;

          if (Settings.EnableCaching)
          {
              item = GetCacheItem(key) as List<Advertisement>;
              if (item == null)
              {
                  List<AdvertisementDetails> recordSet = SiteProvider.Advertisement.GetAllAdvertisement(laguageId,domainId);
                  item = GetAdvertisementCollectionFromOrderDal(recordSet);
                  AddCacheItem(key, item);
              }
          }
          else
          {
              List<AdvertisementDetails> recordSet = SiteProvider.Advertisement.GetAllAdvertisement(laguageId, domainId);
              item = GetAdvertisementCollectionFromOrderDal(recordSet);
          }
          return item;
      }

      private static Advertisement GetAdvertisementFromOrderDal(AdvertisementDetails record)
      {
          if (record != null)
              return new Advertisement(record.AdId, record.ParentId, record.Title,record.Description,
                  record.IsActive,record.LanguageId,record.DomainId ,record.OrderBy);
          return null;
      }

      private static List<Advertisement> GetAdvertisementCollectionFromOrderDal(List<AdvertisementDetails> records)
      {
          List<Advertisement> items = new List<Advertisement>();
          foreach (AdvertisementDetails item in records)
              items.Add(GetAdvertisementFromOrderDal(item));
          return items;
      }
      public Int32 InsertAdvertisement()
      {
          return InsertAdvertisement(AdId, ParentId, Title, Description, IsActive, LanguageId, DomainId,OrderBy);

      }

      private Int32 InsertAdvertisement(Int32 adId, Int32? parentId, String title, String description, Boolean isActive, Int32 languageId, Int32 domainId , Byte orderBy)
      {
          AdvertisementDetails advertisementDetails = new AdvertisementDetails(adId, parentId, title, description, isActive, languageId, domainId,orderBy);
          Int32 ret = SiteProvider.Advertisement.InsertAdvertisement(advertisementDetails);
          if (Settings.EnableCaching & ret > 0)
          {
              SetCache();
              InvalidateCache();
          }

          return ret;
      }



      public bool UpdateAdvertisement()
      {
          return UpdateAdvertisement(AdId, ParentId, Title, Description, IsActive, LanguageId, DomainId,OrderBy);
      }
      private Boolean UpdateAdvertisement(Int32 adId, Int32? parentId, String title, String description, Boolean isActive, Int32 languageId, Int32 domainId , Byte orderBy)
      {
          AdvertisementDetails advertisementDetails = new AdvertisementDetails(adId, parentId, title, description, isActive, languageId, domainId,orderBy);
          Boolean ret = SiteProvider.Advertisement.UpdateAdvertisement(advertisementDetails);
          if (Settings.EnableCaching & ret)
          {
              SetCache();
              InvalidateCache();
          }
          return ret;
      }

      public bool DeleteAdvertisement()
      {
          return DeleteAdvertisement(AdId, ParentId, Title, Description, IsActive, LanguageId, DomainId , OrderBy);
      }

      private bool DeleteAdvertisement(Int32 adId, Int32? parentId, String title, String description, Boolean isActive,
                             Int32 languageId, Int32 domainId , Byte orderBy)
      {
          AdvertisementDetails advertisementDetails = new AdvertisementDetails(adId, parentId, title, description, isActive, languageId, domainId,orderBy);
          bool ret = SiteProvider.Advertisement.DeleteAdvertisement(advertisementDetails.AdId);
          if (Settings.EnableCaching & ret)
              InvalidateCache();
          return ret;
      }
    
#endregion
  }
}
