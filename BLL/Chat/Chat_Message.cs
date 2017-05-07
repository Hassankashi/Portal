using System;
using System.Linq;
using System.Collections.Generic;
using Pine.Dal;
using Pine.Dal.Chat;

namespace Pine.Bll.Chat
{
   public  class Chat_Message : BaseChat
    {
        #region Constructors (2)


        public Chat_Message(Int64 messageId, Int32? conversationId, String comment, DateTime enterdate,Guid userId, String username, Boolean isRead, Int32 domainId, Int32 languageId)
        {
          
            MessageId  =messageId;
            ConversationId = conversationId;
            Comment = comment;
            Enterdate = enterdate;
            UserId = userId;
            Username = username;
            IsRead = isRead;
            DomainId = domainId;
            LanguageId = languageId;

        }

        public Chat_Message()
        {
            CacheDuration = Settings.CacheDuration;
            MasterCacheKey = "Chat";
        }

        #endregion Constructors

        #region Properties (9)

        public Int64 MessageId { get; set; } 

        public Int32? ConversationId { get; set; }

        public String Comment { get; set; }

        public DateTime Enterdate { get; set; }

        public Guid UserId { get; set; }

        public String Username { get; set; }

        public Boolean IsRead { get; set; }

        public Int32 DomainId { get; set; }

        public Int32 LanguageId { get; set; }

        #endregion Properties

        #region Methods(3)

        //*** Mahsa Count message Comment 

        public static Int32 GetChat_CountConversationByConversationIDAnduserID(Int32? conversationId, Guid userId)
        {
            return SiteProvider.Chat.GetChat_CountConversationByConversationIDAnduserID(conversationId, userId);
        }

        public static List<Chat_Message> GetChat_MessageByConversationId(Int32? conersationId)
        {
            List<Chat_Message> item;

            String key = "Chat_Message_conersationId_" + conersationId;

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as List<Chat_Message>;
                if (item == null)
                {
                    List<Chat_MessageDetails> recordSet = SiteProvider.Chat.GetChat_MessageByConversationId(conersationId);
                    item = GetChat_MessageCollectionFromOrderDal(recordSet);
                    AddCacheItem(key, item);
                }
            }
            else
            {
                List<Chat_MessageDetails> recordSet = SiteProvider.Chat.GetChat_MessageByConversationId(conersationId);
                item = GetChat_MessageCollectionFromOrderDal(recordSet);
            }
            return item;
        }

