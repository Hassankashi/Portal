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
    public class Store_Categories : BaseStore
    {
        
        #region Constructors (2)

        public Store_Categories(Guid categoryId, String name, String icon, Int32 priority, Guid? parentCategoryId, Int32? productsCount, String username, Boolean status, Int32 domainId, Int32 languageId)
        {

             CategoryId = categoryId;
             Name     = name;
             Icon = icon;
             Priority = priority;
             ParentCategoryId = parentCategoryId;
             ProductsCount = productsCount;
            Username = username;
            Status = status;
            DomainId = domainId;
            LanguageId = languageId;

        }

     
        /// <summary>
        /// سازنده پیش فرض کلاس جزئیات تنظیمات طرح
        /// </summary>
        public Store_Categories()
        {
            CacheDuration = Settings.CacheDuration;
            MasterCacheKey = "Store";
        }

       #endregion Constructors

        #region Properties (4)

      public Guid CategoryId { get; set; }

        public String Name { get; set; }

        public String Icon { get; set; }

        public Int32 Priority { get; set; }

        public Guid? ParentCategoryId { get; set; }

        public Int32? ProductsCount { get; set; }

        public String Username { get; set; }

        public Boolean Status { get; set; }

        public Int32 DomainId { get; set; }

        public Int32 LanguageId { get; set; }

        #endregion Properties

        #region Methods(4)


        public static List<Store_Categories> GetAllCategories()
        {
            List<Store_Categories> item;

            String key = "Store_Category_GetAll";

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as List<Store_Categories>;
                if (item == null)
                {
                    List<Store_CategoriesDetails> recordSet = SiteProvider.Store.GetAllCategories();
                    item = GetStore_CategoriesCollectionFromOrderDal(recordSet);


                    AddCacheItem(key, item);
                }
            }
            else
            {
                List<Store_CategoriesDetails> recordSet = SiteProvider.Store.GetAllCategories();
                item = GetStore_CategoriesCollectionFromOrderDal(recordSet);
            }
            return item;
        
        }

        public static List<Store_Categories> GetCategoryByDomainAndLanguage(int Domain, int Language)
        {
            List<Store_Categories> item;

            String key = "Store_Category_Domain_Language" + Domain + "_" + Language;

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as List<Store_Categories>;
                if (item == null)
                {
                    List<Store_CategoriesDetails> recordSet = SiteProvider.Store.GetCategoryByDomainAndLanguage(Domain, Language);
                    item = GetStore_CategoriesCollectionFromOrderDal(recordSet);


                    AddCacheItem(key, item);
                }
            }
            else
            {
                List<Store_CategoriesDetails> recordSet = SiteProvider.Store.GetCategoryByDomainAndLanguage(Domain, Language);
                item = GetStore_CategoriesCollectionFromOrderDal(recordSet);
            }
            return item;
        
        }
        public static Store_Categories GetCategoriesById(Guid id) 
        {
            Store_Categories item;

            String key = "Store_CategoryIds_" + id; 

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as Store_Categories;
                if (item == null)
                {
                    Store_CategoriesDetails recordSet = SiteProvider.Store.GetCategoriesById(id);
                    item = GetStore_CategoriesConFromOrderDal(recordSet);
                    AddCacheItem(key, item);
                }
            }
            else
            {
                Store_CategoriesDetails recordSet = SiteProvider.Store.GetCategoriesById(id);
                item = GetStore_CategoriesConFromOrderDal(recordSet);
            }
            return item;
        }

        public   Int32 insertCategories()
        {
            return insertCategories(CategoryId, Name, Icon, Priority, ParentCategoryId, ProductsCount, Username, Status, DomainId, LanguageId);
        }

        private Int32 insertCategories(Guid categoryId, String name, String icon, Int32 priority, Guid? parentCategoryId, Int32? productsCount, String username, Boolean status, Int32 domainId, Int32 languageId)
        {
            Store_CategoriesDetails Store_Categories = new Store_CategoriesDetails(categoryId,name,icon,priority,parentCategoryId,productsCount,username,status,domainId,languageId);
            Int32 ret = SiteProvider.Store.insertCategories(Store_Categories);
            if (Settings.EnableCaching & ret > 0)
                InvalidateCache();
            return ret;
        }

        public Boolean UpdateCategories()
        {
            return UpdateCategories(CategoryId, Name, Icon, Priority, ParentCategoryId, ProductsCount, Username, Status, DomainId, LanguageId);
        }

        private  Boolean UpdateCategories(Guid categoryId, String name, String icon, Int32 priority, Guid? parentCategoryId, Int32? productsCount, String username, Boolean status, Int32 domainId, Int32 languageId) 
        {
            Store_CategoriesDetails Store_Categories = new Store_CategoriesDetails(CategoryId, Name, Icon, Priority, ParentCategoryId, ProductsCount, Username, Status, DomainId, LanguageId);
            Boolean ret = SiteProvider.Store.UpdateCategories(Store_Categories);
            if (Settings.EnableCaching & ret)
            {
              
                InvalidateCache();
            }
               
            return ret;
        }

        public  bool DeleteCategories(Guid Id)
        {


            Boolean ret = SiteProvider.Store.DeleteCategories(Id); 
            if (Settings.EnableCaching & ret)
                InvalidateCache();
            return ret;
        }





        //    /// <summary>
        //    /// تبدیل داده های لایه دیتا به داده های لایه تجاری 
        //    /// </summary>
        //    /// <param name="records">رکوردهای ورودی حاوی داده های لایه دیتا</param>
        //    /// <returns></returns>
        private static List<Store_Categories> GetStore_CategoriesCollectionFromOrderDal(List<Store_CategoriesDetails> records)
        {
            List<Store_Categories> items = new List<Store_Categories>();
            foreach (Store_CategoriesDetails item in records)
                items.Add(GetStore_CategoriesConFromOrderDal(item));
            return items;
        }

        /// <summary>
        /// تبدیل داده لایه دیتا به داده لایه تجاری
        /// </summary>
        /// <param name="record">رکورد ورودی حاوی داده لایه دیتا</param>
        /// <returns></returns>
        private static Store_Categories GetStore_CategoriesConFromOrderDal(Store_CategoriesDetails record)
        {
            if (record != null)
                return new Store_Categories(record.CategoryId,record.Name,record.Icon,record.Priority,record.ParentCategoryId,record.ProductsCount,record.Username,record.Status,record.DomainId,record.LanguageId);
            return null;
        }

        #endregion
    }
}
