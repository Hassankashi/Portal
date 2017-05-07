using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Pine.Dal.Core;

namespace Pine.Dal.SqlClient
{
    /// <summary>
    /// کلاسی برای پیاده سازی هسته
    /// </summary>
    public class SqlCoreProvider : CoreProvider
    {
        
        #region CoreParameter (6)

        public override List<CoreParameterDetails> GetCoreParameterByParameter(String parameter)
        {
            
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT * FROM CoreParameter WHERE (Parameter = @Parameter)";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@Parameter", SqlDbType.NVarChar).Value = parameter;
                    connection.Open();
                    return GetCoreParameterCollectionFromDataReader(ExecuteReader(command));
                }
            }
        }

        /// <summary>
        /// ثبت جزئیات یک پرداخت نقدی
        /// </summary>
        /// <param name="swift">جزئیات پرداخت نقدی</param>
        /// <returns></returns>
        /// 

        public override List<CoreParameterDetails> GetCoreParameterByParameterAndValue(String parameter, String value)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = @"select * from CoreParameter where Parameter Like @Parameter and Value1 Like @Value1";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@Parameter", SqlDbType.NVarChar).Value = parameter;
                    command.Parameters.Add("@Value1", SqlDbType.NVarChar).Value = value;
                    connection.Open();
                    return GetCoreParameterCollectionFromDataReader(ExecuteReader(command));
                }
            }

        }

        public override CoreParameterDetails GetCoreParameterByCoreParameterId(Int32 coreParameterId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "select * from CoreParameter where (CoreParameterId = @CoreParameterId)";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@coreParameterId", SqlDbType.Int).Value = coreParameterId;
                    connection.Open();

                    IDataReader reader = ExecuteReader(command, CommandBehavior.SingleRow);

                    if (reader.Read())
                        return GetCoreParameterFromDataReader(reader);
                    return null;
                   // return GetMenuUserFromDataReader(ExecuteReader(command));
                }
            }
        }

        public override Boolean DeleteCoreParameterByParameter(String parameter)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "DELETE FROM CoreParameter Where Parameter = @Parameter";
                    command.Parameters.Clear();
                    command.Parameters.Add("@Parameter", SqlDbType.NVarChar).Value = parameter;
                    command.CommandType = CommandType.Text;
                    command.Connection = connection;
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
        public override int InsertCoreParameter(CoreParameterDetails coreParameter)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand com = new SqlCommand();
                com.CommandText = "INSERT INTO CoreParameter (Parameter,name,Value1,Value2,Value3,DomainId,LanguageId) VALUES (@Parameter,@name,@Value1,@Value2,@Value3,@DomainId,@LanguageId) SELECT CAST(scope_identity() AS int)";
                //com.Parameters.Add("@CoreParameterId", SqlDbType.Int).Direction = ParameterDirection.Output;
                com.Parameters.Add("@Parameter", SqlDbType.NVarChar).Value = coreParameter.Parameter;
                com.Parameters.Add("@name", SqlDbType.NVarChar).Value = coreParameter.Name;
                com.Parameters.Add("@Value1", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(coreParameter.Value1) ? DBNull.Value : (Object)coreParameter.Value1;
                com.Parameters.Add("@Value2", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(coreParameter.Value2) ? DBNull.Value : (Object)coreParameter.Value2;
                com.Parameters.Add("@Value3", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(coreParameter.Value3) ? DBNull.Value : (Object)coreParameter.Value3;
                com.Parameters.Add("@DomainId", SqlDbType.Int).Value = coreParameter.DomainId;
                com.Parameters.Add("@LanguageId", SqlDbType.Int).Value = coreParameter.LanguageId;
                com.Connection = connection;
                connection.Open();
                int id = (int)com.ExecuteScalar();
                connection.Close();
                return id;
            }
        }

        /// <summary>
        /// بروز رسانی اطلاعات یک فیش نقدی
        /// </summary>
        /// <param name="swift">جزئیات فیش نقدی</param>
        /// <returns></returns>
        public override Boolean UpdateCoreParameter(CoreParameterDetails coreParameter)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand com = new SqlCommand("Update CoreParameter set Parameter=@Parameter,name=@name,Value1=@Value1,Value2=@Value2,Value3=@Value3,DomainId=@DomainId,LanguageId=@LanguageId  where CoreParameterId=@CoreParameterId", connection))
                {
                    com.CommandType = CommandType.Text;
                    com.Parameters.Add("@CoreParameterId", SqlDbType.Int).Value = coreParameter.CoreParameterId;
                    com.Parameters.Add("@Parameter", SqlDbType.NVarChar).Value = coreParameter.Parameter;
                    com.Parameters.Add("@name", SqlDbType.NVarChar).Value = coreParameter.Name;
                    com.Parameters.Add("@Value1", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(coreParameter.Value1) ? DBNull.Value : (Object)coreParameter.Value1;
                    com.Parameters.Add("@Value2", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(coreParameter.Value2) ? DBNull.Value : (Object)coreParameter.Value2;
                    com.Parameters.Add("@Value3", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(coreParameter.Value3) ? DBNull.Value : (Object)coreParameter.Value3;
                    com.Parameters.Add("@DomainId", SqlDbType.Int).Value = coreParameter.DomainId;
                    com.Parameters.Add("@LanguageId", SqlDbType.Int).Value = coreParameter.LanguageId;
                    connection.Open();
                    Int32 result = ExecuteNonQuery(com);
                    return result == 1;
                }
            }
        }

      
       #endregion

        #region CoreThemeSetting (1)

        public override List<CoreThemeSettingDetails> GetCoreThemeSettingDetailsByThemeName(String themeName)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = @"SELECT  CoreThemeSetting.ThemeSettingId, CoreThemeSetting.ThemeSettingTypeId, CoreThemeSetting.Value1, CoreThemeSetting.Value2, CoreThemeSetting.Value3, 
                         CoreThemeSetting.Value4, CoreThemeSetting.Value5, CoreThemeSetting.Value6, CoreThemeSetting.Value7, CoreThemeSettingType.Parameter
                            FROM   CoreMasterPageNames INNER JOIN
                         CoreThemeMiddelSetting ON CoreMasterPageNames.MasterPageNameId = CoreThemeMiddelSetting.MasterPageNameId INNER JOIN
                         CoreThemeSetting ON CoreThemeMiddelSetting.ThemeSettingId = CoreThemeSetting.ThemeSettingId INNER JOIN
                         CoreThemeSettingType ON CoreThemeSetting.ThemeSettingTypeId = CoreThemeSettingType.ThemeSettingTypeId
                            WHERE  (CoreMasterPageNames.ThemeName = @ThemeName)";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@ThemeName", SqlDbType.NVarChar).Value = themeName;
                    connection.Open();
                    return GetCoreThemeSettingDetailsCollectionFromDataReader(ExecuteReader(command));
                }
            }
        
        }

        public override int InsertCoreThemeSetting(Pine.Dal.Core.CoreThemeSettingDetails coreThemeSettingDetails)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand com = new SqlCommand();
                com.CommandText = "INSERT INTO CoreThemeSetting (ThemeSettingTypeId,Value1,Value2,Value3,Value4,Value5,Value6,Value7,Parameter,DomainId,LanguageId) VALUES (@ThemeSettingTypeId,@Value1,@Value2,@Value3,@Value4,@Value5,@Value6,@Value7,@Parameter,@DomainId,@LanguageId) SELECT CAST(scope_identity() AS int)";
                com.Parameters.Add("@ThemeSettingTypeId", SqlDbType.Int).Value = coreThemeSettingDetails.Parameter;
                com.Parameters.Add("@Value1", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(coreThemeSettingDetails.Value1) ? DBNull.Value : (Object)coreThemeSettingDetails.Value1;
                com.Parameters.Add("@Value2", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(coreThemeSettingDetails.Value2) ? DBNull.Value : (Object)coreThemeSettingDetails.Value2;
                com.Parameters.Add("@Value3", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(coreThemeSettingDetails.Value3) ? DBNull.Value : (Object)coreThemeSettingDetails.Value3;
                com.Parameters.Add("@Value4", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(coreThemeSettingDetails.Value4) ? DBNull.Value : (Object)coreThemeSettingDetails.Value4;
                com.Parameters.Add("@Value5", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(coreThemeSettingDetails.Value5) ? DBNull.Value : (Object)coreThemeSettingDetails.Value5;
                com.Parameters.Add("@Value6", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(coreThemeSettingDetails.Value6) ? DBNull.Value : (Object)coreThemeSettingDetails.Value6;
                com.Parameters.Add("@Value7", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(coreThemeSettingDetails.Value7) ? DBNull.Value : (Object)coreThemeSettingDetails.Value7;
                com.Parameters.Add("@Parameter", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(coreThemeSettingDetails.Parameter) ? DBNull.Value : (Object)coreThemeSettingDetails.Parameter;
                com.Parameters.Add("@DomainId", SqlDbType.Int).Value = coreThemeSettingDetails.DomainId;
                com.Parameters.Add("@LanguageId", SqlDbType.Int).Value = coreThemeSettingDetails.LanguageId;
                com.Connection = connection;
                connection.Open();
                int id = (int)com.ExecuteScalar();
                connection.Close();
                return id;
            }
        }

        public override bool UpdateCoreThemeSetting(CoreThemeSettingDetails coreThemeSettingDetails)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand com = new SqlCommand("Update CoreThemeSetting set ThemeSettingTypeId=@ThemeSettingTypeId,Value1=@Value1,Value2=@Value2,Value3=@Value3,Value4=@Value4,Value5=@Value5,Value6=@Value6,Value7=@Value7,DomainId = @DomainId ,LanguageId = @LanguageId  where ThemeSettingId = @ThemeSettingId", connection))
                {
                    com.CommandType = CommandType.Text;
                    com.Parameters.Add("@ThemeSettingId", SqlDbType.Int).Value = coreThemeSettingDetails.ThemeSettingId;
                    com.Parameters.Add("@ThemeSettingTypeId", SqlDbType.Int).Value = coreThemeSettingDetails.Parameter;
                    com.Parameters.Add("@Value1", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(coreThemeSettingDetails.Value1) ? DBNull.Value : (Object)coreThemeSettingDetails.Value1;
                    com.Parameters.Add("@Value2", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(coreThemeSettingDetails.Value2) ? DBNull.Value : (Object)coreThemeSettingDetails.Value2;
                    com.Parameters.Add("@Value3", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(coreThemeSettingDetails.Value3) ? DBNull.Value : (Object)coreThemeSettingDetails.Value3;
                    com.Parameters.Add("@Value4", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(coreThemeSettingDetails.Value4) ? DBNull.Value : (Object)coreThemeSettingDetails.Value4;
                    com.Parameters.Add("@Value5", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(coreThemeSettingDetails.Value5) ? DBNull.Value : (Object)coreThemeSettingDetails.Value5;
                    com.Parameters.Add("@Value6", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(coreThemeSettingDetails.Value6) ? DBNull.Value : (Object)coreThemeSettingDetails.Value6;
                    com.Parameters.Add("@Value7", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(coreThemeSettingDetails.Value7) ? DBNull.Value : (Object)coreThemeSettingDetails.Value7;
                    com.Parameters.Add("@Parameter", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(coreThemeSettingDetails.Parameter) ? DBNull.Value : (Object)coreThemeSettingDetails.Parameter;
                    com.Parameters.Add("@DomainId", SqlDbType.Int).Value = coreThemeSettingDetails.DomainId;
                    com.Parameters.Add("@LanguageId", SqlDbType.Int).Value = coreThemeSettingDetails.LanguageId;
                    connection.Open();
                    Int32 result = ExecuteNonQuery(com);
                    return result == 1;
                }
            }
        }

        public override bool DeleteCoreThemeSetting(int themeSettingId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "DELETE FROM CoreThemeSetting Where ThemeSettingId = @ThemeSettingId";
                    command.Parameters.Add("@ThemeSettingId", SqlDbType.Int).Value = themeSettingId;
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    Int32 result = ExecuteNonQuery(command);
                    return result == 1;
                }
            }
        }
        #endregion

        #region CoreMasterPageNames (4)

        public override CoreMasterPageNamesDetails GetCoreMasterPageNamesDetailsThemeName()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT top(1) CoreMasterPageNames.* FROM  CorePages LEFT OUTER JOIN CoreMasterPageNames ON CorePages.MasterPageNameId = CoreMasterPageNames.MasterPageNameId";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    connection.Open();

                    IDataReader reader = ExecuteReader(command, CommandBehavior.SingleRow);

                    if (reader.Read())
                        return GetCoreMasterPageNamesDetailsFromDataReader(reader);
                    return null;
                    //return GetCoreThemeSettingDetailsCollectionFromDataReader(ExecuteReader(command));
                }
            }
        
        }
        public override int InsertCoreMasterPageNames(Pine.Dal.Core.CoreMasterPageNamesDetails coreMasterPageNamesDetails)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand com = new SqlCommand();
                com.CommandText = "INSERT INTO CoreMasterPageNames(MasterPageGroupNameId,ThemeName,Path,PathSmallImage,PathImage,NameImage,RTL,DomainId,LanguageId) VALUES (@MasterPageGroupNameId,@ThemeName,@Path,@PathSmallImage,@PathImage,@NameImage,@RTL,@DomainId,@LanguageId) SELECT CAST(scope_identity() AS int)";
                com.Parameters.Add("@MasterPageGroupNameId", SqlDbType.Int).Value = coreMasterPageNamesDetails.MasterPageGroupNameId;
                com.Parameters.Add("@ThemeName", SqlDbType.NVarChar).Value = coreMasterPageNamesDetails.ThemeName;
                com.Parameters.Add("@Path", SqlDbType.NVarChar).Value = coreMasterPageNamesDetails.Path;
                com.Parameters.Add("@PathSmallImage", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(coreMasterPageNamesDetails.PathSmallImage) ? DBNull.Value : (Object)coreMasterPageNamesDetails.PathSmallImage;
                com.Parameters.Add("@PathImage", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(coreMasterPageNamesDetails.PathImage) ? DBNull.Value : (Object)coreMasterPageNamesDetails.PathImage;
                com.Parameters.Add("@NameImage", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(coreMasterPageNamesDetails.NameImage) ? DBNull.Value : (Object)coreMasterPageNamesDetails.NameImage;
                com.Parameters.Add("@RTL", SqlDbType.Int).Value = coreMasterPageNamesDetails.Rtl;
                com.Parameters.Add("@DomainId", SqlDbType.Int).Value = coreMasterPageNamesDetails.DomainId;
                com.Parameters.Add("@LanguageId", SqlDbType.Int).Value = coreMasterPageNamesDetails.LanguageId;
                com.Connection = connection;
                connection.Open();
                int id = (int)com.ExecuteScalar();
                connection.Close();
                return id;
            }
        }
        public override bool UpdateCoreMasterPageNames(CoreMasterPageNamesDetails coreMasterPageNamesDetails)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand com = new SqlCommand("Update CoreMasterPageNames set MasterPageGroupNameId=@MasterPageGroupNameId,ThemeName=@ThemeName,Path=@Path,PathSmallImage=@PathSmallImage,PathImage=@PathImage,NameImage = @NameImage ,RTL=@RTL , DomainId=@domainId , LanguageId = @languageId  where MasterPageNameId = @MasterPageNameId", connection))
                {
                    com.CommandType = CommandType.Text;
                    com.Parameters.Add("@MasterPageNameId", SqlDbType.Int).Value = coreMasterPageNamesDetails.MasterPageNameId;
                    com.Parameters.Add("@MasterPageGroupNameId", SqlDbType.Int).Value = coreMasterPageNamesDetails.MasterPageGroupNameId;
                    com.Parameters.Add("@ThemeName", SqlDbType.NVarChar).Value = coreMasterPageNamesDetails.ThemeName;
                    com.Parameters.Add("@Path", SqlDbType.NVarChar).Value = coreMasterPageNamesDetails.Path;
                    com.Parameters.Add("@PathSmallImage", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(coreMasterPageNamesDetails.PathSmallImage) ? DBNull.Value : (Object)coreMasterPageNamesDetails.PathSmallImage;
                    com.Parameters.Add("@PathImage", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(coreMasterPageNamesDetails.PathImage) ? DBNull.Value : (Object)coreMasterPageNamesDetails.PathImage;
                    com.Parameters.Add("@NameImage", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(coreMasterPageNamesDetails.NameImage) ? DBNull.Value : (Object)coreMasterPageNamesDetails.NameImage;
                    com.Parameters.Add("@RTL", SqlDbType.Int).Value = coreMasterPageNamesDetails.Rtl;
                    com.Parameters.Add("@DomainId", SqlDbType.Int).Value = coreMasterPageNamesDetails.DomainId;
                    com.Parameters.Add("@LanguageId", SqlDbType.Int).Value = coreMasterPageNamesDetails.LanguageId;
                    connection.Open();
                    Int32 result = ExecuteNonQuery(com);
                    return result == 1;
                }
            }
        }
        public override bool DeleteCoreMasterPageNames(int masterPageNameId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "DELETE FROM CoreMasterPageNames Where masterPageNameId = @masterPageNameId";
                    command.Parameters.Clear();
                    command.Parameters.Add("@MasterPageNameId", SqlDbType.Int).Value = masterPageNameId;
                    command.CommandType = CommandType.Text;
                    command.Connection = connection;
                    connection.Open();
                    Int32 result = ExecuteNonQuery(command);
                    return result == 1;
                }
            }
        }
        #endregion

        #region CoreUserControlPaths_PageContents(1)

        public override List<CoreUserControlPaths_PageContentsDetails> GetCoreUserControlPaths_PageContentsDetailsByPageContentId(Int32 pageContentId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = @"SELECT  CoreUserControlPaths.Path, CorePageContents.UserControlPathId, CorePageContents.CoreParameterId
                            FROM            CorePageContents INNER JOIN
                              CoreUserControlPaths ON CorePageContents.UserControlPathId = CoreUserControlPaths.UserControlPathId
                               WHERE        (CorePageContents.PageContentId = @PageContentId)";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@PageContentId", SqlDbType.Int).Value = pageContentId;
                    connection.Open();
                    return GetCoreUserControlPaths_PageContentsDetailsCollectionFromDataReader(ExecuteReader(command));
                }
            }
        }
        #endregion

        #region CoreMasterPageContents(1)

        public override List<CoreMasterPageContentsDetails> GetCoreMasterPageContentsByContentNameIdAndMasterPageNameId(Int32 contentNameId, Int32 masterPageNameId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = @"SELECT * FROM CoreMasterPageContents WHERE (CoreMasterPageContents.ContentNameId = @ContentNameId) AND (CoreMasterPageContents.MasterPageNameId = @MasterPageNameId)";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@ContentNameId", SqlDbType.Int).Value = contentNameId;
                    command.Parameters.Add("@MasterPageNameId", SqlDbType.Int).Value = masterPageNameId;
                    connection.Open();
                    return GetCoreMasterPageContentsDetailsCollectionFromDataReader(ExecuteReader(command));
                }
            }
        }

        public override int InsertCoreMasterPageContents(CoreMasterPageContentsDetails coreMasterPageContents)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand com = new SqlCommand();
                com.CommandText = "INSERT INTO CoreMasterPageContents (MasterPageNameId,ContentNameId,MasterPageContentName) VALUES (@MasterPageNameId,@ContentNameId,@MasterPageContentName) SELECT CAST(scope_identity() AS int)";
                com.Parameters.Add("@MasterPageNameId", SqlDbType.Int).Value = coreMasterPageContents.MasterPageNameId;
                com.Parameters.Add("@ContentNameId", SqlDbType.Int).Value = coreMasterPageContents.ContentNameId;
                com.Parameters.Add("@MasterPageContentName", SqlDbType.NVarChar).Value = coreMasterPageContents.MasterPageContentName;
                com.Parameters.Add("@DomainId", SqlDbType.Int).Value = coreMasterPageContents.DomainId;
                com.Parameters.Add("@LanguageId", SqlDbType.Int).Value = coreMasterPageContents.LanguageId;
                com.Connection = connection;
                connection.Open();
                int id = (int)com.ExecuteScalar();
                connection.Close();
                return id;
            }
        }

        public override Boolean UpdateCoreMasterPageContents(CoreMasterPageContentsDetails coreMasterPageContents)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand com = new SqlCommand("Update CoreMasterPageContents set MasterPageNameId=@MasterPageNameId,ContentNameId=@ContentNameId,MasterPageContentName=@MasterPageContentName where MasterPageContentId=@MasterPageContentId", connection))
                {
                    com.CommandType = CommandType.Text;
                    com.Parameters.Add("@MasterPageContentId", SqlDbType.Int).Value = coreMasterPageContents.MasterPageContentId;
                    com.Parameters.Add("@MasterPageNameId", SqlDbType.Int).Value = coreMasterPageContents.MasterPageNameId;
                    com.Parameters.Add("@ContentNameId", SqlDbType.Int).Value = coreMasterPageContents.ContentNameId;
                    com.Parameters.Add("@MasterPageContentName", SqlDbType.NVarChar).Value = coreMasterPageContents.MasterPageContentName;
                    com.Parameters.Add("@DomainId", SqlDbType.Int).Value = coreMasterPageContents.DomainId;
                    com.Parameters.Add("@LanguageId", SqlDbType.Int).Value = coreMasterPageContents.LanguageId;
                    connection.Open();
                    Int32 result = ExecuteNonQuery(com);
                    return result == 1;
                }
            }
        }

        public override bool DeleteCoreMasterPageContents(int masterPageContentId)
        {

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "DELETE FROM CoreMasterPageContents Where masterPageContentId = @masterPageContentId";
                   command.Parameters.Clear();
                    command.Parameters.Add("@masterPageContentId", SqlDbType.Int).Value = masterPageContentId;
                    command.CommandType = CommandType.Text;
                    command.Connection = connection;
                    connection.Open();
                    Int32 result = ExecuteNonQuery(command);
                    return result == 1;
                }
            }

        }


        #endregion

        #region CorePageContents(4)

        public override List<CorePageContentsDetails> GetCorePageContentsByPageId(Int32 pageId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = @"SELECT * from CorePageContents WHERE (PageId = @PageId) order by Priority";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@PageId", SqlDbType.Int).Value = pageId;
                    connection.Open();
                    return GetCorePageContentsDetailsCollectionFromDataReader(ExecuteReader(command));
                }
            }
        }

        public override int  InsertCorePageContents(Pine.Dal.Core.CorePageContentsDetails corePageContentsDetails)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand com = new SqlCommand();
                com.CommandText = "INSERT INTO CorePageContents (PageId,UserControlPathId,ContentNameId,CoreParameterId,Priority,IsStaticCantent) VALUES (@PageId,@UserControlPathId,@ContentNameId,@CoreParameterId,@Priority,@IsStaticCantent) SELECT CAST(scope_identity() AS int)";
                com.Parameters.Add("@PageId", SqlDbType.Int).Value = corePageContentsDetails.PageId;
                com.Parameters.Add("@UserControlPathId", SqlDbType.Int).Value = corePageContentsDetails.UserControlPathId;
                com.Parameters.Add("@ContentNameId", SqlDbType.Int).Value = corePageContentsDetails.ContentNameId;
                com.Parameters.Add("@CoreParameterId", SqlDbType.Int).Value = (object)corePageContentsDetails.CoreParameterId ?? DBNull.Value;
                com.Parameters.Add("@Priority", SqlDbType.TinyInt).Value = corePageContentsDetails.Priority;
                com.Parameters.Add("@IsStaticCantent", SqlDbType.Bit).Value = corePageContentsDetails.IsStaticCantent;
                com.Parameters.Add("@DomainId", SqlDbType.Int).Value = corePageContentsDetails.DomainId;
                com.Parameters.Add("@LanguageId", SqlDbType.Int).Value = corePageContentsDetails.LanguageId;
                com.Connection = connection;
                connection.Open();
                int id = (int)com.ExecuteScalar();
                connection.Close();
                return id;
            }
        }

        public override Boolean UpdateCorePageContents(Pine.Dal.Core.CorePageContentsDetails corePageContentsDetails)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand com = new SqlCommand("Update CorePageContents set PageId=@PageId,UserControlPathId=@UserControlPathId,ContentNameId=@ContentNameId,Priority=@Priority,IsStaticCantent=@IsStaticCantent  where PageContentId=@PageContentId", connection))
                {
                    com.CommandType = CommandType.Text;
                    com.Parameters.Add("@PageContentId", SqlDbType.Int).Value = corePageContentsDetails.PageContentId;
                    com.Parameters.Add("@PageId", SqlDbType.Int).Value = corePageContentsDetails.PageId;
                    com.Parameters.Add("@UserControlPathId", SqlDbType.Int).Value = corePageContentsDetails.UserControlPathId;
                    com.Parameters.Add("@ContentNameId", SqlDbType.Int).Value = corePageContentsDetails.ContentNameId;
                    com.Parameters.Add("@CoreParameterId", SqlDbType.Int).Value = (object)corePageContentsDetails.CoreParameterId ?? DBNull.Value;
                    com.Parameters.Add("@Priority", SqlDbType.TinyInt).Value = corePageContentsDetails.Priority;
                    com.Parameters.Add("@IsStaticCantent", SqlDbType.Bit).Value = corePageContentsDetails.IsStaticCantent;
                    com.Parameters.Add("@DomainId", SqlDbType.Int).Value = corePageContentsDetails.DomainId;
                    com.Parameters.Add("@LanguageId", SqlDbType.Int).Value = corePageContentsDetails.LanguageId;
                    connection.Open();
                    Int32 result = ExecuteNonQuery(com);
                    return result == 1;
                }
            }
        }

        public override Boolean DeleteCorePageContents(int pageContentId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "DELETE FROM CorePageContents Where PageContentId = @PageContentId";
                   command.Parameters.Clear();
                    command.Parameters.Add("@PageContentId", SqlDbType.Int).Value = pageContentId;
                    command.CommandType = CommandType.Text;
                    command.Connection = connection;
                    connection.Open();
                    Int32 result = ExecuteNonQuery(command);
                    return result == 1;
                }
            }
        }

        #endregion

        #region CoreMasterPageNamesCorePages (3)

        public override CoreMasterPageNamesCorePagesDetails GetCoreMasterPageNamesCorePages()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = @"SELECT top(1) CoreMasterPageNames.ThemeName FROM  CorePages LEFT OUTER JOIN CoreMasterPageNames
                            ON CorePages.MasterPageNameId =  CoreMasterPageNames.MasterPageNameId";
                                                   
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    IDataReader reader = ExecuteReader(command, CommandBehavior.SingleRow);

                    if (reader.Read())
                        return GetCoreMasterPageNamesCorePagesDetailsFromDataReader(reader);
                    return null;
                    
                }
            }
        }

      
        public override CoreMasterPageNamesCorePagesDetails GetCoreMasterPageNamesCorePagesByIsDefault()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = @"SELECT CoreMasterPageNames.ThemeName, CorePages.PageId, CoreMasterPageNames.Path, CoreMasterPageNames.MasterPageNameId
                            FROM CoreMasterPageNames INNER JOIN
                         CorePages ON CoreMasterPageNames.MasterPageNameId = CorePages.MasterPageNameId
                            WHERE  (CorePages.IsDefault = 1)";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;

                    connection.Open();


                    IDataReader reader = ExecuteReader(command, CommandBehavior.SingleRow);

                    if (reader.Read())
                        return GetCoreMasterPageNamesCorePagesDetailsFromDataReader(reader);
                    return null;
                   // return GetCoreMasterPageNamesCorePagesDetailsCollectionFromDataReader(ExecuteReader(command));
                }
            }
        }

        public override List<CoreMasterPageNamesCorePagesDetails> GetCoreMasterPageNamesCorePagesByPageId(Int32 pageId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = @"SELECT  CoreMasterPageNames.ThemeName, CorePages.PageId, CoreMasterPageNames.Path, CoreMasterPageNames.MasterPageNameId
                             FROM CorePages INNER JOIN CoreMasterPageNames ON CorePages.MasterPageNameId = CoreMasterPageNames.MasterPageNameId
                             WHERE (CorePages.PageId = @PageId)";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@PageId", SqlDbType.Int).Value = pageId;
                    connection.Open();
                    return GetCoreMasterPageNamesCorePagesDetailsCollectionFromDataReader(ExecuteReader(command));
                }
            }
        }

        #endregion
     
        #region CoreAccess

        public override int InsertCoreAccess(CoreAccessDetails coreAccessDetails)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand com = new SqlCommand();
                com.CommandText = "INSERT INTO CoreAccess (userControlPathId,userName,useManager,languageId,domainId) VALUES (@userControlPathId,@userName,@useManager,@languageId,@domainId) SELECT CAST(scope_identity() AS int)";
                com.Parameters.Add("@userControlPathId", SqlDbType.Int).Value = coreAccessDetails.UserControlPathId;
                com.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = coreAccessDetails.UserName;
                com.Parameters.Add("@useManager", SqlDbType.Bit).Value = coreAccessDetails.UseManager;
                com.Parameters.Add("@languageId", SqlDbType.Int).Value = coreAccessDetails.LanguageId;
                com.Parameters.Add("@domainId", SqlDbType.Int).Value = coreAccessDetails.DomainId;
                com.Connection = connection;
                connection.Open();
                int id = (int)com.ExecuteScalar();
                connection.Close();
                return id;
            }
        }
      
        public override Boolean UpdateCoreAccess(CoreAccessDetails coreAccessDetails)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand com = new SqlCommand("Update CoreAccess set userControlPathId=@userControlPathId,userName=@userName,useManager=@useManager,languageId=@languageId,domainId=@domainId  where accessId=@accessId", connection))
                {
                    com.CommandType = CommandType.Text;
                    com.Parameters.Add("@accessId", SqlDbType.Int).Value = coreAccessDetails.AccessId;
                    com.Parameters.Add("@userControlPathId", SqlDbType.Int).Value = coreAccessDetails.UserControlPathId;
                    com.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = coreAccessDetails.UserName;
                    com.Parameters.Add("@useManager", SqlDbType.Bit).Value = coreAccessDetails.UseManager;
                    com.Parameters.Add("@languageId", SqlDbType.Int).Value = coreAccessDetails.LanguageId;
                    com.Parameters.Add("@domainId", SqlDbType.Int).Value = coreAccessDetails.DomainId;
                    connection.Open();
                    Int32 result = ExecuteNonQuery(com);
                    return result == 1;
                }
            }
        }

        public override Boolean DeleteCoreAccess(int accessId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "DELETE FROM CoreAccess Where accessId = @accessId";
                    command.Parameters.Clear();
                    command.Parameters.Add("@accessId", SqlDbType.Int).Value = accessId;
                    command.Connection = connection;
                    connection.Open();
                    Int32 result = ExecuteNonQuery(command);
                    return result == 1;
                }
            }
        }


        #endregion 

        #region CoreAccessPage

        public override int InsertCoreAccessPage(CoreAccessPageDetails coreAccessPageDetails)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand com = new SqlCommand();
                com.CommandText = "INSERT INTO CoreAccessPage (MasterPageNameId,Username,useManager,languageId,domainId) VALUES (@MasterPageNameId,@Username,@useManager,@languageId,@domainId) SELECT CAST(scope_identity() AS int)";
                com.Parameters.Add("@MasterPageNameId", SqlDbType.Int).Value = (object)coreAccessPageDetails.MasterPageNameId ?? DBNull.Value;
                com.Parameters.Add("@Username", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(coreAccessPageDetails.Username) ? DBNull.Value : (object)coreAccessPageDetails.Username;
                com.Parameters.Add("@useManager", SqlDbType.Bit).Value = coreAccessPageDetails.UseManager;
                com.Parameters.Add("@LanguageId", SqlDbType.Int).Value = coreAccessPageDetails.LanguageId;
                com.Parameters.Add("@domainId", SqlDbType.Int).Value = coreAccessPageDetails.DomainId;
                com.Connection = connection;
                connection.Open();
                int id = (int)com.ExecuteScalar();
                connection.Close();
                return id;
            }
        }

        public override Boolean UpdateCoreAccessPage(CoreAccessPageDetails coreAccessPageDetails)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand com = new SqlCommand("Update CoreAccessPage set MasterPageNameId=@MasterPageNameId,Username=@Username,useManager=@useManager,languageId=@languageId,domainId=@domainId where AccessPageId=@AccessPageId", connection))
                {
                    com.CommandType = CommandType.Text;
                    com.Parameters.Add("@AccessPageId", SqlDbType.Int).Value = coreAccessPageDetails.AccessPageId;
                    com.Parameters.Add("@MasterPageNameId", SqlDbType.Int).Value = (object)coreAccessPageDetails.MasterPageNameId ?? DBNull.Value;
                    com.Parameters.Add("@Username", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(coreAccessPageDetails.Username) ? DBNull.Value : (object)coreAccessPageDetails.Username;
                    com.Parameters.Add("@useManager", SqlDbType.Bit).Value = coreAccessPageDetails.UseManager;
                    com.Parameters.Add("@LanguageId", SqlDbType.Int).Value = coreAccessPageDetails.LanguageId;
                    com.Parameters.Add("@domainId", SqlDbType.Int).Value = coreAccessPageDetails.DomainId;
                    connection.Open();
                    Int32 result = ExecuteNonQuery(com);
                    return result == 1;
                }
            }
        }

        public override Boolean DeleteCoreAccessPage(int accessPageId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "DELETE FROM CoreAccessPage Where AccessPageId = @accessPageId";
                    command.Parameters.Clear();
                    command.Parameters.Add("@accessPageId", SqlDbType.Int).Value = accessPageId;
                    command.CommandType = CommandType.Text;
                    command.Connection = connection;
                    connection.Open();
                    Int32 result = ExecuteNonQuery(command);
                    return result == 1;
                }
            }
        }

        #endregion

        #region CoreContentNames
        public override int InsertCoreContentNames(CoreContentNamesDetails coreContentNamesDetails)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand com = new SqlCommand();
                com.CommandText = "INSERT INTO CoreContentNames (Position,NameFarsi,DomainId,LanguageId) values (@Position,@NameFarsi,@DomainId,@LanguageId) SELECT CAST(scope_identity() AS int)";
                com.Parameters.Add("@Position", SqlDbType.NVarChar).Value = coreContentNamesDetails.Position;
                com.Parameters.Add("@NameFarsi", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(coreContentNamesDetails.NameFarsi) ? DBNull.Value : (object)coreContentNamesDetails.NameFarsi;
                com.Parameters.Add("@DomainId", SqlDbType.Int).Value = coreContentNamesDetails.DomainId;
                com.Parameters.Add("@LanguageId", SqlDbType.Int).Value = coreContentNamesDetails.LanguageId;
                com.Connection = connection;
                connection.Open();
                int id = (int)com.ExecuteScalar();
                connection.Close();
                return id;
            }
        }
            public override Boolean UpdateCoreContentNames(CoreContentNamesDetails coreContentNamesDetails)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand com = new SqlCommand("Update CoreContentNames set Position=@Position,NameFarsi=@NameFarsi,DomainId=@DomainId,languageId=@languageId where ContentNameId=@ContentNameId", connection))
                {
                    com.CommandType = CommandType.Text;
                    com.Parameters.Add("@Position", SqlDbType.NVarChar).Value = coreContentNamesDetails.Position;
                    com.Parameters.Add("@NameFarsi", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(coreContentNamesDetails.NameFarsi) ? DBNull.Value : (object)coreContentNamesDetails.NameFarsi;
                    com.Parameters.Add("@DomainId", SqlDbType.Int).Value = coreContentNamesDetails.DomainId;
                    com.Parameters.Add("@LanguageId", SqlDbType.Int).Value = coreContentNamesDetails.LanguageId;
                    com.Parameters.Add("@ContentNameId", SqlDbType.Int).Value = coreContentNamesDetails.ContentNameId;
                    connection.Open();
                    Int32 result = ExecuteNonQuery(com);
                    return result == 1;
                }
            }
        }

            public override Boolean DeleteCoreContentNames(int contentNameId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "DELETE FROM CoreContentNames Where ContentNameId = @ContentNameId";
                    command.Parameters.Clear();
                    command.Parameters.Add("@ContentNameId", SqlDbType.Int).Value = contentNameId;
                    command.CommandType = CommandType.Text;
                    command.Connection = connection;
                    connection.Open();
                    Int32 result = ExecuteNonQuery(command);
                    return result == 1;
                }
            }
        }
        #endregion 

        #region CoreDomains
            public override int InsertCoreDomains(CoreDomainsDetails coreDomainsDetails)
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    SqlCommand com = new SqlCommand();
                    com.CommandText = "INSERT INTO CoreDomains (DomainName,DomainTheme,EnterDate,LanguageId) values (@DomainName,@DomainTheme,@EnterDate,@LanguageId) SELECT CAST(scope_identity() AS int)";
                    com.Parameters.Add("@DomainName", SqlDbType.NVarChar).Value = coreDomainsDetails.DomainName;
                    com.Parameters.Add("@DomainTheme", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(coreDomainsDetails.DomainTheme) ? DBNull.Value : (object)coreDomainsDetails.DomainTheme;
                    com.Parameters.Add("@EnterDate", SqlDbType.DateTime).Value = (object)coreDomainsDetails.EnterDate ?? DBNull.Value;
                    com.Parameters.Add("@LanguageId", SqlDbType.Int).Value = coreDomainsDetails.LanguageId;
                    com.Connection = connection;
                    connection.Open();
                    int id = (int)com.ExecuteScalar();
                    connection.Close();
                    return id;
                }
            }
            public override Boolean UpdateCoreDomains(CoreDomainsDetails coreDomainsDetails)
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand com = new SqlCommand("Update CoreDomains set DomainName=@DomainName,DomainTheme=@DomainTheme,EnterDate=@EnterDate,languageId=@languageId where DomainId=@DomainId", connection))
                    {
                        com.CommandType = CommandType.Text;
                        com.Parameters.Add("@DomainName", SqlDbType.NVarChar).Value = coreDomainsDetails.DomainName;
                        com.Parameters.Add("@DomainTheme", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(coreDomainsDetails.DomainTheme) ? DBNull.Value : (object)coreDomainsDetails.DomainTheme;
                        com.Parameters.Add("@EnterDate", SqlDbType.DateTime).Value = (object)coreDomainsDetails.EnterDate ?? DBNull.Value;
                        com.Parameters.Add("@LanguageId", SqlDbType.Int).Value = coreDomainsDetails.LanguageId;
                        com.Parameters.Add("@DomainId", SqlDbType.Int).Value = coreDomainsDetails.DomainId;
                        connection.Open();
                        Int32 result = ExecuteNonQuery(com);
                        return result == 1;
                    }
                }
            }

            public override Boolean DeleteCoreDomains(int domainId)
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.CommandText = "DELETE FROM CoreDomains Where DomainId = @domainId";
                        command.Parameters.Clear();
                        command.Parameters.Add("@domainId", SqlDbType.Int).Value = domainId;
                        command.CommandType = CommandType.Text;
                        command.Connection = connection;
                        connection.Open();
                        Int32 result = ExecuteNonQuery(command);
                        return result == 1;
                    }
                }
            }

        #endregion

        #region CoreLocationPageContent
            public override int InsertCoreLocationPageContent(CoreLocationPageContentDetails coreLocationPageContentDetails)
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    SqlCommand com = new SqlCommand();
                    com.CommandText = "INSERT INTO CoreLocationPageContent (UserControlPathId,ContentNameId,CoreParameterId,Priority,DomainId,LanguageId) values (@UserControlPathId,@ContentNameId,@CoreParameterId,@Priority,@DomainId,@LanguageId) SELECT CAST(scope_identity() AS int)";
                    com.Parameters.Add("@UserControlPathId", SqlDbType.Int).Value = coreLocationPageContentDetails.CoreParameterId;
                    com.Parameters.Add("@ContentNameId", SqlDbType.Int).Value = coreLocationPageContentDetails.CoreParameterId;
                    com.Parameters.Add("@CoreParameterId", SqlDbType.Int).Value = (object)coreLocationPageContentDetails.CoreParameterId ?? DBNull.Value;
                    com.Parameters.Add("@Priority", SqlDbType.TinyInt).Value = coreLocationPageContentDetails.Priority;
                    com.Parameters.Add("@DomainId", SqlDbType.Int).Value = coreLocationPageContentDetails.DomainId;
                    com.Parameters.Add("@LanguageId", SqlDbType.Int).Value = coreLocationPageContentDetails.LanguageId;
                    com.Connection = connection;
                    connection.Open();
                    int id = (int)com.ExecuteScalar();
                    connection.Close();
                    return id;
                }
            }
            public override Boolean UpdateCoreLocationPageContent(CoreLocationPageContentDetails coreLocationPageContentDetails)
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand com = new SqlCommand("Update CoreLocationPageContent set UserControlPathId=@UserControlPathId,ContentNameId=@ContentNameId,CoreParameterId=@CoreParameterId,Priority=@Priority,DomainId=@DomainId,languageId=@languageId where CoreLocationPageContentId=@CoreLocationPageContentId", connection))
                    {
                        com.CommandType = CommandType.Text;
                        com.Parameters.Add("@CoreLocationPageContentId", SqlDbType.Int).Value = coreLocationPageContentDetails.CoreLocationPageContentId;
                        com.Parameters.Add("@UserControlPathId", SqlDbType.Int).Value = coreLocationPageContentDetails.UserControlPathId;
                        com.Parameters.Add("@ContentNameId", SqlDbType.Int).Value = coreLocationPageContentDetails.ContentNameId;
                        com.Parameters.Add("@CoreParameterId", SqlDbType.Int).Value = (object)coreLocationPageContentDetails.CoreParameterId ?? DBNull.Value;
                        com.Parameters.Add("@Priority", SqlDbType.TinyInt).Value = coreLocationPageContentDetails.Priority;
                        com.Parameters.Add("@DomainId", SqlDbType.Int).Value = coreLocationPageContentDetails.DomainId;
                        com.Parameters.Add("@LanguageId", SqlDbType.Int).Value = coreLocationPageContentDetails.LanguageId;
                        connection.Open();
                        Int32 result = ExecuteNonQuery(com);
                        return result == 1;
                    }
                }
            }

            public override Boolean DeleteCoreLocationPageContent(int coreLocationPageContentId)
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.CommandText = "DELETE FROM CoreLocationPageContent Where CoreLocationPageContentId = @CoreLocationPageContentId";
                        command.Parameters.Clear();
                        command.Parameters.Add("@coreLocationPageContentId", SqlDbType.Int).Value = coreLocationPageContentId;
                        command.CommandType = CommandType.Text;
                        command.Connection = connection;
                        connection.Open();
                        Int32 result = ExecuteNonQuery(command);
                        return result == 1;
                    }
                }
            }
            #endregion

        #region CoreMasterPageGroupName
            public override int InsertCoreMasterPageGroupName(CoreMasterPageGroupNameDetails coreMasterPageGroupName)
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    SqlCommand com = new SqlCommand();
                    com.CommandText = "INSERT INTO CoreMasterPageGroupName (Name,DomainId,LanguageId) values (@Name,@DomainId,@LanguageId) SELECT CAST(scope_identity() AS int)";
                    com.Parameters.Add("@Name", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(coreMasterPageGroupName.Name) ? DBNull.Value : (object)coreMasterPageGroupName.Name;
                    com.Parameters.Add("@DomainId", SqlDbType.Int).Value = coreMasterPageGroupName.DomainId;
                    com.Parameters.Add("@LanguageId", SqlDbType.Int).Value = coreMasterPageGroupName.LanguageId;
                    com.Connection = connection;
                    connection.Open();
                    int id = (int)com.ExecuteScalar();
                    connection.Close();
                    return id;
                }
            }
            public override Boolean UpdateCoreMasterPageGroupName(CoreMasterPageGroupNameDetails coreMasterPageGroupName)
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand com = new SqlCommand("Update CoreMasterPageGroupName set Name=@Name,DomainId=@DomainId,languageId=@languageId where MasterPageGroupNameId=@MasterPageGroupNameId", connection))
                    {
                        com.CommandType = CommandType.Text;
                        com.Parameters.Add("@MasterPageGroupNameId", SqlDbType.Int).Value = coreMasterPageGroupName.MasterPageGroupNameId;
                        com.Parameters.Add("@Name", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(coreMasterPageGroupName.Name) ? DBNull.Value : (object)coreMasterPageGroupName.Name;
                        com.Parameters.Add("@LanguageId", SqlDbType.Int).Value = coreMasterPageGroupName.LanguageId;
                        com.Parameters.Add("@DomainId", SqlDbType.Int).Value = coreMasterPageGroupName.DomainId;
                        connection.Open();
                        Int32 result = ExecuteNonQuery(com);
                        return result == 1;
                    }
                }
            }

            public override Boolean DeleteCoreMasterPageGroupName(int masterPageGroupNameId)
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.CommandText = "DELETE FROM CoreMasterPageGroupName Where masterPageGroupNameId = @masterPageGroupNameId";
                        command.Parameters.Clear();
                        command.Parameters.Add("@masterPageGroupNameId", SqlDbType.Int).Value = masterPageGroupNameId;
                        command.CommandType = CommandType.Text;
                        command.Connection = connection;
                        connection.Open();
                        Int32 result = ExecuteNonQuery(command);
                        return result == 1;
                    }
                }
            }
        #endregion

        #region CorePages

            public override List<CorePagesDetails> GetCorePages()
            {

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.CommandText = "select TOP(1) * from CorePages";
                        command.Connection = connection;
                        command.CommandType = CommandType.Text;
                        connection.Open();
                        return GetCorePagesDetailsCollectionFromDataReader(ExecuteReader(command));
                    }
                }
            }

            public override int InsertCorePages(Pine.Dal.Core.CorePagesDetails corePages)
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    SqlCommand com = new SqlCommand();
                    com.CommandText = "INSERT INTO CorePages (MasterPageNameId,IsDefault,PageName,DomainId,LanguageId) values (@MasterPageNameId,@IsDefault,@PageName,@DomainId,@LanguageId) SELECT CAST(scope_identity() AS int)";
                    com.Parameters.Add("@MasterPageNameId", SqlDbType.Int).Value = corePages.MasterPageNameId;
                    com.Parameters.Add("@IsDefault", SqlDbType.Bit).Value = corePages.IsDefault;
                    com.Parameters.Add("@PageName", SqlDbType.NVarChar).Value = corePages.PageName;
                    com.Parameters.Add("@DomainId", SqlDbType.Int).Value = corePages.DomainId;
                    com.Parameters.Add("@LanguageId", SqlDbType.Int).Value = corePages.LanguageId;
                    com.Connection = connection;
                    connection.Open();
                    int id = (int)com.ExecuteScalar();
                    connection.Close();
                    return id;
                }
            }

            public override bool UpdateCorePages(CorePagesDetails corePages)
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand com = new SqlCommand("Update CorePages set MasterPageNameId=@MasterPageNameId,IsDefault=@IsDefault,PageName=@PageName,DomainId=@DomainId,languageId=@languageId where PageId=@PageId", connection))
                    {
                        com.CommandType = CommandType.Text;
                        com.Parameters.Add("@PageId", SqlDbType.Int).Value = corePages.PageId;
                        com.Parameters.Add("@MasterPageNameId", SqlDbType.Int).Value = corePages.MasterPageNameId;
                        com.Parameters.Add("@IsDefault", SqlDbType.Bit).Value = corePages.IsDefault;
                        com.Parameters.Add("@PageName", SqlDbType.NVarChar).Value = corePages.PageName;
                        com.Parameters.Add("@DomainId", SqlDbType.Int).Value = corePages.DomainId;
                        com.Parameters.Add("@LanguageId", SqlDbType.Int).Value = corePages.LanguageId;
                        com.Connection = connection;
                        connection.Open();
                        Int32 result = ExecuteNonQuery(com);
                        return result == 1;
                    }
                }
            }

            public override bool DeleteCorePages(int pageId)
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.CommandText = "DELETE FROM CorePages Where PageId = @PageId";
                        command.Parameters.Clear();
                        command.Parameters.Add("@PageId", SqlDbType.Int).Value = pageId;
                        command.CommandType = CommandType.Text;
                        command.Connection = connection;
                        connection.Open();
                        Int32 result = ExecuteNonQuery(command);
                        return result == 1;
                    }
                }
            }
        #endregion

        #region CoreThemeMiddleSetting
            public override int InsertCoreThemeMiddleSetting(Pine.Dal.Core.CoreThemeMiddleSettingDetails coreThemeMiddleSetting)
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    SqlCommand com = new SqlCommand();
                    com.CommandText = "INSERT INTO CoreThemeMiddelSetting (MasterPageNameId,ThemeSettingId) values (@MasterPageNameId,@ThemeSettingId)";
                    com.Parameters.Add("@MasterPageNameId", SqlDbType.Int).Value = coreThemeMiddleSetting.MasterPageNameId;
                    com.Parameters.Add("@ThemeSettingId", SqlDbType.Int).Value = coreThemeMiddleSetting.ThemeSettingId;
                    com.Connection = connection;
                    connection.Open();
                    int id = ExecuteNonQuery(com);
                    connection.Close();
                    return id;
                }
            }

            public override bool UpdateCoreThemeMiddleSetting(CoreThemeMiddleSettingDetails coreThemeMiddleSetting)
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand com = new SqlCommand("Update CoreThemeMiddelSetting set MasterPageNameId=@MasterPageNameId,ThemeSettingId=@ThemeSettingId where MasterPageNameId=@MasterPageNameId and ThemeSettingId=@ThemeSettingId", connection))
                    {
                        com.CommandType = CommandType.Text;
                        com.Parameters.Add("@MasterPageNameId", SqlDbType.Int).Value = coreThemeMiddleSetting.MasterPageNameId;
                        com.Parameters.Add("@ThemeSettingId", SqlDbType.Int).Value = coreThemeMiddleSetting.ThemeSettingId;
                       
                        com.Connection = connection;
                        connection.Open();
                        Int32 result = ExecuteNonQuery(com);
                        return result == 1;
                    }
                }
            }
            public override bool DeleteCoreThemeMiddleSetting(int masterPageNameId, int themeSettingId)
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.CommandText = "DELETE FROM CoreThemeMiddelSetting Where masterPageNameId = @masterPageNameId and themeSettingId = @themeSettingId";
                        command.Parameters.Clear();
                        command.Parameters.Add("@MasterPageNameId", SqlDbType.Int).Value = masterPageNameId;
                        command.Parameters.Add("@ThemeSettingId", SqlDbType.Int).Value = themeSettingId;
                        command.CommandType = CommandType.Text;
                        command.Connection = connection;
                        connection.Open();
                        Int32 result = ExecuteNonQuery(command);
                        return result == 1;
                    }
                }
            }
       #endregion

        #region CoreThemeSettingChild 

      public override List<CoreThemeSettingChildDetails> GetCoreThemeSettingChildByThemeSettingId(Int32 themeSettingId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "select * From CoreThemeSettingChild where ThemeSettingId=@ThemeSettingId";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@themeSettingId", SqlDbType.Int).Value = themeSettingId;
                    connection.Open();
                    return GetCoreThemeSettingChildDetailsCollectionFromDataReader(ExecuteReader(command));
                }
            }

        }


        public override CoreThemeSettingChildDetails GetCoreThemeSettingChild(Int32 themeSettingChildId)
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.CommandText = "select * from CoreThemeSettingChild where ThemeSettingChildId=@ThemeSettingChildId";
                        command.Connection = connection;
                        command.CommandType = CommandType.Text;
                        command.Parameters.Add("@ThemeSettingChildId", SqlDbType.Int).Value = themeSettingChildId;
                        connection.Open();

                        IDataReader reader = ExecuteReader(command, CommandBehavior.SingleRow);

                        if (reader.Read())
                            return GetCoreThemeSettingChildDetailsFromDataReader(reader);
                        return null;
                        //return GetCoreThemeSettingDetailsCollectionFromDataReader(ExecuteReader(command));
                    }
                }

            }

            public override int InsertCoreThemeSettingChild(Pine.Dal.Core.CoreThemeSettingChildDetails coreThemeSettingChildDetails)
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    SqlCommand com = new SqlCommand();
                    com.CommandText = "INSERT INTO CoreThemeSettingChild (ThemeSettingId,Value1,Value2,Value3,Value4,Value5,Value6,Value7,Parameter,DomainId,LanguageId) VALUES (@ThemeSettingId,@Value1,@Value2,@Value3,@Value4,@Value5,@Value6,@Value7,@Parameter,@DomainId,@LanguageId) SELECT CAST(scope_identity() AS int)";
                    com.Parameters.Add("@ThemeSettingId", SqlDbType.Int).Value = coreThemeSettingChildDetails.ThemeSettingId;
                    com.Parameters.Add("@Value1", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(coreThemeSettingChildDetails.Value1) ? DBNull.Value : (Object)coreThemeSettingChildDetails.Value1;
                    com.Parameters.Add("@Value2", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(coreThemeSettingChildDetails.Value2) ? DBNull.Value : (Object)coreThemeSettingChildDetails.Value2;
                    com.Parameters.Add("@Value3", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(coreThemeSettingChildDetails.Value3) ? DBNull.Value : (Object)coreThemeSettingChildDetails.Value3;
                    com.Parameters.Add("@Value4", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(coreThemeSettingChildDetails.Value4) ? DBNull.Value : (Object)coreThemeSettingChildDetails.Value4;
                    com.Parameters.Add("@Value5", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(coreThemeSettingChildDetails.Value5) ? DBNull.Value : (Object)coreThemeSettingChildDetails.Value5;
                    com.Parameters.Add("@Value6", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(coreThemeSettingChildDetails.Value6) ? DBNull.Value : (Object)coreThemeSettingChildDetails.Value6;
                    com.Parameters.Add("@Value7", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(coreThemeSettingChildDetails.Value7) ? DBNull.Value : (Object)coreThemeSettingChildDetails.Value7;
                    com.Parameters.Add("@Parameter", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(coreThemeSettingChildDetails.Parameter) ? DBNull.Value : (Object)coreThemeSettingChildDetails.Parameter;
                    com.Parameters.Add("@DomainId", SqlDbType.Int).Value = coreThemeSettingChildDetails.DomainId;
                    com.Parameters.Add("@LanguageId", SqlDbType.Int).Value = coreThemeSettingChildDetails.LanguageId;
                    com.Connection = connection;
                    connection.Open();
                    int id = (int)com.ExecuteScalar();
                    connection.Close();
                    return id;
                }
            }

            public override bool UpdateCoreThemeSettingChild(CoreThemeSettingChildDetails coreThemeSettingChildDetails)
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand com = new SqlCommand("Update CoreThemeSettingChild set ThemeSettingId=@ThemeSettingId,Value1=@Value1,Value2=@Value2,Value3=@Value3,Value4=@Value4,Value5=@Value5,Value6=@Value6,Value7=@Value7,parameter=@parameter,DomainId = @DomainId ,LanguageId = @LanguageId  where ThemeSettingChildId = @ThemeSettingChildId", connection))
                    {
                        com.CommandType = CommandType.Text;
                        com.Parameters.Add("@ThemeSettingChildId", SqlDbType.Int).Value = coreThemeSettingChildDetails.ThemeSettingChildId;
                        com.Parameters.Add("@ThemeSettingId", SqlDbType.Int).Value = coreThemeSettingChildDetails.ThemeSettingId;
                        com.Parameters.Add("@Value1", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(coreThemeSettingChildDetails.Value1) ? DBNull.Value : (Object)coreThemeSettingChildDetails.Value1;
                        com.Parameters.Add("@Value2", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(coreThemeSettingChildDetails.Value2) ? DBNull.Value : (Object)coreThemeSettingChildDetails.Value2;
                        com.Parameters.Add("@Value3", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(coreThemeSettingChildDetails.Value3) ? DBNull.Value : (Object)coreThemeSettingChildDetails.Value3;
                        com.Parameters.Add("@Value4", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(coreThemeSettingChildDetails.Value4) ? DBNull.Value : (Object)coreThemeSettingChildDetails.Value4;
                        com.Parameters.Add("@Value5", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(coreThemeSettingChildDetails.Value5) ? DBNull.Value : (Object)coreThemeSettingChildDetails.Value5;
                        com.Parameters.Add("@Value6", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(coreThemeSettingChildDetails.Value6) ? DBNull.Value : (Object)coreThemeSettingChildDetails.Value6;
                        com.Parameters.Add("@Value7", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(coreThemeSettingChildDetails.Value7) ? DBNull.Value : (Object)coreThemeSettingChildDetails.Value7;
                        com.Parameters.Add("@Parameter", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(coreThemeSettingChildDetails.Parameter) ? DBNull.Value : (Object)coreThemeSettingChildDetails.Parameter;
                        com.Parameters.Add("@DomainId", SqlDbType.Int).Value = coreThemeSettingChildDetails.DomainId;
                        com.Parameters.Add("@LanguageId", SqlDbType.Int).Value = coreThemeSettingChildDetails.LanguageId;
                        connection.Open();
                        Int32 result = ExecuteNonQuery(com);
                        return result == 1;
                    }
                }
            }

            public override bool DeleteCoreThemeSettingChild(int themeSettingChildId)
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.CommandText = "DELETE FROM CoreThemeSettingChild Where ThemeSettingChildId = @ThemeSettingChildId";
                        command.Parameters.Clear();
                        command.Parameters.Add("@ThemeSettingChildId", SqlDbType.Int).Value = themeSettingChildId;
                        command.CommandType = CommandType.Text;
                        command.Connection = connection;
                        connection.Open();
                        Int32 result = ExecuteNonQuery(command);
                        return result == 1;
                    }
                }
            }
            #endregion

        #region CoreThemeSettingType
            public override int InsertCoreThemeSettingType(Pine.Dal.Core.CoreThemeSettingTypeDetails coreThemeSettingType)
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    SqlCommand com = new SqlCommand();
                    com.CommandText = "INSERT INTO CoreThemeSettingType (Parameter,Name,DomainId,LanguageId) VALUES (@Parameter,@Name,@DomainId,@LanguageId) SELECT CAST(scope_identity() AS int)";
                    com.Parameters.Add("@Parameter", SqlDbType.NVarChar).Value = coreThemeSettingType.Parameter;
                    com.Parameters.Add("@Name", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(coreThemeSettingType.Name) ? DBNull.Value : (Object)coreThemeSettingType.Name;
                    com.Parameters.Add("@DomainId", SqlDbType.Int).Value = coreThemeSettingType.DomainId;
                    com.Parameters.Add("@LanguageId", SqlDbType.Int).Value = coreThemeSettingType.LanguageId;
                    com.Connection = connection;
                    connection.Open();
                    int id = (int)com.ExecuteScalar();
                    connection.Close();
                    return id;
                }
            }

            public override bool UpdateCoreThemeSettingType(CoreThemeSettingTypeDetails coreThemeSettingType)
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand com = new SqlCommand("Update CoreThemeSettingType set Parameter=@Parameter,Name=@Name,DomainId = @DomainId ,LanguageId = @LanguageId  where ThemeSettingTypeId=@ThemeSettingTypeId", connection))
                    {
                        com.CommandType = CommandType.Text;
                        com.Parameters.Add("@ThemeSettingTypeId", SqlDbType.Int).Value = coreThemeSettingType.ThemeSettingTypeId;
                        com.Parameters.Add("@Parameter", SqlDbType.NVarChar).Value = coreThemeSettingType.Parameter;
                        com.Parameters.Add("@Name", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(coreThemeSettingType.Name) ? DBNull.Value : (Object)coreThemeSettingType.Name;
                        com.Parameters.Add("@DomainId", SqlDbType.Int).Value = coreThemeSettingType.DomainId;
                        com.Parameters.Add("@LanguageId", SqlDbType.Int).Value = coreThemeSettingType.LanguageId;
                        connection.Open();
                        Int32 result = ExecuteNonQuery(com);
                        return result == 1;
                    }
                }
            }

            public override bool DeleteCoreThemeSettingType(int ThemeSettingTypeId)
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.CommandText = "DELETE FROM CoreThemeSettingType Where ThemeSettingTypeId=@ThemeSettingTypeId";
                        command.Parameters.Clear();
                        command.Parameters.Add("@ThemeSettingTypeId", SqlDbType.Int).Value = ThemeSettingTypeId;
                        command.CommandType = CommandType.Text;
                        command.Connection = connection;
                        connection.Open();
                        Int32 result = ExecuteNonQuery(command);
                        return result == 1;
                    }
                }
            }
        #endregion

        #region CoreUserControlNames
            public override int InsertCoreUserControlNames(Pine.Dal.Core.CoreUserControlNamesDetails coreUserControlNames)
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    SqlCommand com = new SqlCommand();
                    com.CommandText = "INSERT INTO CoreUserControlNames (UserControlName,DomainId,LanguageId) VALUES (@UserControlName,@DomainId,@LanguageId) SELECT CAST(scope_identity() AS int)";
                    com.Parameters.Add("@UserControlName", SqlDbType.NVarChar).Value = coreUserControlNames.UserControlName;
                    com.Parameters.Add("@DomainId", SqlDbType.Int).Value = coreUserControlNames.DomainId;
                    com.Parameters.Add("@LanguageId", SqlDbType.Int).Value = coreUserControlNames.LanguageId;
                    com.Connection = connection;
                    connection.Open();
                    int id = (int)com.ExecuteScalar();
                    connection.Close();
                    return id;
                }
            }

            public override bool UpdateCoreUserControlNames(CoreUserControlNamesDetails coreUserControlNames)
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand com = new SqlCommand("Update CoreUserControlNames set UserControlName=@UserControlName,DomainId = @DomainId ,LanguageId = @LanguageId  where UserControlNameId=@UserControlNameId", connection))
                    {
                        com.CommandType = CommandType.Text;
                        com.Parameters.Add("@UserControlNameId", SqlDbType.Int).Value = coreUserControlNames.UserControlNameId;
                        com.Parameters.Add("@UserControlName", SqlDbType.NVarChar).Value = coreUserControlNames.UserControlName;
                        com.Parameters.Add("@DomainId", SqlDbType.Int).Value = coreUserControlNames.DomainId;
                        com.Parameters.Add("@LanguageId", SqlDbType.Int).Value = coreUserControlNames.LanguageId;
                        connection.Open();
                        Int32 result = ExecuteNonQuery(com);
                        return result == 1;
                    }
                }
            }

            public override bool DeleteCoreUserControlNames(int UserControlNameId)
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.CommandText = "DELETE FROM CoreUserControlNames Where UserControlNameId=@UserControlNameId";
                        command.Parameters.Clear();
                        command.Parameters.Add("@UserControlNameId", SqlDbType.Int).Value = UserControlNameId;
                        command.CommandType = CommandType.Text;
                        command.Connection = connection;
                        connection.Open();
                        Int32 result = ExecuteNonQuery(command);
                        return result == 1;
                    }
                }
            }

        #endregion

        #region CoreUserControlPaths
            public override int InsertCoreUserControlPaths(Pine.Dal.Core.CoreUserControlPathDetails coreUserControlPaths)
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    SqlCommand com = new SqlCommand();
                    com.CommandText = @"INSERT INTO CoreUserControlPaths (UserControlNameId,Path,name,IsQueryString,QueryString,IsGroups,parameter,AdminSetting,AdminInsert,DefaltValue,OrderBy,visible,LocationName,DomainId,LanguageId) 
                    VALUES (@UserControlNameId,@Path,@name,@IsQueryString,@QueryString,@IsGroups,@parameter,@AdminSetting,@AdminInsert,@DefaltValue,@OrderBy,@visible,@LocationName,@DomainId,@LanguageId) SELECT CAST(scope_identity() AS int)";
                    com.Parameters.Add("@UserControlNameId", SqlDbType.Int).Value = coreUserControlPaths.UserControlNameId;
                    com.Parameters.Add("@Path", SqlDbType.NVarChar).Value = coreUserControlPaths.Path;
                    com.Parameters.Add("@name", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(coreUserControlPaths.Name) ? DBNull.Value : (object)coreUserControlPaths.Name;
                    com.Parameters.Add("@IsQueryString", SqlDbType.Bit).Value = coreUserControlPaths.IsQueryString;
                    com.Parameters.Add("@QueryString", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(coreUserControlPaths.QueryString) ? DBNull.Value : (object)coreUserControlPaths.QueryString;
                    com.Parameters.Add("@IsGroups", SqlDbType.Bit).Value = coreUserControlPaths.IsGroups;
                    com.Parameters.Add("@parameter", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(coreUserControlPaths.Parameter) ? DBNull.Value : (object)coreUserControlPaths.Parameter;
                    com.Parameters.Add("@AdminSetting", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(coreUserControlPaths.AdminSetting) ? DBNull.Value : (object)coreUserControlPaths.AdminSetting;
                    com.Parameters.Add("@AdminInsert", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(coreUserControlPaths.AdminInsert) ? DBNull.Value : (object)coreUserControlPaths.AdminInsert;
                    com.Parameters.Add("@DefaltValue", SqlDbType.Int).Value = (object)coreUserControlPaths.DefaltValue ?? DBNull.Value;
                    com.Parameters.Add("@OrderBy", SqlDbType.Int).Value = (object)coreUserControlPaths.OrderBy ?? DBNull.Value;
                    com.Parameters.Add("@visible", SqlDbType.Bit).Value = coreUserControlPaths.Visible;
                    com.Parameters.Add("@LocationName", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(coreUserControlPaths.LocationName) ? DBNull.Value : (object)coreUserControlPaths.LocationName;
                    com.Parameters.Add("@DomainId", SqlDbType.Int).Value = coreUserControlPaths.DomainId;
                    com.Parameters.Add("@LanguageId", SqlDbType.Int).Value = coreUserControlPaths.LanguageId;
                    com.Connection = connection;
                    connection.Open();
                    int id = (int)com.ExecuteScalar();
                    connection.Close();
                    return id;
                }
            }

            public override bool UpdateCoreUserControlPaths(CoreUserControlPathDetails coreUserControlPaths)
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand com = new SqlCommand("Update CoreUserControlPaths set UserControlNameId=@UserControlNameId,Path=@Path,name=@name,IsQueryString=@IsQueryString,QueryString=@QueryString,IsGroups=@IsGroups,parameter=@parameter,AdminSetting=@AdminSetting,AdminInsert=@AdminInsert,DefaltValue=@DefaltValue,OrderBy=@OrderBy,visible=@visible,LocationName=@LocationName,DomainId = @DomainId ,LanguageId = @LanguageId  where UserControlPathId=@UserControlPathId", connection))
                    {
                        com.CommandType = CommandType.Text;
                        com.Parameters.Add("@UserControlPathId", SqlDbType.Int).Value = coreUserControlPaths.UserControlPathId;
                        com.Parameters.Add("@UserControlNameId", SqlDbType.Int).Value = coreUserControlPaths.UserControlNameId;
                        com.Parameters.Add("@Path", SqlDbType.NVarChar).Value = coreUserControlPaths.Path;
                        com.Parameters.Add("@name", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(coreUserControlPaths.Name) ? DBNull.Value : (object)coreUserControlPaths.Name;
                        com.Parameters.Add("@IsQueryString", SqlDbType.Bit).Value = coreUserControlPaths.IsQueryString;
                        com.Parameters.Add("@QueryString", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(coreUserControlPaths.QueryString) ? DBNull.Value : (object)coreUserControlPaths.QueryString;
                        com.Parameters.Add("@IsGroups", SqlDbType.Bit).Value = coreUserControlPaths.IsGroups;
                        com.Parameters.Add("@parameter", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(coreUserControlPaths.Parameter) ? DBNull.Value : (object)coreUserControlPaths.Parameter;
                        com.Parameters.Add("@AdminSetting", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(coreUserControlPaths.AdminSetting) ? DBNull.Value : (object)coreUserControlPaths.AdminSetting;
                        com.Parameters.Add("@AdminInsert", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(coreUserControlPaths.AdminInsert) ? DBNull.Value : (object)coreUserControlPaths.AdminInsert;
                        com.Parameters.Add("@DefaltValue", SqlDbType.Int).Value = (object)coreUserControlPaths.DefaltValue ?? DBNull.Value;
                        com.Parameters.Add("@OrderBy", SqlDbType.Int).Value = (object)coreUserControlPaths.OrderBy ?? DBNull.Value;
                        com.Parameters.Add("@visible", SqlDbType.Bit).Value = coreUserControlPaths.Visible;
                        com.Parameters.Add("@LocationName", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(coreUserControlPaths.LocationName) ? DBNull.Value : (object)coreUserControlPaths.LocationName;
                        com.Parameters.Add("@DomainId", SqlDbType.Int).Value = coreUserControlPaths.DomainId;
                        com.Parameters.Add("@LanguageId", SqlDbType.Int).Value = coreUserControlPaths.LanguageId;
                        connection.Open();
                        Int32 result = ExecuteNonQuery(com);
                        return result == 1;
                    }
                }
            }

            public override bool DeleteCoreUserControlPaths(int userControlPathId)
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.CommandText = "DELETE FROM CoreUserControlPaths Where UserControlPathId=@UserControlPathId";
                        command.Parameters.Clear();
                        command.Parameters.Add("@UserControlPathId", SqlDbType.Int).Value = userControlPathId;
                        command.CommandType = CommandType.Text;
                        command.Connection = connection;
                        connection.Open();
                        Int32 result = ExecuteNonQuery(command);
                        return result == 1;
                    }
                }
            }

            public override CoreUserControlPathDetails GetCoreUserControlPathByPath(String path)
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.CommandText =
                            "SELECT * FROM CoreUserControlPaths  WHERE (CoreUserControlPaths.Path = @Path)";
                        command.Connection = connection;
                        command.CommandType = CommandType.Text;
                        command.Parameters.Add("@Path", SqlDbType.NVarChar).Value = path;
                        connection.Open();
                        IDataReader reader = ExecuteReader(command, CommandBehavior.SingleRow);
                        if (reader.Read())
                            return GetCoreUserControlPathDetailsFromDataReader(reader);
                        return null;
                    }
                }
            }

            public override CoreUserControlPathDetails GetCoreUserControlPathByUserControlPathId(Int32 userControlPathId)
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.CommandText =
                            "SELECT * from CoreUserControlPaths  WHERE UserControlPathId = @UserControlPathId";
                        command.Connection = connection;
                        command.CommandType = CommandType.Text;
                        command.Parameters.Add("@UserControlPathId", SqlDbType.Int).Value = userControlPathId;
                        connection.Open();
                        IDataReader reader = ExecuteReader(command, CommandBehavior.SingleRow);
                        if (reader.Read())
                            return GetCoreUserControlPathDetailsFromDataReader(reader);
                        return null;
                    }
                }
            }

        #endregion

        #region CoreUserControlPosition

            public override int InsertCoreUserControlPosition(Pine.Dal.Core.CoreUserControlPositionDetails coreUserControlPosition)
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    SqlCommand com = new SqlCommand();
                    com.CommandText = "INSERT INTO CoreUserControlPosition (ContentNameId,UserControlPathId,DomainId,LanguageId) VALUES (@ContentNameId,@UserControlPathId,@DomainId,@LanguageId) SELECT CAST(scope_identity() AS int)";
                    com.Parameters.Add("@ContentNameId", SqlDbType.Int).Value = coreUserControlPosition.ContentNameId;
                    com.Parameters.Add("@UserControlPathId", SqlDbType.Int).Value = coreUserControlPosition.UserControlPathId;
                    com.Parameters.Add("@DomainId", SqlDbType.Int).Value = coreUserControlPosition.DomainId;
                    com.Parameters.Add("@LanguageId", SqlDbType.Int).Value = coreUserControlPosition.LanguageId;
                    com.Connection = connection;
                    connection.Open();
                    int id = (int)com.ExecuteScalar();
                    connection.Close();
                    return id;
                }
            }

            public override bool UpdateCoreUserControlPosition(CoreUserControlPositionDetails coreUserControlPosition)
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand com = new SqlCommand("Update CoreUserControlPosition set ContentNameId=@ContentNameId,UserControlPathId=@UserControlPathId,DomainId = @DomainId ,LanguageId = @LanguageId  where UserControlpositionId=@UserControlpositionId", connection))
                    {
                        com.CommandType = CommandType.Text;
                        com.Parameters.Add("@UserControlpositionId", SqlDbType.Int).Value = coreUserControlPosition.UserControlpositionId;
                        com.Parameters.Add("@ContentNameId", SqlDbType.Int).Value = coreUserControlPosition.ContentNameId;
                        com.Parameters.Add("@UserControlPathId", SqlDbType.Int).Value = coreUserControlPosition.UserControlPathId;
                        com.Parameters.Add("@DomainId", SqlDbType.Int).Value = coreUserControlPosition.DomainId;
                        com.Parameters.Add("@LanguageId", SqlDbType.Int).Value = coreUserControlPosition.LanguageId;
                        connection.Open();
                        Int32 result = ExecuteNonQuery(com);
                        return result == 1;
                    }
                }
            }

            public override bool DeleteCoreUserControlPosition(int userControlpositionId)
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.CommandText = "DELETE FROM CoreUserControlPosition Where UserControlpositionId=@UserControlpositionId";
                        command.Parameters.Clear();
                        command.Parameters.Add("@UserControlpositionId", SqlDbType.Int).Value = userControlpositionId;
                        command.CommandType = CommandType.Text;
                        command.Connection = connection;
                        connection.Open();
                        Int32 result = ExecuteNonQuery(command);
                        return result == 1;
                    }
                }
            }

        #endregion

        #region CoreUserControlSetting

            public override int InsertCoreUserControlSetting(Pine.Dal.Core.CoreUserControlSettingDetails coreUserControlSetting)
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    SqlCommand com = new SqlCommand();
                    com.CommandText = "INSERT INTO CoreUserControlSetting (UserControlPathId,UserControlParameter,UserControlValue,DomainId,LanguageId) VALUES (@UserControlPathId,@UserControlParameter,@UserControlValue,@DomainId,@LanguageId) SELECT CAST(scope_identity() AS int)";
                    com.Parameters.Add("@UserControlPathId", SqlDbType.Int).Value = coreUserControlSetting.UserControlPathId;
                    com.Parameters.Add("@UserControlParameter", SqlDbType.NVarChar).Value = coreUserControlSetting.UserControlParameter;
                    com.Parameters.Add("@UserControlValue", SqlDbType.NVarChar).Value = coreUserControlSetting.UserControlValue;
                    com.Parameters.Add("@DomainId", SqlDbType.Int).Value = coreUserControlSetting.DomainId;
                    com.Parameters.Add("@LanguageId", SqlDbType.Int).Value = coreUserControlSetting.LanguageId;
                    com.Connection = connection;
                    connection.Open();
                    int id = (int)com.ExecuteScalar();
                    connection.Close();
                    return id;
                }
            }

            public override bool UpdateCoreUserControlSetting(CoreUserControlSettingDetails coreUserControlSetting)
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand com = new SqlCommand("Update CoreUserControlSetting set UserControlPathId=@UserControlPathId,UserControlParameter=@UserControlParameter,UserControlValue=@UserControlValue,DomainId = @DomainId ,LanguageId = @LanguageId  where UserControlSettingId=@UserControlSettingId", connection))
                    {
                        com.CommandType = CommandType.Text;
                        com.Parameters.Add("@UserControlSettingId", SqlDbType.Int).Value = coreUserControlSetting.UserControlSettingId;
                        com.Parameters.Add("@UserControlPathId", SqlDbType.Int).Value = coreUserControlSetting.UserControlPathId;
                        com.Parameters.Add("@UserControlParameter", SqlDbType.NVarChar).Value = coreUserControlSetting.UserControlParameter;
                        com.Parameters.Add("@UserControlValue", SqlDbType.NVarChar).Value = coreUserControlSetting.UserControlValue;
                        com.Parameters.Add("@DomainId", SqlDbType.Int).Value = coreUserControlSetting.DomainId;
                        com.Parameters.Add("@LanguageId", SqlDbType.Int).Value = coreUserControlSetting.LanguageId;
                        connection.Open();
                        Int32 result = ExecuteNonQuery(com);
                        return result == 1;
                    }
                }
            }

            public override bool DeleteCoreUserControlSetting(int userControlSettingId)
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.CommandText = "DELETE FROM CoreUserControlSetting Where UserControlSettingId=@UserControlSettingId";
                        command.Parameters.Clear();
                        command.Parameters.Add("@UserControlSettingId", SqlDbType.Int).Value = userControlSettingId;
                        command.CommandType = CommandType.Text;
                        command.Connection = connection;
                        connection.Open();
                        Int32 result = ExecuteNonQuery(command);
                        return result == 1;
                    }
                }
            }

        #endregion

        #region Join
       public override List<CorePageUserControlPathsPageContentDetails> GetCorePage_UserControlPaths_PageContent(String queryString)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = @"SELECT CoreUserControlPaths.IsQueryString, CoreUserControlPaths.QueryString, 
                                            CorePages.PageName, CorePages.PageId FROM CorePages
                                INNER JOIN CorePageContents ON CorePages.PageId = CorePageContents.PageId INNER JOIN 
                    CoreUserControlPaths ON CorePageContents.UserControlPathId = CoreUserControlPaths.UserControlPathId 
    WHERE (CorePages.IsDefault = 0) AND (CoreUserControlPaths.IsQueryString = 1) AND (CoreUserControlPaths.QueryString =@QueryString)";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@queryString", SqlDbType.NVarChar).Value = queryString;
                    connection.Open();
                    return GetCorePageUserControlPathsPageContentCollectionFromDataReader(ExecuteReader(command));
                }
            }

        }

       public override List<CoreUserControlPathsCoreAccessDetails> GetCoreUserControlPaths_CoreAccess(Int32 userControlNameId)
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.CommandText = @"SELECT CoreUserControlPaths.UserControlNameId, CoreUserControlPaths.name, CoreUserControlPaths.UserControlPathId,
                        coreAccess.username FROM CoreUserControlPaths INNER JOIN coreAccess ON CoreUserControlPaths.UserControlPathId = coreAccess.UserControlPathId
         WHERE (coreAccess.username = N'admin') AND (CoreUserControlPaths.UserControlNameId = @UserControlNameId) and (CoreUserControlPaths.IsQueryString = 1)";
                        command.Connection = connection;
                        command.CommandType = CommandType.Text;
                        command.Parameters.Add("@userControlNameId", SqlDbType.Int).Value = userControlNameId;
                        connection.Open();
                        return GetCoreUserControlPathsCoreAccessCollectionFromDataReader(ExecuteReader(command));
                    }
                }

            }

        public override List<CoreUserControlPathsCoreAccessDetails> GetCoreUserControlPathsCoreAccessByPath(String userName , String path)
        {

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = @"SELECT CoreUserControlPaths.UserControlPathId, CoreAccess.UserName, CoreUserControlPaths.Path FROM CoreAccess
INNER JOIN CoreUserControlPaths ON CoreAccess.UserControlPathId = CoreUserControlPaths.UserControlPathId 
WHERE (CoreAccess.UserName = @UserName) AND (CoreUserControlPaths.Path = @Path)";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@userName", SqlDbType.NVarChar).Value = userName;
                    command.Parameters.Add("@path", SqlDbType.NVarChar).Value = path;
                    connection.Open();
                    return GetCoreUserControlPathsCoreAccessCollectionFromDataReader(ExecuteReader(command));
                }
            }
        }

        public  override  List<CoreUserControlNamesAccessUserControlPathsDetails> GetCoreUserControlNames_Access_UserControlPaths(String username)
        {

            using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.CommandText = @"SELECT CoreUserControlNames.UserControlName, CoreUserControlNames.UserControlNameId, coreAccess.username FROM CoreUserControlNames INNER JOIN CoreUserControlPaths ON CoreUserControlNames.UserControlNameId = CoreUserControlPaths.UserControlNameId INNER JOIN coreAccess ON CoreUserControlPaths.UserControlPathId = coreAccess.UserControlPathId GROUP BY CoreUserControlNames.UserControlName,CoreUserControlPaths.IsQueryString, CoreUserControlNames.UserControlNameId, coreAccess.username HAVING (coreAccess.username = @username) and (CoreUserControlPaths.IsQueryString = 1)";
                        command.Connection = connection;
                        command.CommandType = CommandType.Text;
                        command.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;
                        connection.Open();
                        return GetCoreUserControlNamesAccessUserControlPathsCollectionFromDataReader(ExecuteReader(command));
                    }
                }


        }

        public override List<CoreThemeSettingMiddelSettingMasterPageNameDetails> GetCoreThemeSettingMiddelSettingMasterPageName(string themeName)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = @"SELECT  CoreThemeSetting.ThemeSettingId ,CoreThemeSetting.ThemeSettingTypeId,  CoreThemeSetting.Value1, CoreThemeSetting.Value2, CoreThemeSetting.Value3, 
