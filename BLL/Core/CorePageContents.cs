using System;
using System.Linq;
using System.Collections.Generic;
using Pine.Dal;
using Pine.Dal.Core;

namespace Pine.Bll.Core
{

    public class CorePageContents : BaseCore
    {
        #region Constructors (2)


        public CorePageContents(Int32 pageContentId, Int32 pageId, Int32 userControlPathId, Int32 contentNameId, Int32? coreParameterId, Int16 priority, Boolean isStaticCantent , Int32 domainId , Int32 languageId)
        {
            PageContentId = pageContentId;
            PageId = pageId;
            UserControlPathId = userControlPathId;
            ContentNameId = contentNameId;
            CoreParameterId = coreParameterId;
            Priority = priority;
            IsStaticCantent = isStaticCantent;
            LanguageId = languageId;
            DomainId = domainId;
        }



        public CorePageContents()
        {
            CacheDuration = Settings.CacheDuration;
            MasterCacheKey = "Core";
        }

        #endregion Constructors

        #region Properties (7)

        public Int32 PageContentId { get; set; }

        public Int32 PageId { get; set; }

        public Int32 UserControlPathId { get; set; }

        public Int32 ContentNameId { get; set; }

        public Int32? CoreParameterId { get; set; }

        public Int16 Priority { get; set; }

        public Boolean IsStaticCantent { get; set; }

        public Int32 DomainId { get; set; }

        public Int32 LanguageId { get; set; }

        #endregion Properties

        #region Methods(3)

        public List<CorePageContents> GetCorePageContentsByPageId(Int32 pageId)
        {
            List<CorePageContents> item;

            String key = "CorePageContents_PageId_" + pageId;

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as List<CorePageContents>;
                if (item == null)
                {
                    List<CorePageContentsDetails> recordSet = SiteProvider.Core.GetCorePageContentsByPageId(pageId);
                    item = GetCorePageContentsCollectionFromOrderDal(recordSet);
                    AddCacheItem(key, item);
                }
            }
            else
            {
                List<CorePageContentsDetails> recordSet = SiteProvider.Core.GetCorePageContentsByPageId(pageId);
                item = GetCorePageContentsCollectionFromOrderDal(recordSet);
            }
            return item;
        }

        
        public Int32 Insert()
        {
            return Insert(PageContentId, PageId, UserControlPathId, ContentNameId, CoreParameterId, Priority, IsStaticCantent, DomainId, LanguageId);
        }

        private Int32 Insert(Int32 pageContentId, Int32 pageId, Int32 userControlPathId, Int32 contentNameId, Int32? coreParameterId, Int16 priority, Boolean isStaticCantent, Int32 domainId, Int32 languageId)
        {
            CorePageContentsDetails corePageContents = new CorePageContentsDetails(pageContentId, pageId, userControlPathId, contentNameId, coreParameterId, priority, isStaticCantent,domainId,languageId);
            Int32 ret = SiteProvider.Core.InsertCorePageContents(corePageContents);
            if (Settings.EnableCaching & ret > 0)
                InvalidateCache();
            return ret;
        }

        public bool Update()
        {
            return Update(PageContentId, PageId, UserControlPathId, ContentNameId, CoreParameterId, Priority, IsStaticCantent, DomainId, LanguageId);
        }

        private Boolean Update(Int32 pageContentId, Int32 pageId, Int32 userControlPathId, Int32 contentNameId, Int32? coreParameterId, Int16 priority, Boolean isStaticCantent, Int32 domainId, Int32 languageId)
        {
            CorePageContentsDetails corePageContents = new CorePageContentsDetails(pageContentId, pageId, userControlPathId, contentNameId, coreParameterId, priority, isStaticCantent, domainId, languageId);
            Boolean ret = SiteProvider.Core.UpdateCorePageContents(corePageContents);
            if (Settings.EnableCaching & ret)
                InvalidateCache();
            return ret;
        }

        public bool Delete()
        {
            return Delete(PageContentId, PageId, UserControlPathId, ContentNameId, CoreParameterId, Priority, IsStaticCantent, DomainId, LanguageId);
        }

        private bool Delete(Int32 pageContentId, Int32 pageId, Int32 userControlPathId, Int32 contentNameId, Int32? coreParameterId, Int16 priority, Boolean isStaticCantent, Int32 domainId, Int32 languageId)
        {
            CorePageContentsDetails corePageContents = new CorePageContentsDetails(pageContentId, pageId, userControlPathId, contentNameId, coreParameterId, priority, isStaticCantent, domainId, languageId);
            bool ret = SiteProvider.Core.DeleteCorePageContents(corePageContents.PageContentId);
            if (Settings.EnableCaching & ret)
                InvalidateCache();
            return ret;
        }
    
        /// <summary>
        /// تبدیل داده های لایه دیتا به داده های لایه تجاری 
        /// </summary>
        /// <param name="records">رکوردهای ورودی حاوی داده های لایه دیتا</param>
        /// <returns></returns>
        private static List<CorePageContents> GetCorePageContentsCollectionFromOrderDal(List<CorePageContentsDetails> records)
        {
            List<CorePageContents> items = new List<CorePageContents>();
            foreach (CorePageContentsDetails item in records)
                items.Add(GetCoreThemeSettingFromOrderDal(item));
            return items;
        }

        /// <summary>
        /// تبدیل داده لایه دیتا به داده لایه تجاری
        /// </summary>
        /// <param name="record">رکورد ورودی حاوی داده لایه دیتا</param>
        /// <returns></returns>
        private static CorePageContents GetCoreThemeSettingFromOrderDal(CorePageContentsDetails record)
        {
            if (record != null)
                return new CorePageContents(record.PageContentId , record.PageId , record.UserControlPathId, record.ContentNameId, record.CoreParameterId, record.Priority, record.IsStaticCantent,record.DomainId,record.LanguageId);
            return null;
        }

        #endregion
    }
}
