using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Pine.Dal.Store;

namespace Pine.Dal.SqlClient
{
    /// <summary>
    /// کلاسی برای پیاده سازی بلاگ
    /// </summary>
    public class SqlStoreProvider : StoreProvider   
    {
        #region CategoriesConTagGroups

        public override bool DeleteCategoriesConTagGroups(Guid Id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "DELETE FROM Store_CategoriesConTagGroups Where CategoryId = @CategoryId";
                    command.Parameters.Add("@CategoryId", SqlDbType.UniqueIdentifier).Value = Id;
                    command.CommandType = CommandType.Text;
                    command.Connection = connection;
                    connection.Open();
                    Int32 result = ExecuteNonQuery(command);
                    return result == 1;
                }
            } 
        }

        public override int insertCategoriesConTagGroups(Store_CategoriesConTagGroupsDetails store_CategoriesConTagGroupsDetails)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand com = new SqlCommand();
                com.CommandText = @"INSERT INTO Store_CategoriesConTagGroups (CategoryId,TagGroupId) values(@CategoryId,@TagGroupId)";
                com.Parameters.Clear();

                com.Parameters.Add("@CategoryId", SqlDbType.UniqueIdentifier).Value = store_CategoriesConTagGroupsDetails.CategoryId;
                com.Parameters.Add("@TagGroupId", SqlDbType.UniqueIdentifier).Value = store_CategoriesConTagGroupsDetails.TagGroupId;


                com.Connection = connection;
                connection.Open();
                int result = com.ExecuteNonQuery();
                connection.Close();
                return result;
            }
        }

        public override bool UpdateCategoriesConTagGroups(Store_CategoriesConTagGroupsDetails store_CategoriesConTagGroupsDetails)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("Update Store_CategoriesConTagGroups set   TagGroupId=@TagGroupId   where CategoryId=@CategoryId  ", connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.Clear();
                    command.Parameters.Add("@CategoryId", SqlDbType.UniqueIdentifier).Value = store_CategoriesConTagGroupsDetails.CategoryId;
                    command.Parameters.Add("@TagGroupId", SqlDbType.UniqueIdentifier).Value = store_CategoriesConTagGroupsDetails.TagGroupId;
             

                    connection.Open();
                    Int32 result = ExecuteNonQuery(command);
                    return result == 1;
                }
            }
        }

        public override List<Store_CategoriesConTagGroupsDetails> GetCategoriesConTagGroupById(Guid Id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT * FROM Store_CategoriesConTagGroups WHERE (CategoryId = @CategoryId)";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@CategoryId", SqlDbType.UniqueIdentifier).Value = Id;
                    command.Connection = connection;
                    connection.Open();
                    return GetStore_CategoriesConTagGroupCollectionFromDataReader(ExecuteReader(command));
                }

            }
        }

        #endregion


        #region Categories

        public override bool DeleteCategories(Guid Id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "DELETE FROM Store_Categories Where CategoryId = @CategoryId";
                    command.Parameters.Add("@CategoryId", SqlDbType.UniqueIdentifier).Value = Id;
                    command.CommandType = CommandType.Text;
                    command.Connection = connection;
                    connection.Open();
                    Int32 result = ExecuteNonQuery(command);
                    return result == 1;
                }
            } 
        }
        public override List<Store_CategoriesDetails> GetCategoryByDomainAndLanguage(int Domain, int Language)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "select * FROM Store_Categories Where DomainId = @DomainId And LanguageId=@LanguageId  order by Priority Asc ";
                    command.Parameters.Add("@DomainId", SqlDbType.Int).Value = Domain;
                    command.Parameters.Add("@LanguageId", SqlDbType.Int).Value = Language;
                    command.CommandType = CommandType.Text;
                    command.Connection = connection;
                    connection.Open();
                    return GetStore_CategoriesCollectionFromDataReader(ExecuteReader(command));
                }
            } 
        }
        public override int insertCategories(Store_CategoriesDetails store_CategoriesDetails)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand com = new SqlCommand();
                com.CommandText = @"INSERT INTO Store_Categories (Name,Icon,Priority,ParentCategoryId,ProductsCount,Username,Status,DomainId,LanguageId) values(@Name,@Icon,@Priority,@ParentCategoryId,@ProductsCount,@Username,@Status,@DomainId,@LanguageId)"; 
                com.Parameters.Clear();

             //   com.Parameters.Add("@CategoryId", SqlDbType.UniqueIdentifier).Value = store_CategoriesDetails.CategoryId;
                com.Parameters.Add("@Name", SqlDbType.NVarChar).Value = store_CategoriesDetails.Name;
                com.Parameters.Add("@Icon", SqlDbType.NVarChar).Value = String.IsNullOrEmpty(store_CategoriesDetails.Icon) ? DBNull.Value : (Object)store_CategoriesDetails.Icon;
                com.Parameters.Add("@Priority", SqlDbType.Int).Value = store_CategoriesDetails.Priority;
                com.Parameters.Add("@ParentCategoryId", SqlDbType.UniqueIdentifier).Value = (Object)store_CategoriesDetails.ParentCategoryId ?? DBNull.Value ;
                com.Parameters.Add("@ProductsCount", SqlDbType.Int).Value = (Object)store_CategoriesDetails.ProductsCount ?? DBNull.Value;
                com.Parameters.Add("@Username", SqlDbType.NVarChar).Value = store_CategoriesDetails.Username;
                com.Parameters.Add("@Status", SqlDbType.Bit).Value = store_CategoriesDetails.Status;
                com.Parameters.Add("@DomainId", SqlDbType.Int).Value = store_CategoriesDetails.DomainId;
                com.Parameters.Add("@LanguageId", SqlDbType.Int).Value = store_CategoriesDetails.LanguageId;
                com.Connection = connection;
                connection.Open();
                int result = com.ExecuteNonQuery();
                connection.Close();
                return result;
            }
        }

        public override bool UpdateCategories(Store_CategoriesDetails store_CategoriesDetails)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("Update Store_Categories set   Name=@Name ,Icon=@Icon,Priority=@Priority,ParentCategoryId=@ParentCategoryId,ProductsCount=@ProductsCount,Username=@Username,Status=@Status,DomainId=@DomainId,LanguageId=@LanguageId   where CategoryId=@CategoryId  ", connection))
                {
                    command.Parameters.Add("@CategoryId", SqlDbType.UniqueIdentifier).Value = store_CategoriesDetails.CategoryId;
                    command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = store_CategoriesDetails.Name;
                    command.Parameters.Add("@Icon", SqlDbType.NVarChar).Value = String.IsNullOrEmpty(store_CategoriesDetails.Icon) ? DBNull.Value : (Object)store_CategoriesDetails.Icon;
                    command.Parameters.Add("@Priority", SqlDbType.Int).Value = store_CategoriesDetails.Priority;
                    command.Parameters.Add("@ParentCategoryId", SqlDbType.UniqueIdentifier).Value = (Object)store_CategoriesDetails.ParentCategoryId ?? DBNull.Value;
                    command.Parameters.Add("@ProductsCount", SqlDbType.Int).Value = (Object)store_CategoriesDetails.ProductsCount ?? DBNull.Value;
                    command.Parameters.Add("@Username", SqlDbType.NVarChar).Value = store_CategoriesDetails.Username;
                    command.Parameters.Add("@Status", SqlDbType.Bit).Value = store_CategoriesDetails.Status;
                    command.Parameters.Add("@DomainId", SqlDbType.Int).Value = store_CategoriesDetails.DomainId;
                    command.Parameters.Add("@LanguageId", SqlDbType.Int).Value = store_CategoriesDetails.LanguageId;
                    command.Connection = connection;
                    connection.Open();
                    Int32 result = ExecuteNonQuery(command);
                    return result == 1;
                }
            }
        }
        public override List<Store_CategoriesDetails> GetAllCategories()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT * FROM Store_Categories order by CategoryId desc ";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;

                    connection.Open();
                    return GetStore_CategoriesCollectionFromDataReader(ExecuteReader(command));
                }

            }
        }
        public override  Store_CategoriesDetails GetCategoriesById(Guid Id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT * FROM Store_Categories WHERE (CategoryId = @CategoryId)";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@CategoryId", SqlDbType.UniqueIdentifier).Value = Id;
                    command.Connection = connection;
                    connection.Open();


                    IDataReader reader = ExecuteReader(command, CommandBehavior.SingleRow);
                    if (reader.Read())
                        return GetStore_CategoriesFromDataReader(reader);
                    return null;
                }

            }
        }


     
        #endregion


        #region Favorite

        public override bool DeleteFavorite(Guid Id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "DELETE FROM Store_Favorite Where favoriteId = @favoriteId";
                    command.Parameters.Add("@favoriteId", SqlDbType.UniqueIdentifier).Value = Id;
                    command.CommandType = CommandType.Text;
                    command.Connection = connection; 
                    connection.Open();
                    Int32 result = ExecuteNonQuery(command);
                    return result == 1;
                }
            } 
        }

        public override int insertFavorite(Store_FavoriteDetails store_FavoriteDetails)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand com = new SqlCommand();
                com.CommandText = @"INSERT INTO Store_Favorite (FavoriteGroupId,ProductId,EnterDate,DomainId,LanguageId) values(@FavoriteGroupId,@ProductId,@EnterDate,@DomainId,@LanguageId)";
                com.Parameters.Clear();

              //  com.Parameters.Add("@favoriteId", SqlDbType.UniqueIdentifier).Value = store_FavoriteDetails.FavoriteId;
                com.Parameters.Add("@FavoriteGroupId", SqlDbType.Int).Value = store_FavoriteDetails.FavoriteGroupId;
                com.Parameters.Add("@ProductId", SqlDbType.UniqueIdentifier).Value = store_FavoriteDetails.ProductId;
                com.Parameters.Add("@EnterDate", SqlDbType.DateTime).Value = store_FavoriteDetails.EnterDate;
                com.Parameters.Add("@DomainId", SqlDbType.Int).Value = store_FavoriteDetails.DomainId;
                com.Parameters.Add("@LanguageId", SqlDbType.Int).Value = store_FavoriteDetails.LanguageId;
                com.Connection = connection;
                connection.Open();
                int result = com.ExecuteNonQuery();
                connection.Close();
                return result;
            }
        }

        public override bool UpdateFavorite(Store_FavoriteDetails store_FavoriteDetails)
        {

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("Update Store_Favorite set   FavoriteGroupId=@FavoriteGroupId ,ProductId=@ProductId,EnterDate=@EnterDate,DomainId=@DomainId,LanguageId=@LanguageId   where favoriteId=@favoriteId  ", connection))
                {
                    command.Parameters.Add("@favoriteId", SqlDbType.UniqueIdentifier).Value = store_FavoriteDetails.FavoriteId;
                    command.Parameters.Add("@FavoriteGroupId", SqlDbType.Int).Value = store_FavoriteDetails.FavoriteGroupId;
                    command.Parameters.Add("@ProductId", SqlDbType.UniqueIdentifier).Value = store_FavoriteDetails.ProductId;
                    command.Parameters.Add("@EnterDate", SqlDbType.DateTime).Value = store_FavoriteDetails.EnterDate;
                    command.Parameters.Add("@DomainId", SqlDbType.Int).Value = store_FavoriteDetails.DomainId;
                    command.Parameters.Add("@LanguageId", SqlDbType.Int).Value = store_FavoriteDetails.LanguageId;
                    command.Connection = connection;
                    connection.Open();
                    Int32 result = ExecuteNonQuery(command);
                    return result == 1;
                }
            }
        }
        public override List<Store_FavoriteDetails> GetAllFavorite()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = @"SELECT        Store_Products.Name, Store_Favorite.EnterDate AS Expr1, Store_Favorite.*
