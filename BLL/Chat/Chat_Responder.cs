using System;
using System.Linq;
using System.Collections.Generic;
using Pine.Dal;
using Pine.Dal.Chat;

namespace Pine.Bll.Chat
{
  public  class Chat_Responder : BaseChat
    {
          #region Constructors (2)


       public Chat_Responder(Int32 responderId, Int32? partId, String userName, Guid? userId, Int32 domainId, Int32 language) 
        {
            ResponderId = responderId;  
            PartId = partId;
            UserName = userName;
            UserId = userId;
            DomainId = domainId;
            Language = language;

        }

        public Chat_Responder()
        {
            CacheDuration = Settings.CacheDuration;
            MasterCacheKey = "Chat";
        }

        #endregion Constructors

        #region Properties (6)

        public Int32 ResponderId { get; set; }

        public String UserName { get; set; }

        public Int32? PartId { get; set; }

        public Guid? UserId { get; set; } 
       

        public Int32 DomainId { get; set; }

        public Int32 Language { get; set; }

        #endregion Properties

        #region Methods(3)

        public static List<Chat_Responder> GetChat_ResponderByPartId(Int32 partid)
        {
            List<Chat_Responder> item;

            String key = "Chat_Responder_PartId_" + partid;

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as List<Chat_Responder>;
                if (item == null)
                {
                    List<Chat_ResponderDetails> recordSet = SiteProvider.Chat.GetChat_ResponderByPartId(partid);
                    item = GetChat_ResponderCollectionFromOrderDal(recordSet);
                    AddCacheItem(key, item);
                }
            }
            else
            {
                List<Chat_ResponderDetails> recordSet = SiteProvider.Chat.GetChat_ResponderByPartId(partid);
                item = GetChat_ResponderCollectionFromOrderDal(recordSet);
            }
            return item;
        }



        public Int32 Chat_ResponderInsert()
        {
            return Chat_ResponderInsert(ResponderId,  PartId,  UserName,  UserId,  DomainId, Language);
        }

        private Int32 Chat_ResponderInsert(Int32 responderId, Int32? partId, String userName, Guid? userId, Int32 domainId, Int32 languageId)
        {
            Chat_ResponderDetails Responder = new Chat_ResponderDetails( responderId,  partId,  userName,  userId,  domainId, languageId);
            Int32 ret = SiteProvider.Chat.Chat_ResponderInsert(Responder);
            if (Settings.EnableCaching & ret > 0)
                InvalidateCache();
            return ret;
        }

        public Boolean Chat_ResponderUpdate()
        {
            return Chat_ResponderUpdate(ResponderId, PartId, UserName, UserId, DomainId, Language); 
        }

        private Boolean Chat_ResponderUpdate(Int32 responderId, Int32? partId, String userName, Guid? userId, Int32 domainId, Int32 languageId)
        {
            Chat_ResponderDetails Responder = new Chat_ResponderDetails(responderId, partId, userName, userId, domainId, languageId);
            Boolean ret = SiteProvider.Chat.Chat_ResponderUpdate(Responder);
            if (Settings.EnableCaching & ret)
                InvalidateCache();
            return ret;
        }





        //    /// <summary>
        //    /// تبدیل داده های لایه دیتا به داده های لایه تجاری 
        //    /// </summary>
        //    /// <param name="records">رکوردهای ورودی حاوی داده های لایه دیتا</param>
        //    /// <returns></returns>
        private static List<Chat_Responder> GetChat_ResponderCollectionFromOrderDal(List<Chat_ResponderDetails> records)
        {
            List<Chat_Responder> items = new List<Chat_Responder>();
            foreach (Chat_ResponderDetails item in records)
                items.Add(GetChat_ResponderFromOrderDal(item));
            return items;
        }

        /// <summary>
        /// تبدیل داده لایه دیتا به داده لایه تجاری
        /// </summary>
        /// <param name="record">رکورد ورودی حاوی داده لایه دیتا</param>
        /// <returns></returns>
        private static Chat_Responder GetChat_ResponderFromOrderDal(Chat_ResponderDetails record)
        {
            if (record != null)
                return new Chat_Responder(record.ResponderId, record.PartId, record.UserName, record.UserId, record.DomainId, record.Language);
            return null;
        }

        #endregion
    }
}
