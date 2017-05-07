using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pine.Dal;
using Pine.Dal.Store;
namespace Pine.Bll.Store
{
   public class Store_ProductsConSpecificationTexts: BaseStore
    {
         
        #region Constructors (2)


        public Store_ProductsConSpecificationTexts(Guid productId, Guid specificationTextId, String description)
        {

            SpecificationTextId = specificationTextId;
            ProductId = productId;
            Description = description;


        }

        public Store_ProductsConSpecificationTexts()
        {
        }

        #endregion Constructors

        #region Properties (2)

        public Guid ProductId { get; set; }

        public Guid SpecificationTextId { get; set; }

        public String Description { get; set; }

        #endregion Properties

          #region Methods(4)
       
        public static List<Store_ProductsConSpecificationTexts>  GetStore_ProductsConSpecificationTextsByProductId( Guid productId)
        {

          List<Store_ProductsConSpecificationTexts> item;

            String key = "Store_ProductsConSpecificationTexts_productId" + productId;

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as List< Store_ProductsConSpecificationTexts>;
                if (item == null)
                {
                    List<Store_ProductsConSpecificationTextsDetails> recordSet = SiteProvider.Store.GetProductsConSpecificationTextByProductId(productId);
                   item = GetStore_ProductsConSpecificationTextsCollectionFromOrderDal(recordSet); 
                    AddCacheItem(key, item);
                }
            }
            else
            {
                List<Store_ProductsConSpecificationTextsDetails> recordSet = SiteProvider.Store.GetProductsConSpecificationTextByProductId(productId);
                item = GetStore_ProductsConSpecificationTextsCollectionFromOrderDal(recordSet);
            }
            return item;
        
        }

        public static List<Store_ProductsConSpecificationTexts> GetAllProductsConSpecificationText()
        {

          List<Store_ProductsConSpecificationTexts> item;

            String key = "Store_ProductsConSpecificationTexts_GetAll";

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as List< Store_ProductsConSpecificationTexts>;
                if (item == null)
                {
                    List<Store_ProductsConSpecificationTextsDetails> recordSet = SiteProvider.Store.GetAllProductsConSpecificationText();
                   item = GetStore_ProductsConSpecificationTextsCollectionFromOrderDal(recordSet); 
                    AddCacheItem(key, item);
                }
            }
            else
            {
                List<Store_ProductsConSpecificationTextsDetails> recordSet = SiteProvider.Store.GetAllProductsConSpecificationText();
                item = GetStore_ProductsConSpecificationTextsCollectionFromOrderDal(recordSet);
            }
            return item;
        
        }
       




        public Int32 InsertProductsConSpecificationTexts()
        {
            return InsertProductsConSpecificationTexts(ProductId,SpecificationTextId,Description);
        }

        private Int32 InsertProductsConSpecificationTexts(Guid productId, Guid specificationTextId, String description)
        {
            Store_ProductsConSpecificationTextsDetails Store_ProductsConSpecificationTexts = new Store_ProductsConSpecificationTextsDetails(ProductId, SpecificationTextId, Description);
            Int32 ret = SiteProvider.Store.InsertProductsConSpecificationText(Store_ProductsConSpecificationTexts);
            if (Settings.EnableCaching & ret > 0)
                InvalidateCache();
            return ret;
        }





        public bool DeleteProductsConSpecificationTextsByProductId( Guid productId)
        {


            Boolean ret = SiteProvider.Store.DeleteProductsConSpecificationTextByProductId( productId);
            if (Settings.EnableCaching & ret)
                InvalidateCache();
            return ret;
        }

        public bool DeleteProductsConSpecificationTextsBySpecificationTextId(Guid specificationTextId)
        {


            Boolean ret = SiteProvider.Store.DeleteProductsConSpecificationTextByspecificationTextId(specificationTextId);
            if (Settings.EnableCaching & ret)
                InvalidateCache();
            return ret;
        }




        ////    /// <summary>
        ////    /// تبدیل داده های لایه دیتا به داده های لایه تجاری 
        ////    /// </summary>
        ////    /// <param name="records">رکوردهای ورودی حاوی داده های لایه دیتا</param>
        ////    /// <returns></returns>
        private static List<Store_ProductsConSpecificationTexts> GetStore_ProductsConSpecificationTextsCollectionFromOrderDal(List<Store_ProductsConSpecificationTextsDetails> records)
        {
            List<Store_ProductsConSpecificationTexts> items = new List<Store_ProductsConSpecificationTexts>();
            foreach (Store_ProductsConSpecificationTextsDetails item in records)
                items.Add(GetStore_ProductsConSpecificationTextsFromOrderDal(item));
            return items;
        }

        /// <summary>
        /// تبدیل داده لایه دیتا به داده لایه تجاری
        /// </summary>
        /// <param name="record">رکورد ورودی حاوی داده لایه دیتا</param>
        /// <returns></returns>
        private static Store_ProductsConSpecificationTexts GetStore_ProductsConSpecificationTextsFromOrderDal(Store_ProductsConSpecificationTextsDetails record) 
        {
            if (record != null) 
                return new Store_ProductsConSpecificationTexts(record.ProductId,record.SpecificationTextId,record.Description);
            return null;
        }

        #endregion
    }

     
}
