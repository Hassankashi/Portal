using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Pine.Dal.Menu;

namespace Pine.Dal.SqlClient
{
    /// <summary>
    /// کلاسی برای پیاده سازی منوها
    /// </summary>
    public class SqlMenuProvider : MenuProvider
    {
        #region MenuName(Group) (3)

        public override string GetNameMenuById(int menuNameId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT MenuName FROM MenuName WHERE (MenuNameId = @MenuNameId) ";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@MenuNameId", SqlDbType.Int).Value = menuNameId;
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result == DBNull.Value)
                    {
                        return "";
                    }
                    else
                    {
                        return (string)result;
                    }
                }
            }
        }

        /// <summary>
        /// ثبت جزئیات یک پرداخت نقدی
        /// </summary>
        /// <param name="swift">جزئیات پرداخت نقدی</param>
        /// <returns></returns>
        public override int InsertGroupName(MenuGroupDetails menuGroup)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand com = new SqlCommand();
                com.CommandText = "INSERT INTO MenuName (MenuName) VALUES (@MenuName) SELECT CAST(scope_identity() AS int)";
                com.Parameters.Clear();
               // com.Parameters.Add("@MenuNameId", SqlDbType.Int).Direction = ParameterDirection.Output;
                com.Parameters.Add("@MenuName", SqlDbType.NVarChar).Value = menuGroup.MenuName;
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
        public override Boolean UpdateGroupName(MenuGroupDetails menuGroup)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("Update MenuName set MenuName=@MenuName  where MenuNameId=@MenuNameId", connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.Clear();
                    command.Parameters.Add("@MenuNameId", SqlDbType.Int).Value = menuGroup.MenuNameId;
                    command.Parameters.Add("@MenuName", SqlDbType.NVarChar).Value = menuGroup.MenuName;
                    connection.Open();
                    Int32 result = ExecuteNonQuery(command);
                    return result == 1;
                }
            }
        }
        #endregion

        #region MenuUser (3)

        public override List<MenuDetails> GetMenuByMenuNameId(int menuNameId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "select * from MenuUser where (MenuNameId = @MenuNameId) order by Priority";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@MenuNameId", SqlDbType.Int).Value = menuNameId;
                    connection.Open();
                    return GetMenuUserCollectionFromDataReader(ExecuteReader(command));
                }
            }
        }

        public override MenuDetails GetMenuById(int menuId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "select * from MenuUser where (menuId = @menuId)";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@MenuId", SqlDbType.Int).Value = menuId;
                    connection.Open();

                    IDataReader reader = ExecuteReader(command, CommandBehavior.SingleRow);

                    if (reader.Read())
                        return GetMenuUserFromDataReader(reader);
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
        public override bool UpdateMenuNavigateUrl(int menuId, string navigateUrl, string userControl)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {

                using (SqlCommand command = new SqlCommand("Update MenuUser set NavigateUrl=@NavigateUrl , UserControl=@UserControl  where MenuId=@MenuId", connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.Clear();
                    command.Parameters.Add("@MenuId", SqlDbType.Int).Value = menuId;
                    command.Parameters.Add("@NavigateUrl", SqlDbType.NVarChar).Value = navigateUrl;
                    command.Parameters.Add("@UserControl", SqlDbType.NVarChar).Value = userControl;
                    connection.Open();
                    Int32 result = ExecuteNonQuery(command);
                    return result == 1;
                }
            }
        }

        public override Boolean UpdateMenu(MenuDetails menu) 
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("Update MenuUser set Priority=@Priority , Text=@Text  where MenuId=@MenuId", connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.Clear();
                    command.Parameters.Add("@MenuId", SqlDbType.Int).Value = menu.MenuId;
                    command.Parameters.Add("@Text", SqlDbType.NVarChar).Value = menu.Text;
                    command.Parameters.Add("@Priority", SqlDbType.Int).Value = menu.Priority ;
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
        public override int InsertMenu(MenuDetails menu)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand com = new SqlCommand();
                com.CommandText = "INSERT INTO MenuUser (ParentMenuId,MenuNameId,Text,Priority) VALUES (@ParentMenuId,@MenuNameId,@Text,@Priority) SELECT CAST(scope_identity() AS int)";
                com.Parameters.Clear();
               // com.Parameters.Add("@MenuId", SqlDbType.Int).Direction = ParameterDirection.Output;
                com.Parameters.Add("@ParentMenuId", SqlDbType.Int).Value = (object)menu.ParentMenuId ?? DBNull.Value ;
                com.Parameters.Add("@MenuNameId", SqlDbType.Int).Value = menu.MenuNameId;
                com.Parameters.Add("@Text", SqlDbType.NVarChar).Value = menu.Text;
                com.Parameters.Add("@Priority", SqlDbType.TinyInt).Value = menu.Priority;
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

