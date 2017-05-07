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
    public class Store_Prices : BaseStore
    {
        
        #region Constructors (2)

         public Store_Prices(Guid priceId, Guid? productId, Guid? priceDescriptionId, Decimal price, DateTime enterDate, Boolean status, Int32 domainId, Int32 languageId, String namePriceDes, String nameProduct)
        {

            PriceId = priceId;
            ProductId = productId;
            PriceDescriptionId = priceDescriptionId;
            Price = price;
            EnterDate = enterDate;
            Status = status;
            DomainId = domainId;
            LanguageId = languageId;
            NamePriceDes = namePriceDes;
            NameProduct = nameProduct; 

        }

     
        /// <summary>
        /// سازنده پیش فرض کلاس جزئیات تنظیمات طرح
        /// </summary>
        public Store_Prices()
        {
            CacheDuration = Settings.CacheDuration;
            MasterCacheKey = "Store";
        }

       #endregion Constructors

        #region Properties (4)

     

      public Guid PriceId { get; set; }

      public Guid? ProductId { get; set; }

      public Guid? PriceDescriptionId { get; set; }

      public Decimal Price { get; set; }

      public DateTime EnterDate { get; set; }


      public Boolean Status { get; set; }

      public Int32 DomainId { get; set; }

      public Int32 LanguageId { get; set; }

      public String NamePriceDes { get; set; }

      public String NameProduct { get; set; } 

        #endregion Properties

        #region Methods(4)

      public static Store_Prices GetPricesById(Guid id) 
        {
            Store_Prices item;

            String key = "Store_Prices_Id_" + id; 

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as Store_Prices;
                if (item == null)
                {
                    Store_PricesDetails recordSet = SiteProvider.Store.GetPricesById(id);
                    item = GetStore_PricesFromOrderDal(recordSet);
                    AddCacheItem(key, item);
                }
            }
            else
            {
                Store_PricesDetails recordSet = SiteProvider.Store.GetPricesById(id);
                item = GetStore_PricesFromOrderDal(recordSet);
            }
            return item;
        }


      public static List<Store_Prices> GetAllPrices() 
        {
            List<Store_Prices> item;

            String key = "Store_Prices_GetAll" ; 

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as List<Store_Prices>;
                if (item == null)
                {
                    List<Store_PricesDetails> recordSet = SiteProvider.Store.GetAllPrices();
                    item = GetStore_PricesCollectionFromOrderDal(recordSet);
                    AddCacheItem(key, item);
                }
            }
            else
            {
                List<Store_PricesDetails> recordSet = SiteProvider.Store.GetAllPrices();
                item = GetStore_PricesCollectionFromOrderDal(recordSet);
            }
            return item;
        }


      public Int32 insertPrices()
      {
          return insertPrices(PriceId, ProductId, PriceDescriptionId, Price,EnterDate, Status, DomainId,LanguageId,NamePriceDes,NameProduct);
      }

      private Int32 insertPrices(Guid priceId, Guid? productId, Guid? priceDescriptionId, Decimal price, DateTime enterDate, Boolean status, Int32 domainId, Int32 languageId, String namePriceDes, String nameProduct)
      {
          Store_PricesDetails Store_Prices = new Store_PricesDetails(priceId, productId, priceDescriptionId, price, enterDate, status, domainId, languageId,namePriceDes,nameProduct);
          Int32 ret = SiteProvider.Store.insertPrices(Store_Prices);
          if (Settings.EnableCaching & ret > 0)
              InvalidateCache();
          return ret;
      }

      public Boolean UpdatePrices()
      {
          return UpdatePrices(PriceId, ProductId, PriceDescriptionId, Price, EnterDate, Status, DomainId, LanguageId, NamePriceDes, NameProduct);
      }

      private Boolean UpdatePrices(Guid priceId, Guid? productId, Guid? priceDescriptionId, Decimal price, DateTime enterDate, Boolean status, Int32 domainId, Int32 languageId, String namePriceDes, String nameProduct)  
      {
          Store_PricesDetails Store_Prices = new Store_PricesDetails(PriceId, ProductId, PriceDescriptionId, Price, EnterDate, Status, DomainId, LanguageId,NamePriceDes,NameProduct);
          Boolean ret = SiteProvider.Store.UpdatePrices(Store_Prices);
          if (Settings.EnableCaching & ret)
              InvalidateCache();
          return ret;
      }

      public bool DeletePrices(Guid Id) 
      {


          Boolean ret = SiteProvider.Store.DeletePrices(Id);
          if (Settings.EnableCaching & ret)
              InvalidateCache();
          return ret;
      }





        //    /// <summary>
        //    /// تبدیل داده های لایه دیتا به داده های لایه تجاری 
        //    /// </summary>
        //    /// <param name="records">رکوردهای ورودی حاوی داده های لایه دیتا</param>
        //    /// <returns></returns>
      private static List<Store_Prices> GetStore_PricesCollectionFromOrderDal(List<Store_PricesDetails> records)
        {
            List<Store_Prices> items = new List<Store_Prices>();
            foreach (Store_PricesDetails item in records)
                items.Add(GetStore_PricesFromOrderDal(item));
            return items;
        }

        /// <summary>
        /// تبدیل داده لایه دیتا به داده لایه تجاری
        /// </summary>
        /// <param name="record">رکورد ورودی حاوی داده لایه دیتا</param>
        /// <returns></returns>
      private static Store_Prices GetStore_PricesFromOrderDal(Store_PricesDetails record)
        {
            if (record != null)
                return new Store_Prices(record.PriceId,record.ProductId,record.PriceDescriptionId,record.Price,record.EnterDate,record.Status,record.DomainId,record.LanguageId,record.NamePriceDes,record.NameProduct);
            return null;
        }

        #endregion
    }
}
