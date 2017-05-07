using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pine.Dal.Store;
using Pine.Dal;

namespace Pine.Bll.Store
{
   public  class Store_Specification1 : BaseStore
    {

        #region Constructors (2)


        public  Store_Specification1(String name, String text, String description)
        {

            Name = name;
            Text = text;
            Description = description;


        }

        public Store_Specification1()
        {
            CacheDuration = Settings.CacheDuration;
            MasterCacheKey = "Store";
        }

        #endregion Constructors

        #region Properties (2)

        public String Name { get; set; }

        public String Text { get; set; }

        public String Description { get; set; }

        #endregion Properties



        #region Methods(4)

        public static List<Store_Specification1> GetStore_SpecificationJoin(Guid productId)
        {

            List<Store_Specification1> item;

            String key = "Store_Specification_productId_" + productId;

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as List<Store_Specification1>;
                if (item == null)
                {
                    List<Store_SpecificationDetails> recordSet = SiteProvider.Store.GetSpecificationJoin(productId);
                    item = GetStore_SpecificationCollectionFromOrderDal(recordSet);
                    AddCacheItem(key, item);
                }
            }
            else
            {
                List<Store_SpecificationDetails> recordSet = SiteProvider.Store.GetSpecificationJoin(productId);
                item = GetStore_SpecificationCollectionFromOrderDal(recordSet);
            }
            return item;

        }

      

        private static List<Store_Specification1> GetStore_SpecificationCollectionFromOrderDal(List<Store_SpecificationDetails> records)
        {
            List<Store_Specification1> items = new List<Store_Specification1>();
            foreach (Store_SpecificationDetails item in records)
                items.Add(GetStore_SpecificationFromOrderDal(item));
            return items;
        }

        /// <summary>
        /// تبدیل داده لایه دیتا به داده لایه تجاری
        /// </summary>
        /// <param name="record">رکورد ورودی حاوی داده لایه دیتا</param>
        /// <returns></returns>
        private static Store_Specification1 GetStore_SpecificationFromOrderDal(Store_SpecificationDetails record)
        {
            if (record != null)
                return new Store_Specification1(record.Name, record.Text, record.Description);
            return null;
        }



        #endregion


    }
}
