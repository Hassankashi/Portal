using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
//using Pine.Dal.Poll;
using Pine.Dal.Tag;

namespace Pine.Dal.SqlClient
{
    /// <summary>
    /// کلاسی برای پیاده سازی منوها
    /// </summary>
    public class SqlTagProvider : TagProvider
    {
     
     public override TagDetails GetTagByTagId(Guid tagId)
     {
         using (SqlConnection connection = new SqlConnection(ConnectionString))
         {
             using (SqlCommand command = new SqlCommand())
             {
                 command.CommandText = "SELECT * FROM Tag WHERE (TagId = @tagId) ";
                 command.Connection = connection;
                 command.CommandType = CommandType.Text;
                 command.Parameters.Add("@tagId", SqlDbType.UniqueIdentifier).Value = tagId;
                 connection.Open();
                 IDataReader reader = ExecuteReader(command, CommandBehavior.SingleRow);
                 if (reader.Read())
                     return GetTagFromDataReader(reader);
                 return null;
             }
         }
     }

        public override List<TagDetails> GetTagByTagGroupId(Guid tagGroupId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "select * from Tag where (TagGroupId = @tagGroupId)";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@tagGroupId", SqlDbType.UniqueIdentifier).Value = tagGroupId;
                   connection.Open();
                    return GetTagCollectionFromDataReader(ExecuteReader(command));
                }
            }
        }
                                             
        public override List<TagDetails>  GetTagByAdItemId(Guid adItemId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = @"select t.TagId,t.Title,t.TagGroupId , j.AdItemId from Tag as t
                    join TagJunction as j 
                        on t.TagId = j.TagId
                    where (AdItemId = @AdItemId)";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@AdItemId", SqlDbType.UniqueIdentifier).Value = adItemId;
                   connection.Open();
                    return GetTagCollectionFromDataReader(ExecuteReader(command));
                }
            }
        }

        public override int InsertTag(TagDetails tagDetails)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
               SqlCommand com = new SqlCommand();
               com.CommandText = @"INSERT INTO Tag(Title,TagGroupId)
                                   VALUES (@title,@tagGroupId)";
                com.Parameters.Clear();
                com.Parameters.Add("@tagId", SqlDbType.UniqueIdentifier).Value = tagDetails.TagId;
                com.Parameters.Add("@title", SqlDbType.NVarChar).Value = tagDetails.Title;
                com.Parameters.Add("@tagGroupId", SqlDbType.UniqueIdentifier).Value = tagDetails.TagGroupId;
                com.Connection = connection;
                connection.Open();
                int id = ExecuteNonQuery(com);
                connection.Close();
                return id;
            }
        }

        public override bool UpdateTag(TagDetails tagDetails)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("Update Tag set Title=@Title,TagGroupId=@tagGroupId "+
                                                           "where TagId=@TagId", connection))
               {
                    command.Parameters.Clear();
                    command.Parameters.Add("@tagId", SqlDbType.UniqueIdentifier).Value = tagDetails.TagId;
                    command.Parameters.Add("@title", SqlDbType.NVarChar).Value = tagDetails.Title;
                    command.Parameters.Add("@tagGroupId", SqlDbType.UniqueIdentifier).Value = tagDetails.TagGroupId;
                    command.CommandType = CommandType.Text;
                   command.Connection = connection;
                    connection.Open();
                    Int32 result = ExecuteNonQuery(command);
                    return result == 1;
                }
            }
        }

        public override bool DeleteTag(Guid tagId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand com = new SqlCommand();
                com.CommandText = " Delete from Tag where TagId = @tagId ";
                com.Parameters.Clear();
                com.Parameters.Add("@tagId", SqlDbType.UniqueIdentifier).Value = tagId;
                com.Connection = connection;
                connection.Open();
                Int32 result = com.ExecuteNonQuery();
                connection.Close();
                return result == 1;
            }
        }

        public override List<TagGroupDetails> GetAllTagGroup(int languageId, int domainId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "select * from TagGroup where LanguageId = @languageId and DomainId = @domainId";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@languageId", SqlDbType.Int).Value = languageId;
                    command.Parameters.Add("@domainId", SqlDbType.Int).Value = domainId;
                    connection.Open();
                    return GetTagGroupCollectionFromDataReader(ExecuteReader(command));
                }
            }
        }

        public override TagGroupDetails GetTagGroupByTagGroupId(Guid tagGroupId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT * FROM TagGroup WHERE (tagGroupId = @tagGroupId) ";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@tagGroupId", SqlDbType.UniqueIdentifier).Value = tagGroupId;
                    connection.Open();
                    IDataReader reader = ExecuteReader(command, CommandBehavior.SingleRow);
                    if (reader.Read())
                        return GetTagGroupFromDataReader(reader);
                    return null;
                }
            }
        }

        public override int InsertTagGroup(TagGroupDetails tagGroupDetails)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand com = new SqlCommand();
                com.CommandText = @"INSERT INTO TagGroup(TagGroupName,LanguageId,DomainId)
                                   VALUES (@TagGroupName,@LanguageId,@DomainId)";
                com.Parameters.Clear();
                com.Parameters.Add("@TagGroupName", SqlDbType.NVarChar).Value = tagGroupDetails.TagGroupName;
                com.Parameters.Add("@LanguageId", SqlDbType.Int).Value = tagGroupDetails.LanguageId;
                com.Parameters.Add("@DomainId", SqlDbType.Int).Value = tagGroupDetails.DomainId;
                com.Connection = connection;
                connection.Open();
                int id = ExecuteNonQuery(com);
                connection.Close();
                return id;
            }
        }

      
        public override bool UpdateTagGroup(TagGroupDetails tagGroupDetails)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("Update TagGroup set TagGroupName=@TagGroupName,LanguageId=@LanguageId,DomainId=@DomainId " +
                                                           "where TagGroupId=@TagGroupId", connection))
                {
                    command.Parameters.Clear();
                    command.Parameters.Add("@TagGroupId", SqlDbType.UniqueIdentifier).Value = tagGroupDetails.TagGroupId;
                    command.Parameters.Add("@TagGroupName", SqlDbType.NVarChar).Value = tagGroupDetails.TagGroupName;
                    command.Parameters.Add("@LanguageId", SqlDbType.Int).Value = tagGroupDetails.LanguageId;
                    command.Parameters.Add("@DomainId", SqlDbType.Int).Value = tagGroupDetails.DomainId;
                    command.CommandType = CommandType.Text;
                    command.Connection = connection;
                    connection.Open();
                    Int32 result = ExecuteNonQuery(command);
                    return result == 1;
                }
            }
        }

        public override bool DeleteTagGroup(Guid tagGroupId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand com = new SqlCommand();
                com.CommandText = " Delete from TagGroup where TagGroupId = @TagGroupId ";
                com.Parameters.Clear();
                com.Parameters.Add("@tagGroupId", SqlDbType.UniqueIdentifier).Value = tagGroupId;
                com.Connection = connection;
                connection.Open();
                Int32 result = com.ExecuteNonQuery();
                connection.Close();
                return result == 1;
            }
        }

        public override int InsertTagJunction(TagJunctionDetails tagJunctionDetails)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand com = new SqlCommand();
                com.CommandText = @"INSERT INTO TagJunction(TagId,AdItemId)
                                   VALUES (@tagId,@adItemId)";
                com.Parameters.Clear();
                com.Parameters.Add("@tagId", SqlDbType.UniqueIdentifier).Value = tagJunctionDetails.TagId;
                com.Parameters.Add("@adItemId", SqlDbType.UniqueIdentifier).Value = tagJunctionDetails.AdItemId;
                com.Connection = connection;
                connection.Open();
                int id = ExecuteNonQuery(com);
                connection.Close();
                return id;
            }
        }

        public override List<TagJunctionDetails> GetTagJunctionByadItemId(Guid adItemId)
       {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT * FROM TagJunction WHERE (adItemId = @adItemId) ";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@adItemId", SqlDbType.UniqueIdentifier).Value = adItemId;
                    connection.Open();
                    return GetTagJunctionCollectionFromDataReader(ExecuteReader(command));
                }
            }
        }

        public override bool DeleteTagJunction(Guid tagId, Guid adItemId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand com = new SqlCommand();
                com.CommandText = " Delete from TagJunction where tagId = @tagId and adItemId = @adItemId ";
                com.Parameters.Clear();
                com.Parameters.Add("@tagId", SqlDbType.UniqueIdentifier).Value = tagId;
                com.Parameters.Add("@adItemId", SqlDbType.UniqueIdentifier).Value = adItemId;
                com.Connection = connection;
                connection.Open();
                Int32 result = com.ExecuteNonQuery();
                connection.Close();
                return result == 1;
            }
        }

     }
}

