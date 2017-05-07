using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
//using Pine.Dal.Poll;
using Pine.Dal.Advertisement;

namespace Pine.Dal.SqlClient
{
   public class SqlAdvertisementProvider : AdvertisementProvider
    {
       public override AdvertisementDetails GetAdvertisementByAdId(int adId)
       {
           using (SqlConnection connection = new SqlConnection(ConnectionString))
           {
               using (SqlCommand command = new SqlCommand())
               {
                   command.CommandText = "SELECT * FROM Advertisement WHERE adId = @adId";
                   command.Connection = connection;
                   command.CommandType = CommandType.Text;
                   command.Parameters.Add("@adId", SqlDbType.Int).Value = adId;
                   connection.Open();
                   IDataReader reader = ExecuteReader(command, CommandBehavior.SingleRow);
                   if (reader.Read())
                       return GetAdvertisementFromDataReader(reader);
                   return null;
               }
           }
       }

       public override List<AdvertisementDetails> GetAllAdvertisement(int languageId, int domainId)
       {
           using (SqlConnection connection = new SqlConnection(ConnectionString))
           {
               using (SqlCommand command = new SqlCommand())
               {
                   command.CommandText = "select * from Advertisement where LanguageId = @languageId and DomainId = @domainId order by OrderBy asc";
                   command.Connection = connection;
                   command.CommandType = CommandType.Text;
                   command.Parameters.Add("@languageId", SqlDbType.Int).Value = languageId;
                   command.Parameters.Add("@domainId", SqlDbType.Int).Value = domainId;
                   connection.Open();
                   return GetAdvertisementCollectionFromDataReader(ExecuteReader(command));
               }
           }
       }

       

