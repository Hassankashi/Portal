using System;
using System.Linq;
using System.Collections.Generic;
using Pine.Dal;
using Pine.Dal.Core;

namespace Pine.Bll.Core
{
    /// <summary>
    /// کلاسی برای نگهداری منو
    /// </summary>
    public class CoreMasterPageContents : BaseCore
    {
        
        #region Constructors (2)

        public CoreMasterPageContents(Int32 masterPageContentId, Int32 masterPageNameId, Int32 contentNameId, String masterPageContentName, Int32 domainId, Int32 languageId)
        {
            MasterPageContentId = masterPageContentId;
            MasterPageNameId = masterPageNameId;
            ContentNameId = contentNameId;
            MasterPageContentName = masterPageContentName;
            DomainId = domainId;
            LanguageId = languageId;
        }

        /// <summary>
        /// سازنده پیش فرض کلاس جزئیات تنظیمات طرح
        /// </summary>
        public CoreMasterPageContents()
        {
            CacheDuration = Settings.CacheDuration;
            MasterCacheKey = "Core";
        }

        #endregion Constructors

        #region Properties (4)

        public Int32 MasterPageContentId { get; set; }

        public Int32 MasterPageNameId { get; set; }

        public Int32 ContentNameId { get; set; }

        public String MasterPageContentName { get; set; }

        public Int32 DomainId { get; set; }

        public Int32 LanguageId { get; set; }
        #endregion Properties

        #region Methods(3)

        public List<CoreMasterPageContents> GetCoreMasterPageContentsByContentNameIdAndMasterPageNameId(Int32 contentNameId, Int32 masterPageNameId)
        {
            List<CoreMasterPageContents> item;

            String key = "CoreMasterPageContents_ContentNameId_" + contentNameId + "_MasterPageNameI_" + masterPageNameId;

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as List<CoreMasterPageContents>;
                if (item == null)
                {
                    List<CoreMasterPageContentsDetails> recordSet = SiteProvider.Core.GetCoreMasterPageContentsByContentNameIdAndMasterPageNameId(contentNameId, masterPageNameId);
                    item = GetCoreMasterPageContentsCollectionFromOrderDal(recordSet);
                    AddCacheItem(key, item);
                }
            }
            else
            {
                List<CoreMasterPageContentsDetails> recordSet = SiteProvider.Core.GetCoreMasterPageContentsByContentNameIdAndMasterPageNameId(contentNameId, masterPageNameId);
                item = GetCoreMasterPageContentsCollectionFromOrderDal(recordSet);
            }
            return item;
        }



        public Int32 Insert()
        {
            return Insert(MasterPageContentId, MasterPageNameId, ContentNameId, MasterPageContentName, DomainId, LanguageId);
        }

        private Int32 Insert(Int32 masterPageContentId, Int32 masterPageNameId, Int32 contentNameId, String masterPageContentName,Int32 domainId, Int32 languageId)
        {
            CoreMasterPageContentsDetails coreMasterPageContentsDetails = new CoreMasterPageContentsDetails(masterPageContentId, masterPageNameId, contentNameId, masterPageContentName,domainId,languageId);
            Int32 ret = SiteProvider.Core.InsertCoreMasterPageContents(coreMasterPageContentsDetails);
            if (Settings.EnableCaching & ret > 0)
                InvalidateCache();
            return ret;
        }

        public bool Update()
        {
            return Update(MasterPageContentId, MasterPageNameId, ContentNameId, MasterPageContentName,DomainId,LanguageId);
        }

        private Boolean Update(Int32 masterPageContentId, Int32 masterPageNameId, Int32 contentNameId, String masterPageContentName, Int32 domainId, Int32 languageId)
        {
            CoreMasterPageContentsDetails coreMasterPageContentsDetails = new CoreMasterPageContentsDetails(masterPageContentId, masterPageNameId, contentNameId, masterPageContentName,domainId,languageId);
            Boolean ret = SiteProvider.Core.UpdateCoreMasterPageContents(coreMasterPageContentsDetails);
            if (Settings.EnableCaching & ret)
                InvalidateCache();
            return ret;
        }


        public bool Delete()
        {
            return Delete(MasterPageContentId, MasterPageNameId, ContentNameId, MasterPageContentName, DomainId, LanguageId);
        }

        private bool Delete(Int32 masterPageContentId, Int32 masterPageNameId, Int32 contentNameId, String masterPageContentName, Int32 domainId, Int32 languageId)
        {
            CoreMasterPageContentsDetails coreMasterPageContentsDetails = new CoreMasterPageContentsDetails(masterPageContentId, masterPageNameId, contentNameId, masterPageContentName, domainId, languageId);
            bool ret = SiteProvider.Core.DeleteCoreMasterPageContents(coreMasterPageContentsDetails.MasterPageContentId);
            if (Settings.EnableCaching & ret)
                InvalidateCache();
            return ret;
        }

       

        /// <summary>
        /// تبدیل داده های لایه دیتا به داده های لایه تجاری 
        /// </summary>
        /// <param name="records">رکوردهای ورودی حاوی داده های لایه دیتا</param>
        /// <returns></returns>
        private static List<CoreMasterPageContents> GetCoreMasterPageContentsCollectionFromOrderDal(List<CoreMasterPageContentsDetails> records)
        {
            List<CoreMasterPageContents> items = new List<CoreMasterPageContents>();
            foreach (CoreMasterPageContentsDetails item in records)
                items.Add(GetCoreMasterPageContentsFromOrderDal(item));
            return items;
        }

        /// <summary>
        /// تبدیل داده لایه دیتا به داده لایه تجاری
        /// </summary>
        /// <param name="record">رکورد ورودی حاوی داده لایه دیتا</param>
        /// <returns></returns>
        private static CoreMasterPageContents GetCoreMasterPageContentsFromOrderDal(CoreMasterPageContentsDetails record)
        {
            if (record != null)
                return new CoreMasterPageContents(record.MasterPageContentId, record.MasterPageNameId, record.ContentNameId, record.MasterPageContentName, record.DomainId,record.LanguageId);
            return null;
        }

        #endregion
    }
}