CoreThemeSetting.Value4, CoreThemeSetting.Value5, CoreThemeSetting.Value6, CoreThemeSetting.Value7, CoreThemeSettingType.Parameter FROM CoreMasterPageNames INNER JOIN 
CoreThemeMiddelSetting ON CoreMasterPageNames.MasterPageNameId = CoreThemeMiddelSetting.MasterPageNameId INNER JOIN CoreThemeSetting ON 
CoreThemeMiddelSetting.ThemeSettingId = CoreThemeSetting.ThemeSettingId INNER JOIN CoreThemeSettingType ON CoreThemeSetting.ThemeSettingTypeId = 
CoreThemeSettingType.ThemeSettingTypeId WHERE (CoreMasterPageNames.ThemeName = @ThemeName)";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@themeName", SqlDbType.NVarChar).Value = themeName;
                    connection.Open();
                    return GetCoreThemeSettingMiddelSettingMasterPageNameCollectionFromDataReader(ExecuteReader(command));
                }
            }
        }

        public override List<CoreMasterPageNameCoreAccessPageDetails> GetCoreMasterPageNameCoreAccessPage(string userName)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = @"SELECT CoreMasterPageNames.MasterPageNameId, CoreMasterPageNames.PathSmallImage, CoreMasterPageNames.PathImage,
