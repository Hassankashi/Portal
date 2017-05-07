using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace Pine.Dal.Advertisement
{
   public abstract class AdvertisementProvider : DataAccess
    {
       #region Fields (1)

       static private AdvertisementProvider _instance;

       #endregion Fields


        #region Constructors (1)

        /// <summary>
        /// سازنده اصلی کلاس
        /// </summary>
       protected AdvertisementProvider()
        {
            ConnectionString = Globals.Settings.Advertisement.ConnectionString;
            EnableCaching = Globals.Settings.Advertisement.EnableCaching;
            CacheDuration = Globals.Settings.Advertisement.CacheDuration;
        }

        #endregion Constructors

       static public AdvertisementProvider Instance
       {
           get
           {
               return _instance ?? (_instance = (AdvertisementProvider)Activator.CreateInstance(
                   Type.GetType(Globals.Settings.Advertisement.ProviderType)));
           }
       }

       #region Advertisement
       public abstract AdvertisementDetails GetAdvertisementByAdId(Int32 adId);
       public abstract List<AdvertisementDetails> GetAllAdvertisement(Int32 laguageId,Int32 domainId);
       public abstract List<AdvertisementItemsDetails> GetAdvertisementItemsByTagId(Guid tagId);
       public abstract Int32 InsertAdvertisement(AdvertisementDetails advertisementDetails);
       public abstract Boolean UpdateAdvertisement(AdvertisementDetails advertisementDetails);
       public abstract Boolean DeleteAdvertisement(Int32 adId);
#endregion

       #region Virtual Protected Methods (2)

       protected virtual List<AdvertisementDetails> GetAdvertisementCollectionFromDataReader(IDataReader reader)
       {
           List<AdvertisementDetails> items = new List<AdvertisementDetails>();
           while (reader.Read())
               items.Add(GetAdvertisementFromDataReader(reader));
           return items;
       }

     protected virtual AdvertisementDetails GetAdvertisementFromDataReader(IDataReader reader)
       {
           return new AdvertisementDetails
               (
                   (Int32)reader["adId"],
                   reader["parentId"] as Int32?,
                   (String)reader["title"],
                   reader["description"].ToString(),
                   (bool)reader["isActive"],
                   (Int32)reader["languageId"],
                   (Int32)reader["domainId"],
                   (Byte)reader["OrderBy"]
               );
       }
       #endregion


#region AdvertisementItem
     public abstract AdvertisementItemsDetails GetAdvertisementItemByAdItemId(Guid adItemlId);
       public abstract List<AdvertisementItemsDetails> GetAdvertisementItemsByAdId(Int32 adId);
       public abstract Int32 InsertAdvertisementItem(AdvertisementItemsDetails advertisementItemsDetails);
       public abstract Boolean UpdateAdvertisementItem(AdvertisementItemsDetails advertisementItemsDetails);
       public abstract Boolean DeleteAdvertisementItem(Guid adItemlId);
#endregion

       #region Virtual Protected Methods (2)

       protected virtual List<AdvertisementItemsDetails> GetAdvertisementItemsCollectionFromDataReader(IDataReader reader)
       {
           List<AdvertisementItemsDetails> items = new List<AdvertisementItemsDetails>();
           while (reader.Read())
               items.Add(GetAdvertisementItemFromDataReader(reader));
           return items;
       }

      protected virtual AdvertisementItemsDetails GetAdvertisementItemFromDataReader(IDataReader reader)
       {
           return new AdvertisementItemsDetails
               (
                   (Guid)reader["adItemId"],
                   (Int32)reader["AdId"],
                   (String)reader["title"],
                   reader["description"].ToString(),
                   reader["bigPicture"].ToString(),
                   reader["smallPicture"].ToString(),
                   (DateTime)reader["enterDate"],
                   reader["expireDate"] as DateTime?,
                   reader["googleMap"].ToString(),
                   reader["address"].ToString(),
                   reader["tel"].ToString(),
                   reader["mobile"].ToString(),
                   reader["webUrl"].ToString(),
                   reader["email"].ToString(),
                   (Int32)reader["visitCount"],
                   (Int32)reader["languageId"],
                   (Int32)reader["domainId"]
               );
       }
       #endregion
      
#region AdvertisementRate
      public abstract Int32 InsertAdvertisementRate(AdvertisementRateDetails advertisementRateDetails);
      public abstract AdvertisementRateDetails GetAdvertisementRateByAdRateId(Int32 adRateId);

      protected virtual AdvertisementRateDetails GetAdvertisementRateFromDataReader(IDataReader reader)
      {
          return new AdvertisementRateDetails
              (
                 (Int32)reader["adRateId"],
                   (Byte)reader["rate"],
                   (Int32)reader["userId"]
              
              );
      }

       #endregion
    }
}