FROM            Store_Favorite INNER JOIN
                         Store_Products ON Store_Favorite.ProductId = Store_Products.ProductId  order by favoriteId desc ";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;

                    connection.Open();
                    return GetStore_FavoriteCollectionFromDataReader(ExecuteReader(command));
                }

            }
        }
        public override List<Store_FavoriteDetails> GetFavoriteById(Guid Id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT * FROM Store_Favorite WHERE (favoriteId = @favoriteId)";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text; 
                    command.Parameters.Add("@favoriteId", SqlDbType.UniqueIdentifier).Value = Id;
                    command.Connection = connection; 
                    connection.Open();
                    return GetStore_FavoriteCollectionFromDataReader(ExecuteReader(command)); 
                }

            }
        }


        #endregion


        #region FavoriteGroup

        public override List<Store_FavoriteGroupDetails> GetAllFavoriteGroup()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT * FROM Store_FavoriteGroup order by FavoriteGroupId desc ";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    
                    connection.Open();
                    return GetStore_FavoriteGroupCollectionFromDataReader(ExecuteReader(command));
                }

            }
        }
        public override bool DeleteFavoriteGroup(int Id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "DELETE FROM Store_FavoriteGroup Where FavoriteGroupId = @FavoriteGroupId";
                    command.Parameters.Add("@FavoriteGroupId", SqlDbType.Int).Value = Id;
                    command.CommandType = CommandType.Text;
                    command.Connection = connection;
                    connection.Open();
                    Int32 result = ExecuteNonQuery(command);
                    return result == 1;
                }
            } 
        }

        public override int insertFavoriteGroup(Store_FavoriteGroupDetails store_FavoriteGroupDetails)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand com = new SqlCommand();
                com.CommandText = @"INSERT INTO Store_FavoriteGroup (NameGroup,DomainId,LanguageId) values(@NameGroup,@DomainId,@LanguageId)";
                com.Parameters.Clear();

                com.Parameters.Add("@FavoriteGroupId", SqlDbType.Int).Value = store_FavoriteGroupDetails.FavoriteGroupId;
                com.Parameters.Add("@NameGroup", SqlDbType.NVarChar).Value = String.IsNullOrEmpty(store_FavoriteGroupDetails.NameGroup) ? DBNull.Value : (Object)store_FavoriteGroupDetails.NameGroup;
                com.Parameters.Add("@DomainId", SqlDbType.Int).Value = store_FavoriteGroupDetails.DomainId;
                com.Parameters.Add("@LanguageId", SqlDbType.Int).Value = store_FavoriteGroupDetails.LanguageId;
                com.Connection = connection;
                connection.Open();
                int result = com.ExecuteNonQuery();
                connection.Close();
                return result;
            }
        }

        public override bool UpdateFavoriteGroup(Store_FavoriteGroupDetails store_FavoriteGroupDetails)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("Update Store_FavoriteGroup set   NameGroup=@NameGroup ,DomainId=@DomainId,LanguageId=@LanguageId   where FavoriteGroupId=@FavoriteGroupId  ", connection))
                {
                    command.Parameters.Add("@FavoriteGroupId", SqlDbType.Int).Value = store_FavoriteGroupDetails.FavoriteGroupId;
                    command.Parameters.Add("@NameGroup", SqlDbType.NVarChar).Value = String.IsNullOrEmpty(store_FavoriteGroupDetails.NameGroup) ? DBNull.Value : (Object)store_FavoriteGroupDetails.NameGroup;
                    command.Parameters.Add("@DomainId", SqlDbType.Int).Value = store_FavoriteGroupDetails.DomainId;
                    command.Parameters.Add("@LanguageId", SqlDbType.Int).Value = store_FavoriteGroupDetails.LanguageId;
                    command.Connection = connection;
                    connection.Open();
                    Int32 result = ExecuteNonQuery(command);
                    return result == 1;
                }
            }
        }

        public override Store_FavoriteGroupDetails GetFavoriteGroupById(int Id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT * FROM Store_FavoriteGroup WHERE (FavoriteGroupId = @FavoriteGroupId)";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@FavoriteGroupId", SqlDbType.Int).Value = Id;
                    connection.Open();
                    IDataReader reader = ExecuteReader(command, CommandBehavior.SingleRow);
                    if (reader.Read())
                        return GetStore_FavoriteGroupFromDataReader(reader);
                    return null; 
                }

            }
        }

        #endregion

        #region PriceDescriptions

        public override bool DeletePriceDescriptions(Guid Id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "DELETE FROM Store_PriceDescriptions Where PriceDescriptionId = @PriceDescriptionId";
                    command.Parameters.Add("@PriceDescriptionId", SqlDbType.UniqueIdentifier).Value = Id;
                    command.CommandType = CommandType.Text;
                    command.Connection = connection;
                    connection.Open();
                    Int32 result = ExecuteNonQuery(command);
                    return result == 1;
                }
            } 
        }

        public override int insertPriceDescriptions(Store_PriceDescriptionsDetails store_PriceDescriptionsDetails)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand com = new SqlCommand();
                com.CommandText = @"INSERT INTO Store_PriceDescriptions (Name,Priority,RoleName,Status,DomainId,LanguageId) values(@Name,@Priority,@RoleName,@Status,@DomainId,@LanguageId)";
                com.Parameters.Clear();

                com.Parameters.Add("@PriceDescriptionId", SqlDbType.UniqueIdentifier).Value = store_PriceDescriptionsDetails.PriceDescriptionId;
                com.Parameters.Add("@Name", SqlDbType.NVarChar).Value = store_PriceDescriptionsDetails.Name;
                com.Parameters.Add("@Priority", SqlDbType.Int).Value = store_PriceDescriptionsDetails.Priority;
                com.Parameters.Add("@RoleName", SqlDbType.NVarChar).Value = String.IsNullOrEmpty(store_PriceDescriptionsDetails.RoleName) ? DBNull.Value : (Object)store_PriceDescriptionsDetails.RoleName;
                com.Parameters.Add("@Status", SqlDbType.Bit).Value = store_PriceDescriptionsDetails.Status;
                com.Parameters.Add("@DomainId", SqlDbType.Int).Value = store_PriceDescriptionsDetails.DomainId;
                com.Parameters.Add("@LanguageId", SqlDbType.Int).Value = store_PriceDescriptionsDetails.LanguageId;
                com.Connection = connection;
                connection.Open();
                int result = com.ExecuteNonQuery();
                connection.Close();
                return result;
            }
        }

        public override bool UpdatePriceDescriptions(Store_PriceDescriptionsDetails store_PriceDescriptionsDetails)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("Update Store_PriceDescriptions set   Name=@Name ,Priority=@Priority,RoleName=@RoleName,Status=@Status,DomainId=@DomainId,LanguageId=@LanguageId   where PriceDescriptionId=@PriceDescriptionId  ", connection))
                {
                    command.Parameters.Add("@PriceDescriptionId", SqlDbType.UniqueIdentifier).Value = store_PriceDescriptionsDetails.PriceDescriptionId;
                    command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = store_PriceDescriptionsDetails.Name;
                    command.Parameters.Add("@Priority", SqlDbType.Int).Value = store_PriceDescriptionsDetails.Priority;
                    command.Parameters.Add("@RoleName", SqlDbType.NVarChar).Value = String.IsNullOrEmpty(store_PriceDescriptionsDetails.RoleName) ? DBNull.Value : (Object)store_PriceDescriptionsDetails.RoleName;
                    command.Parameters.Add("@Status", SqlDbType.Bit).Value = store_PriceDescriptionsDetails.Status;
                    command.Parameters.Add("@DomainId", SqlDbType.Int).Value = store_PriceDescriptionsDetails.DomainId;
                    command.Parameters.Add("@LanguageId", SqlDbType.Int).Value = store_PriceDescriptionsDetails.LanguageId;
                    command.Connection = connection;
                    connection.Open(); 
                    Int32 result = ExecuteNonQuery(command);
                    return result == 1;
                }
            }
        }
        public override List<Store_PriceDescriptionsDetails> GetAllPriceDescriptions()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT * FROM Store_PriceDescriptions order by PriceDescriptionId desc ";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    return GetStore_PriceDescriptionsCollectionFromDataReader(ExecuteReader(command)); 
                }


            }

          
        }

        public override Store_PriceDescriptionsDetails GetPriceDescriptionsById(Guid Id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT * FROM Store_PriceDescriptions WHERE (PriceDescriptionId = @PriceDescriptionId)";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text; 
                    command.Parameters.Add("@PriceDescriptionId", SqlDbType.UniqueIdentifier).Value = Id;
                    command.Connection = connection;
                    connection.Open();
                    IDataReader reader = ExecuteReader(command, CommandBehavior.SingleRow);
                    if (reader.Read())
                        return GetStore_PriceDescriptionsFromDataReader(reader);
                    return null; 
                }

            }
        }

        #endregion

        #region Prices

        public override int insertPrices(Store_PricesDetails store_PricesDetails)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand com = new SqlCommand();
                com.CommandText = @"INSERT INTO Store_Prices (ProductId,PriceDescriptionId,Price,EnterDate,Status,DomainId,LanguageId) values(@ProductId,@PriceDescriptionId,@Price,@EnterDate,@Status,@DomainId,@LanguageId)";
                com.Parameters.Clear();

                com.Parameters.Add("@PriceId", SqlDbType.UniqueIdentifier).Value = store_PricesDetails.PriceId;
                com.Parameters.Add("@ProductId", SqlDbType.UniqueIdentifier).Value = (Object)store_PricesDetails.ProductId ?? DBNull.Value ;
                com.Parameters.Add("@PriceDescriptionId", SqlDbType.UniqueIdentifier).Value = (Object)store_PricesDetails.PriceDescriptionId ?? DBNull.Value;
                com.Parameters.Add("@Price", SqlDbType.Decimal).Value = store_PricesDetails.Price;
                com.Parameters.Add("@EnterDate", SqlDbType.DateTime).Value = store_PricesDetails.EnterDate;
                com.Parameters.Add("@Status", SqlDbType.Bit).Value = store_PricesDetails.Status;
                com.Parameters.Add("@DomainId", SqlDbType.Int).Value = store_PricesDetails.DomainId;
                com.Parameters.Add("@LanguageId", SqlDbType.Int).Value = store_PricesDetails.LanguageId;
                com.Connection = connection;
                connection.Open();
                int result = com.ExecuteNonQuery();
                connection.Close();
                return result;
            }
        }

        public override bool DeletePrices(Guid Id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "DELETE FROM Store_Prices Where PriceId = @PriceId";
                    command.Parameters.Add("@PriceId", SqlDbType.UniqueIdentifier).Value = Id;
                    command.CommandType = CommandType.Text;
                    command.Connection = connection;
                    connection.Open();
                    Int32 result = ExecuteNonQuery(command);
                    return result == 1;
                }
            } 
        }

        public override bool UpdatePrices(Store_PricesDetails store_PricesDetails)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("Update Store_Prices set   ProductId=@ProductId ,PriceDescriptionId=@PriceDescriptionId,Price=@Price,EnterDate=@EnterDate,Status=@Status,DomainId=@DomainId,LanguageId=@LanguageId   where PriceId=@PriceId  ", connection))
                {
                    command.Parameters.Add("@PriceId", SqlDbType.UniqueIdentifier).Value = store_PricesDetails.PriceId;
                    command.Parameters.Add("@ProductId", SqlDbType.UniqueIdentifier).Value = (Object)store_PricesDetails.ProductId ?? DBNull.Value;
                    command.Parameters.Add("@PriceDescriptionId", SqlDbType.UniqueIdentifier).Value = (Object)store_PricesDetails.PriceDescriptionId ?? DBNull.Value;
                    command.Parameters.Add("@Price", SqlDbType.Decimal).Value = store_PricesDetails.Price;
                    command.Parameters.Add("@EnterDate", SqlDbType.DateTime).Value = store_PricesDetails.EnterDate;
                    command.Parameters.Add("@Status", SqlDbType.Bit).Value = store_PricesDetails.Status;
                    command.Parameters.Add("@DomainId", SqlDbType.Int).Value = store_PricesDetails.DomainId;
                    command.Parameters.Add("@LanguageId", SqlDbType.Int).Value = store_PricesDetails.LanguageId;
                    command.Connection = connection;
                    connection.Open();
                    Int32 result = ExecuteNonQuery(command);
                    return result == 1;
                }
            }
        }
        public override List<Store_PricesDetails> GetAllPrices()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = @"SELECT  Store_PriceDescriptions.Name AS NamePriceDes, Store_Products.Name AS NameProduct, Store_Prices.*
                          FROM    Store_Prices left outer JOIN
                         Store_PriceDescriptions ON Store_Prices.PriceDescriptionId = Store_PriceDescriptions.PriceDescriptionId left outer JOIN
                         Store_Products ON Store_Prices.ProductId = Store_Products.ProductId  ";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                  //  command.Connection = connection;
                    connection.Open();
                    return GetStore__PricesCollectionFromDataReader(ExecuteReader(command));
                }

            }
        }

        public override Store_PricesDetails GetPricesById(Guid Id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = @"SELECT        Store_PriceDescriptions.Name AS NamePriceDes, Store_Products.Name AS NameProduct, Store_Prices.*
                          FROM            Store_Prices left outer JOIN
                         Store_PriceDescriptions ON Store_Prices.PriceDescriptionId = Store_PriceDescriptions.PriceDescriptionId INNER JOIN
                         Store_Products ON Store_Prices.ProductId = Store_Products.ProductId WHERE (PriceId = @PriceId)";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@PriceId", SqlDbType.UniqueIdentifier).Value = Id;
                    command.Connection = connection;
                    connection.Open();
                    IDataReader reader = ExecuteReader(command, CommandBehavior.SingleRow);
                    if (reader.Read())
                        return GetStore__PricesFromDataReader(reader);
                    return null; 
                }

            }
        }


        


        #endregion

        #region ProductsConCategories

        public override int insertProductsConCategories(Store_ProductsConCategoriesDetails store_ProductsConCategoriesDetails)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand com = new SqlCommand();
                com.CommandText = @"INSERT INTO Store_ProductsConCategories (CategoryId,ProductId) values(@CategoryId,@ProductId)";
                com.Parameters.Clear();

                com.Parameters.Add("@CategoryId", SqlDbType.UniqueIdentifier).Value = store_ProductsConCategoriesDetails.CategoryId;
                com.Parameters.Add("@ProductId", SqlDbType.UniqueIdentifier).Value = store_ProductsConCategoriesDetails.ProductId;


                com.Connection = connection;
                connection.Open();
                int result = com.ExecuteNonQuery(); 
                connection.Close();
                return result;
            }
        }

        public override bool DeleteProductsConCategories(Guid Id, Guid ProductId) 
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "DELETE FROM Store_ProductsConCategories Where CategoryId = @CategoryId and ProductId=@ProductId ";
                    command.Parameters.Add("@CategoryId", SqlDbType.UniqueIdentifier).Value = Id;
                    command.Parameters.Add("@ProductId", SqlDbType.UniqueIdentifier).Value = ProductId; 
                    command.CommandType = CommandType.Text;
                    command.Connection = connection;
                    connection.Open();
                    Int32 result = ExecuteNonQuery(command);
                    return result == 1;
                }
            } 
        }
        public override Store_ProductsConCategoriesDetails GetProductsConCategoriesByCategoryIdAndProductId(Guid Category, Guid ProductId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT * FROM Store_ProductsConCategories WHERE  ProductId=@ProductId And CategoryId=@CategoryId ";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    //  command.Parameters.Add("@CategoryId", SqlDbType.UniqueIdentifier).Value = Id;
                    command.Parameters.Add("@ProductId", SqlDbType.UniqueIdentifier).Value = ProductId;
                    command.Parameters.Add("@CategoryId", SqlDbType.UniqueIdentifier).Value = Category;
                    command.Connection = connection;
                    connection.Open();
                    IDataReader reader = ExecuteReader(command, CommandBehavior.SingleRow);
                    if (reader.Read())
                        return GetStore__ProductsConCategoriesFromDataReader(reader);
                    return null;
                }

            }
        }
        public override bool UpdateProductsConCategories(Store_ProductsConCategoriesDetails store_ProductsConCategoriesDetails)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("Update Store_ProductsConCategories set   ProductId=@ProductId   where CategoryId=@CategoryId  ", connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.Clear();

                    command.Parameters.Add("@CategoryId", SqlDbType.UniqueIdentifier).Value = store_ProductsConCategoriesDetails.CategoryId;
                    command.Parameters.Add("@ProductId", SqlDbType.UniqueIdentifier).Value = store_ProductsConCategoriesDetails.ProductId;
                    command.Connection = connection;
                     

                    connection.Open();
                    Int32 result = ExecuteNonQuery(command);
                    return result == 1;
                }
            }
        }

        public override List<Store_ProductsConCategoriesDetails> GetProductsConCategoriesByIdAndProductId(Guid ProductId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT * FROM Store_ProductsConCategories WHERE  ProductId=@ProductId ";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                  //  command.Parameters.Add("@CategoryId", SqlDbType.UniqueIdentifier).Value = Id;
                    command.Parameters.Add("@ProductId", SqlDbType.UniqueIdentifier).Value =ProductId;
                    command.Connection = connection;
                    connection.Open();
                    return GetStore__ProductsConCategoriesCollectionFromDataReader(ExecuteReader(command));
                }

            }
        }

        public override List<Store_ProductsConCategoriesDetails> GetProductsConCategoriesById(Guid Id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT * FROM Store_ProductsConCategories WHERE CategoryId = @CategoryId   ";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text; 
                    command.Parameters.Add("@CategoryId", SqlDbType.UniqueIdentifier).Value = Id;
                    command.Connection = connection;
                    connection.Open();
                    return GetStore__ProductsConCategoriesCollectionFromDataReader(ExecuteReader(command));
                }

            }
        }

        #endregion

        #region ProductsConTags
        public override int insertProductsConTags(Store_ProductsConTagsDetails store_ProductsConTagsDetails)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand com = new SqlCommand();
                com.CommandText = @"INSERT INTO Store_ProductsConTags (TagId,ProductId) values(@TagId,@ProductId)";
                com.Parameters.Clear();

                com.Parameters.Add("@TagId", SqlDbType.UniqueIdentifier).Value = store_ProductsConTagsDetails.TagId;
                com.Parameters.Add("@ProductId", SqlDbType.UniqueIdentifier).Value = store_ProductsConTagsDetails.ProductId;


                com.Connection = connection;
                connection.Open();
                int result = com.ExecuteNonQuery();
                connection.Close();
                return result;
            }
        }

        public override bool DeleteProductsConTags(Guid Id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "DELETE FROM Store_ProductsConTags Where TagId = @TagId";
                    command.Parameters.Add("@TagId", SqlDbType.UniqueIdentifier).Value = Id;
                    command.CommandType = CommandType.Text;
                    command.Connection = connection;
                    connection.Open();
                    Int32 result = ExecuteNonQuery(command);
                    return result == 1;
                }
            } 
        }

        public override bool UpdateProductsConTags(Store_ProductsConTagsDetails store_ProductsConTagsDetails)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("Update Store_ProductsConTags set   ProductId=@ProductId   where TagId=@TagId  ", connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.Clear();
                    command.Parameters.Add("@TagId", SqlDbType.UniqueIdentifier).Value = store_ProductsConTagsDetails.TagId;
                    command.Parameters.Add("@ProductId", SqlDbType.UniqueIdentifier).Value = store_ProductsConTagsDetails.ProductId;
                    command.Connection = connection;

                    connection.Open();
                    Int32 result = ExecuteNonQuery(command);
                    return result == 1;
                }
            }
        }

        public override List<Store_ProductsConTagsDetails> GetProductsConTagsById(Guid Id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT * FROM Store_ProductsConTags WHERE (TagId = @TagId)";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@TagId", SqlDbType.UniqueIdentifier).Value = Id;
                    command.Connection = connection;
                    connection.Open(); 
                    return GetStore__ProductsConTagsCollectionFromDataReader(ExecuteReader(command)); 
                }

            }
        }

        #endregion


        #region Products
        public override bool DeleteProducts(Guid Id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "DELETE FROM Store_Products Where ProductId = @ProductId";
                    command.Parameters.Add("@ProductId", SqlDbType.UniqueIdentifier).Value = Id;
                    command.CommandType = CommandType.Text;
                    command.Connection = connection;
                    connection.Open();
                    Int32 result = ExecuteNonQuery(command);
                    return result == 1;
                }
            } 
        }

        public override Guid insertProducts(Store_ProductsDetails store_ProductsDetails)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand com = new SqlCommand();
 //               declare @v table (newguid uniqueidentifier)
 //INSERT INTO Table1 (ColumnName1, ColumnName2) OUTPUT INSERTED.GuidColumnID INTO @v VALUES (value1, value2)
 //select newguid from @v
                com.CommandText = @" declare @v table (newguid uniqueidentifier)   INSERT INTO Store_Products (Name,Description,MainImage,Condition,Score,Status,EnterDate,LastUpdateDate,Username,DomainId,LanguageId) OUTPUT INSERTED.ProductId into @v values(@Name,@Description,@MainImage,@Condition,@Score,@Status,@EnterDate,@LastUpdateDate,@Username,@DomainId,@LanguageId) select @ProductId=newguid from @v ";
                com.Parameters.Clear();
               // com.Parameters.Add(, ).Value = store_ProductsDetails.ProductId;
                SqlParameter param = new SqlParameter("@ProductId",SqlDbType.UniqueIdentifier);
                param.Direction = ParameterDirection.Output;
                com.Parameters.Add(param);

                com.Parameters.Add("@Name", SqlDbType.NVarChar).Value = store_ProductsDetails.Name; 
                com.Parameters.Add("@Description", SqlDbType.NVarChar).Value = String.IsNullOrEmpty(store_ProductsDetails.Description) ? DBNull.Value : (Object)store_ProductsDetails.Description;
                com.Parameters.Add("@MainImage", SqlDbType.NVarChar).Value = String.IsNullOrEmpty(store_ProductsDetails.MainImage) ? DBNull.Value : (Object)store_ProductsDetails.MainImage;
                com.Parameters.Add("@Condition", SqlDbType.NVarChar).Value = String.IsNullOrEmpty(store_ProductsDetails.Condition) ? DBNull.Value : (Object)store_ProductsDetails.Condition;
                com.Parameters.Add("@Score", SqlDbType.TinyInt).Value = (Object)store_ProductsDetails.Score ?? DBNull.Value ;
                com.Parameters.Add("@Status", SqlDbType.Bit).Value = store_ProductsDetails.Status;
                com.Parameters.Add("@EnterDate", SqlDbType.DateTime).Value = store_ProductsDetails.EnterDate;
                com.Parameters.Add("@LastUpdateDate", SqlDbType.DateTime).Value = (Object)store_ProductsDetails.LastUpdateDate ?? DBNull.Value;
                com.Parameters.Add("@Username", SqlDbType.NVarChar).Value = store_ProductsDetails.Username;
                com.Parameters.Add("@DomainId", SqlDbType.Int).Value = store_ProductsDetails.DomainId;
                com.Parameters.Add("@LanguageId", SqlDbType.Int).Value = store_ProductsDetails.LanguageId;
                com.Connection = connection;
                connection.Open();
                com.ExecuteNonQuery(); 
                 Guid s = (Guid) param.Value;
                connection.Close();
                return s;
            }
        }

        public override bool UpdateProducts(Store_ProductsDetails store_ProductsDetails)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("Update Store_Products set   Name=@Name ,Description=@Description,MainImage=@MainImage,Condition=@Condition,Score=@Score,Status=@Status,EnterDate=@EnterDate,LastUpdateDate=@LastUpdateDate,Username=@Username,DomainId=@DomainId,LanguageId=@LanguageId   where ProductId=@ProductId  ", connection))
                {

                    command.Parameters.Add("@ProductId", SqlDbType.UniqueIdentifier).Value = store_ProductsDetails.ProductId;
                    command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = store_ProductsDetails.Name;
                    command.Parameters.Add("@Description", SqlDbType.NVarChar).Value = String.IsNullOrEmpty(store_ProductsDetails.Description) ? DBNull.Value : (Object)store_ProductsDetails.Description;
                    command.Parameters.Add("@MainImage", SqlDbType.NVarChar).Value = String.IsNullOrEmpty(store_ProductsDetails.MainImage) ? DBNull.Value : (Object)store_ProductsDetails.MainImage;
                    command.Parameters.Add("@Condition", SqlDbType.NVarChar).Value = String.IsNullOrEmpty(store_ProductsDetails.Condition) ? DBNull.Value : (Object)store_ProductsDetails.Condition;
                    command.Parameters.Add("@Score", SqlDbType.TinyInt).Value = (Object)store_ProductsDetails.Score ?? DBNull.Value;
                    command.Parameters.Add("@Status", SqlDbType.Bit).Value = store_ProductsDetails.Status;
                    command.Parameters.Add("@EnterDate", SqlDbType.DateTime).Value = store_ProductsDetails.EnterDate;
                    command.Parameters.Add("@LastUpdateDate", SqlDbType.DateTime).Value = (Object)store_ProductsDetails.LastUpdateDate ?? DBNull.Value;
                    command.Parameters.Add("@Username", SqlDbType.NVarChar).Value = store_ProductsDetails.Username;
                    command.Parameters.Add("@DomainId", SqlDbType.Int).Value = store_ProductsDetails.DomainId;
                    command.Parameters.Add("@LanguageId", SqlDbType.Int).Value = store_ProductsDetails.LanguageId;
                    command.Connection = connection;
                    connection.Open();
                    Int32 result = ExecuteNonQuery(command);
                    return result == 1;
                }
            }
        }
        public override List<Store_ProductsDetails> GetProductByCategory(Guid category)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = @"SELECT  Store_Products.* FROM   
                    Store_ProductsConCategories INNER JOIN  Store_Products ON Store_ProductsConCategories.ProductId = Store_Products.ProductId
                     WHERE  (Store_ProductsConCategories.CategoryId = @CategoryId)";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@CategoryId", SqlDbType.UniqueIdentifier).Value = category; 
                    command.Connection = connection;
                    connection.Open();
                    return GetStore_ProductsCollectionFromDataReader(ExecuteReader(command));
                }

            }
        }
        public override List<Store_ProductsDetails> GetAllProducts()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT * FROM Store_Products order by ProductId desc ";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    return GetStore_ProductsCollectionFromDataReader(ExecuteReader(command));
                }

            }
        }

        public override Store_ProductsDetails GetProductsById(Guid Id) 
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT * FROM Store_Products WHERE (ProductId = @ProductId)";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@ProductId", SqlDbType.UniqueIdentifier).Value = Id;
                    command.Connection = connection;
                    connection.Open();
                    IDataReader reader = ExecuteReader(command, CommandBehavior.SingleRow);
                    if (reader.Read())
                        return GetStore_ProductsFromDataReader(reader);
                    return null; 
                }

            }
        }
        #endregion

        #region Setting

        public override bool DeleteSetting(Guid Id)
        {

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "DELETE FROM Store_Setting Where SettingId = @SettingId";
                    command.Parameters.Add("@SettingId", SqlDbType.UniqueIdentifier).Value = Id;
                    command.CommandType = CommandType.Text;
                    command.Connection = connection;
                    connection.Open();
                    Int32 result = ExecuteNonQuery(command);
                    return result == 1;
                }
            } 
        }

        public override int insertSetting(Store_SettingDetails store_SettingDetails)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand com = new SqlCommand();
                com.CommandText = @"INSERT INTO Store_Setting (Parameter,Value1,Value2,Value3,Value4,Value5,DomainId,LanguageId) values(@Parameter,@Value1,@Value2,@Value3,@Value4,@Value5,@DomainId,@LanguageId)";
                com.Parameters.Clear();

                com.Parameters.Add("@SettingId", SqlDbType.UniqueIdentifier).Value = store_SettingDetails.SettingId;
                com.Parameters.Add("@Parameter", SqlDbType.NVarChar).Value = String.IsNullOrEmpty(store_SettingDetails.Parameter) ? DBNull.Value : (Object)store_SettingDetails.Parameter;
                com.Parameters.Add("@Value1", SqlDbType.NVarChar).Value = String.IsNullOrEmpty(store_SettingDetails.Value1) ? DBNull.Value : (Object)store_SettingDetails.Value1;
                com.Parameters.Add("@Value2", SqlDbType.NVarChar).Value = String.IsNullOrEmpty(store_SettingDetails.Value2) ? DBNull.Value : (Object)store_SettingDetails.Value2;
                com.Parameters.Add("@Value3", SqlDbType.NVarChar).Value = String.IsNullOrEmpty(store_SettingDetails.Value3) ? DBNull.Value : (Object)store_SettingDetails.Value3;
                com.Parameters.Add("@Value4", SqlDbType.NVarChar).Value = String.IsNullOrEmpty(store_SettingDetails.Value4) ? DBNull.Value : (Object)store_SettingDetails.Value4;
                com.Parameters.Add("@Value5", SqlDbType.NVarChar).Value = String.IsNullOrEmpty(store_SettingDetails.Value5) ? DBNull.Value : (Object)store_SettingDetails.Value5;
                com.Parameters.Add("@DomainId", SqlDbType.Int).Value = store_SettingDetails.DomainId;
                com.Parameters.Add("@LanguageId", SqlDbType.Int).Value = store_SettingDetails.LanguageId; 
                
                com.Connection = connection;
                connection.Open();
                int result = com.ExecuteNonQuery();
                connection.Close();
                return result;
            }
        }

        
        public override bool UpdateSetting(Store_SettingDetails store_SettingDetails)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("Update Store_Setting set  Parameter=@Parameter,Value1=@Value1,Value2=@Value2,Value3=@Value3,Value4=@Value4,Value5=@Value5,DomainId=@DomainId,LanguageId=@LanguageId   where SettingId=@SettingId  ", connection))
                {

                    command.Parameters.Add("@SettingId", SqlDbType.UniqueIdentifier).Value = store_SettingDetails.SettingId;
                    command.Parameters.Add("@Parameter", SqlDbType.NVarChar).Value = String.IsNullOrEmpty(store_SettingDetails.Parameter) ? DBNull.Value : (Object)store_SettingDetails.Parameter;
                    command.Parameters.Add("@Value1", SqlDbType.NVarChar).Value = String.IsNullOrEmpty(store_SettingDetails.Value1) ? DBNull.Value : (Object)store_SettingDetails.Value1;
                    command.Parameters.Add("@Value2", SqlDbType.NVarChar).Value = String.IsNullOrEmpty(store_SettingDetails.Value2) ? DBNull.Value : (Object)store_SettingDetails.Value2;
                    command.Parameters.Add("@Value3", SqlDbType.NVarChar).Value = String.IsNullOrEmpty(store_SettingDetails.Value3) ? DBNull.Value : (Object)store_SettingDetails.Value3;
                    command.Parameters.Add("@Value4", SqlDbType.NVarChar).Value = String.IsNullOrEmpty(store_SettingDetails.Value4) ? DBNull.Value : (Object)store_SettingDetails.Value4;
                    command.Parameters.Add("@Value5", SqlDbType.NVarChar).Value = String.IsNullOrEmpty(store_SettingDetails.Value5) ? DBNull.Value : (Object)store_SettingDetails.Value5;
                    command.Parameters.Add("@DomainId", SqlDbType.Int).Value = store_SettingDetails.DomainId;
                    command.Parameters.Add("@LanguageId", SqlDbType.Int).Value = store_SettingDetails.LanguageId; 
                    command.Connection = connection;
                    connection.Open();
                    Int32 result = ExecuteNonQuery(command);
                    return result == 1;
                }
            }
        }
        public override List<Store_SettingDetails> GetSettingById(Guid Id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT * FROM Store_Setting WHERE (SettingId = @SettingId)";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@SettingId", SqlDbType.UniqueIdentifier).Value = Id;
                    command.Connection = connection;
                    connection.Open();
                    return GetStore_SettingCollectionFromDataReader(ExecuteReader(command)); 
                }

            }
        }


        #endregion


        #region SpecificationGroups

        public override bool DeleteSpecificationGroups(Guid Id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "DELETE FROM Store_SpecificationGroups Where SpecificationGroupId = @SpecificationGroupId";
                    command.Parameters.Add("@SpecificationGroupId", SqlDbType.UniqueIdentifier).Value = Id;
                    command.CommandType = CommandType.Text;
                    command.Connection = connection;
                    connection.Open();
                    Int32 result = ExecuteNonQuery(command);
                    return result == 1;
                }
            } 
        }

        public override int insertSpecificationGroups(Store_SpecificationGroupsDetails store_SpecificationGroupsDetails)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand com = new SqlCommand();
                com.CommandText = @"INSERT INTO Store_SpecificationGroups (Name,DomainId,LanguageId) values(@Name,@DomainId,@LanguageId)";
                com.Parameters.Clear();

                com.Parameters.Add("@SpecificationGroupId", SqlDbType.UniqueIdentifier).Value = store_SpecificationGroupsDetails.SpecificationGroupId;
                com.Parameters.Add("@Name", SqlDbType.NVarChar).Value = store_SpecificationGroupsDetails.Name;
                com.Parameters.Add("@DomainId", SqlDbType.Int).Value = store_SpecificationGroupsDetails.DomainId;
                com.Parameters.Add("@LanguageId", SqlDbType.Int).Value = store_SpecificationGroupsDetails.LanguageId;
                com.Connection = connection;
                connection.Open();
                int result = com.ExecuteNonQuery();
                connection.Close();
                return result;
            }
        }

        public override bool UpdateSpecificationGroups(Store_SpecificationGroupsDetails store_SpecificationGroupsDetails)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("Update Store_SpecificationGroups set   Name=@Name ,DomainId=@DomainId,LanguageId=@LanguageId   where SpecificationGroupId=@SpecificationGroupId  ", connection))
                {
                    command.Parameters.Add("@SpecificationGroupId", SqlDbType.UniqueIdentifier).Value = store_SpecificationGroupsDetails.SpecificationGroupId;
                    command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = store_SpecificationGroupsDetails.Name;
                    command.Parameters.Add("@DomainId", SqlDbType.Int).Value = store_SpecificationGroupsDetails.DomainId;
                    command.Parameters.Add("@LanguageId", SqlDbType.Int).Value = store_SpecificationGroupsDetails.LanguageId;
                    command.Connection = connection;
                    connection.Open();
                    Int32 result = ExecuteNonQuery(command);
                    return result == 1;
                }
            }
        }
        public override List<Store_SpecificationGroupsDetails> GetAllSpecificationGroups()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT * FROM Store_SpecificationGroups order by SpecificationGroupId desc ";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;

                    connection.Open();
                    return GetStore_SpecificationGroupsCollectionFromDataReader(ExecuteReader(command));
                }

            }
        }

        public override Store_SpecificationGroupsDetails GetSpecificationGroupsById(Guid Id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT * FROM Store_SpecificationGroups WHERE (SpecificationGroupId = @SpecificationGroupId)";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@SpecificationGroupId", SqlDbType.UniqueIdentifier).Value = Id;
                    command.Connection = connection;
                    connection.Open();
                    IDataReader reader = ExecuteReader(command, CommandBehavior.SingleRow);
                    if (reader.Read())
                        return GetStore_SpecificationGroupsFromDataReader(reader);
                    return null; 
                }

            }
        }
        #endregion

        #region SpecificationTexts

        public override bool DeleteSpecificationTexts(Guid Id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "DELETE FROM Store_SpecificationTexts Where SpecificationTextId = @SpecificationTextId";
                    command.Parameters.Add("@SpecificationTextId", SqlDbType.UniqueIdentifier).Value = Id;
                    command.CommandType = CommandType.Text;
                    command.Connection = connection;
                    connection.Open();
                    Int32 result = ExecuteNonQuery(command);
                    return result == 1;
                }
            } 
        }

        public override int insertSpecificationTexts(Store_SpecificationTextsDetails store_SpecificationTextsDetails)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand com = new SqlCommand();
                com.CommandText = @"INSERT INTO Store_SpecificationTexts (SpecificationTitleId,Text,Description,DomainId,LanguageId) values(@SpecificationTitleId,@Text,@Description,@DomainId,@LanguageId)";
                com.Parameters.Clear();

              //  com.Parameters.Add("@SpecificationTextId", SqlDbType.UniqueIdentifier).Value = store_SpecificationTextsDetails.SpecificationTextId;
                com.Parameters.Add("@SpecificationTitleId", SqlDbType.UniqueIdentifier).Value = store_SpecificationTextsDetails.SpecificationTitleId;
               // com.Parameters.Add("@ProductId", SqlDbType.UniqueIdentifier).Value = store_SpecificationTextsDetails.ProductId;
                com.Parameters.Add("@Text", SqlDbType.NVarChar).Value = store_SpecificationTextsDetails.Text;
                com.Parameters.Add("@Description", SqlDbType.NVarChar).Value = String.IsNullOrEmpty(store_SpecificationTextsDetails.Description) ? DBNull.Value : (Object)store_SpecificationTextsDetails.Description; ;
                com.Parameters.Add("@DomainId", SqlDbType.Int).Value = store_SpecificationTextsDetails.DomainId;
                com.Parameters.Add("@LanguageId", SqlDbType.Int).Value = store_SpecificationTextsDetails.LanguageId;
                com.Connection = connection;
                connection.Open();
                int result = com.ExecuteNonQuery();
                connection.Close();
                return result;
            }
        }

        public override bool UpdateSpecificationTexts(Store_SpecificationTextsDetails store_SpecificationTextsDetails)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("Update Store_SpecificationTexts set   SpecificationTitleId=@SpecificationTitleId,Text=@Text,Description=@Description ,DomainId=@DomainId,LanguageId=@LanguageId   where SpecificationTextId=@SpecificationTextId  ", connection))
                {
                    command.Parameters.Add("@SpecificationTextId", SqlDbType.UniqueIdentifier).Value = store_SpecificationTextsDetails.SpecificationTextId;
                    command.Parameters.Add("@SpecificationTitleId", SqlDbType.UniqueIdentifier).Value = store_SpecificationTextsDetails.SpecificationTitleId;
                  //  command.Parameters.Add("@ProductId", SqlDbType.UniqueIdentifier).Value = store_SpecificationTextsDetails.ProductId;
                    command.Parameters.Add("@Text", SqlDbType.NVarChar).Value = store_SpecificationTextsDetails.Text;
                    command.Parameters.Add("@Description", SqlDbType.NVarChar).Value = String.IsNullOrEmpty(store_SpecificationTextsDetails.Description) ? DBNull.Value : (Object)store_SpecificationTextsDetails.Description; ;
                    command.Parameters.Add("@DomainId", SqlDbType.Int).Value = store_SpecificationTextsDetails.DomainId;
                    command.Parameters.Add("@LanguageId", SqlDbType.Int).Value = store_SpecificationTextsDetails.LanguageId;
                    command.Connection = connection;
                    connection.Open();
                    Int32 result = ExecuteNonQuery(command);
                    return result == 1;
                }
            }
        }
        public override List<Store_SpecificationTextsDetails> GetSpecificationTextsBySpecificationTextIdAndSpecificationTitleId(Guid specificationTextId, Guid specificationTitleId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = @"SELECT  Store_SpecificationTitles.Name , Store_SpecificationTexts.Text, Store_SpecificationTexts.SpecificationTextId, Store_SpecificationTitles.SpecificationTitleId, 
                         Store_SpecificationTexts.Description , Store_SpecificationTexts.DomainId , Store_SpecificationTexts.LanguageId
                          FROM            Store_SpecificationTitles INNER JOIN
                         Store_SpecificationTexts ON Store_SpecificationTitles.SpecificationTitleId = Store_SpecificationTexts.SpecificationTitleId
                         WHERE  Store_SpecificationTexts.SpecificationTextId = @specificationTextId and Store_SpecificationTexts.SpecificationTitleId = @specificationTitleId order by Store_SpecificationTitles.Name ";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@specificationTextId", SqlDbType.UniqueIdentifier).Value = specificationTextId;
                    command.Parameters.Add("@specificationTitleId", SqlDbType.UniqueIdentifier).Value = specificationTitleId;
                    command.Connection = connection;
                    connection.Open();
                    return GetStore_SpecificationTextsCollectionFromDataReader(ExecuteReader(command));
                }

            }
        }

        public override List<Store_SpecificationTextsDetails>  GetSpecificationTextsByGroups(Guid groupId)
{
    using (SqlConnection connection = new SqlConnection(ConnectionString))
    {
        using (SqlCommand command = new SqlCommand())
        {
            command.CommandText = @"SELECT  Store_SpecificationTitles.Name , Store_SpecificationTexts.Text, Store_SpecificationTexts.SpecificationTextId, Store_SpecificationTitles.SpecificationTitleId, 
                         Store_SpecificationTexts.Description , Store_SpecificationTexts.DomainId , Store_SpecificationTexts.LanguageId
                          FROM            Store_SpecificationTitles INNER JOIN
                         Store_SpecificationTexts ON Store_SpecificationTitles.SpecificationTitleId = Store_SpecificationTexts.SpecificationTitleId
                         WHERE        (Store_SpecificationTitles.SpecificationGroupId = @id)";
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.Parameters.Add("@id", SqlDbType.UniqueIdentifier).Value = groupId;
            command.Connection = connection;
            connection.Open();
            return GetStore_SpecificationTextsCollectionFromDataReader(ExecuteReader(command));
        }

}
        
           
           
        }
        public override List<Store_SpecificationTextsDetails> GetAllSpecificationTexts()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = @"SELECT    Store_SpecificationTexts.*, Store_SpecificationTitles.Name
                         FROM            Store_SpecificationTexts INNER JOIN
                         Store_SpecificationTitles ON Store_SpecificationTexts.SpecificationTitleId = Store_SpecificationTitles.SpecificationTitleId  order by SpecificationTextId desc ";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    return GetStore_SpecificationTextsCollectionFromDataReader(ExecuteReader(command));
                }

            }
        } 
        public override Store_SpecificationTextsDetails GetSpecificationTextsById(Guid Id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = @"SELECT        Store_SpecificationTitles.Name, Store_SpecificationTexts.*
                      FROM            Store_SpecificationTexts INNER JOIN
                         Store_SpecificationTitles ON Store_SpecificationTexts.SpecificationTitleId = Store_SpecificationTitles.SpecificationTitleId where  SpecificationTextId=@SpecificationTextId";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@SpecificationTextId", SqlDbType.UniqueIdentifier).Value = Id;
                    command.Connection = connection;
                    connection.Open();
                    IDataReader reader = ExecuteReader(command, CommandBehavior.SingleRow);
                    if (reader.Read())
                        return GetStore_SpecificationTextsFromDataReader(reader);
                    return null; 
                }

            }
        }
