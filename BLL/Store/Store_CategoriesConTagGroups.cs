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
    public class Store_CategoriesConTagGroups : BaseStore
    {
        
        #region Constructors (2)

        public Store_CategoriesConTagGroups(Guid categoryId, Guid tagGroupId)
        {

            CategoryId = categoryId;
            TagGroupId = tagGroupId;


        }
        /// <summary>
        /// سازنده پیش فرض کلاس جزئیات تنظیمات طرح
        /// </summary>
        public Store_CategoriesConTagGroups()
        {
            CacheDuration = Settings.CacheDuration;
            MasterCacheKey = "Store";
       } 

       #endregion Constructors

        #region Properties (4)

        public Guid CategoryId { get; set; }

        public Guid TagGroupId { get; set; }
        #endregion Properties

        #region Methods(3)

        public List<Store_CategoriesConTagGroups> GetCategoriesConTagGroupById(Guid id)
        {
            List<Store_CategoriesConTagGroups> item;

            String key = "Store_CategoryId_" + id;

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as List<Store_CategoriesConTagGroups>;
                if (item == null)
                { 
                    List<Store_CategoriesConTagGroupsDetails> recordSet = SiteProvider.Store.GetCategoriesConTagGroupById(id);
                    item = GetStore_CategoriesConTagGroupsCollectionFromOrderDal(recordSet);
                    AddCacheItem(key, item);
                }
            }
            else
            {
                List<Store_CategoriesConTagGroupsDetails> recordSet = SiteProvider.Store.GetCategoriesConTagGroupById(id);
                item = GetStore_CategoriesConTagGroupsCollectionFromOrderDal(recordSet);
            }
            return item;
        }

        public Int32 insertCategoriesConTagGroups()
        {
            return insertCategoriesConTagGroups(CategoryId, TagGroupId);
        }

        private Int32 insertCategoriesConTagGroups(Guid categoryId, Guid tagGroupId)
        {
            Store_CategoriesConTagGroupsDetails Store_CategorieConTagGroups = new Store_CategoriesConTagGroupsDetails(categoryId, tagGroupId);
            Int32 ret = SiteProvider.Store.insertCategoriesConTagGroups(Store_CategorieConTagGroups);
            if (Settings.EnableCaching & ret > 0)
                InvalidateCache();
            return ret;
        }

        public Boolean UpdateCategoriesConTagGroups()
        {
            return UpdateCategoriesConTagGroups(CategoryId, TagGroupId);
        }

        private Boolean UpdateCategoriesConTagGroups(Guid categoryId, Guid tagGroupId) 
        {
            Store_CategoriesConTagGroupsDetails Store_CategorieConTagGroups = new Store_CategoriesConTagGroupsDetails(CategoryId,TagGroupId ); 
            Boolean ret = SiteProvider.Store.UpdateCategoriesConTagGroups(Store_CategorieConTagGroups);
            if (Settings.EnableCaching & ret)
                InvalidateCache();
            return ret;
        }

        public bool DeleteCategoriesConTagGroups(Guid Id)
        {


            Boolean ret = SiteProvider.Store.DeleteCategoriesConTagGroups(Id);
            if (Settings.EnableCaching & ret)
                InvalidateCache();
            return ret;
        }

    

       

    //    /// <summary>
    //    /// تبدیل داده های لایه دیتا به داده های لایه تجاری 
    //    /// </summary>
    //    /// <param name="records">رکوردهای ورودی حاوی داده های لایه دیتا</param>
    //    /// <returns></returns>
        private static List<Store_CategoriesConTagGroups> GetStore_CategoriesConTagGroupsCollectionFromOrderDal(List<Store_CategoriesConTagGroupsDetails> records)
        {
            List<Store_CategoriesConTagGroups> items = new List<Store_CategoriesConTagGroups>();
            foreach (Store_CategoriesConTagGroupsDetails item in records)
                items.Add(GetStore_CategoriesConTagGroupsFromOrderDal(item));
            return items;
        }

        /// <summary>
        /// تبدیل داده لایه دیتا به داده لایه تجاری
        /// </summary>
        /// <param name="record">رکورد ورودی حاوی داده لایه دیتا</param>
        /// <returns></returns>
        private static Store_CategoriesConTagGroups GetStore_CategoriesConTagGroupsFromOrderDal(Store_CategoriesConTagGroupsDetails record)
        {
            if (record != null)
                return new Store_CategoriesConTagGroups(record.CategoryId,record.TagGroupId);
            return null;
        }

       #endregion
    }
}
