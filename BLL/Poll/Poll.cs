using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pine.Dal;
using Pine.Dal.Poll;

namespace Pine.Bll.Poll
{
   public class Poll : BasePoll
     {
        public Poll(Int32 pollId, String pollName, Boolean isActive, DateTime enterDate, Int32 pollNameMenuId, Int32 languageId, Int32 domainId)
        {
            PollId = pollId;
            PollName = pollName;
            IsActive = isActive;
            EnterDate = enterDate;
            PollNameMenuId = pollNameMenuId;
            LanguageId = languageId;
            DomainId = domainId;
        }

       public Poll()
       {
       }

       #region properties

       public Int32 PollId { get; set; }
       public String PollName { get; set; }
       public Boolean IsActive { get; set; }
       public DateTime EnterDate { get; set; }
       public Int32 PollNameMenuId { get; set; }
       public Int32 LanguageId { get; set; }
       public Int32 DomainId { get; set; }

#endregion

#region Methods


        public static Poll GetPollByActive(bool active)
        {
            Poll item;
            SetCache();
            String key = "Poll_active_" + active;

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as Poll;
                if (item == null)
                {
                  PollDetails  record = SiteProvider.Poll.GetPollByActive(active);
                  item = GetPollFromOrderDal(record);
                   AddCacheItem(key, item);
                }
            }
            else
            {
                PollDetails recordSet = SiteProvider.Poll.GetPollByActive(active);
                item = GetPollFromOrderDal(recordSet);
            }

            return item;
        }


        public static Poll GetPollByPollId(Int32 id)
        {
            Poll item;
            SetCache();
            String key = "Poll_PollId_" + id;

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as Poll;
                if (item == null)
                {
                    PollDetails record = SiteProvider.Poll.GetPollByPollId(id);
                    item = GetPollFromOrderDal(record);
                    AddCacheItem(key, item);
                }
            }
            else
            {
                PollDetails recordSet = SiteProvider.Poll.GetPollByPollId(id);
                item = GetPollFromOrderDal(recordSet);
            }

            return item;
        }
        public static List<Poll> GetPollByDomainId(Int32 domainId, Int32 languageId)
        {

            SetCache();
            List<Poll> item;

            String key = "Poll_domainId_languageId_" + domainId + "_" + languageId;

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as List<Poll>;
                if (item == null)
                {
                    List<PollDetails> recordSet = SiteProvider.Poll.GetPollByDomainId(domainId, languageId);
                    item = GetPollCollectionFromOrderDal(recordSet);
                    AddCacheItem(key, item);
                }
            }
            else
            {
                List<PollDetails> recordSet = SiteProvider.Poll.GetPollByDomainId(domainId, languageId);
                item = GetPollCollectionFromOrderDal(recordSet);
            }
            return item;
        }

        public Int32 Insert()
        {
            return Insert(PollId,PollName,IsActive,EnterDate,PollNameMenuId,LanguageId,DomainId);
        }

        private Int32 Insert(Int32 pollId, String pollName, Boolean isActive, DateTime enterDate, Int32 pollNameMenuId, Int32 languageId, Int32 domainId)
        {
            PollDetails poll = new PollDetails(pollId, pollName, isActive, enterDate, pollNameMenuId, languageId, domainId);
            Int32 ret = SiteProvider.Poll.InsertPoll(poll);
            if (Settings.EnableCaching & ret > 0)
            {
                SetCache();
                InvalidateCache();
            }
           
            return ret;
        }

       

        public bool UpdatePoll()
        {
            return UpdatePoll(PollId,PollName,IsActive,EnterDate,PollNameMenuId,LanguageId,DomainId);
        }

        private Boolean UpdatePoll(Int32 pollId, String pollName, Boolean isActive, DateTime enterDate, Int32 pollNameMenuId, Int32 languageId, Int32 domainId)
        {
            PollDetails poll = new PollDetails(pollId, pollName, isActive, enterDate, pollNameMenuId, languageId, domainId);
            Boolean ret = SiteProvider.Poll.UpdatePoll(poll);
            if (Settings.EnableCaching & ret)
            {
                SetCache();
                InvalidateCache();
            }
            return ret;
        }


        /// <summary>
        /// تبدیل داده لایه دیتا به داده لایه تجاری
        /// </summary>
        /// <param name="record">رکورد ورودی حاوی داده لایه دیتا</param>
        /// <returns></returns>
        private static Poll GetPollFromOrderDal(PollDetails record)
        {
            if (record != null)
                return new Poll(record.PollId,record.PollName,record.IsActive,record.EnterDate,record.PollNameMenuId,record.LanguageId,record.DomainId);
            return null;
        }
        private static List<Poll> GetPollCollectionFromOrderDal(List<PollDetails> records)
        {
            List<Poll> items = new List<Poll>();
            foreach (PollDetails item in records)
                items.Add(GetPollFromOrderDal(item));
            return items;
        }

#endregion

       
     }
}
