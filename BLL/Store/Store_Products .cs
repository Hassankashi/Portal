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
    public class Store_Products  : BaseStore
    {
        
        #region Constructors (2)

        public Store_Products(Guid productId, String name, String description, String mainImage, String condition, Byte? score,  Boolean status, DateTime enterDate, DateTime? lastUpdateDate, String username, Int32 domainId, Int32 languageId)
        {

            ProductId = productId;
             Name     = name;
             Description = description;
             MainImage = mainImage;
             Condition = condition;
             Score = score;
             Status = status;
             EnterDate = enterDate;
             LastUpdateDate = lastUpdateDate;
            Username = username;
            DomainId = domainId;
            LanguageId = languageId;

        }

     
        /// <summary>
        /// سازنده پیش فرض کلاس جزئیات تنظیمات طرح
        /// </summary>
        public Store_Products()
        {
            CacheDuration = Settings.CacheDuration;
            MasterCacheKey = "Store";
        }

       #endregion Constructors

        #region Properties (4)

        public Guid ProductId { get; set; }

        public String Name { get; set; }

        public String Description { get; set; }

        public String MainImage { get; set; }

        public String Condition { get; set; }

        public Byte? Score { get; set; }

        public Boolean Status { get; set; }

        public DateTime EnterDate { get; set; }

        public DateTime? LastUpdateDate { get; set; }

        public String Username { get; set; }

        public Int32 DomainId { get; set; }

        public Int32 LanguageId { get; set; }

        #endregion Properties

        #region Methods(4)

        public static Store_Products GetProductsById(Guid id) 
        {
          Store_Products item;

            String key = "Store_Product_Id" + id;

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as Store_Products;
                if (item == null)
                {
                    Store_ProductsDetails recordSet = SiteProvider.Store.GetProductsById(id);
                    item = GetStore_ProductsFromOrderDal(recordSet);
                    AddCacheItem(key, item);
                }
            }
            else
            {
                Store_ProductsDetails recordSet = SiteProvider.Store.GetProductsById(id);
                item = GetStore_ProductsFromOrderDal(recordSet);
            }
            return item;
        }

        public static List<Store_Products> GetProductByCategory(Guid category)
        {
            List<Store_Products> item;

            String key = "Store_Product_Category" + category;

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as List<Store_Products>;
                if (item == null)
                {
                    List<Store_ProductsDetails> recordSet = SiteProvider.Store.GetProductByCategory(category);
                    item = GetStore_ProductsCollectionFromOrderDal(recordSet);
                    AddCacheItem(key, item);
                }
            }
            else
            {
                List<Store_ProductsDetails> recordSet = SiteProvider.Store.GetProductByCategory(category);
                item = GetStore_ProductsCollectionFromOrderDal(recordSet);
            }
            return item;
        }



        public static List<Store_Products> GetAllProducts()
        {
            List<Store_Products> item;

            String key = "Store_Product_GetAll" ;

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as List<Store_Products>;
                if (item == null)
                {
                    List<Store_ProductsDetails> recordSet = SiteProvider.Store.GetAllProducts();
                    item = GetStore_ProductsCollectionFromOrderDal(recordSet);
                    AddCacheItem(key, item);
                }
            }
            else
            {
                List<Store_ProductsDetails> recordSet = SiteProvider.Store.GetAllProducts();
                item = GetStore_ProductsCollectionFromOrderDal(recordSet);
            }
            return item;
        }

        public static List<Store_Products> GetProductByName(String Name)
        {
            if (Name == null)
            {
                List<Store_Products> result1 = GetAllProducts();
                return result1;
            }

            else
            {
                List<Store_Products> result = GetAllProducts();
                List<Store_Products> result2 = (from r in result where r.Name.Contains(Name) select r).ToList();
                return result2;  // List<UserObject> result2 = result.FindAll(j => j.UserName.Contains(userName)).Where(i => i.UserId !=userNameId  && isExixtUserIsd);
            }
            //if(!isExixtUserIsd) 
            //{
            //  return  result2.FindAll(j => j.UserId != userNameId);
            //}
            
        }
        public Guid insertProducts()
        {
            return insertProducts(ProductId, Name, Description, MainImage, Condition, Score, Status, EnterDate, LastUpdateDate, Username, DomainId, LanguageId);
        }

        private Guid insertProducts(Guid productId, String name, String description, String mainImage, String condition, Byte? score, Boolean status, DateTime enterDate, DateTime? lastUpdateDate, String username, Int32 domainId, Int32 languageId)
        {
            Store_ProductsDetails Store_Products  = new Store_ProductsDetails(productId, name, description, mainImage, condition, score, status, enterDate, lastUpdateDate, username, domainId, languageId);
            Guid ret = SiteProvider.Store.insertProducts(Store_Products);
            if (Settings.EnableCaching )
                InvalidateCache();
            return ret;
        }

        public Boolean UpdateProducts()
        {
            return UpdateProducts(ProductId, Name, Description, MainImage, Condition, Score, Status, EnterDate, LastUpdateDate, Username, DomainId, LanguageId);
        }

        private Boolean UpdateProducts(Guid productId, String name, String description, String mainImage, String condition, Byte? score, Boolean status, DateTime enterDate, DateTime? lastUpdateDate, String username, Int32 domainId, Int32 languageId) 
        {
            Store_ProductsDetails Store_Products  = new Store_ProductsDetails(ProductId, Name, Description, MainImage, Condition, Score, Status, EnterDate, LastUpdateDate, Username, DomainId, LanguageId);
            Boolean ret = SiteProvider.Store.UpdateProducts(Store_Products);
            if (Settings.EnableCaching & ret)
                InvalidateCache();
            return ret;
        }

        public bool DeleteProducts(Guid Id)
        {


            Boolean ret = SiteProvider.Store.DeleteProducts(Id);
            if (Settings.EnableCaching & ret)
                InvalidateCache();
            return ret;
        }





        //    /// <summary>
        //    /// تبدیل داده های لایه دیتا به داده های لایه تجاری 
        //    /// </summary>
        //    /// <param name="records">رکوردهای ورودی حاوی داده های لایه دیتا</param>
        //    /// <returns></returns>
        private static List<Store_Products> GetStore_ProductsCollectionFromOrderDal(List<Store_ProductsDetails> records)
        {
            List<Store_Products> items = new List<Store_Products>();
            foreach (Store_ProductsDetails item in records)
                items.Add(GetStore_ProductsFromOrderDal(item));
            return items;
        }

        /// <summary>
        /// تبدیل داده لایه دیتا به داده لایه تجاری
        /// </summary>
        /// <param name="record">رکورد ورودی حاوی داده لایه دیتا</param>
        /// <returns></returns>
        private static Store_Products GetStore_ProductsFromOrderDal(Store_ProductsDetails record)
        {
            if (record != null)
                return new Store_Products(record.ProductId, record.Name,record.Description,record.MainImage,record.Condition,record.Score,record.Status,record.EnterDate,record.LastUpdateDate,record.Username,record.DomainId,record.LanguageId);
            return null;
        }

        #endregion
    }
}
