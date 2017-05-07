using System;
using System.Linq;
using System.Collections.Generic;
using Pine.Dal;
using Pine.Dal.Chat;

namespace Pine.Bll.Chat
{
   public  class Chat_Part: BaseChat
    {
         #region Constructors (2)


        public Chat_Part(Int32 partId, String name, Int32 domainId, Int32 languageId) 
        {
           PartId = partId;
            Name  = name;
            DomainId = domainId;
            LanguageId = languageId;

        }

        public Chat_Part()
        {
            CacheDuration = Settings.CacheDuration;
            MasterCacheKey = "Chat";
        }

        #endregion Constructors

        #region Properties (4)

        public Int32 PartId { get; set; }

        public String Name { get; set; }

        public Int32 DomainId { get; set; }

        public Int32 LanguageId { get; set; }

        #endregion Properties

        #region Methods(3)


        public List<Chat_Part> GetChat_PartGetAllOrderPartId()
        {
            List<Chat_Part> item;

            String key = "Chat_Message_GetAll" ;

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as List<Chat_Part>;
                if (item == null)
                {
                    List<Chat_PartDetails> recordSet = SiteProvider.Chat.GetChat_PartGetAllOrderPartId();
                    item = GetChat_PartCollectionFromOrderDal(recordSet);
                    AddCacheItem(key, item);
                }
            }
            else
            {
                List<Chat_PartDetails> recordSet = SiteProvider.Chat.GetChat_PartGetAllOrderPartId();
                item = GetChat_PartCollectionFromOrderDal(recordSet);
            }
            return item;
        }
        public Int32 Chat_PartInsert()
        {
            return Chat_PartInsert( PartId, Name, DomainId, LanguageId);
        }

        private Int32 Chat_PartInsert(Int32 partId, String name, Int32 domainId, Int32 languageId)
        {
            Chat_PartDetails Part = new Chat_PartDetails(PartId, Name, DomainId, LanguageId);
            Int32 ret = SiteProvider.Chat.Chat_PartInsert(Part);
            if (Settings.EnableCaching & ret > 0)
                InvalidateCache();
            return ret;
        }
        public Boolean Chat_PartUpdate()
        {
            return Chat_PartUpdate(PartId, Name, DomainId, LanguageId);
        }

        private Boolean Chat_PartUpdate(Int32 partId, String name, Int32 domainId, Int32 languageId)
        {
            Chat_PartDetails Part = new Chat_PartDetails(partId, name, domainId, languageId);
            Boolean ret = SiteProvider.Chat.Chat_PartUpdate(Part);
            if (Settings.EnableCaching & ret)
                InvalidateCache();
            return ret;
        }



     



        //    /// <summary>
        //    /// تبدیل داده های لایه دیتا به داده های لایه تجاری 
        //    /// </summary>
        //    /// <param name="records">رکوردهای ورودی حاوی داده های لایه دیتا</param>
        //    /// <returns></returns>
        private static List<Chat_Part> GetChat_PartCollectionFromOrderDal(List<Chat_PartDetails> records)
        {
            List<Chat_Part> items = new List<Chat_Part>();
            foreach (Chat_PartDetails item in records)                      
                items.Add(GetChat_PartFromOrderDal(item));
            return items;
        }

        /// <summary>
        /// تبدیل داده لایه دیتا به داده لایه تجاری
        /// </summary>
        /// <param name="record">رکورد ورودی حاوی داده لایه دیتا</param>
        /// <returns></returns>
        private static Chat_Part GetChat_PartFromOrderDal(Chat_PartDetails record)
        {
            if (record != null)
                return new Chat_Part(record.PartId,record.Name,record.DomainId,record.LanguageId);
            return null;
        }

        #endregion
    }

     
}
