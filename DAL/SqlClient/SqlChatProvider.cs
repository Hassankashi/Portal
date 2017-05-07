using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Pine.Dal.Chat;
using Pine.Dal;

namespace Pine.Dal.SqlClient
{
    public  class SqlChatProvider :ChatProvider
    {
        #region Chat_Conversation()

        //***Mahsa Kashi Change due to IGet all of Admin messages without ConversationID
        public override List<Chat_ConversationDetails> GetChat_ConversationByPartId(Int32 partId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    List<string> query = new List<string>();
                    //string strCommand = @"SELECT * FROM Chat_Conversation ";
                    //command.CommandText = "SELECT * FROM Chat_Message WHERE ConversationId = @ConversationId And UserId = @UserId And  IsRead = @IsRead";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT * FROM Chat_Conversation WHERE partId = @partId and flag = 0 ";
                    command.Parameters.Add("@partId", SqlDbType.Int).Value = partId;
                    //command.Parameters.Add("@flag", SqlDbType.TinyInt).Value = flag;
                    // command.CommandText = strCommand;
                    connection.Open();
                    return GetChat_ConversationCollectionFromDataReader(ExecuteReader(command));
                }

            }
        }

      
        public override List<Chat_ConversationDetails> GetChat_ConversationByConversationId(Int32 conersationId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT * FROM Chat_Conversation WHERE (ConversationId = @ConversationId)";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@ConversationId", SqlDbType.Int).Value = conersationId;
                    connection.Open();
                    return GetChat_ConversationCollectionFromDataReader(ExecuteReader(command));
                }

            }
       
        }


        public override Chat_ConversationDetails GetChat_ConversationBySenderIdOrResposerId(Guid id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT * FROM Chat_Conversation WHERE (SenderId = @SenderId Or ResposerId = @ResposerId)";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@SenderId", SqlDbType.Int).Value = id;
                    command.Parameters.Add("@ResposerId", SqlDbType.Int).Value = id;
                    connection.Open();
                   // return GetChat_ConversationCollectionFromDataReader(ExecuteReader(command));
                    
                    IDataReader reader = ExecuteReader(command, CommandBehavior.SingleRow);

                    if (reader.Read())

                        return GetChat_ConversationFromDataReader(reader);
                    return null;
                }

            }

        }

        public override Int32 Chat_ConversationInsert(Chat_ConversationDetails Conversation)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand com = new SqlCommand();
                com.CommandText = @"INSERT INTO Chat_Conversation (SenderId,ReceiverId,PartId,flag,DomainId,LanguageId) values(@SenderId,@ReceiverId, @PartId,@flag,@DomainId,@LanguageId)";
                com.Parameters.Clear();

                com.Parameters.Add("@SenderId", SqlDbType.UniqueIdentifier).Value = Conversation.SenderId;
                com.Parameters.Add("@ReceiverId", SqlDbType.UniqueIdentifier).Value = (Object)Conversation.ReceiverId ?? DBNull.Value;
                com.Parameters.Add("@PartId", SqlDbType.Int).Value = (Object)Conversation.PartId ?? DBNull.Value;
                com.Parameters.Add("@flag", SqlDbType.TinyInt).Value = (Object)Conversation.Flag ?? DBNull.Value;
                com.Parameters.Add("@DomainId", SqlDbType.Int).Value = Conversation.DomainId;
                com.Parameters.Add("@LanguageId", SqlDbType.Int).Value = Conversation.LanguageId;

                com.Connection = connection;
                connection.Open();
                int result = com.ExecuteNonQuery();
                connection.Close();
                return result;
            }
        }

        public override Boolean Chat_ConversationUpdate(Chat_ConversationDetails Conversation)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("Update Chat_Conversation set   PartId=@PartId ,SenderId=@SenderId , ReceiverId=@ReceiverId, flag=@flag, DomainId=@DomainId, LanguageId=@LanguageId   where ConversationId=@ConversationId ", connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.Clear();
                    command.Parameters.Add("@ConversationId", SqlDbType.Int).Value = Conversation.ConversationId;
                    command.Parameters.Add("@SenderId", SqlDbType.UniqueIdentifier).Value = Conversation.SenderId;
                    command.Parameters.Add("@ReceiverId", SqlDbType.UniqueIdentifier).Value = (Object)Conversation.ReceiverId ?? DBNull.Value;
                    command.Parameters.Add("@PartId", SqlDbType.Int).Value = (Object)Conversation.PartId ?? DBNull.Value;
                    command.Parameters.Add("@flag", SqlDbType.TinyInt).Value = (Object)Conversation.Flag ?? DBNull.Value;
                    command.Parameters.Add("@DomainId", SqlDbType.Int).Value = Conversation.DomainId;
                    command.Parameters.Add("@LanguageId", SqlDbType.Int).Value = Conversation.LanguageId;

                    connection.Open();
                    Int32 result = ExecuteNonQuery(command);
                    return result == 1;
                }
            }
        }

        public override Chat_ConversationDetails GetChat_ConversationBySenderIdAndReceiverId(Guid senderId, Guid? receiverId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {

                    List<string> query = new List<string>();

                    if (senderId != null)
                    {
                        query.Add(" (SenderId = @SenderId) ");
                        command.Parameters.Add("@SenderId", SqlDbType.UniqueIdentifier).Value = senderId;
                    }

                    if (receiverId != null)
                    {
                        query.Add(" (receiverId = @receiverId) ");
                        command.Parameters.Add("@receiverId", SqlDbType.UniqueIdentifier).Value = senderId;
                    }

                    string strCommand = @"SELECT * FROM Chat_Conversation ";
                    if (query.Count != 0)
                    {
                        strCommand += " where " + string.Join(" and ", query);
                    }
                    //command.CommandText = "SELECT * FROM Chat_Conversation WHERE SenderId = @SenderId  And  receiverId = @receiverId ";
                    command.CommandText = strCommand;
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;

                    // command.Parameters.Add("@receiverId", SqlDbType.UniqueIdentifier).Value = receiverId ;
                    connection.Open();
                    IDataReader reader = ExecuteReader(command, CommandBehavior.SingleRow);

                    if (reader.Read())

                        return GetChat_ConversationFromDataReader(reader);
                    return null;

                    // return GetChat_ConversationCollectionFromDataReader(ExecuteReader(command));
                }

            }
        }


        //public override Chat_ConversationDetails GetChat_ConversationBySenderIdAndReceiverId(Guid senderId, Guid receiverId)
        //{
        //    using (SqlConnection connection = new SqlConnection(ConnectionString))
        //    {
        //        using (SqlCommand command = new SqlCommand())
        //        {
        //            command.CommandText = "SELECT * FROM Chat_Conversation WHERE SenderId = @SenderId  And  receiverId = @receiverId ";
        //            command.Connection = connection;
        //            command.CommandType = CommandType.Text;
        //            command.Parameters.Add("@SenderId", SqlDbType.UniqueIdentifier).Value = senderId;
        //            command.Parameters.Add("@receiverId", SqlDbType.UniqueIdentifier).Value = receiverId;
        //            connection.Open();
        //            IDataReader reader = ExecuteReader(command, CommandBehavior.SingleRow);

        //            if (reader.Read())

        //                return GetChat_ConversationFromDataReader(reader);
        //            return null;

        //            // return GetChat_ConversationCollectionFromDataReader(ExecuteReader(command));
        //        }

        //    }
        //}

        public override List<Chat_ConversationDetails> GetChat_ConversationBySenderIdAndReceiverIdAndPartId(Guid senderId, Guid? receiverId , Int32 partId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT * FROM Chat_Conversation WHERE SenderId = @SenderId  And  receiverId = @receiverId And PartId = @partId ";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@SenderId", SqlDbType.UniqueIdentifier).Value = senderId;
                    command.Parameters.Add("@partId", SqlDbType.Int).Value = partId;
                    command.Parameters.Add("@receiverId", SqlDbType.UniqueIdentifier).Value = (Object)receiverId ?? DBNull.Value;
                    connection.Open();
                    return GetChat_ConversationCollectionFromDataReader(ExecuteReader(command));
                }

            }
        }

         
        #endregion

        #region Chat_Message()

        //***Mahsa Kashi Count of Message Details Comments return Message comment 
        public override Int32 GetChat_CountConversationByConversationIDAnduserID(Int32? conversationId, Guid userId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    List<string> query = new List<string>();
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT count(*) FROM Chat_Message WHERE ConversationId = @ConversationId and IsRead = false and UserId = @UserId ";
                    command.Parameters.Add("@ConversationId", SqlDbType.NVarChar).Value = (Object)conversationId ?? DBNull.Value;
                    command.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = userId;

                    connection.Open();
                    Int32 countConv = Int32.Parse(ExecuteScalar(command).ToString());
                    return countConv;

                }

            }
        }
        
        public override Int32 Chat_MessageInsert(Chat_MessageDetails Message)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand com = new SqlCommand();
                com.CommandText = @"INSERT INTO Chat_Message (ConversationId,Comment,UserId,username,IsRead,DomainId,LanguageId) values(@ConversationId,@Comment, @UserId,@username,@IsRead,@DomainId,@LanguageId)";
                com.Parameters.Clear();

                com.Parameters.Add("@ConversationId", SqlDbType.Int).Value =(Object) Message.ConversationId?? DBNull.Value;
                com.Parameters.Add("@Comment", SqlDbType.NVarChar).Value = (Object)Message.Comment ?? DBNull.Value;
                com.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = Message.UserId;
                com.Parameters.Add("@username", SqlDbType.NVarChar).Value = Message.Username;
                com.Parameters.Add("@IsRead", SqlDbType.Bit).Value = Message.IsRead;
                com.Parameters.Add("@DomainId", SqlDbType.Int).Value = Message.DomainId;
                com.Parameters.Add("@LanguageId", SqlDbType.Int).Value = Message.LanguageId;

                com.Connection = connection;
                connection.Open();
                int result = com.ExecuteNonQuery();
                connection.Close();
                return result;
            } 
        }

        public override Boolean Chat_MessageUpdate(Chat_MessageDetails Message)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("Update Chat_Message set   ConversationId=@ConversationId , Comment=@Comment, Enterdate=@Enterdate,UserId=@UserId,username=@username,IsRead=@IsRead ,DomainId=@DomainId, LanguageId=@LanguageId   where MessageId=@MessageId ", connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.Clear();
                    command.Parameters.Add("@MessageId", SqlDbType.BigInt).Value = Message.MessageId;
                    command.Parameters.Add("@ConversationId", SqlDbType.Int).Value = (Object)Message.ConversationId ?? DBNull.Value;
                    command.Parameters.Add("@Comment", SqlDbType.NVarChar).Value = (Object)Message.Comment ?? DBNull.Value;
                    command.Parameters.Add("@Enterdate", SqlDbType.DateTime).Value = Message.Enterdate;
                    command.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = Message.UserId;
                    command.Parameters.Add("@username", SqlDbType.NVarChar).Value = Message.Username;
                    command.Parameters.Add("@IsRead", SqlDbType.Bit).Value = Message.IsRead;
                    command.Parameters.Add("@DomainId", SqlDbType.Int).Value = Message.DomainId;
                    command.Parameters.Add("@LanguageId", SqlDbType.Int).Value = Message.LanguageId;

                    connection.Open();
                    Int32 result = ExecuteNonQuery(command);
                    return result == 1;
                }
            }
        }

        public override List<Chat_MessageDetails> GetChat_MessageByConversationId(Int32? conersationId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT * FROM Chat_Message WHERE (ConversationId = @ConversationId)";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@ConversationId", SqlDbType.NVarChar).Value = (Object)conersationId ?? DBNull.Value;
                    connection.Open();
                    return GetChat_MessageCollectionFromDataReader(ExecuteReader(command));
                }

            }
        }

        public override List<Chat_MessageDetails> GetChat_MessageByConversationIdAndEnterDate(Int32? conersationId , DateTime enterDate)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT * FROM Chat_Message WHERE (ConversationId = @ConversationId and enterDate = @enterDate)";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@ConversationId", SqlDbType.NVarChar).Value = (Object)conersationId ?? DBNull.Value;
                    command.Parameters.Add("@enterDate", SqlDbType.DateTime).Value = enterDate;
                    connection.Open();
                    return GetChat_MessageCollectionFromDataReader(ExecuteReader(command));
                }

            }
        }
        public override List<Chat_MessageDetails> GetChat_MessageByConversationIdAndUserIdAndIsRead(Int32? conersationId, Guid userId, Boolean isRead)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT * FROM Chat_Message WHERE ConversationId = @ConversationId And UserId = @UserId And  IsRead = @IsRead";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@ConversationId", SqlDbType.NVarChar).Value = (Object)conersationId ?? DBNull.Value;
                    command.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = userId;
                    command.Parameters.Add("@IsRead", SqlDbType.Bit).Value = isRead;
                    connection.Open();
                    return GetChat_MessageCollectionFromDataReader(ExecuteReader(command));
                }

            }
        }


        public override List<Chat_MessageDetails> GetChat_MessageByConversationIdAndUserId(Int32? conersationId, Guid userId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT * FROM Chat_Message WHERE ConversationId = @ConversationId and UserId = @UserId ";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@ConversationId", SqlDbType.NVarChar).Value = (Object)conersationId ?? DBNull.Value;
                    command.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = userId;
                    connection.Open();
                    return GetChat_MessageCollectionFromDataReader(ExecuteReader(command));
                }

            }
        }
        #endregion

        #region Chat_Part()
        public override Int32 Chat_PartInsert(Chat_PartDetails Part)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand com = new SqlCommand();
                com.CommandText = @"INSERT INTO Chat_Part (Name,DomainId,LanguageId) values(@Name,@DomainId,@LanguageId)";
                com.Parameters.Clear();


                com.Parameters.Add("@Name", SqlDbType.NVarChar).Value = (Object)Part.Name ?? DBNull.Value;
                com.Parameters.Add("@DomainId", SqlDbType.Int).Value = Part.DomainId;
                com.Parameters.Add("@LanguageId", SqlDbType.Int).Value = Part.LanguageId;

                com.Connection = connection;
                connection.Open();
                int result = com.ExecuteNonQuery();
                connection.Close();
                return result;
            }
        }

        public override Boolean Chat_PartUpdate(Chat_PartDetails Part)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("Update Chat_Part set   Name=@Name , DomainId=@DomainId, LanguageId=@LanguageId   where PartId=@PartId ", connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.Clear();
                    command.Parameters.Add("@PartId", SqlDbType.Int).Value = Part.PartId;
                    command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = (Object)Part.Name ?? DBNull.Value;
                    command.Parameters.Add("@DomainId", SqlDbType.Int).Value = Part.DomainId;
                    command.Parameters.Add("@LanguageId", SqlDbType.Int).Value = Part.LanguageId;

                    connection.Open();
                    Int32 result = ExecuteNonQuery(command);
                    return result == 1;
                }
            }
        }

        public override List<Chat_PartDetails> GetChat_PartGetAllOrderPartId()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT * FROM Chat_Part order by PartId desc ";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                   
                    connection.Open();
                    return GetChat_PartCollectionFromDataReader(ExecuteReader(command));
                }

            }
        }

        #endregion

        #region Chat_Responder()
        public override Int32 Chat_ResponderInsert(Chat_ResponderDetails Responder)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand com = new SqlCommand();
                com.CommandText = @"INSERT INTO Chat_Responder (PartId,UserName,UserId,DomainId,Language) values(@PartId,@UserName, @UserId,@DomainId,@Language)";
                com.Parameters.Clear();


                com.Parameters.Add("@PartId", SqlDbType.Int).Value = (Object)Responder.PartId ?? DBNull.Value;
                com.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = (Object)Responder.UserName ?? DBNull.Value;
                com.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = (Object)Responder.UserId ?? DBNull.Value;
                com.Parameters.Add("@DomainId", SqlDbType.Int).Value = Responder.DomainId;
                com.Parameters.Add("@Language", SqlDbType.Int).Value = Responder.Language;

                com.Connection = connection;
                connection.Open();
                int result = com.ExecuteNonQuery();
                connection.Close();
                return result;
            }
        }

        public override Boolean Chat_ResponderUpdate(Chat_ResponderDetails Responder)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("Update Chat_Responder set   PartId=@PartId,UserName=@UserName,UserId=@UserId , DomainId=@DomainId, Language=@Language   where ResponderId=@ResponderId ", connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.Clear();
                    command.Parameters.Add("@ResponderId", SqlDbType.Int).Value = Responder.ResponderId;
                    command.Parameters.Add("@PartId", SqlDbType.Int).Value = (Object)Responder.PartId ?? DBNull.Value;
                    command.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = (Object)Responder.UserName ?? DBNull.Value;
                    command.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = (Object)Responder.UserId ?? DBNull.Value;
                    command.Parameters.Add("@DomainId", SqlDbType.Int).Value = Responder.DomainId;
                    command.Parameters.Add("@Language", SqlDbType.Int).Value = Responder.Language;

                    connection.Open();
                    Int32 result = ExecuteNonQuery(command);
                    return result == 1;
                }
            }
        }

        public override List<Chat_ResponderDetails> GetChat_ResponderByPartId(Int32 partid)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT * FROM Chat_Responder WHERE (partid = @partid)";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@partid", SqlDbType.Int).Value = partid;
                    connection.Open();
                    return GetChat_ResponderCollectionFromDataReader(ExecuteReader(command));
                }

            }
       
        }
        

        #endregion

    }
}
