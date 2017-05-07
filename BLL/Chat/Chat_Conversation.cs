using System;
using System.Linq;
using System.Collections.Generic;
using Pine.Dal;
using Pine.Dal.Chat;

namespace Pine.Bll.Chat
{
    /// <summary>
    /// کلاسی برای نگهداری منو
    /// </summary>
    public class Chat_Conversation : BaseChat
    {
        
        #region Constructors (2)

        public Chat_Conversation(Int32 conversationId, Guid senderId, Guid receiverId, Int32? partId, Int16? flag, Int32 domainId, Int32 languageId)
        {
            ConversationId = conversationId;
            SenderId = senderId;
            ReceiverId = receiverId;
            PartId = partId;
            Flag = flag;
            DomainId = domainId;
            LanguageId = languageId;

        }
        /// <summary>
        /// سازنده پیش فرض کلاس جزئیات تنظیمات طرح
        /// </summary>
        public Chat_Conversation()
        {
            CacheDuration = Settings.CacheDuration;
            MasterCacheKey = "Chat";
       }

       #endregion Constructors

        #region Properties (4)

        public Int32 ConversationId { get; set; }

        public Guid SenderId { get; set; }

        public Guid ReceiverId { get; set; }

        public Int32? PartId { get; set; }

        public Int16? Flag { get; set; }

        public Int32 DomainId { get; set; }

        public Int32 LanguageId { get; set; }
        #endregion Properties

        #region Methods(3)

        //Mahsa List of ConversationID
        public static List<Chat_Conversation> GetChat_ConversationByPartId(Int32 partId)
        {
            SetCache();
            List<Chat_Conversation> item;

            String key = "Chat_Conversation_PartId_" + partId;

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as List<Chat_Conversation>;
                if (item == null)
                {
                    List<Chat_ConversationDetails> recordSet = SiteProvider.Chat.GetChat_ConversationByPartId(partId);
                    item = GetChat_ConversationCollectionFromOrderDal(recordSet);
                    AddCacheItem(key, item);
                }
            }
            else
            {
                List<Chat_ConversationDetails> recordSet = SiteProvider.Chat.GetChat_ConversationByPartId(partId);
                item = GetChat_ConversationCollectionFromOrderDal(recordSet);
            }
            return item;
        }

