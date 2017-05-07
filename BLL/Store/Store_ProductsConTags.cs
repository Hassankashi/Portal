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
    public class Store_ProductsConTags : BaseStore 
    {
        
        #region Constructors (2)

        public Store_ProductsConTags(Guid tagId, Guid productId)
        {

            TagId = tagId;
            ProductId = productId;


        }


     
        /// <summary>
        /// سازنده پیش فرض کلاس جزئیات تنظیمات طرح
        /// </summary>
        public Store_ProductsConTags()  
        {
            CacheDuration = Settings.CacheDuration;
            MasterCacheKey = "Store";
        }

       #endregion Constructors

        #region Properties (2)

        public Guid TagId { get; set; }

        public Guid ProductId { get; set; }


        #endregion Properties

       #region Methods(4)

        public List<Store_ProductsConTags> GetProductsConTagsById(Guid id)
        {
            List<Store_ProductsConTags> item;

            String key = "Store_ProductsConTagsId_" + id;

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as List<Store_ProductsConTags>;
                if (item == null)
                {
                    List<Store_ProductsConTagsDetails> recordSet = SiteProvider.Store.GetProductsConTagsById(id);
                    item = GetStore_ProductsConTagsCollectionFromOrderDal(recordSet);
                    AddCacheItem(key, item);
                }
            }
            else
            {
                List<Store_ProductsConTagsDetails> recordSet = SiteProvider.Store.GetProductsConTagsById(id);
                item = GetStore_ProductsConTagsCollectionFromOrderDal(recordSet);
            }
            return item;
        }

        public Int32 insertProductsConTags()
        {
            return insertProductsConTags(TagId,ProductId);  
        }

        private Int32 insertProductsConTags(Guid tagId, Guid productId)
        {
            Store_ProductsConTagsDetails Store_favoriteGroup = new Store_ProductsConTagsDetails(tagId, productId);
            Int32 ret = SiteProvider.Store.insertProductsConTags(Store_favoriteGroup);
            if (Settings.EnableCaching & ret > 0)
                InvalidateCache();
            return ret;
        }

        public Boolean UpdateProductsConTags()
        {
            return UpdateProductsConTags(TagId, ProductId);
        }

        private Boolean UpdateProductsConTags(Guid tagId, Guid productId)
        {
            Store_ProductsConTagsDetails Store_favorite = new Store_ProductsConTagsDetails(TagId, ProductId);
            Boolean ret = SiteProvider.Store.UpdateProductsConTags(Store_favorite);
            if (Settings.EnableCaching & ret)
                InvalidateCache();
            return ret;
        }

        public bool DeleteProductsConTags(Guid id)
        {


            Boolean ret = SiteProvider.Store.DeleteProductsConTags(id); 
            if (Settings.EnableCaching & ret)
                InvalidateCache();
            return ret;
        }





        //////    /// <summary>
        //////    /// تبدیل داده های لایه دیتا به داده های لایه تجاری 
        //////    /// </summary>
        //////    /// <param name="records">رکوردهای ورودی حاوی داده های لایه دیتا</param>
        //////    /// <returns></returns>
        private static List<Store_ProductsConTags> GetStore_ProductsConTagsCollectionFromOrderDal(List<Store_ProductsConTagsDetails> records)
        {
            List<Store_ProductsConTags> items = new List<Store_ProductsConTags>();
            foreach (Store_ProductsConTagsDetails item in records)
                items.Add(GetStore_ProductsConTagsFromOrderDal(item));
            return items;
        }

        /// <summary>
        /// تبدیل داده لایه دیتا به داده لایه تجاری
        /// </summary>
        /// <param name="record">رکورد ورودی حاوی داده لایه دیتا</param>
        /// <returns></returns>
        private static Store_ProductsConTags GetStore_ProductsConTagsFromOrderDal(Store_ProductsConTagsDetails record)
        {
            if (record != null)
                return new Store_ProductsConTags(record.TagId,record.ProductId); 
            return null;
        }

       #endregion
    }
}
