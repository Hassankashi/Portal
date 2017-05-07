using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pine.Bll;
using Pine.Dal.Store;
using Pine.Dal;
namespace Pine.Bll.Store
{
    public class Store_ProductsConModules : BaseStore
    {

        #region Constructors (2)


       public Store_ProductsConModules(Guid productId, Int32 idModule, String description, String value1, String value2, String value3, String value4, String value5)
        {

            ProductId = productId;
            IdModule =idModule;
            Description = description;
            Value1 = value1;
            Value2 = value2;
            Value3 = value3;
            Value4 = value4;
            Value5 = value5;
          

        }

       public Store_ProductsConModules()
        {
            CacheDuration = Settings.CacheDuration;
            MasterCacheKey = "Store";
        }

        #endregion Constructors

        #region Properties (9)

        public Guid ProductId { get; set; }

       public Int32 IdModule { get; set; }

       public String Description { get; set; }

       public String Value1 { get; set; }

       public String Value2 { get; set; }

       public String Value3 { get; set; }

       public String Value4 { get; set; }

       public String Value5 { get; set; }
  

        #endregion Properties

        #region Methods
       public Int32 InsertProductsConModules()
       {
           return InsertProductsConModules(ProductId,IdModule, Description, Value1, Value2, Value3, Value4, Value5);
       }

       private Int32 InsertProductsConModules(Guid productId, Int32 idModule, String description, String value1, String value2, String value3, String value4, String value5)
       {
           Store_ProductsConModulesDetails Store_ProductsConModules = new Store_ProductsConModulesDetails(productId, idModule, description, value1, value2, value3, value4, value5);
           Int32 ret = SiteProvider.Store.InsertProductsConModules(Store_ProductsConModules);
           if (Settings.EnableCaching & ret > 0)
               InvalidateCache();
           return ret;
       }

       public bool DeleteProductsConModules(Guid id)
       {


           Boolean ret = SiteProvider.Store.DeleteProductsConModules(id);
           if (Settings.EnableCaching & ret)
               InvalidateCache();
           return ret;
       }


       //    /// <summary>
       //    /// تبدیل داده های لایه دیتا به داده های لایه تجاری 
       //    /// </summary>
       //    /// <param name="records">رکوردهای ورودی حاوی داده های لایه دیتا</param>
       //    /// <returns></returns>
       private static List<Store_ProductsConModules> GetStore_ProductsConModulesCollectionFromOrderDal(List<Store_ProductsConModulesDetails> records)
       {
           List<Store_ProductsConModules> items = new List<Store_ProductsConModules>();
           foreach (Store_ProductsConModulesDetails item in records)
               items.Add(GetStore_ProductsConModulesFromOrderDal(item));
           return items;
       }

       /// <summary>
       /// تبدیل داده لایه دیتا به داده لایه تجاری
       /// </summary>
       /// <param name="record">رکورد ورودی حاوی داده لایه دیتا</param>
       /// <returns></returns>
       private static Store_ProductsConModules GetStore_ProductsConModulesFromOrderDal(Store_ProductsConModulesDetails record)
       {
           if (record != null)
               return new Store_ProductsConModules(record.ProductId,record.IdModule, record.Description, record.Value1, record.Value2, record.Value3, record.Value4, record.Value5);
           return null;
       }

        #endregion
    }
}