        public static List<Chat_Conversation> GetChat_ConversationByConversationId(Int32 conersationId)
        {
            List<Chat_Conversation> item;

            String key = "Chat_Conversation_conersationId_" + conersationId;

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as List<Chat_Conversation>;
                if (item == null)
                {
                    List<Chat_ConversationDetails> recordSet = SiteProvider.Chat.GetChat_ConversationByConversationId(conersationId);
                    item = GetChat_ConversationCollectionFromOrderDal(recordSet);
                    AddCacheItem(key, item);
                }
            }
            else
            {
                List<Chat_ConversationDetails> recordSet = SiteProvider.Chat.GetChat_ConversationByConversationId(conersationId);
                item = GetChat_ConversationCollectionFromOrderDal(recordSet);
            }
            return item;
        }

       public static Chat_Conversation GetChat_ConversationBySenderIdAndReceiverId(Guid senderId, Guid? receiverId)
        {
            SetCache();
            Chat_Conversation item;

            String key = "Chat_Conversation_conersationId_receiverId" + senderId +"_"+ receiverId;

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as Chat_Conversation;
                if (item == null)
                {
                    Chat_ConversationDetails recordSet = SiteProvider.Chat.GetChat_ConversationBySenderIdAndReceiverId(senderId, receiverId);
                    item = GetChat_ConversationFromOrderDal(recordSet);
                    if (recordSet!=null)
                    {
                        AddCacheItem(key, item);
                    }
                   
                }
            }
            else
            {
                Chat_ConversationDetails recordSet = SiteProvider.Chat.GetChat_ConversationBySenderIdAndReceiverId(senderId, receiverId);
                item = GetChat_ConversationFromOrderDal(recordSet);
            }
            return item;
        }

    
       public static Chat_Conversation GetChat_ConversationBySenderIdOrResponserId(Guid id)
       {
           Chat_Conversation item;

           String key = "Chat_Conversation_SenderId_ResponserId" + id;

           if (Settings.EnableCaching)
           {
               item = GetCacheItem(key) as Chat_Conversation;
               if (item == null)
               {
                   Chat_ConversationDetails record = SiteProvider.Chat.GetChat_ConversationBySenderIdOrResposerId(id);
                   item = GetChat_ConversationFromOrderDal(record);
                   AddCacheItem(key, item);
               }
           }
           else
           {
               Chat_ConversationDetails record = SiteProvider.Chat.GetChat_ConversationBySenderIdOrResposerId(id);
               item = GetChat_ConversationFromOrderDal(record);
           }
           return item;
       }


       public static List<Chat_Conversation> GetChat_ConversationBySenderIdAndReceiverIdAndPartId(Guid senderId, Guid? receiverId , Int32 partId)
       {
           List<Chat_Conversation> item;

           String key = "Chat_Conversation_conersationId_receiverId_partId" + senderId + receiverId + partId ;

           if (Settings.EnableCaching)
           {
               item = GetCacheItem(key) as List<Chat_Conversation>;
               if (item == null)
               {
                   List<Chat_ConversationDetails> recordSet = SiteProvider.Chat.GetChat_ConversationBySenderIdAndReceiverIdAndPartId(senderId, receiverId , partId);
                   item = GetChat_ConversationCollectionFromOrderDal(recordSet);
                   AddCacheItem(key, item);
               }
           }
           else
           {
               List<Chat_ConversationDetails> recordSet = SiteProvider.Chat.GetChat_ConversationBySenderIdAndReceiverIdAndPartId(senderId, receiverId, partId);
               item = GetChat_ConversationCollectionFromOrderDal(recordSet);
           }
           return item;
       }

        public  Int32 Chat_ConversationInsert()
        {
            return Chat_ConversationInsert(ConversationId, SenderId, ReceiverId, PartId, Flag, DomainId, LanguageId);
        }



        private Int32 Chat_ConversationInsert(Int32 conversationId, Guid senderId, Guid receiverId, Int32? partId, Int16? flag, Int32 domainId, Int32 languageId)
        {
            Chat_ConversationDetails Conversation = new Chat_ConversationDetails(conversationId, senderId, receiverId, partId, flag, domainId, languageId);
            Int32 ret = SiteProvider.Chat.Chat_ConversationInsert(Conversation);
            if (Settings.EnableCaching & ret > 0)
                InvalidateCache();
            return ret;
        }

        public Boolean Chat_ConversationUpdate()
        {
            return Chat_ConversationUpdate(ConversationId, SenderId, ReceiverId, PartId, Flag, DomainId, LanguageId);
        }

        private Boolean Chat_ConversationUpdate(Int32 conversationId, Guid senderId, Guid receiverId, Int32? partId, Int16? flag, Int32 domainId, Int32 languageId)
        {
            Chat_ConversationDetails Conversation = new Chat_ConversationDetails(conversationId, senderId, receiverId, partId, flag, domainId, languageId);
            Boolean ret = SiteProvider.Chat.Chat_ConversationUpdate(Conversation);
            if (Settings.EnableCaching & ret)
                InvalidateCache();
            return ret;
        }

    

       

    //    /// <summary>
    //    /// تبدیل داده های لایه دیتا به داده های لایه تجاری 
    //    /// </summary>
    //    /// <param name="records">رکوردهای ورودی حاوی داده های لایه دیتا</param>
    //    /// <returns></returns>
        private static List<Chat_Conversation> GetChat_ConversationCollectionFromOrderDal(List<Chat_ConversationDetails> records)
        {
            List<Chat_Conversation> items = new List<Chat_Conversation>();
            foreach (Chat_ConversationDetails item in records)
                items.Add(GetChat_ConversationFromOrderDal(item));
            return items;
        }

        /// <summary>
        /// تبدیل داده لایه دیتا به داده لایه تجاری
        /// </summary>
        /// <param name="record">رکورد ورودی حاوی داده لایه دیتا</param>
        /// <returns></returns>
        private static Chat_Conversation GetChat_ConversationFromOrderDal(Chat_ConversationDetails record)
        {
            if (record != null)
                return new Chat_Conversation(record.ConversationId,record.SenderId,record.ReceiverId,record.PartId,record.Flag,record.DomainId,record.LanguageId);
            return null;
        }

       #endregion
    }
}
