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
    public class Store_ProductsConCategories : BaseStore 
    {
        
        #region Constructors (2)

        public Store_ProductsConCategories(Guid categoryId, Guid productId)
        {

            CategoryId = categoryId; 
            ProductId = productId;


        }


     
        /// <summary>
        /// سازنده پیش فرض کلاس جزئیات تنظیمات طرح
        /// </summary>
        public Store_ProductsConCategories() 
        {
            CacheDuration = Settings.CacheDuration;
            MasterCacheKey = "Store";
        }

       #endregion Constructors

        #region Properties (2)

        public Guid CategoryId { get; set; }

        public Guid ProductId { get; set; }



        #endregion Properties

        #region Methods(4)
        public static Store_ProductsConCategories GetProductsConCategoriesByCategoryIdAndProductId(Guid Category, Guid ProductId)
        {

            Store_ProductsConCategories item;

            String key = "Store_ProductsConCategories_Category_ProductId" + Category + ProductId;

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as Store_ProductsConCategories;
                if (item == null)
                {
                    Store_ProductsConCategoriesDetails recordSet = SiteProvider.Store.GetProductsConCategoriesByCategoryIdAndProductId(Category, ProductId);
                    item = GetStore_ProductsConCategoriesFromOrderDal(recordSet); 
                    AddCacheItem(key, item);
                }
            }
            else
            {
                Store_ProductsConCategoriesDetails recordSet = SiteProvider.Store.GetProductsConCategoriesByCategoryIdAndProductId(Category, ProductId);
                item = GetStore_ProductsConCategoriesFromOrderDal(recordSet);
            }
            return item;
        
        }

        public static List<Store_ProductsConCategories> GetProductsConCategoriesById(Guid id) 
        {
            List<Store_ProductsConCategories> item;

            String key = "Store_ProductsConCategoriesId_" + id; 

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as List<Store_ProductsConCategories>;
                if (item == null)
                {
                    List<Store_ProductsConCategoriesDetails> recordSet = SiteProvider.Store.GetProductsConCategoriesById(id);
                    item = GetStore_ProductsConCategoriesCollectionFromOrderDal(recordSet);
                    AddCacheItem(key, item);
                }
            }
            else
            {
                List<Store_ProductsConCategoriesDetails> recordSet = SiteProvider.Store.GetProductsConCategoriesById(id);
                item = GetStore_ProductsConCategoriesCollectionFromOrderDal(recordSet);
            }
            return item;
        }


        public static List<Store_ProductsConCategories> GetProductsConCategoriesByIdAndProductId(Guid ProductId)
        {
            List<Store_ProductsConCategories> item;

            String key = "Store_ProductsConCategoriesId_ProductId" +  "_" + ProductId;

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as List<Store_ProductsConCategories>;
                if (item == null)
                {
                    List<Store_ProductsConCategoriesDetails> recordSet = SiteProvider.Store.GetProductsConCategoriesByIdAndProductId(ProductId);
                    item = GetStore_ProductsConCategoriesCollectionFromOrderDal(recordSet);
                    AddCacheItem(key, item);
                }
            }
            else
            {
                List<Store_ProductsConCategoriesDetails> recordSet = SiteProvider.Store.GetProductsConCategoriesByIdAndProductId( ProductId);
                item = GetStore_ProductsConCategoriesCollectionFromOrderDal(recordSet);
            }
            return item;
        }

        public Int32 insertProductsConCategories()
        {
            return insertProductsConCategories(CategoryId,ProductId);
        }

        private Int32 insertProductsConCategories(Guid categoryId, Guid productId)
        {
            Store_ProductsConCategoriesDetails Store_ProductsConCategories = new Store_ProductsConCategoriesDetails(CategoryId, ProductId);
            Int32 ret = SiteProvider.Store.insertProductsConCategories(Store_ProductsConCategories);  
            if (Settings.EnableCaching & ret > 0)
                InvalidateCache();
            return ret;
        }

        public Boolean UpdateProductsConCategories()
        {
            return UpdateProductsConCategories(CategoryId, ProductId);
        }

        private Boolean UpdateProductsConCategories(Guid categoryId, Guid productId) 
        {
            Store_ProductsConCategoriesDetails Store_ProductsConCategories = new Store_ProductsConCategoriesDetails(CategoryId, ProductId);
            Boolean ret = SiteProvider.Store.UpdateProductsConCategories(Store_ProductsConCategories);
            if (Settings.EnableCaching & ret)
                InvalidateCache();
            return ret;
        }

        public bool DeleteProductsConCategories(Guid id , Guid ProductId) 
        {


            Boolean ret = SiteProvider.Store.DeleteProductsConCategories(id, ProductId); 
            if (Settings.EnableCaching & ret)
                InvalidateCache();
            return ret;
        }





        ////    /// <summary>
        ////    /// تبدیل داده های لایه دیتا به داده های لایه تجاری 
        ////    /// </summary>
        ////    /// <param name="records">رکوردهای ورودی حاوی داده های لایه دیتا</param>
        ////    /// <returns></returns>
        private static List<Store_ProductsConCategories> GetStore_ProductsConCategoriesCollectionFromOrderDal(List<Store_ProductsConCategoriesDetails> records)
        {
            List<Store_ProductsConCategories> items = new List<Store_ProductsConCategories>();
            foreach (Store_ProductsConCategoriesDetails item in records)
                items.Add(GetStore_ProductsConCategoriesFromOrderDal(item));
            return items;
        }

        /// <summary>
        /// تبدیل داده لایه دیتا به داده لایه تجاری
        /// </summary>
        /// <param name="record">رکورد ورودی حاوی داده لایه دیتا</param>
        /// <returns></returns>
        private static Store_ProductsConCategories GetStore_ProductsConCategoriesFromOrderDal(Store_ProductsConCategoriesDetails record) 
        {
            if (record != null)
                return new Store_ProductsConCategories(record.CategoryId,record.ProductId);
            return null;
        }

        #endregion
    }
}
