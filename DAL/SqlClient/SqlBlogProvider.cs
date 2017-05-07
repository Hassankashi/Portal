using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Pine.Dal.Blog;

namespace Pine.Dal.SqlClient
{
    /// <summary>
    /// کلاسی برای پیاده سازی بلاگ
    /// </summary>
    public class SqlBlogProvider : BlogProvider
    {
        #region blog (3)

        public override BlogDetails GetBlogByBlogId(Guid blogId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT * FROM Blog WHERE (BlogId = @BlogId) ";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@BlogId", SqlDbType.UniqueIdentifier).Value = blogId;
                    connection.Open();

                    IDataReader reader = ExecuteReader(command, CommandBehavior.SingleRow);

                    if (reader.Read())
                        return GetBlogFromDataReader(reader);
                    return null;
                }
            }
        }


        public override List<BlogDetails> GetBlogByBlogGoupId(Int32 blogGroupId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT * FROM Blog WHERE (GroupId = @GroupId) ";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@GroupId", SqlDbType.Int).Value = blogGroupId;
                    connection.Open();
                    return GetBlogCollectionFromDataReader(ExecuteReader(command));
                }
            }
        }
        public override List<BlogDetails> GetAllBlogs()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT * from Blog ";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                   
                    connection.Open();
                    return GetBlogCollectionFromDataReader(ExecuteReader(command));
                }
            }
        }

        public override List<BlogDetails> GetBlogsByTagId(Guid tagId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = @"SELECT  Blog.* FROM   BlogMiddleTag INNER JOIN
                         Blog ON BlogMiddleTag.BlogId = Blog.BlogId
                        WHERE        (BlogMiddleTag.BlogTagId = @BlogTagId)  ";
                    command.Connection = connection;
                    command.Parameters.Add("@BlogTagId", SqlDbType.UniqueIdentifier).Value = tagId;
                    command.CommandType = CommandType.Text;

                    connection.Open();
                    return GetBlogCollectionFromDataReader(ExecuteReader(command));
                }
            }
        }
        public override List<BlogDetails> GetBlogsByAuthor(Guid author)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT  * from Blog where Author=@Author order by EnterDate desc  ";
                    command.Connection = connection;
                    command.Parameters.Add("@Author", SqlDbType.UniqueIdentifier).Value = author; 
                    command.CommandType = CommandType.Text;

                    connection.Open();
                    return GetBlogCollectionFromDataReader(ExecuteReader(command));
                }
            }
        }
        public override int InsertBlog(BlogDetails blog)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand com = new SqlCommand();
                com.CommandText = @"INSERT INTO Blog (BlogId,GroupId,Title,Text,ShortText,EnterDate,Author,AuthorUserName,IsActive,CommentCount,ViewCount,Rate,UpdateDate) VALUES (@BlogId,@GroupId,@Title,@Text,@ShortText,@EnterDate,@Author,@AuthorUserName,@IsActive,@CommentCount,@ViewCount,@Rate,@UpdateDate)";
                com.Parameters.Clear();
                com.Parameters.Add("@BlogId", SqlDbType.UniqueIdentifier).Value = blog.BlogId;
                com.Parameters.Add("@GroupId", SqlDbType.Int).Value = blog.GroupId;
                com.Parameters.Add("@Title", SqlDbType.NVarChar).Value = blog.Title;
                com.Parameters.Add("@Text", SqlDbType.NVarChar).Value = blog.Text;
                com.Parameters.Add("@ShortText", SqlDbType.NVarChar).Value = blog.ShortText;
                com.Parameters.Add("@EnterDate", SqlDbType.DateTime).Value = blog.EnterDate;
                com.Parameters.Add("@Author", SqlDbType.UniqueIdentifier).Value = blog.Author;
                com.Parameters.Add("@AuthorUserName", SqlDbType.NVarChar).Value = blog.AuthorUserName;
                com.Parameters.Add("@IsActive", SqlDbType.Bit).Value = blog.IsActive;
                com.Parameters.Add("@CommentCount", SqlDbType.Int).Value =(Object) blog.CommentCount??DBNull.Value;
                com.Parameters.Add("@ViewCount", SqlDbType.Int).Value = (Object)blog.ViewCount ?? DBNull.Value;
                com.Parameters.Add("@Rate", SqlDbType.TinyInt).Value = (Object)blog.Rate ?? DBNull.Value;
                com.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = (Object)blog.UpdateDate ?? DBNull.Value;
                com.Connection = connection;
                connection.Open();
                int id= com.ExecuteNonQuery();
                connection.Close();
                return id;
            }
        }



        /// <summary>
        /// ویرایش بلاگ
        /// </summary>
        /// <param name="menuGroup"></param>
        /// <returns></returns>
        public override Boolean UpdateBlog(BlogDetails blog)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand com = new SqlCommand(@"Update Blog set GroupId=@GroupId,Title=@Title,
                 Text=@Text,ShortText=@ShortText,EnterDate=@EnterDate,Author=@Author,
                 IsActive=@IsActive,CommentCount=@CommentCount,ViewCount=@ViewCount,
                  Rate=@Rate,UpdateDate=@UpdateDate  where BlogId=@BlogId", connection))
                {
                    com.CommandType = CommandType.Text;
                    com.Parameters.Clear();
                    com.Parameters.Add("@BlogId", SqlDbType.UniqueIdentifier).Value = blog.BlogId;
                    com.Parameters.Add("@GroupId", SqlDbType.Int).Value = blog.GroupId;
                    com.Parameters.Add("@Title", SqlDbType.NVarChar).Value = blog.Title;
                    com.Parameters.Add("@Text", SqlDbType.NVarChar).Value = blog.Text;
                    com.Parameters.Add("@ShortText", SqlDbType.NVarChar).Value = blog.ShortText;
                    com.Parameters.Add("@EnterDate", SqlDbType.DateTime).Value = blog.EnterDate;
                    com.Parameters.Add("@Author", SqlDbType.UniqueIdentifier).Value = blog.Author;
                    com.Parameters.Add("@IsActive", SqlDbType.Bit).Value = blog.IsActive;
                    com.Parameters.Add("@CommentCount", SqlDbType.Int).Value = (Object)blog.CommentCount ?? DBNull.Value;
                    com.Parameters.Add("@ViewCount", SqlDbType.Int).Value = (Object)blog.ViewCount ?? DBNull.Value;
                    com.Parameters.Add("@Rate", SqlDbType.TinyInt).Value = (Object)blog.Rate ?? DBNull.Value;
                    com.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = (Object)blog.UpdateDate ?? DBNull.Value;
                    connection.Open();
                    Int32 result = ExecuteNonQuery(com);
                    return result == 1;
                }
            }
        }
        #endregion

        #region BlogComment
        public override BlogCommentDetails GetBlogCommentByBlogCommentId(Guid blogCommentId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT * FROM BlogComment WHERE (BlogCommentId = @BlogCommentId) ";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@BlogCommentId", SqlDbType.UniqueIdentifier).Value = blogCommentId;
                    connection.Open();

                    IDataReader reader = ExecuteReader(command, CommandBehavior.SingleRow);

                    if (reader.Read())
                        return GetBlogCommentFromDataReader(reader);
                    return null;
                }
            }
        }


        public override Int32 InsertBlogComment(BlogCommentDetails blogComment)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand com = new SqlCommand();
                com.CommandText = @"INSERT INTO BlogComment (BlogId,UserName,Email,WebSite,PrivateComment,DisplayConfirmed,EnterDate,TextComment) VALUES (@BlogId,@UserName,@Email,@WebSite,@PrivateComment,@DisplayConfirmed,@EnterDate,@TextComment)";
                com.Parameters.Clear();
               // com.Parameters.Add("@BlogCommentId", SqlDbType.UniqueIdentifier).Value = blogComment.BlogCommentId ;
                com.Parameters.Add("@BlogId", SqlDbType.UniqueIdentifier).Value = blogComment.BlogId;
                com.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = blogComment.UserName;
                com.Parameters.Add("@Email", SqlDbType.NVarChar).Value = blogComment.Email;
                com.Parameters.Add("@WebSite", SqlDbType.NVarChar).Value = blogComment.WebSite;
                com.Parameters.Add("@PrivateComment", SqlDbType.TinyInt).Value = blogComment.PrivateComment;
                com.Parameters.Add("@DisplayConfirmed", SqlDbType.TinyInt).Value = blogComment.DisplayConfirmed;
                com.Parameters.Add("@EnterDate", SqlDbType.DateTime).Value = blogComment.EnterDate;
                com.Parameters.Add("@TextComment", SqlDbType.NVarChar).Value = blogComment.TextComment;
                com.Connection = connection;
                connection.Open();
                int id = com.ExecuteNonQuery();
                connection.Close();
                return id;
            }
        }



        /// <summary>
        /// ویرایش بلاگ
        /// </summary>
        /// <param name="menuGroup"></param>
        /// <returns></returns>
        public override Boolean UpdateBlogComment(BlogCommentDetails blogComment)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand com = new SqlCommand(@"Update BlogComment set BlogId=@BlogId,UserName=@UserName,
                 Email=@Email,WebSite=@WebSite,PrivateComment=@PrivateComment,DisplayConfirmed=@DisplayConfirmed,
                 EnterDate=@EnterDate where BlogCommentId=@BlogCommentId", connection))
                {
                    com.CommandType = CommandType.Text;
                    com.Parameters.Clear();
                    com.Parameters.Add("@BlogCommentId", SqlDbType.UniqueIdentifier).Value = blogComment.BlogCommentId;
                    com.Parameters.Add("@BlogId", SqlDbType.UniqueIdentifier).Value = blogComment.BlogId;
                    com.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = blogComment.UserName;
                    com.Parameters.Add("@Email", SqlDbType.NVarChar).Value = blogComment.Email;
                    com.Parameters.Add("@WebSite", SqlDbType.NVarChar).Value = blogComment.WebSite;
                    com.Parameters.Add("@PrivateComment", SqlDbType.TinyInt).Value = blogComment.PrivateComment;
                    com.Parameters.Add("@DisplayConfirmed", SqlDbType.TinyInt).Value = blogComment.DisplayConfirmed;
                    com.Parameters.Add("@EnterDate", SqlDbType.DateTime).Value = blogComment.EnterDate;
                    connection.Open();
                    Int32 result = ExecuteNonQuery(com);
                    return result == 1;
                }
            }
        }
        public override List<BlogCommentDetails> GetBlogCommentByBlogId(Guid blogId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT * FROM BlogComment WHERE (BlogId = @BlogId) order by EnterDate desc   ";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@BlogId", SqlDbType.UniqueIdentifier).Value = blogId;
                    connection.Open();

                    return GetBlogCommentCollectionFromDataReader(ExecuteReader(command));
                }
            }
        }
        #endregion

        #region BlogGroup (3)

        public override BlogGroupDetails GetBlogGroupByBlogGroupId(Int32 blogGroupId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT * FROM BlogGroup WHERE (BlogGroupId = @BlogGroupId)";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@BlogGroupId", SqlDbType.Int).Value = blogGroupId;
                    connection.Open();
                    IDataReader reader = ExecuteReader(command, CommandBehavior.SingleRow);
                    if (reader.Read())
                        return GetBlogGroupFromDataReader(reader);
                    return null;
                }
            }
        }


        public override List<BlogGroupDetails> GetBlogGroup()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT * FROM BlogGroup ";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    //IDataReader reader = ExecuteReader(command, CommandBehavior.SingleRow);
                    //if (reader.Read())
                    //    return GetBlogGroupFromDataReader(reader);
                    return GetBlogGroupCollectionFromDataReader(ExecuteReader(command));
                }
            }
        }

        public override Int32 InsertBlogGroup(BlogGroupDetails blogGroup)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand com = new SqlCommand();
                com.CommandText = @"INSERT INTO BlogGroup (GroupName,IsShow) VALUES (@GroupName,@IsShow)";
                com.Parameters.Clear();
                com.Parameters.Add("@GroupName", SqlDbType.NVarChar).Value = blogGroup.GroupName;
                com.Parameters.Add("@IsShow", SqlDbType.Bit).Value = blogGroup.IsShow;
                com.Connection = connection;
                connection.Open();
                int id = com.ExecuteNonQuery();
                connection.Close();
                return id;
            }
        }



        /// <summary>
        /// ویرایش گروه بلاگ
        /// </summary>
        /// <param name="menuGroup"></param>
        /// <returns></returns>
        public override Boolean UpdateBlogGroup(BlogGroupDetails blogGroup)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand com = new SqlCommand(@"Update BlogGroup set GroupName=@GroupName,
                 IsShow=@IsShow where BlogGroupId=@BlogGroupId", connection))
                {
                    com.CommandType = CommandType.Text;
                    com.Parameters.Clear();
                    com.Parameters.Add("@BlogGroupId", SqlDbType.Int).Value = blogGroup.BlogGroupId;
                    com.Parameters.Add("@GroupName", SqlDbType.NVarChar).Value = blogGroup.GroupName;
                    com.Parameters.Add("@IsShow", SqlDbType.Bit).Value = blogGroup.IsShow;
                    connection.Open();
                    Int32 result = ExecuteNonQuery(com);
                    return result == 1;
                }
            }
        }

        #endregion

        #region BlogTag (3)


        public override List<BlogTagDetails> GetAllTags()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT * FROM BlogTag  order by TagName";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    
                    connection.Open();

                    return GetBlogTagCollectionFromDataReader(ExecuteReader(command));
                }
            }
        }
        public override BlogTagDetails GetBlogTagByBlogTagId(Guid blogTagId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT * FROM BlogTag WHERE (BlogTagId = @BlogTagId) ";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@BlogTagId", SqlDbType.UniqueIdentifier).Value = blogTagId;
                    connection.Open();
                    IDataReader reader = ExecuteReader(command, CommandBehavior.SingleRow);
                    if (reader.Read())
                        return GetBlogTagFromDataReader(reader);
                    return null;
                }
            }
        }
        public override List<BlogTagDetails> GetBlogTagByBlogTagGroupId(Int32 blogTagGroupId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT * FROM BlogTag WHERE (BlogTagGroupId = @BlogTagGroupId) order by TagName";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@BlogTagGroupId", SqlDbType.Int).Value = blogTagGroupId;
                    connection.Open();

                    return GetBlogTagCollectionFromDataReader(ExecuteReader(command));
                }
            }
        }
  


        public override Int32 InsertBlogTag(BlogTagDetails blogTag)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand com = new SqlCommand();
                com.CommandText = @"INSERT INTO BlogTag (BlogTagGroupId,TagName,DomainId,LanguageId) VALUES (@BlogTagGroupId,@TagName,@DomainId,@LanguageId)";
                com.Parameters.Clear();
               
                com.Parameters.Add("@BlogTagGroupId", SqlDbType.Int).Value = blogTag.BlogTagGroupId;
                com.Parameters.Add("@TagName", SqlDbType.NVarChar).Value = blogTag.TagName;
                com.Parameters.Add("@DomainId", SqlDbType.Int).Value = blogTag.DomainId;
                com.Parameters.Add("@LanguageId", SqlDbType.Int).Value = blogTag.LanguageId; 
                com.Connection = connection;
                connection.Open();
                int id = com.ExecuteNonQuery();
                connection.Close();
                return id;
            }
        }



        /// <summary>
        /// ویرایش تگ بلاگ
        /// </summary>
        /// <param name="menuGroup"></param>
        /// <returns></returns>
        /// 
        public override List<BlogTagDetails> GetTagByBlogId(Guid blogId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = @"SELECT  *
                    FROM            BlogMiddleTag INNER JOIN
                         BlogTag ON BlogMiddleTag.BlogTagId = BlogTag.BlogTagId
                     WHERE        (BlogMiddleTag.BlogId = @BlogId)";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@BlogId", SqlDbType.UniqueIdentifier).Value = blogId;
                    connection.Open();
                    return GetBlogTagCollectionFromDataReader(ExecuteReader(command));
                }
            }
        }
        public override Boolean UpdateBlogTag(BlogTagDetails blogTag)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand com = new SqlCommand(@"Update BlogTag set TagName=@TagName,
                 BlogTagGroupId=@BlogTagGroupId , DomainId=@DomainId , LanguageId=@LanguageId   where BlogTagId=@BlogTagId", connection))
                {
                    com.CommandType = CommandType.Text;
                    com.Parameters.Clear();
                    com.Parameters.Add("@BlogTagId", SqlDbType.UniqueIdentifier).Value = blogTag.BlogTagId;
                    com.Parameters.Add("@BlogTagGroupId", SqlDbType.Int).Value = blogTag.BlogTagGroupId;
                    com.Parameters.Add("@TagName", SqlDbType.NVarChar).Value = blogTag.TagName;
                    com.Parameters.Add("@DomainId", SqlDbType.NVarChar).Value = blogTag.DomainId;
                    com.Parameters.Add("@LanguageId", SqlDbType.NVarChar).Value = blogTag.LanguageId; 
                    connection.Open();
                    Int32 result = ExecuteNonQuery(com);
                    return result == 1;
                }
            }
        }

        #endregion

        #region BlogTagGroup (3)

        public override BlogTagGroupDetails GetBlogTagGroupByBlogTagGroupId(Int32 blogTagGroupId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT * FROM BlogTagGroup WHERE (BlogTagGroupId = @BlogTagGroupId) ";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@BlogTagGroupId", SqlDbType.UniqueIdentifier).Value = blogTagGroupId;
                    connection.Open();
                    IDataReader reader = ExecuteReader(command, CommandBehavior.SingleRow);
                    if (reader.Read())
                        return GetBlogTagGroupFromDataReader(reader);
                    return null;
                }
            }
        }

        public override List<BlogTagGroupDetails> GetBlogTagGroup()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT * FROM BlogTagGroup order by TagGroupName";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;

                    connection.Open();

                    return GetBlogTagGroupCollectionFromDataReader(ExecuteReader(command));
                }
            }
        }

        public override Int32 InsertBlogTagGroup(BlogTagGroupDetails blogTagGroup)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand com = new SqlCommand();
                com.CommandText = @"INSERT INTO BlogTagGroup (TagGroupName,DomainId,LanguageId) VALUES (@TagGroupName,@DomainId,@LanguageId)";
                com.Parameters.Clear();
                //com.Parameters.Add("@BlogTagGroupId", SqlDbType.Int).Value = blogTagGroup.BlogTagGroupId;
                com.Parameters.Add("@TagGroupName", SqlDbType.NVarChar).Value = blogTagGroup.TagGroupName;
                com.Parameters.Add("@DomainId", SqlDbType.Int).Value = blogTagGroup.DomainId;
                com.Parameters.Add("@LanguageId", SqlDbType.Int).Value = blogTagGroup.LanguageId;
                com.Connection = connection;
                connection.Open();
                int id = com.ExecuteNonQuery();
                connection.Close();
                return id;
            }
        }



        /// <summary>
        /// ویرایش گروه تگ بلاگ
        /// </summary>
        /// <param name="menuGroup"></param>
        /// <returns></returns>
        public override Boolean UpdateBlogTagGroup(BlogTagGroupDetails blogTagGroup)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand com = new SqlCommand(@"Update BlogTagGroup set TagGroupName=@TagGroupName ,
                  DomainId=@DomainId , LanguageId=@LanguageId 
                  where BlogTagGroupId=@BlogTagGroupId", connection))
                {
                    com.CommandType = CommandType.Text;
                    com.Parameters.Clear();
                    com.Parameters.Add("@BlogTagGroupId", SqlDbType.Int).Value = blogTagGroup.BlogTagGroupId;
                    com.Parameters.Add("@TagGroupName", SqlDbType.NVarChar).Value = blogTagGroup.TagGroupName;
                    com.Parameters.Add("@DomainId", SqlDbType.Int).Value = blogTagGroup.DomainId;
                    com.Parameters.Add("@LanguageId", SqlDbType.Int).Value = blogTagGroup.LanguageId;
                    connection.Open();
                    Int32 result = ExecuteNonQuery(com);
                    return result == 1;
                }
            }
        }

        #endregion

        #region BlogRate (3)

        public override BlogRateDetails GetBlogRateByBlogRateId(Guid blogRateId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT * FROM BlogRate WHERE (BlogRateId = @BlogRateId) ";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@BlogRateId", SqlDbType.UniqueIdentifier).Value = blogRateId;
                    connection.Open();
                    IDataReader reader = ExecuteReader(command, CommandBehavior.SingleRow);
                    if (reader.Read())
                        return GetBlogRateFromDataReader(reader);
                    return null;
                }
            }
        }


        public override Int32 InsertBlogRate(BlogRateDetails blogRate)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand com = new SqlCommand();
                com.CommandText = @"INSERT INTO BlogRate (BlogRateId,BlogId,UserNmae,Rate) VALUES (@BlogRateId,@BlogId,@UserNmae,@Rate)";
                com.Parameters.Clear();
                com.Parameters.Add("@BlogRateId", SqlDbType.UniqueIdentifier).Value = blogRate.BlogRateId;
                com.Parameters.Add("@BlogId", SqlDbType.UniqueIdentifier).Value = blogRate.BlogId;
                com.Parameters.Add("@UserNmae", SqlDbType.NVarChar).Value = blogRate.UserNmae;
                com.Parameters.Add("@Rate", SqlDbType.TinyInt).Value = blogRate.Rate;
                com.Connection = connection;
                connection.Open();
                int id = com.ExecuteNonQuery();
                connection.Close();
                return id;
            }
        }



        /// <summary>
        /// ویرایش رتبه بلاگ
        /// </summary>
        /// <param name="menuGroup"></param>
        /// <returns></returns>
        public override Boolean UpdateBlogRate(BlogRateDetails blogRate)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand com = new SqlCommand(@"Update BlogTag set BlogId=@BlogId,UserNmae=@UserNmae,Rate=@Rate
                  where BlogRateId=@BlogRateId", connection))
                {
                    com.CommandType = CommandType.Text;
                    com.Parameters.Clear();
                    com.Parameters.Add("@BlogRateId", SqlDbType.UniqueIdentifier).Value = blogRate.BlogRateId;
                    com.Parameters.Add("@BlogId", SqlDbType.UniqueIdentifier).Value = blogRate.BlogId;
                    com.Parameters.Add("@UserNmae", SqlDbType.NVarChar).Value = blogRate.UserNmae;
                    com.Parameters.Add("@Rate", SqlDbType.TinyInt).Value = blogRate.Rate;
                    connection.Open();
                    Int32 result = ExecuteNonQuery(com);
                    return result == 1;
                }
            }
        }

        #endregion

        #region BlogMiddleTag (1)


        public override Int32 InsertBlogMiddleTag(BlogMiddleTagDetails blogMiddleTag)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand com = new SqlCommand();
                com.CommandText = @"INSERT INTO BlogMiddleTag (BlogId,BlogTagId) VALUES (@BlogId,@BlogTagId)";
                com.Parameters.Clear();
                com.Parameters.Add("@BlogId", SqlDbType.UniqueIdentifier).Value = blogMiddleTag.BlogId;
                com.Parameters.Add("@BlogTagId", SqlDbType.UniqueIdentifier).Value = blogMiddleTag.BlogTagId;
                com.Connection = connection;
                connection.Open();
                int id = com.ExecuteNonQuery();
                connection.Close();
                return id;
            }
        }



        #endregion

        #region BlogUser


        public override List<BlogUserDetails> GetBlogUser()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT * FROM BlogUser WHERE IsActive=1";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text; 
                    connection.Open();
                    return GetBlogUserCollectionFromDataReader(ExecuteReader(command));
                }
            }
        }
        public override BlogUserDetails GetBlogUserByUserGuid(Guid userGuid)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT * FROM BlogUser WHERE (UserGuid = @UserGuid)";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@UserGuid", SqlDbType.UniqueIdentifier).Value = userGuid;
                    connection.Open();
                    IDataReader reader = ExecuteReader(command, CommandBehavior.SingleRow);
                    if (reader.Read())
                        return GetBlogUserFromDataReader(reader);
                    return null;
                }
            }
        }

        public override BlogUserDetails GetBlogUserByUserGuidIsActive(Guid userGuid)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT * FROM BlogUser WHERE (UserGuid = @UserGuid) and IsActive=1 ";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@UserGuid", SqlDbType.UniqueIdentifier).Value = userGuid;
                    connection.Open();
                    IDataReader reader = ExecuteReader(command, CommandBehavior.SingleRow);
                    if (reader.Read())
                        return GetBlogUserFromDataReader(reader);
                    return null;
                }
            }
        }

        public override Int32 InsertBlogUser(BlogUserDetails blogUser)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand com = new SqlCommand();
                com.CommandText = @"INSERT INTO BlogUser (UserGuid,UserName,Posts,IsActive,EnterDate) VALUES (@UserGuid,@UserName,@Posts,@IsActive,@EnterDate)";
                com.Parameters.Clear();
                com.Parameters.Add("@UserGuid", SqlDbType.UniqueIdentifier).Value = blogUser.UserGuid;
                com.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = blogUser.UserName;
                com.Parameters.Add("@Posts", SqlDbType.Int).Value = blogUser.Posts;
                com.Parameters.Add("@IsActive", SqlDbType.Bit).Value = blogUser.IsActive;
                com.Parameters.Add("@EnterDate", SqlDbType.DateTime).Value = blogUser.EnterDate;
                com.Connection = connection;
                connection.Open();
                int id = com.ExecuteNonQuery();
                connection.Close();
                return id;
            }
        }

        public override Boolean UpdateBlogUser(BlogUserDetails blogUser)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand com = new SqlCommand(@"Update BlogUser set Posts=@Posts,IsActive=@IsActive where UserGuid=@UserGuid", connection))
                {
                    com.CommandType = CommandType.Text;
                    com.Parameters.Clear();
                    com.Parameters.Add("@Posts", SqlDbType.Int).Value = blogUser.Posts;
                    com.Parameters.Add("@IsActive", SqlDbType.Bit).Value = blogUser.IsActive;
                    com.Parameters.Add("@UserGuid", SqlDbType.UniqueIdentifier).Value = blogUser.UserGuid;
                    connection.Open();
                    Int32 result = ExecuteNonQuery(com);
                    return result == 1;
                }
            }
        }
        #endregion
    }
}