//SELECT  Store_SpecificationTitles.Name, Store_SpecificationTexts.Text, Store_SpecificationTexts.SpecificationTextId, Store_SpecificationTitles.SpecificationTitleId, 
//                         Store_SpecificationTexts.Description
//                          FROM            Store_SpecificationTitles INNER JOIN
//                         Store_SpecificationTexts ON Store_SpecificationTitles.SpecificationTitleId = Store_SpecificationTexts.SpecificationTitleId
//                         WHERE        (Store_SpecificationTitles.SpecificationGroupId = @id

        #endregion

        #region SpecificationTitles

        public override bool DeleteSpecificationTitles(Guid Id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "DELETE FROM Store_SpecificationTitles Where SpecificationTitleId = @SpecificationTitleId";
                    command.Parameters.Add("@SpecificationTitleId", SqlDbType.UniqueIdentifier).Value = Id;
                    command.CommandType = CommandType.Text;
                    command.Connection = connection;
                    connection.Open();
                    Int32 result = ExecuteNonQuery(command);
                    return result == 1;
                }
            } 
        }

        public override int insertSpecificationTitles(Store_SpecificationTitlesDetails store_SpecificationTitlesDetails)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand com = new SqlCommand();
                com.CommandText = @"INSERT INTO Store_SpecificationTitles (SpecificationGroupId,Name,Description,DomainId,LanguageId) values(@SpecificationGroupId,@Name,@Description,@DomainId,@LanguageId)";
                com.Parameters.Clear();

                com.Parameters.Add("@SpecificationTitleId", SqlDbType.UniqueIdentifier).Value = store_SpecificationTitlesDetails.SpecificationTitleId;
                
                com.Parameters.Add("@SpecificationGroupId", SqlDbType.UniqueIdentifier).Value = store_SpecificationTitlesDetails.SpecificationGroupId;
               
                com.Parameters.Add("@Name", SqlDbType.NVarChar).Value = store_SpecificationTitlesDetails.Name;
                com.Parameters.Add("@Description", SqlDbType.NVarChar).Value = String.IsNullOrEmpty(store_SpecificationTitlesDetails.Description) ? DBNull.Value : (Object)store_SpecificationTitlesDetails.Description ;
                com.Parameters.Add("@DomainId", SqlDbType.Int).Value = store_SpecificationTitlesDetails.DomainId;
                com.Parameters.Add("@LanguageId", SqlDbType.Int).Value = store_SpecificationTitlesDetails.LanguageId;
                com.Connection = connection;
                connection.Open();
                int result = com.ExecuteNonQuery();
                connection.Close();
                return result;
            }
        }

        public override bool UpdateSpecificationTitles(Store_SpecificationTitlesDetails store_SpecificationTitlesDetails)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("Update Store_SpecificationTitles set   SpecificationGroupId=@SpecificationGroupId,Name=@Name,Description=@Description ,DomainId=@DomainId,LanguageId=@LanguageId   where SpecificationTitleId=@SpecificationTitleId  ", connection))
                {
                    command.Parameters.Add("@SpecificationTitleId", SqlDbType.UniqueIdentifier).Value = store_SpecificationTitlesDetails.SpecificationTitleId;
                    command.Parameters.Add("@SpecificationGroupId", SqlDbType.UniqueIdentifier).Value = store_SpecificationTitlesDetails.SpecificationGroupId;
                    command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = store_SpecificationTitlesDetails.Name;
                    command.Parameters.Add("@Description", SqlDbType.NVarChar).Value = String.IsNullOrEmpty(store_SpecificationTitlesDetails.Description) ? DBNull.Value : (Object)store_SpecificationTitlesDetails.Description; ;
                    command.Parameters.Add("@DomainId", SqlDbType.Int).Value = store_SpecificationTitlesDetails.DomainId;
                    command.Parameters.Add("@LanguageId", SqlDbType.Int).Value = store_SpecificationTitlesDetails.LanguageId;
                    command.Connection = connection;
                    connection.Open();
                    Int32 result = ExecuteNonQuery(command);
                    return result == 1;
                }
            }
        }

        public override List<Store_SpecificationTitlesDetails> GetSpecificationTitlesBySpecificationGroupId(Guid specificationGroupId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT * FROM Store_SpecificationTitles WHERE (SpecificationGroupId = @SpecificationGroupId) order by SpecificationTitleId desc";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@SpecificationGroupId", SqlDbType.UniqueIdentifier).Value = specificationGroupId;
                    command.Connection = connection;
                    connection.Open();
                    return GetStore_SpecificationTitlesCollectionFromDataReader(ExecuteReader(command));
                }

            }
        }
        public override List<Store_SpecificationTitlesDetails> GetAllSpecificationTitles()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT * FROM Store_SpecificationTitles order by SpecificationTitleId desc ";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.Connection = connection;
                    connection.Open();
                    return GetStore_SpecificationTitlesCollectionFromDataReader(ExecuteReader(command));
                }

            }
        }

        public override Store_SpecificationTitlesDetails GetSpecificationTitlesById(Guid Id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT * FROM Store_SpecificationTitles WHERE (SpecificationTitleId = @SpecificationTitleId)";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@SpecificationTitleId", SqlDbType.UniqueIdentifier).Value = Id;
                    command.Connection = connection;
                    connection.Open();
                    IDataReader reader = ExecuteReader(command, CommandBehavior.SingleRow);
                    if (reader.Read())
                        return GetStore_SpecificationTitlesFromDataReader(reader); 
                    return null; 
                }

            }
        }
      


        #endregion


        #region TabDescriptions

        public override int insertTabDescriptions(Store_TabDescriptionsDetails store_TabDescriptionsDetails)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand com = new SqlCommand();
                com.CommandText = @"INSERT INTO Store_TabDescriptions (ProductId,Name,Description,DomainId,LanguageId) values(@ProductId,@Name,@Description,@DomainId,@LanguageId)";
                com.Parameters.Clear();

                com.Parameters.Add("@TabDescriptionId", SqlDbType.UniqueIdentifier).Value = store_TabDescriptionsDetails.TabDescriptionId;
                com.Parameters.Add("@ProductId", SqlDbType.UniqueIdentifier).Value = store_TabDescriptionsDetails.ProductId;
                com.Parameters.Add("@Name", SqlDbType.NVarChar).Value = store_TabDescriptionsDetails.Name;
                com.Parameters.Add("@Description", SqlDbType.NVarChar).Value = store_TabDescriptionsDetails.Description;
                com.Parameters.Add("@DomainId", SqlDbType.Int).Value = store_TabDescriptionsDetails.DomainId;
                com.Parameters.Add("@LanguageId", SqlDbType.Int).Value = store_TabDescriptionsDetails.LanguageId;
                com.Connection = connection;
                connection.Open();
                int result = com.ExecuteNonQuery();
                connection.Close();
                return result;
            }
        }

        public override bool DeleteTabDescriptions(Guid Id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "DELETE FROM Store_TabDescriptions Where TabDescriptionId = @TabDescriptionId";
                    command.Parameters.Add("@TabDescriptionId", SqlDbType.UniqueIdentifier).Value = Id;
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    Int32 result = ExecuteNonQuery(command);
                    return result == 1;
                }
            } 
        }

        public override bool UpdateTabDescriptions(Store_TabDescriptionsDetails store_TabDescriptionsDetails)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("Update Store_TabDescriptions set   ProductId=@ProductId,Name=@Name,Description=@Description ,DomainId=@DomainId,LanguageId=@LanguageId   where TabDescriptionId=@TabDescriptionId  ", connection))
                {
                    command.Parameters.Add("@TabDescriptionId", SqlDbType.UniqueIdentifier).Value = store_TabDescriptionsDetails.TabDescriptionId;
                    command.Parameters.Add("@ProductId", SqlDbType.UniqueIdentifier).Value = store_TabDescriptionsDetails.ProductId;
                    command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = store_TabDescriptionsDetails.Name;
                    command.Parameters.Add("@Description", SqlDbType.NVarChar).Value = store_TabDescriptionsDetails.Description;
                    command.Parameters.Add("@DomainId", SqlDbType.Int).Value = store_TabDescriptionsDetails.DomainId;
                    command.Parameters.Add("@LanguageId", SqlDbType.Int).Value = store_TabDescriptionsDetails.LanguageId;
                    command.Connection = connection;
                    connection.Open();
                    Int32 result = ExecuteNonQuery(command);
                    return result == 1;
                }
            }
        }

        public override List<Store_TabDescriptionsDetails> GetTabDescriptionsById(Guid Id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT * FROM Store_TabDescriptions WHERE (TabDescriptionId = @TabDescriptionId)";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@TabDescriptionId", SqlDbType.UniqueIdentifier).Value = Id;
                    command.Connection = connection;
                    connection.Open();
                    return GetStore_TabDescriptionsCollectionFromDataReader(ExecuteReader(command));
                }

            }
        }
        #endregion

        #region TagGroups

        public override bool DeleteTagGroups(Guid Id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "DELETE FROM Store_TagGroups Where TagGroupId = @TagGroupId";
                    command.Parameters.Add("@TagGroupId", SqlDbType.UniqueIdentifier).Value = Id;
                    command.CommandType = CommandType.Text;
                    command.Connection = connection;
                    connection.Open();
                    Int32 result = ExecuteNonQuery(command);
                    return result == 1;
                }
            } 
        }

        public override int insertTagGroups(Store_TagGroupsDetails store_TagGroupsDetails)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand com = new SqlCommand();
                com.CommandText = @"INSERT INTO Store_TagGroups (Name,Description,DomainId,LanguageId) values(@Name,@Description,@DomainId,@LanguageId)";
                com.Parameters.Clear();

                com.Parameters.Add("@TagGroupId", SqlDbType.UniqueIdentifier).Value = store_TagGroupsDetails.TagGroupId;
                com.Parameters.Add("@Name", SqlDbType.NVarChar).Value = store_TagGroupsDetails.Name;
                com.Parameters.Add("@Description", SqlDbType.NVarChar).Value = String.IsNullOrEmpty(store_TagGroupsDetails.Description) ? DBNull.Value : (Object)store_TagGroupsDetails.Description;
                com.Parameters.Add("@DomainId", SqlDbType.Int).Value = store_TagGroupsDetails.DomainId;
                com.Parameters.Add("@LanguageId", SqlDbType.Int).Value = store_TagGroupsDetails.LanguageId;
                com.Connection = connection;
                connection.Open();
                int result = com.ExecuteNonQuery();
                connection.Close();
                return result;
            }
        }

        public override bool UpdateTagGroups(Store_TagGroupsDetails store_TagGroupsDetails)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("Update Store_TagGroups set   Name=@Name,Description=@Description ,DomainId=@DomainId,LanguageId=@LanguageId   where TagGroupId=@TagGroupId  ", connection))
                {
                    command.Parameters.Add("@TagGroupId", SqlDbType.UniqueIdentifier).Value = store_TagGroupsDetails.TagGroupId;
                    command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = store_TagGroupsDetails.Name;
                    command.Parameters.Add("@Description", SqlDbType.NVarChar).Value = String.IsNullOrEmpty(store_TagGroupsDetails.Description) ? DBNull.Value : (Object)store_TagGroupsDetails.Description;
                    command.Parameters.Add("@DomainId", SqlDbType.Int).Value = store_TagGroupsDetails.DomainId;
                    command.Parameters.Add("@LanguageId", SqlDbType.Int).Value = store_TagGroupsDetails.LanguageId;
                    command.Connection = connection;
                    connection.Open();
                    Int32 result = ExecuteNonQuery(command);
                    return result == 1;
                }
            }
        }

        public override List<Store_TagGroupsDetails> GetTagGroupsById(Guid Id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT * FROM Store_TagGroups WHERE (TagGroupId = @TagGroupId)";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text; 
                    command.Parameters.Add("@TagGroupId", SqlDbType.UniqueIdentifier).Value = Id;
                    command.Connection = connection;
                    connection.Open();
                    return GetStore_TagGroupsCollectionFromDataReader(ExecuteReader(command)); 
                }

            }
        }
      
        #endregion

        #region Tags
        public override bool DeleteTags(Guid Id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "DELETE FROM Store_Tags Where TagId = @TagId";
                    command.Parameters.Add("@TagId", SqlDbType.UniqueIdentifier).Value = Id;
                    command.CommandType = CommandType.Text;
                    command.Connection = connection;
                    connection.Open();
                    Int32 result = ExecuteNonQuery(command);
                    return result == 1;
                }
            } 
        }

        public override int insertTags(Store_TagsDetails store_TagsDetails)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand com = new SqlCommand();
                com.CommandText = @"INSERT INTO Store_Tags (TagGroupId,Name,DomainId,LanguageId) values(@TagGroupId,@Name,@DomainId,@LanguageId)";
                com.Parameters.Clear();

                com.Parameters.Add("@TagId", SqlDbType.UniqueIdentifier).Value = store_TagsDetails.TagId;
                com.Parameters.Add("@TagGroupId", SqlDbType.UniqueIdentifier).Value = store_TagsDetails.TagGroupId;
                com.Parameters.Add("@Name", SqlDbType.NVarChar).Value = store_TagsDetails.Name;
                com.Parameters.Add("@DomainId", SqlDbType.Int).Value = store_TagsDetails.DomainId;
                com.Parameters.Add("@LanguageId", SqlDbType.Int).Value = store_TagsDetails.LanguageId;
                com.Connection = connection;
                connection.Open();
                int result = com.ExecuteNonQuery();
                connection.Close();
                return result;
            }
        }

        public override bool UpdateTags(Store_TagsDetails store_TagsDetails)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("Update Store_Tags set   TagGroupId=@TagGroupId,Name=@Name,DomainId=@DomainId,LanguageId=@LanguageId   where TagId=@TagId  ", connection))
                {
                    command.Parameters.Add("@TagId", SqlDbType.UniqueIdentifier).Value = store_TagsDetails.TagId;
                    command.Parameters.Add("@TagGroupId", SqlDbType.UniqueIdentifier).Value = store_TagsDetails.TagGroupId;
                    command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = store_TagsDetails.Name;
                    command.Parameters.Add("@DomainId", SqlDbType.Int).Value = store_TagsDetails.DomainId;
                    command.Parameters.Add("@LanguageId", SqlDbType.Int).Value = store_TagsDetails.LanguageId;
                    command.Connection = connection;
                    connection.Open();
                    Int32 result = ExecuteNonQuery(command);
                    return result == 1;
                }
            }
        }

        public override List<Store_TagsDetails> GetTagsById(Guid Id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT * FROM Store_Tags WHERE (TagId = @TagId)";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@TagId", SqlDbType.UniqueIdentifier).Value = Id;
                    command.Connection = connection;
                    connection.Open();
                    return GetStore_TagsCollectionFromDataReader(ExecuteReader(command)); 
                }

            }
        }
        #endregion

        #region UserScores

        public override bool DeleteUserScores(Guid Id)
        {


            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "DELETE FROM Store_UserScores Where UserScoreId = @UserScoreId";
                    command.Parameters.Add("@UserScoreId", SqlDbType.UniqueIdentifier).Value = Id;
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    Int32 result = ExecuteNonQuery(command);
                    return result == 1;
                }
            } 
        }


        public override int insertUserScores(Store_UserScoresDetails store_UserScoresDetails)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand com = new SqlCommand();
                com.CommandText = @"INSERT INTO Store_UserScores (UserScoreTitleId,Username,Score,DomainId,LanguageId) values(@UserScoreTitleId,@Username,@Score,@DomainId,@LanguageId)";
                com.Parameters.Clear();

                com.Parameters.Add("@UserScoreId", SqlDbType.UniqueIdentifier).Value = store_UserScoresDetails.UserScoreId;
                com.Parameters.Add("@UserScoreTitleId", SqlDbType.UniqueIdentifier).Value = store_UserScoresDetails.UserScoreTitleId;
                com.Parameters.Add("@Username", SqlDbType.NVarChar).Value = store_UserScoresDetails.Username;
                com.Parameters.Add("@Score", SqlDbType.TinyInt).Value = store_UserScoresDetails.Score;
                com.Parameters.Add("@DomainId", SqlDbType.Int).Value = store_UserScoresDetails.DomainId;
                com.Parameters.Add("@LanguageId", SqlDbType.Int).Value = store_UserScoresDetails.LanguageId;
                com.Connection = connection;
                connection.Open();
                int result = com.ExecuteNonQuery();
                connection.Close();
                return result;
            }
        }

        public override bool UpdateUserScores(Store_UserScoresDetails store_UserScoresDetails)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("Update Store_UserScores set   UserScoreTitleId=@UserScoreTitleId,Username=@Username,Score=@Score,DomainId=@DomainId,LanguageId=@LanguageId   where UserScoreId=@UserScoreId  ", connection))
                {
                    command.Parameters.Add("@UserScoreId", SqlDbType.UniqueIdentifier).Value = store_UserScoresDetails.UserScoreId;
                    command.Parameters.Add("@UserScoreTitleId", SqlDbType.UniqueIdentifier).Value = store_UserScoresDetails.UserScoreTitleId;
                    command.Parameters.Add("@Username", SqlDbType.NVarChar).Value = store_UserScoresDetails.Username;
                    command.Parameters.Add("@Score", SqlDbType.TinyInt).Value = store_UserScoresDetails.Score;
                    command.Parameters.Add("@DomainId", SqlDbType.Int).Value = store_UserScoresDetails.DomainId;
                    command.Parameters.Add("@LanguageId", SqlDbType.Int).Value = store_UserScoresDetails.LanguageId;
                    command.Connection = connection;
                    connection.Open();
                    Int32 result = ExecuteNonQuery(command);
                    return result == 1;
                }
            }
        }


        public override List<Store_UserScoresDetails> GetUserScoresById(Guid Id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT * FROM Store_UserScores WHERE (UserScoreId = @UserScoreId)";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@UserScoreId", SqlDbType.UniqueIdentifier).Value = Id;
                    command.Connection = connection;
                    connection.Open();
                    return GetStore_UserScoresCollectionFromDataReader(ExecuteReader(command));
                }

            }
        }
        #endregion

        #region UserScoreTitles

        public override bool DeleteUserScoreTitles(Guid Id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "DELETE FROM Store_UserScoreTitles Where UserScoreTitleId = @UserScoreTitleId";
                    command.Parameters.Add("@UserScoreTitleId", SqlDbType.UniqueIdentifier).Value = Id;
                    command.CommandType = CommandType.Text;
                    command.Connection = connection;
                    connection.Open();
                    Int32 result = ExecuteNonQuery(command);
                    return result == 1;
                }
            } 
        }

        public override int insertUserScoreTitles(Store_UserScoreTitlesDetails store_UserScoreTitlesDetails)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand com = new SqlCommand();
                com.CommandText = @"INSERT INTO Store_UserScoreTitles (ProductId,Name,Description,DomainId,LanguageId) values(@ProductId,@Name,@Description,@DomainId,@LanguageId)";
                com.Parameters.Clear();

                com.Parameters.Add("@UserScoreTitleId", SqlDbType.UniqueIdentifier).Value = store_UserScoreTitlesDetails.UserScoreTitleId;
                com.Parameters.Add("@ProductId", SqlDbType.UniqueIdentifier).Value = store_UserScoreTitlesDetails.ProductId;
                com.Parameters.Add("@Name", SqlDbType.NVarChar).Value = String.IsNullOrEmpty(store_UserScoreTitlesDetails.Name) ? DBNull.Value : (Object)store_UserScoreTitlesDetails.Name;
                com.Parameters.Add("@Description", SqlDbType.NVarChar).Value = String.IsNullOrEmpty(store_UserScoreTitlesDetails.Description) ? DBNull.Value : (Object)store_UserScoreTitlesDetails.Description;
                com.Parameters.Add("@DomainId", SqlDbType.Int).Value = store_UserScoreTitlesDetails.DomainId;
                com.Parameters.Add("@LanguageId", SqlDbType.Int).Value = store_UserScoreTitlesDetails.LanguageId;
                com.Connection = connection;
                connection.Open();
                int result = com.ExecuteNonQuery();
                connection.Close();
                return result;
            }
        }

        public override bool UpdateUserScoreTitles(Store_UserScoreTitlesDetails store_UserScoreTitlesDetails)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("Update Store_UserScoreTitles set   ProductId=@ProductId,Name=@Name,Description=@Description,DomainId=@DomainId,LanguageId=@LanguageId   where UserScoreTitleId=@UserScoreTitleId  ", connection))
                {
                    command.Parameters.Add("@UserScoreTitleId", SqlDbType.UniqueIdentifier).Value = store_UserScoreTitlesDetails.UserScoreTitleId;
                    command.Parameters.Add("@ProductId", SqlDbType.UniqueIdentifier).Value = store_UserScoreTitlesDetails.ProductId;
                    command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = String.IsNullOrEmpty(store_UserScoreTitlesDetails.Name) ? DBNull.Value : (Object)store_UserScoreTitlesDetails.Name;
                    command.Parameters.Add("@Description", SqlDbType.NVarChar).Value = String.IsNullOrEmpty(store_UserScoreTitlesDetails.Description) ? DBNull.Value : (Object)store_UserScoreTitlesDetails.Description;
                    command.Parameters.Add("@DomainId", SqlDbType.Int).Value = store_UserScoreTitlesDetails.DomainId;
                    command.Parameters.Add("@LanguageId", SqlDbType.Int).Value = store_UserScoreTitlesDetails.LanguageId;
                    command.Connection = connection;
                    connection.Open(); 
                    Int32 result = ExecuteNonQuery(command);
                    return result == 1;
                }
            }
        }

        public override List<Store_UserScoreTitlesDetails> GetUserScoreTitlesById(Guid Id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT * FROM Store_UserScoreTitles WHERE (UserScoreTitleId = @UserScoreTitleId)";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@UserScoreTitleId", SqlDbType.UniqueIdentifier).Value = Id;
                    command.Connection = connection;
                    connection.Open();
                    return GetStore_UserScoreTitlesCollectionFromDataReader(ExecuteReader(command));
                }

            }
        }
        #endregion

        #region ProductsConSpecificationText

        public override bool DeleteProductsConSpecificationTextByProductId(Guid productId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "DELETE FROM Store_ProductsConSpecificationTexts Where ProductId = @ProductId  ";
                    command.Parameters.Add("@ProductId", SqlDbType.UniqueIdentifier).Value = productId;
                    command.CommandType = CommandType.Text;
                    command.Connection = connection;
                    connection.Open();
                    Int32 result = ExecuteNonQuery(command);
                    return result == 1;
                }
            } 
        }

        public override bool DeleteProductsConSpecificationTextByspecificationTextId(Guid specificationTextId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "DELETE FROM Store_ProductsConSpecificationTexts Where SpecificationTextId = @SpecificationTextId";
                    command.Parameters.Add("@SpecificationTextId", SqlDbType.UniqueIdentifier).Value = specificationTextId;
                    command.CommandType = CommandType.Text;
                    command.Connection = connection;
                    connection.Open();
                    Int32 result = ExecuteNonQuery(command);
                    return result == 1;
                }
            } 
        }

        public override List<Store_ProductsConSpecificationTextsDetails> GetAllProductsConSpecificationText()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT * FROM Store_ProductsConSpecificationTexts ";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    
                    command.Connection = connection;
                    connection.Open();
                    return GetStore__ProductsConSpecificationTextCollectionFromDataReader(ExecuteReader(command));
                }

            }
        }

        public override List<Store_ProductsConSpecificationTextsDetails> GetProductsConSpecificationTextByProductId(Guid productId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT * FROM Store_ProductsConSpecificationTexts WHERE (ProductId = @ProductId) ORDER BY Store_ProductsConSpecificationTexts.SpecificationTextId";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@ProductId", SqlDbType.UniqueIdentifier).Value = productId;
                    command.Connection = connection;
                    connection.Open();
                    return GetStore__ProductsConSpecificationTextCollectionFromDataReader(ExecuteReader(command));
                }

            }
        }

        public override int InsertProductsConSpecificationText(Store_ProductsConSpecificationTextsDetails Store_ProductsConSpecificationTextsDetails)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand com = new SqlCommand();
                com.CommandText = @"INSERT INTO Store_ProductsConSpecificationTexts (ProductId,SpecificationTextId,Description) values(@ProductId,@SpecificationTextId,@Description)";
                com.Parameters.Clear();

                com.Parameters.Add("@ProductId", SqlDbType.UniqueIdentifier).Value = Store_ProductsConSpecificationTextsDetails.ProductId;
                com.Parameters.Add("@SpecificationTextId", SqlDbType.UniqueIdentifier).Value = Store_ProductsConSpecificationTextsDetails.SpecificationTextId;
                com.Parameters.Add("@Description", SqlDbType.NVarChar).Value = Store_ProductsConSpecificationTextsDetails.Description;


                com.Connection = connection;
                connection.Open();
                int result = com.ExecuteNonQuery();
                connection.Close();
                return result;
            }
        }

        #endregion

        #region  Store_Specification

        public override List<Store_SpecificationDetails> GetSpecificationJoin(Guid productId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = @"SELECT        Store_SpecificationTitles.Name,Store_SpecificationTexts.Text, Store_ProductsConSpecificationTexts.Description
                  FROM            Store_SpecificationTexts INNER JOIN
                         Store_ProductsConSpecificationTexts ON Store_SpecificationTexts.SpecificationTextId = Store_ProductsConSpecificationTexts.SpecificationTextId INNER JOIN
                         Store_SpecificationTitles ON Store_SpecificationTexts.SpecificationTitleId = Store_SpecificationTitles.SpecificationTitleId
                 WHERE        (Store_ProductsConSpecificationTexts.ProductId = @ProductId)
                   ORDER BY Store_SpecificationTitles.Name";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@ProductId", SqlDbType.UniqueIdentifier).Value = productId;
                    command.Connection = connection;
                    connection.Open();
                    return GetStore__SpecificationCollectionFromDataReader(ExecuteReader(command));
                }

            }
        }

        #endregion


        #region Store_ProductsConModules

        public override int InsertProductsConModules(Store_ProductsConModulesDetails store_ProductsConModulesDetails)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand com = new SqlCommand();
                com.CommandText = @"INSERT INTO Store_ProductsConModules (ProductId,IdModule,Description,Value1,Value2,Value3,Value4,Value5) values(@ProductId,@IdModule,@Description,@Value1,@Value2,@Value3,@Value4,@Value5)";
                com.Parameters.Clear();

                com.Parameters.Add("@ProductId", SqlDbType.UniqueIdentifier).Value = store_ProductsConModulesDetails.ProductId;
                com.Parameters.Add("@IdModule", SqlDbType.UniqueIdentifier).Value = store_ProductsConModulesDetails.IdModule;
                com.Parameters.Add("@Description", SqlDbType.NVarChar).Value = String.IsNullOrEmpty(store_ProductsConModulesDetails.Description) ? DBNull.Value : (Object)store_ProductsConModulesDetails.Description;
                com.Parameters.Add("@Value1", SqlDbType.NVarChar).Value = String.IsNullOrEmpty(store_ProductsConModulesDetails.Value1) ? DBNull.Value : (Object)store_ProductsConModulesDetails.Value1;
                com.Parameters.Add("@Value2", SqlDbType.NVarChar).Value = String.IsNullOrEmpty(store_ProductsConModulesDetails.Value2) ? DBNull.Value : (Object)store_ProductsConModulesDetails.Value2;
                com.Parameters.Add("@Value3", SqlDbType.NVarChar).Value = String.IsNullOrEmpty(store_ProductsConModulesDetails.Value3) ? DBNull.Value : (Object)store_ProductsConModulesDetails.Value3;
                com.Parameters.Add("@Value4", SqlDbType.NVarChar).Value = String.IsNullOrEmpty(store_ProductsConModulesDetails.Value4) ? DBNull.Value : (Object)store_ProductsConModulesDetails.Value4;
                com.Parameters.Add("@Value5", SqlDbType.NVarChar).Value = String.IsNullOrEmpty(store_ProductsConModulesDetails.Value5) ? DBNull.Value : (Object)store_ProductsConModulesDetails.Value5;
                

                com.Connection = connection;
                connection.Open();
                int result = com.ExecuteNonQuery();
                connection.Close();
                return result;
            }
        }


        public override bool DeleteProductsConModules(Guid productId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "DELETE FROM Store_ProductsConModules Where ProductId = @ProductId";
                    command.Parameters.Add("@ProductId", SqlDbType.UniqueIdentifier).Value = productId;
                    command.CommandType = CommandType.Text;
                    command.Connection = connection;
                    connection.Open();
                    Int32 result = ExecuteNonQuery(command);
                    return result == 1;
                }
            } 
        }

        #endregion  


        #region Store_TabModules

        public override bool DeleteTabModules(int idModule)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "DELETE FROM Store_TabModules Where IdModule = @IdModule";
                    command.Parameters.Add("@IdModule", SqlDbType.Int).Value = idModule;
                    command.CommandType = CommandType.Text;
                    command.Connection = connection;
                    connection.Open();
                    Int32 result = ExecuteNonQuery(command);
                    return result == 1;
                }
            } 
        }

        public override int InsertTabModules(Store_TabModulesDetails store_TabModulesDetails)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand com = new SqlCommand();
                com.CommandText = @"INSERT INTO Store_TabModules (Name,Description,UserControlAddress,IsActive,DomainId,LanguageId) values(@Name,@Description,@UserControlAddress,@IsActive,@DomainId,@LanguageI)";
                com.Parameters.Clear();


              //  com.Parameters.Add("@IdModule", SqlDbType.).Value = store_TabModulesDetails.IdModule;
                com.Parameters.Add("@Name", SqlDbType.Int).Value = store_TabModulesDetails.Name;
                com.Parameters.Add("@Description", SqlDbType.NVarChar).Value = String.IsNullOrEmpty(store_TabModulesDetails.Description) ? DBNull.Value : (Object)store_TabModulesDetails.Description;
                com.Parameters.Add("@UserControlAddress", SqlDbType.NVarChar).Value = store_TabModulesDetails.UserControlAddress;
                com.Parameters.Add("@IsActive", SqlDbType.Bit).Value = store_TabModulesDetails.IsActive;
                com.Parameters.Add("@DomainId", SqlDbType.Int).Value = store_TabModulesDetails.DomainId;
                com.Parameters.Add("@LanguageId", SqlDbType.Int).Value = store_TabModulesDetails.LanguageId;
               


                com.Connection = connection;
                connection.Open();
                int result = com.ExecuteNonQuery();
                connection.Close();
                return result;
            }
        }

        #endregion


    }
}