        public static List<Chat_Message> GetChat_MessageByConversationIdAndEnterDate(Int32? conersationId, DateTime enterDate)
        {
            List<Chat_Message> item;

            String key = "Chat_Message_conersationId_enetrDate" + conersationId + enterDate;

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as List<Chat_Message>;
                if (item == null)
                {
                    List<Chat_MessageDetails> recordSet = SiteProvider.Chat.GetChat_MessageByConversationIdAndEnterDate(conersationId, enterDate);
                    item = GetChat_MessageCollectionFromOrderDal(recordSet);
                    AddCacheItem(key, item);
                }
            }
            else
            {
                List<Chat_MessageDetails> recordSet = SiteProvider.Chat.GetChat_MessageByConversationIdAndEnterDate(conersationId, enterDate);
                item = GetChat_MessageCollectionFromOrderDal(recordSet);
            }
            return item;
        }


        public static List<Chat_Message> GetChat_MessageByConversationIdAndUserId(Int32? conersationId, Guid userId)
        {
            List<Chat_Message> item;

            String key = "Chat_Message_conersationId_UserId" + conersationId + userId;

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as List<Chat_Message>;
                if (item == null)
                {
                    List<Chat_MessageDetails> recordSet = SiteProvider.Chat.GetChat_MessageByConversationIdAndUserId(conersationId,userId);
                    item = GetChat_MessageCollectionFromOrderDal(recordSet);
                    AddCacheItem(key, item);
                }
            }
            else
            {
                List<Chat_MessageDetails> recordSet = SiteProvider.Chat.GetChat_MessageByConversationIdAndUserId(conersationId, userId);
                item = GetChat_MessageCollectionFromOrderDal(recordSet);
            }
            return item;
        }

        public static List<Chat_Message> GetChat_MessageByConversationIdAndUserIdAndIsRead(Int32? conersationId, Guid userId, Boolean isRead)
        {
            List<Chat_Message> item;

            String key = "Chat_Message_conersationId_UserId_isRead" + conersationId + userId + isRead;

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as List<Chat_Message>;
                if (item == null)
                {
                    List<Chat_MessageDetails> recordSet = SiteProvider.Chat.GetChat_MessageByConversationIdAndUserIdAndIsRead(conersationId, userId,isRead);
                    item = GetChat_MessageCollectionFromOrderDal(recordSet);
                    AddCacheItem(key, item);
                }
            }
            else
            {
                List<Chat_MessageDetails> recordSet = SiteProvider.Chat.GetChat_MessageByConversationIdAndUserIdAndIsRead(conersationId, userId,isRead);
                item = GetChat_MessageCollectionFromOrderDal(recordSet);
            }
            return item;
        }



        public Int32  Chat_MessageInsert()  
        {
            return Chat_MessageInsert(MessageId,  ConversationId,  Comment,  Enterdate, UserId,  Username,  IsRead, DomainId, LanguageId);
        }

        private Int32 Chat_MessageInsert(Int64 messageId, Int32? conversationId, String comment, DateTime enterdate,Guid userId, String username, Boolean isRead, Int32 domainId, Int32 languageId)
        {
            Chat_MessageDetails Message = new Chat_MessageDetails( messageId,  conversationId,  comment,  enterdate, userId,  username,  isRead, domainId, languageId);
            Int32 ret = SiteProvider.Chat.Chat_MessageInsert(Message);
            if (Settings.EnableCaching & ret > 0)
                InvalidateCache();
            return ret;
        }

        public Boolean Chat_MessageUpdate()
        {
            return Chat_MessageUpdate(MessageId, ConversationId, Comment, Enterdate, UserId, Username, IsRead, DomainId, LanguageId);
        }

        private Boolean Chat_MessageUpdate(Int64 messageId, Int32? conversationId, String comment, DateTime enterdate, Guid userId, String username, Boolean isRead, Int32 domainId, Int32 languageId)
        {
            Chat_MessageDetails Message = new Chat_MessageDetails(messageId, conversationId, comment, enterdate, userId, username, isRead, domainId, languageId);
            Boolean ret = SiteProvider.Chat.Chat_MessageUpdate(Message);
            if (Settings.EnableCaching & ret)
                InvalidateCache();
            return ret;
        }





        //    /// <summary>
        //    /// تبدیل داده های لایه دیتا به داده های لایه تجاری 
        //    /// </summary>
        //    /// <param name="records">رکوردهای ورودی حاوی داده های لایه دیتا</param>
        //    /// <returns></returns>
        private static List<Chat_Message> GetChat_MessageCollectionFromOrderDal(List<Chat_MessageDetails> records)
        {
            List<Chat_Message> items = new List<Chat_Message>();
            foreach (Chat_MessageDetails item in records)
                items.Add(GetChat_MessageFromOrderDal(item));
            return items;
        }

        /// <summary>
        /// تبدیل داده لایه دیتا به داده لایه تجاری
        /// </summary>
        /// <param name="record">رکورد ورودی حاوی داده لایه دیتا</param>
        /// <returns></returns>
        private static Chat_Message GetChat_MessageFromOrderDal(Chat_MessageDetails record)
        {
            if (record != null)
                return new Chat_Message(record.MessageId,record.ConversationId,record.Comment,record.Enterdate,record.UserId,record.Username,record.IsRead, record.DomainId, record.LanguageId);
            return null;
        }

        #endregion

    }
}
