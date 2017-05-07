using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pine.Dal;
using Pine.Dal.Advertisement;

namespace Pine.Bll.Advertisement
{
  public  class AdvertisementItems : BaseAdvertisement
    {

        public AdvertisementItems()
      {

      }

      public AdvertisementItems(Guid adItemId, Int32 adId, String title, String description, String bigPicture, String smallPicture,
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

#region Method
      public static AdvertisementItems GetAdvertisementItemsByAdItemId(Guid adItemId)
      {
          AdvertisementItems item;
          SetCache();
          String key = "AdvertisementItems_adItemId_" + adItemId;

          if (Settings.EnableCaching)
          {
              item = GetCacheItem(key) as AdvertisementItems;
              if (item == null)
              {
                  AdvertisementItemsDetails record = SiteProvider.Advertisement.GetAdvertisementItemByAdItemId(adItemId);
                  item = GetAdvertisementItemFromOrderDal(record);
                  AddCacheItem(key, item);
              }
          }
          else
          {
              AdvertisementItemsDetails recordSet = SiteProvider.Advertisement.GetAdvertisementItemByAdItemId(adItemId);
              item = GetAdvertisementItemFromOrderDal(recordSet);
          }

          return item;
      }


      public static List<AdvertisementItems> GetAdvertisementItemsByAdId(Int32 adId)
      {

          SetCache();
          List<AdvertisementItems> item;

          String key = "AdvertisementItems_AdId_" + adId;

          if (Settings.EnableCaching)
          {
              item = GetCacheItem(key) as List<AdvertisementItems>;
              if (item == null)
              {
                  List<AdvertisementItemsDetails> recordSet = SiteProvider.Advertisement.GetAdvertisementItemsByAdId(adId);
                  item = GetAdvertisementItemCollectionFromOrderDal(recordSet);
                  AddCacheItem(key, item);
              }
          }
          else
          {
              List<AdvertisementItemsDetails> recordSet = SiteProvider.Advertisement.GetAdvertisementItemsByAdId(adId);
              item = GetAdvertisementItemCollectionFromOrderDal(recordSet);
          }

          return item;
      }

      public static List<AdvertisementItems> GetAdvertisementItemsByTagId(Guid tagId)
      {

          SetCache();
          List<AdvertisementItems> item;

          String key = "AdvertisementItems_tagId_" + tagId;

          if (Settings.EnableCaching)
          {
              item = GetCacheItem(key) as List<AdvertisementItems>;
              if (item == null)
              {
                  List<AdvertisementItemsDetails> recordSet = SiteProvider.Advertisement.GetAdvertisementItemsByTagId(tagId);
                  item = GetAdvertisementItemCollectionFromOrderDal(recordSet);
                  AddCacheItem(key, item);
              }
          }
          else
          {
              List<AdvertisementItemsDetails> recordSet = SiteProvider.Advertisement.GetAdvertisementItemsByTagId(tagId);
              item = GetAdvertisementItemCollectionFromOrderDal(recordSet);
          }
          return item;
      }

     private static AdvertisementItems GetAdvertisementItemFromOrderDal(AdvertisementItemsDetails record)
      {
          if (record != null)
              return new AdvertisementItems(record.AdItemId, record.AdId, record.Title, record.Description,record.BigPicture,
                  record.SmallPicture, record.EnterDate, record.ExpireDate,record.GoogleMap,record.Address,record.Tel,record.Mobile,record.WebUrl,record.Email,
                  record.VisitCount,record.LanguageId,record.DomainId);
          return null;
      }

     private static List<AdvertisementItems> GetAdvertisementItemCollectionFromOrderDal(List<AdvertisementItemsDetails> records)
     {
         List<AdvertisementItems> items = new List<AdvertisementItems>();
         foreach (AdvertisementItemsDetails item in records)
             items.Add(GetAdvertisementItemFromOrderDal(item));
         return items;
     }

     public Int32 InsertAdvertisementItem()
     {
         return InsertAdvertisementItem(AdItemId,AdId,Title,Description,BigPicture,SmallPicture,
          EnterDate, ExpireDate, GoogleMap, Address, Tel, Mobile, WebUrl, Email,
          VisitCount, LanguageId, DomainId);

     }

     private Int32 InsertAdvertisementItem(Guid adItemId, Int32 adId, String title, String description, String bigPicture, String smallPicture,
          DateTime enterDate, DateTime? expireDate, String googleMap, String address, String tel, String mobile, String webUrl, String email,
          Int32 visitCount, Int32 languageId, Int32 domainId)
     {
         AdvertisementItemsDetails advertisementItemDetails = new AdvertisementItemsDetails(adItemId, adId, title, description,
                                                                                  bigPicture, smallPicture,
                                                                                  enterDate, expireDate, googleMap,
                                                                                  address, tel, mobile, webUrl, email,
                                                                                  visitCount, languageId, domainId);
         Int32 ret = SiteProvider.Advertisement.InsertAdvertisementItem(advertisementItemDetails);
         if (Settings.EnableCaching & ret > 0)
         {
             SetCache();
             InvalidateCache();
         }

         return ret;
     }



     public bool UpdateAdvertisementItem()
     {
         return UpdateAdvertisement(AdItemId, AdId, Title, Description, BigPicture, SmallPicture,
          EnterDate, ExpireDate, GoogleMap, Address, Tel, Mobile, WebUrl, Email,
          VisitCount, LanguageId, DomainId);
     }
     private Boolean UpdateAdvertisement(Guid adItemId, Int32 adId, String title, String description, String bigPicture, String smallPicture,
          DateTime enterDate, DateTime? expireDate, String googleMap, String address, String tel, String mobile, String webUrl, String email,
          Int32 visitCount, Int32 languageId, Int32 domainId)
     {
         AdvertisementItemsDetails advertisementItemDetails = new AdvertisementItemsDetails(adItemId, adId, title, description,
                                                                                  bigPicture, smallPicture,
                                                                                  enterDate, expireDate, googleMap,
                                                                                  address, tel, mobile, webUrl, email,
                                                                                  visitCount, languageId, domainId);
         Boolean ret = SiteProvider.Advertisement.UpdateAdvertisementItem(advertisementItemDetails);
         if (Settings.EnableCaching & ret)
         {
             SetCache();
             InvalidateCache();
         }
         return ret;
     }

     public bool DeleteAdvertisementItem()
     {
         return DeleteAdvertisementItem(AdItemId, AdId, Title, Description, BigPicture, SmallPicture,
          EnterDate, ExpireDate, GoogleMap, Address, Tel, Mobile, WebUrl, Email,
          VisitCount, LanguageId, DomainId);
     }

     private bool DeleteAdvertisementItem(Guid adItemId, Int32 adId, String title, String description, String bigPicture, String smallPicture,
          DateTime enterDate, DateTime? expireDate, String googleMap, String address, String tel, String mobile, String webUrl, String email,
          Int32 visitCount, Int32 languageId, Int32 domainId)
     {
         AdvertisementItemsDetails advertisementItemDetails = new AdvertisementItemsDetails(adItemId, adId, title, description,
                                                                                  bigPicture, smallPicture,
                                                                                  enterDate, expireDate, googleMap,
                                                                                  address, tel, mobile, webUrl, email,
                                                                                  visitCount, languageId, domainId);
         bool ret = SiteProvider.Advertisement.DeleteAdvertisementItem(advertisementItemDetails.AdItemId);
         if (Settings.EnableCaching & ret)
             InvalidateCache();
         return ret;
     }
    

#endregion
    }
}
