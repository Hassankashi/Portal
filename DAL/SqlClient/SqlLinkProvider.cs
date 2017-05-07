using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Pine.Dal.Link;

namespace Pine.Dal.SqlClient
{
    /// <summary>
    /// کلاسی برای پیاده سازی لینک
    /// </summary>
    public class SqlLinkProvider : LinkProvider
    {
        #region LinkGroup (3)

        public override LinkGroupDetails GetLinkGroupByLinkGroupId(Int32 linkGroupId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT * FROM LinkGroup WHERE (LinkGroupId = @LinkGroupId) ";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@LinkGroupId", SqlDbType.Int).Value = linkGroupId;
                    connection.Open();
                    IDataReader reader = ExecuteReader(command, CommandBehavior.SingleRow);
                    if (reader.Read())
                        return GetLinkGroupFromDataReader(reader);
                    return null;
                }
            }
        }

        /// <summary>
        /// یک گروه جدید
        /// </summary>
        /// <param name="Name">نام گروه لینک</param>
        /// <returns></returns>
        public override Int32 InsertLinkGroup(LinkGroupDetails linkGroup)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand com = new SqlCommand();
                com.CommandText = "INSERT INTO LinkGroup (Name) VALUES (@Name) SELECT CAST(scope_identity() AS int)";
                com.Parameters.Clear();
               // com.Parameters.Add("@MenuNameId", SqlDbType.Int).Direction = ParameterDirection.Output;
                com.Parameters.Add("@Name", SqlDbType.NVarChar).Value = linkGroup.Name;
                com.Connection = connection;
                connection.Open();
                int id = (int)com.ExecuteScalar();
                connection.Close();
                return id;
            }
        }



        /// <summary>
        /// ویرایش نام گروه
        /// </summary>
        /// <param name="menuGroup"></param>
        /// <returns></returns>
        public override Boolean UpdateLinkGroup(LinkGroupDetails linkGroup)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("Update LinkGroup set Name=@Name  where LinkGroupId=@LinkGroupId", connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.Clear();
                    command.Parameters.Add("@LinkGroupId", SqlDbType.Int).Value = linkGroup.LinkGroupId ;
                    command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = linkGroup.Name;
                    connection.Open();
                    Int32 result = ExecuteNonQuery(command);
                    return result == 1;
                }
            }
        }
        #endregion

        #region Link (3)

        public override List<LinkDetails> GetLinkByLinkGroupId(int linkGroupId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "select * from Link where (LinkGroupId = @LinkGroupId)";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@LinkGroupId", SqlDbType.Int).Value = linkGroupId;
                    connection.Open();
                    return GetLinkCollectionFromDataReader(ExecuteReader(command));
                }
            }
        }

        public override LinkDetails GetLinkByLinkId(Int32 linkId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "select * from Link where (LinkId = @LinkId)";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@LinkId", SqlDbType.Int).Value = linkId;
                    connection.Open();

                    IDataReader reader = ExecuteReader(command, CommandBehavior.SingleRow);

                    if (reader.Read())
                        return GetLinkFromDataReader(reader);
                    return null;

                   // return GetMenuUserFromDataReader(ExecuteReader(command));
                }
            }
        }


        /// <summary>
        /// بروز رسانی اطلاعات یک فیش نقدی
        /// </summary>
        /// <param name="swift">جزئیات فیش نقدی</param>
        /// <returns></returns>
        public override Boolean UpdateLink(LinkDetails link)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("Update Link set LinkName=@LinkName, NavigateUrl=@NavigateUrl ,IsActive=@IsActive, UserControl=@UserControl  where LinkId=@LinkId", connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.Clear();
                    command.Parameters.Add("@LinkName", SqlDbType.NVarChar).Value = link.LinkName;
                    command.Parameters.Add("@LinkId", SqlDbType.Int).Value = link.LinkId ;
                    command.Parameters.Add("@NavigateUrl", SqlDbType.NVarChar).Value = (object)link.NavigateUrl ?? DBNull.Value;
                    command.Parameters.Add("@UserControl", SqlDbType.NVarChar).Value = (object)link.UserControl??DBNull.Value;
                    command.Parameters.Add("@IsActive", SqlDbType.Bit).Value = link.IsActive;
                    connection.Open();
                    Int32 result = ExecuteNonQuery(command);
                    return result == 1;
                }
            }
        }

       
        /// <summary>
        /// ثبت جزئیات یک پرداخت نقدی
        /// </summary>
        /// <param name="swift">جزئیات پرداخت نقدی</param>
        /// <returns></returns>
        public override Int32 InsertLink(LinkDetails link)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand com = new SqlCommand();
                com.CommandText = "INSERT INTO Link (LinkGroupId,LinkName,NavigateUrl,IconUrl,IsActive,Priority,EnterDate,UserControl) VALUES (@LinkGroupId,@LinkName,@NavigateUrl,@IconUrl,@IsActive,@Priority,@EnterDate,@UserControl) SELECT CAST(scope_identity() AS int)";
                com.Parameters.Clear();
               // com.Parameters.Add("@MenuId", SqlDbType.Int).Direction = ParameterDirection.Output;
                com.Parameters.Add("@LinkGroupId", SqlDbType.Int).Value = link.LinkGroupId ;
                com.Parameters.Add("@LinkName", SqlDbType.NVarChar).Value = link.LinkName ;
                com.Parameters.Add("@NavigateUrl", SqlDbType.NVarChar).Value = (object)link.NavigateUrl ?? DBNull.Value;
                com.Parameters.Add("@IconUrl", SqlDbType.NVarChar).Value = (object)link.IconUrl ?? DBNull.Value;
                com.Parameters.Add("@IsActive", SqlDbType.Bit).Value =link.IsActive;
                com.Parameters.Add("@Priority", SqlDbType.TinyInt).Value = link.Priority;
                com.Parameters.Add("@EnterDate", SqlDbType.DateTime).Value = link.EnterDate;
                com.Parameters.Add("@UserControl", SqlDbType.NVarChar).Value = (object)link.UserControl??DBNull.Value ;
                com.Connection = connection;
                connection.Open();
                int id = (int)com.ExecuteScalar();
                connection.Close();
               //com.ExecuteNonQuery();
                return id;
            }
        }

        #endregion

    }
}

