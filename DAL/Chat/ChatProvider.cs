using System;
using System.Collections.Generic;
using System.Data;


namespace Pine.Dal.Chat
{
    public abstract class ChatProvider : DataAccess 
    {
        #region Fields (1)

        static private ChatProvider _instance;

        #endregion Fields

        #region Constructors (1)

        /// <summary>
        /// سازنده اصلی کلاس
        /// </summary>
        protected ChatProvider()
        {
            ConnectionString = Globals.Settings.Chat.ConnectionString;
            EnableCaching = Globals.Settings.Chat.EnableCaching;
            CacheDuration = Globals.Settings.Chat.CacheDuration;
        }
         
        #endregion Constructors

        #region Properties (1)

        /// <summary>
        /// Returns an instance of the provider type specified in the config file
        /// </summary>
        static public ChatProvider Instance
        {
            get
            {
                return _instance ?? (_instance = (ChatProvider)Activator.CreateInstance(
                    Type.GetType(Globals.Settings.Chat.ProviderType)));
            }
        }

        #endregion Properties

        #region Chat_Conversation (6)

        //Mahsa List of ConversationID
        public abstract List<Chat_ConversationDetails> GetChat_ConversationByPartId(Int32 partId);
     
        public abstract List<Chat_ConversationDetails> GetChat_ConversationByConversationId(Int32 conersationId);
        public abstract Chat_ConversationDetails GetChat_ConversationBySenderIdOrResposerId(Guid id);
       
        public abstract Chat_ConversationDetails GetChat_ConversationBySenderIdAndReceiverId(Guid senderId,Guid? receiverId);

        public abstract List<Chat_ConversationDetails> GetChat_ConversationBySenderIdAndReceiverIdAndPartId(Guid senderId, Guid? receiverId , Int32 partId);
     
        public abstract Int32 Chat_ConversationInsert(Chat_ConversationDetails Conversation);

        public abstract Boolean Chat_ConversationUpdate(Chat_ConversationDetails Conversation);

        #region Virtual Protected Methods (2)

        protected virtual List<Chat_ConversationDetails> GetChat_ConversationCollectionFromDataReader(IDataReader reader)
        {
            List<Chat_ConversationDetails> items = new List<Chat_ConversationDetails>();
            while (reader.Read())
                items.Add(GetChat_ConversationFromDataReader(reader));
            return items;
        }


        protected virtual Chat_ConversationDetails GetChat_ConversationFromDataReader(IDataReader reader)
        {
            return new Chat_ConversationDetails
                (
                    (Int32)reader["ConversationId"],
                     (Guid)reader["SenderId"],
                   (Guid) reader["ReceiverId"],
                    reader["PartId"] as Int32?,
                    reader["flag"] as Int16?,
                     (Int32)reader["DomainId"],
                      (Int32)reader["LanguageId"]

                );
        }

        #endregion
      
        #endregion

        #region Chat_Message (5)

        //***Mahsa Kashi  ---- Count -----  //** Message Comment
        public abstract Int32 GetChat_CountConversationByConversationIDAnduserID(Int32? conversationId, Guid userId);
       
        public abstract List<Chat_MessageDetails> GetChat_MessageByConversationId(Int32? conersationId);

        public abstract List<Chat_MessageDetails> GetChat_MessageByConversationIdAndEnterDate(Int32? conersationId , DateTime enterDate);
       
        public abstract List<Chat_MessageDetails> GetChat_MessageByConversationIdAndUserId(Int32? conersationId, Guid userId);

       public abstract List<Chat_MessageDetails> GetChat_MessageByConversationIdAndUserIdAndIsRead(Int32? conersationId, Guid userId, Boolean isRead);
      
       public abstract Int32 Chat_MessageInsert( Chat_MessageDetails  Message);

       public abstract Boolean Chat_MessageUpdate(Chat_MessageDetails Message);

       protected virtual List<Chat_MessageDetails> GetChat_MessageCollectionFromDataReader(IDataReader reader)
       {
           List<Chat_MessageDetails> items = new List<Chat_MessageDetails>();
           while (reader.Read())
               items.Add(GetChat_MessageFromDataReader(reader));
           return items;
       }


       protected virtual Chat_MessageDetails GetChat_MessageFromDataReader(IDataReader reader)
       {
           return new Chat_MessageDetails
               (
                   (Int64)reader["MessageId"],
                   reader["ConversationId"] as Int32?,
                    reader["Comment"].ToString(),
                    (DateTime)reader["Enterdate"],
                     (Guid)reader["UserId"],
                      reader["username"].ToString(),
                    (Boolean)reader["IsRead"],
                    (Int32)reader["DomainId"],
                     (Int32)reader["LanguageId"] );
       }




        #endregion

        #region Chat_Part(3)

        public abstract List<Chat_PartDetails> GetChat_PartGetAllOrderPartId(); 

        public abstract Int32 Chat_PartInsert(Chat_PartDetails Part);

        public abstract Boolean Chat_PartUpdate(Chat_PartDetails Part);

        #region Virtual Protected Methods (2)

        protected virtual List<Chat_PartDetails> GetChat_PartCollectionFromDataReader(IDataReader reader)
        {
            List<Chat_PartDetails> items = new List<Chat_PartDetails>();
            while (reader.Read())
                items.Add(GetChat_PartFromDataReader(reader));
            return items;
        }


        protected virtual Chat_PartDetails GetChat_PartFromDataReader(IDataReader reader)
        {
            return new Chat_PartDetails
                (
                    (Int32)reader["PartId"],
                      reader["Name"].ToString(),
                     (Int32)reader["DomainId"],
                      (Int32)reader["LanguageId"]

                );
        }

        #endregion

        #endregion

        #region Chat_Responer(3)


       
        public abstract List<Chat_ResponderDetails> GetChat_ResponderByPartId(Int32 partid);

        public abstract Int32 Chat_ResponderInsert(Chat_ResponderDetails Responder);

        public abstract Boolean Chat_ResponderUpdate(Chat_ResponderDetails Responder);

        #region Virtual Protected Methods (2)

        protected virtual List<Chat_ResponderDetails> GetChat_ResponderCollectionFromDataReader(IDataReader reader)  
        {
            List<Chat_ResponderDetails> items = new List<Chat_ResponderDetails>();
            while (reader.Read())
                items.Add(GetChat_ResponderFromDataReader(reader));
            return items;
        }


        protected virtual Chat_ResponderDetails GetChat_ResponderFromDataReader(IDataReader reader)
        {
            return new Chat_ResponderDetails
                (
                    (Int32)reader["ResponderId"],
                    reader["PartId"] as Int32?,
                     reader["UserName"].ToString(),
                    reader["UserId"] as Guid?,
                     (Int32)reader["DomainId"],
                      (Int32)reader["Language"]

                );
        }

        #endregion

        #endregion

        
    }
}
