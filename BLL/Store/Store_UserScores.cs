using System;
using System.Linq;
using System.Collections.Generic;
using Pine.Dal;
using Pine.Dal.Store;
 
namespace Pine.Bll.Store
{
    /// <summary>
    /// کلاسی برای نگهداری منو
    /// </summary>
    public class Store_UserScores : BaseStore
    { 
        
        #region Constructors (2)

        public Store_UserScores(Guid userScoreId, Guid userScoreTitleId, String username, Byte score , Int32 domainId, Int32 languageId)
        {

            UserScoreId = userScoreId;
            UserScoreTitleId = userScoreTitleId;
            Username = username;
            Score = score; 
            DomainId = domainId;
            LanguageId = languageId;

        }



     
        /// <summary>
        /// سازنده پیش فرض کلاس جزئیات تنظیمات طرح
        /// </summary>
        public Store_UserScores() 
        {
            CacheDuration = Settings.CacheDuration;
            MasterCacheKey = "Store";
        }
         
       #endregion Constructors

        #region Properties (4)

        public Guid UserScoreId { get; set; }

        public Guid UserScoreTitleId { get; set; }

        public String Username { get; set; }

        public Byte Score { get; set; }

        public Int32 DomainId { get; set; }

        public Int32 LanguageId { get; set; }
        #endregion Properties

        #region Methods(4)

        public List<Store_UserScores> GetUserScoresById(Guid id)  
        {
            List<Store_UserScores> item;

            String key = "Store_UserScoresId_" + id;
             
            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as List<Store_UserScores>;
                if (item == null)
                {
                    List<Store_UserScoresDetails> recordSet = SiteProvider.Store.GetUserScoresById(id);
                    item = GetStore_UserScoresCollectionFromOrderDal(recordSet);
                    AddCacheItem(key, item);
                }
            }
            else
            {
                List<Store_UserScoresDetails> recordSet = SiteProvider.Store.GetUserScoresById(id);
                item = GetStore_UserScoresCollectionFromOrderDal(recordSet);
            }
            return item;
        }

        public Int32 insertUserScores()
        {
            return insertUserScores(UserScoreId, UserScoreTitleId, Username, Score, DomainId, LanguageId);
        }

        private Int32 insertUserScores(Guid userScoreId, Guid userScoreTitleId, String username, Byte score, Int32 domainId, Int32 languageId)
        {
            Store_UserScoresDetails Store_UserScores = new Store_UserScoresDetails(UserScoreId, UserScoreTitleId, Username, Score, DomainId, LanguageId);
            Int32 ret = SiteProvider.Store.insertUserScores(Store_UserScores);
            if (Settings.EnableCaching & ret > 0)
                InvalidateCache();
            return ret;
        }

        public Boolean UpdateUserScores()
        {
            return UpdateUserScores(UserScoreId, UserScoreTitleId, Username, Score, DomainId, LanguageId);
        }

        private Boolean UpdateUserScores(Guid userScoreId, Guid userScoreTitleId, String username, Byte score, Int32 domainId, Int32 languageId)
        {
            Store_UserScoresDetails Store_UserScores = new Store_UserScoresDetails(UserScoreId, UserScoreTitleId, Username, Score, DomainId, LanguageId);
            Boolean ret = SiteProvider.Store.UpdateUserScores(Store_UserScores);
            if (Settings.EnableCaching & ret)
                InvalidateCache();
            return ret;
        }

        public bool DeleteUserScores(Guid Id)
        {


            Boolean ret = SiteProvider.Store.DeleteUserScores(Id);
            if (Settings.EnableCaching & ret)
                InvalidateCache();
            return ret;
        } 





         //    /// <summary>
         //    /// تبدیل داده های لایه دیتا به داده های لایه تجاری 
         //    /// </summary>
         //    /// <param name="records">رکوردهای ورودی حاوی داده های لایه دیتا</param>
         //    /// <returns></returns>
        private static List<Store_UserScores> GetStore_UserScoresCollectionFromOrderDal(List<Store_UserScoresDetails> records)
         {
             List<Store_UserScores> items = new List<Store_UserScores>();
             foreach (Store_UserScoresDetails item in records)
                 items.Add(GetStore_UserScoresFromOrderDal(item));
             return items;
         }

        /// <summary>
        /// تبدیل داده لایه دیتا به داده لایه تجاری
        /// </summary>
        /// <param name="record">رکورد ورودی حاوی داده لایه دیتا</param>
        /// <returns></returns>
        private static Store_UserScores GetStore_UserScoresFromOrderDal(Store_UserScoresDetails record)
        {
            if (record != null)
                return new Store_UserScores(record.UserScoreId,record.UserScoreTitleId,record.Username,record.Score,record.DomainId,record.LanguageId);
            return null;
        }

        #endregion
    }
}