CoreMasterPageNames.NameImage FROM   CoreMasterPageNames INNER JOIN CoreAccessPage ON CoreMasterPageNames.MasterPageNameId = CoreAccessPage.MasterPageNameId 
WHERE (CoreAccessPage.Username = @Username) order by NameImage";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@userName", SqlDbType.NVarChar).Value = userName;
                    connection.Open();
                    return GetCoreMasterPageNameCoreAccessPageCollectionFromDataReader(ExecuteReader(command));
                }
            }
        }

        public override List<CoreMasterPageNameCoreAccessPageDetails> GetCoreMasterPageNameCoreAccessPage(string userName, int masterPageNameId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = @"SELECT  CoreMasterPageNames.MasterPageNameId, CoreMasterPageNames.PathSmallImage, CoreMasterPageNames.PathImage, CoreMasterPageNames.NameImage FROM            
CoreMasterPageNames INNER JOIN CoreAccessPage ON CoreMasterPageNames.MasterPageNameId = CoreAccessPage.MasterPageNameId WHERE (CoreAccessPage.Username = @Username) and 
(CoreMasterPageNames.MasterPageNameId=@MasterPageNameId)";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@userName", SqlDbType.NVarChar).Value = userName;
                    command.Parameters.Add("@masterPageNameId", SqlDbType.Int).Value = masterPageNameId;
                    connection.Open();
                    return GetCoreMasterPageNameCoreAccessPageCollectionFromDataReader(ExecuteReader(command));
                }
            } 
        }
        #endregion

    }
}