      public override int InsertAdvertisement(AdvertisementDetails advertisementDetails)
       {
           using (SqlConnection connection = new SqlConnection(ConnectionString))
           {
               SqlCommand com = new SqlCommand();
               com.CommandText = @"INSERT INTO Advertisement(parentId,title,description,isActive,languageId,DomainId,OrderBy)
                                   VALUES (@parentId,@title,@description,@isActive,@languageId,@domainId,@orderBy)";
               com.Parameters.Clear();
               com.Parameters.Add("@parentId", SqlDbType.Int).Value = (object)advertisementDetails.ParentId ?? DBNull.Value;
               com.Parameters.Add("@title", SqlDbType.NVarChar).Value = advertisementDetails.Title;
               com.Parameters.Add("@description", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(advertisementDetails.Description) ? DBNull.Value : (object)advertisementDetails.Description;
               com.Parameters.Add("@isActive", SqlDbType.Bit).Value = advertisementDetails.IsActive;
               com.Parameters.Add("@languageId", SqlDbType.Int).Value = advertisementDetails.LanguageId;
               com.Parameters.Add("@domainId", SqlDbType.Int).Value = advertisementDetails.DomainId;
               com.Parameters.Add("@orderBy", SqlDbType.TinyInt).Value = advertisementDetails.OrderBy;
               com.Connection = connection;
               connection.Open();
               int id = com.ExecuteNonQuery();
               connection.Close();
               return id;
           }
       }

       public override bool UpdateAdvertisement(AdvertisementDetails advertisementDetails)
       {
           using (SqlConnection connection = new SqlConnection(ConnectionString))
           {
               using (SqlCommand command = new SqlCommand("Update Advertisement set parentId=@parentId,title=@title,description=@description,isActive = @isActive,languageId = @languageId, domainId = @domainId , OrderBy = @orderBy" +
                                                          " where adId=@adId", connection))
               {

                   command.CommandType = CommandType.Text;
                   command.Parameters.Clear();
                   command.Parameters.Add("@parentId", SqlDbType.Int).Value = (object)advertisementDetails.ParentId ?? DBNull.Value;
                   command.Parameters.Add("@title", SqlDbType.NVarChar).Value = advertisementDetails.Title;
                   command.Parameters.Add("@description", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(advertisementDetails.Description) ? DBNull.Value : (object)advertisementDetails.Description;
                   command.Parameters.Add("@isActive", SqlDbType.Bit).Value = advertisementDetails.IsActive;
                   command.Parameters.Add("@languageId", SqlDbType.Int).Value = advertisementDetails.LanguageId;
                   command.Parameters.Add("@domainId", SqlDbType.Int).Value = advertisementDetails.DomainId;
                   command.Parameters.Add("@adId", SqlDbType.Int).Value = advertisementDetails.AdId;
                   command.Parameters.Add("@orderBy", SqlDbType.TinyInt).Value = advertisementDetails.OrderBy;
                   command.Connection = connection;
                   connection.Open();
                   Int32 result = ExecuteNonQuery(command);
                   return result == 1;
               }
           }
       }

       public override bool DeleteAdvertisement(Int32 adId)
       {
           using (SqlConnection connection = new SqlConnection(ConnectionString))
           {
               SqlCommand com = new SqlCommand();
               com.CommandText = " Delete from Advertisement where adId= @adId ";
               com.Parameters.Clear();
               com.Parameters.Add("@adId", SqlDbType.Int).Value = adId;
               com.Connection = connection;
               connection.Open();
               Int32 result = com.ExecuteNonQuery();
               connection.Close();
               return result == 1;
           }
       }

       public override AdvertisementItemsDetails GetAdvertisementItemByAdItemId(Guid adItemId)
       {
         using (SqlConnection connection = new SqlConnection(ConnectionString))
           {
               using (SqlCommand command = new SqlCommand())
               {
                   command.CommandText = "SELECT * FROM AdvertisementItems WHERE (adItemId = @adItemId) ";
                   command.Connection = connection;
                   command.CommandType = CommandType.Text;
                   command.Parameters.Add("@adItemId", SqlDbType.UniqueIdentifier).Value = adItemId;
                   connection.Open();
                   IDataReader reader = ExecuteReader(command, CommandBehavior.SingleRow);
                   if (reader.Read())
                       return GetAdvertisementItemFromDataReader(reader);
                   return null;
               }
           }
       }

       public override List<AdvertisementItemsDetails> GetAdvertisementItemsByAdId(Int32 adId)
       {
           using (SqlConnection connection = new SqlConnection(ConnectionString))
           {
               using (SqlCommand command = new SqlCommand())
               {
                   command.CommandText = "select * from AdvertisementItems where adId = @adId order by AdItemId desc";
                   command.Connection = connection;
                   command.CommandType = CommandType.Text;
                   command.Parameters.Add("@adId", SqlDbType.Int).Value = adId;
                   connection.Open();
                   return GetAdvertisementItemsCollectionFromDataReader(ExecuteReader(command));
               }
           }
       }

       public override List<AdvertisementItemsDetails> GetAdvertisementItemsByTagId(Guid tagId)
       {
           using (SqlConnection connection = new SqlConnection(ConnectionString))
           {
               using (SqlCommand command = new SqlCommand())
               {
                   command.CommandText = @"SELECT   AdvertisementItems.*
                    FROM   AdvertisementItems INNER JOIN
                         TagJunction ON AdvertisementItems.AdItemId = TagJunction.AdItemId
                    WHERE   (TagJunction.TagId = @TagId)";
                   command.Connection = connection;
                   command.CommandType = CommandType.Text;
                   command.Parameters.Add("@tagId", SqlDbType.UniqueIdentifier).Value = tagId;
                   connection.Open();
                   return GetAdvertisementItemsCollectionFromDataReader(ExecuteReader(command));
               }
           }
       }
       //(Guid adItemlId, Int32 adId, String title, String description, String bigPicture, String smallPicture,
       //   DateTime enterDate, DateTime? expireDate, String googleMap, String address, String tel, String mobile, String webUrl, String email,
       //   Int32 visitCount, Int32 languageId, Int32 domainId)
       public override int InsertAdvertisementItem(AdvertisementItemsDetails advertisementItemsDetails)
       {
           using (SqlConnection connection = new SqlConnection(ConnectionString))
           {
               SqlCommand com = new SqlCommand();
               com.CommandText = @"INSERT INTO AdvertisementItems(adId,title,description,bigPicture,smallPicture,enterDate,expireDate,
                                     googleMap, address, tel, mobile,webUrl,email,visitCount,languageId,domainId )
                                   VALUES (@adId,@title,@description,@bigPicture,@smallPicture,@enterDate,@expireDate,
                                     @googleMap,@address,@tel,@mobile,@webUrl,@email,@visitCount,@languageId,@domainId )";
               com.Parameters.Clear();
               com.Parameters.Add("@adId", SqlDbType.Int).Value = advertisementItemsDetails.AdId;
               com.Parameters.Add("@title", SqlDbType.NVarChar).Value = advertisementItemsDetails.Title;
               com.Parameters.Add("@description", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(advertisementItemsDetails.Description) ? DBNull.Value : (object)advertisementItemsDetails.Description;
               com.Parameters.Add("@bigPicture", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(advertisementItemsDetails.BigPicture) ? DBNull.Value : (object)advertisementItemsDetails.BigPicture;
               com.Parameters.Add("@smallPicture", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(advertisementItemsDetails.SmallPicture) ? DBNull.Value : (object)advertisementItemsDetails.SmallPicture;
               com.Parameters.Add("@enterDate", SqlDbType.DateTime).Value = advertisementItemsDetails.EnterDate;
               com.Parameters.Add("@expireDate", SqlDbType.DateTime).Value = (object)advertisementItemsDetails.ExpireDate ?? DBNull.Value;
               com.Parameters.Add("@googleMap", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(advertisementItemsDetails.GoogleMap) ? DBNull.Value : (object)advertisementItemsDetails.GoogleMap;
               com.Parameters.Add("@address", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(advertisementItemsDetails.Address) ? DBNull.Value : (object)advertisementItemsDetails.Address;
               com.Parameters.Add("@tel", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(advertisementItemsDetails.Tel) ? DBNull.Value : (object)advertisementItemsDetails.Tel;
               com.Parameters.Add("@mobile", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(advertisementItemsDetails.Mobile) ? DBNull.Value : (object)advertisementItemsDetails.Mobile;
               com.Parameters.Add("@webUrl", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(advertisementItemsDetails.WebUrl) ? DBNull.Value : (object)advertisementItemsDetails.WebUrl;
               com.Parameters.Add("@email", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(advertisementItemsDetails.Email) ? DBNull.Value : (object)advertisementItemsDetails.Email;
               com.Parameters.Add("@visitCount", SqlDbType.Int).Value = advertisementItemsDetails.VisitCount;
               com.Parameters.Add("@languageId", SqlDbType.Int).Value = advertisementItemsDetails.LanguageId;
                com.Parameters.Add("@domainId", SqlDbType.Int).Value = advertisementItemsDetails.DomainId;
               com.Connection = connection;
               connection.Open();
               int id = com.ExecuteNonQuery();
               connection.Close();
               return id;
           }
       }

       public override bool UpdateAdvertisementItem(AdvertisementItemsDetails advertisementItemsDetails)
       {
           using (SqlConnection connection = new SqlConnection(ConnectionString))
           {
               SqlCommand com = new SqlCommand();
               com.CommandText =
                   @"Update AdvertisementItems set adId = @adId,title = @title,description = @description,bigPicture = @bigPicture,
                smallPicture = @smallPicture,enterDate =@enterDate ,expireDate =@expireDate , googleMap = @googleMap, address = @address, 
                        tel = @tel, mobile = @mobile,webUrl = @webUrl,email = @email,visitCount = @visitCount,languageId = @languageId,domainId=@domainId
                                                where AdItemId = @adItemId";
               com.Parameters.Clear();
               com.Parameters.Add("@adId", SqlDbType.Int).Value = advertisementItemsDetails.AdId;
               com.Parameters.Add("@title", SqlDbType.NVarChar).Value = advertisementItemsDetails.Title;
               com.Parameters.Add("@description", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(advertisementItemsDetails.Description) ? DBNull.Value : (object)advertisementItemsDetails.Description;
               com.Parameters.Add("@bigPicture", SqlDbType.NVarChar).Value =
                   string.IsNullOrEmpty(advertisementItemsDetails.BigPicture)
                       ? DBNull.Value
                       : (object) advertisementItemsDetails.BigPicture;
               com.Parameters.Add("@smallPicture", SqlDbType.NVarChar).Value =
                   string.IsNullOrEmpty(advertisementItemsDetails.SmallPicture)
                       ? DBNull.Value
                       : (object) advertisementItemsDetails.SmallPicture;
               com.Parameters.Add("@enterDate", SqlDbType.DateTime).Value = advertisementItemsDetails.EnterDate;
               com.Parameters.Add("@expireDate", SqlDbType.DateTime).Value =
                   (object) advertisementItemsDetails.ExpireDate ?? DBNull.Value;
               com.Parameters.Add("@googleMap", SqlDbType.NVarChar).Value =
                   string.IsNullOrEmpty(advertisementItemsDetails.GoogleMap)
                       ? DBNull.Value
                       : (object) advertisementItemsDetails.GoogleMap;
               com.Parameters.Add("@address", SqlDbType.NVarChar).Value =
                   string.IsNullOrEmpty(advertisementItemsDetails.Address)
                       ? DBNull.Value
                       : (object) advertisementItemsDetails.Address;
               com.Parameters.Add("@tel", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(advertisementItemsDetails.Tel)
                                                                          ? DBNull.Value
                                                                          : (object) advertisementItemsDetails.Tel;
               com.Parameters.Add("@mobile", SqlDbType.NVarChar).Value =
                   string.IsNullOrEmpty(advertisementItemsDetails.Mobile)
                       ? DBNull.Value
                       : (object) advertisementItemsDetails.Mobile;
               com.Parameters.Add("@webUrl", SqlDbType.NVarChar).Value =
                   string.IsNullOrEmpty(advertisementItemsDetails.WebUrl)
                       ? DBNull.Value
                       : (object) advertisementItemsDetails.WebUrl;
               com.Parameters.Add("@email", SqlDbType.NVarChar).Value =
                   string.IsNullOrEmpty(advertisementItemsDetails.Email)
                       ? DBNull.Value
                       : (object) advertisementItemsDetails.Email;
               com.Parameters.Add("@visitCount", SqlDbType.Int).Value = advertisementItemsDetails.VisitCount;
               com.Parameters.Add("@languageId", SqlDbType.Int).Value = advertisementItemsDetails.LanguageId;
               com.Parameters.Add("@domainId", SqlDbType.Int).Value = advertisementItemsDetails.DomainId;
               com.Parameters.Add("@adItemId", SqlDbType.UniqueIdentifier).Value = advertisementItemsDetails.AdItemId;
               com.Connection = connection;
               connection.Open();
               Int32 result = ExecuteNonQuery(com);
               return result == 1;
           }
       }

       public override bool DeleteAdvertisementItem(Guid adItemId)
       {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
           {
               SqlCommand com = new SqlCommand();
               com.CommandText = " Delete from AdvertisementItems where adItemId= @adItemId ";
               com.Parameters.Clear();
               com.Parameters.Add("@adItemId", SqlDbType.UniqueIdentifier).Value = adItemId;
               com.Connection = connection;
               connection.Open();
               Int32 result = com.ExecuteNonQuery();
               connection.Close();
               return result == 1;
           }
       }
      
       public override int InsertAdvertisementRate(AdvertisementRateDetails advertisementRateDetails)
       {
           using (SqlConnection connection = new SqlConnection(ConnectionString))
           {
               SqlCommand com = new SqlCommand();
               com.CommandText = @"INSERT INTO AdvertisementRate(rate,userId)
                                   VALUES (@rate , @userId)";
               com.Parameters.Clear();
               com.Parameters.Add("@rate", SqlDbType.TinyInt).Value = advertisementRateDetails.Rate;
               com.Parameters.Add("@userId", SqlDbType.Int).Value = advertisementRateDetails.UserId;
               com.Connection = connection;
               connection.Open();
               int id = com.ExecuteNonQuery();
               connection.Close();
               return id;
           }
       }

       public override AdvertisementRateDetails GetAdvertisementRateByAdRateId(int adRateId)
       {
           using (SqlConnection connection = new SqlConnection(ConnectionString))
           {
               using (SqlCommand command = new SqlCommand())
               {
                   command.CommandText = "SELECT * FROM AdvertisementRate WHERE (adRateId = @adRateId) ";
                   command.Connection = connection;
                   command.CommandType = CommandType.Text;
                   command.Parameters.Add("@adRateId", SqlDbType.Int).Value = adRateId;
                   connection.Open();
                   IDataReader reader = ExecuteReader(command, CommandBehavior.SingleRow);
                   if (reader.Read())
                       return GetAdvertisementRateFromDataReader(reader);
                   return null;
               }
           }
       }
    }
}

