using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pine.Dal;
using Pine.Dal.Poll;

namespace Pine.Bll.Poll
{
    public class PollItem : BasePoll
    {

#region constructor
     
       public PollItem(Int32 pollItemId, Int32 pollId, String answer, Int32 vote)
       {
           PollItemId = pollItemId;
           PollId = pollId;
           Answer = answer;
           Vote = vote;
       }

       public PollItem()
       {
       }

       #endregion constructor

#region Properties

       public Int32 PollItemId { get; set; }
       public Int32 PollId{ get; set; }
       public String Answer{ get; set; }
       public Int32 Vote{ get; set; }
       #endregion Properties

#region Method
       public static List<PollItem> GetPollItemByPollId(Int32 pollId)
       {
           List<PollItem> item;

           String key = "PollItem_pollId" + pollId;

           if (Settings.EnableCaching)
           {

               item = GetCacheItem(key) as List<PollItem>;
               if (item == null)
               {
                   List<PollItemDetails> recordSet = SiteProvider.Poll.GetPollItemByPollId(pollId);
                   item = GetPollItemCollectionFromOrderDal(recordSet);
                   AddCacheItem(key, item);
               }
           }
           else
           {
               List<PollItemDetails> recordSet = SiteProvider.Poll.GetPollItemByPollId(pollId);
               item = GetPollItemCollectionFromOrderDal(recordSet);
           }
           return item;
       }

       public static PollItem GetPollItemByPollItemId(Int32 pollItemId)
       {
           PollItem item;

           String key = "PollItem_pollItemId" + pollItemId;

           if (Settings.EnableCaching)
           {

               item = GetCacheItem(key) as PollItem;
               if (item == null)
               {
                   PollItemDetails recordSet = SiteProvider.Poll.GetPollItemByPollItemId(pollItemId);
                   item = GetPollItemFromOrderDal(recordSet);
                   AddCacheItem(key, item);
               }
           }
           else
           {
               PollItemDetails record = SiteProvider.Poll.GetPollItemByPollItemId(pollItemId);
               item = GetPollItemFromOrderDal(record);
           }
           return item;
       }

       public Int32 Insert()
       {
           return Insert(PollItemId, PollId, Answer, Vote);
       }

       private Int32 Insert(Int32 pollItemId, Int32 pollId, String answer, Int32 vote)
       {
           PollItemDetails pollItem = new PollItemDetails(pollItemId,pollId,answer,vote);
           Int32 ret = SiteProvider.Poll.InsertPollItem(pollItem);
           if (Settings.EnableCaching & ret > 0)
               InvalidateCache();
           return ret;
       }



       public bool UpdatePollItem()
       {
           return UpdatePollItem(PollItemId, PollId, Answer, Vote);
       }

       private Boolean UpdatePollItem(Int32 pollItemId, Int32 pollId, String answer, Int32 vote)
       {
           PollItemDetails pollItem = new PollItemDetails(pollItemId, pollId, answer, vote);
           Boolean ret = SiteProvider.Poll.UpdatePollItem(pollItem);
           if (Settings.EnableCaching & ret)
               InvalidateCache();
           return ret;
       }

       public bool DeletePollItem()
       {
           return Delete(PollItemId, PollId, Answer, Vote);
       }

       private bool Delete(Int32 pollItemId, Int32 pollId, String answer, Int32 vote)
       {
           PollItemDetails pollItem = new PollItemDetails(pollItemId, pollId, answer, vote);
           bool ret = SiteProvider.Poll.DeletePollItem(pollItem.PollItemId);
           if (Settings.EnableCaching & ret)
               InvalidateCache();
           return ret;
       }

       /// <summary>
       /// تبدیل داده لایه دیتا به داده لایه تجاری
       /// </summary>
       /// <param name="record">رکورد ورودی حاوی داده لایه دیتا</param>
       /// <returns></returns>
       private static PollItem GetPollItemFromOrderDal(PollItemDetails record)
       {
           if (record != null)
               return new PollItem(record.PollItemId, record.PollId, record.Answer, record.Vote);
           return null;
       }

       private static List<PollItem> GetPollItemCollectionFromOrderDal(List<PollItemDetails> records)
       {
           List<PollItem> items = new List<PollItem>();
           foreach (PollItemDetails item in records)
               items.Add(GetPollItemFromOrderDal(item));
           return items;
       }
#endregion
    }
}
