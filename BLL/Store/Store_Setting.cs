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
    public class Store_Setting : BaseStore
    {
        
        #region Constructors (2)

        public Store_Setting(Guid settingId, String parameter, String value1, String value2, String value3, String value4, String value5, Int32 domainId, Int32 languageId)
        {

            SettingId = settingId;
            Parameter = parameter;
            Value1 = value1;
            Value2 = value2;
            Value3 = value3;
            Value4 = value4;
            Value5 = value5;
            DomainId = domainId;
            LanguageId = languageId;

        }


     
        /// <summary>
        /// سازنده پیش فرض کلاس جزئیات تنظیمات طرح
        /// </summary>
        public Store_Setting()
        {
            CacheDuration = Settings.CacheDuration;
            MasterCacheKey = "Store";
        }

       #endregion Constructors

        #region Properties (4)

     public Guid SettingId { get; set; }

       public String Parameter { get; set; }

       public String Value1 { get; set; }

       public String Value2 { get; set; }

       public String Value3 { get; set; }

       public String Value4 { get; set; }

       public String Value5 { get; set; }
  
        public Int32 DomainId { get; set; }

        public Int32 LanguageId { get; set; }

        #endregion Properties

        #region Methods(4)

        public List<Store_Setting> GetSettingById(Guid id)  
        {
            List<Store_Setting> item;

            String key = "Store_CategoryIds_" + id; 

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as List<Store_Setting>;
                if (item == null)
                {
                    List<Store_SettingDetails> recordSet = SiteProvider.Store.GetSettingById(id);
                    item = GetStore_SettingCollectionFromOrderDal(recordSet);
                    AddCacheItem(key, item);
                }
            }
            else
            {
                List<Store_SettingDetails> recordSet = SiteProvider.Store.GetSettingById(id); 
                item = GetStore_SettingCollectionFromOrderDal(recordSet);
            }
            return item;
        }

        public Int32 InsertSetting() 
        {
            return InsertSetting(SettingId, Parameter, Value1,  Value2, Value3, Value4, Value5, DomainId, LanguageId);
        }

        private Int32 InsertSetting(Guid settingId, String parameter, String value1, String value2, String value3, String value4, String value5, Int32 domainId, Int32 languageId)
        {
            Store_SettingDetails Store_Setting = new Store_SettingDetails(settingId, parameter, value1, value2, value3, value4, value5, domainId, languageId);
            Int32 ret = SiteProvider.Store.insertSetting(Store_Setting);
            if (Settings.EnableCaching & ret > 0)
                InvalidateCache(); 
            return ret;
        }

        public Boolean UpdateSetting()
        {
            return UpdateSetting(SettingId, Parameter, Value1, Value2, Value3, Value4, Value5, DomainId, LanguageId);
        }

        private Boolean UpdateSetting(Guid settingId, String parameter, String value1, String value2, String value3, String value4, String value5, Int32 domainId, Int32 languageId)
        {
            Store_SettingDetails Setting1 = new Store_SettingDetails(SettingId, Parameter, Value1, Value2, Value3, Value4, Value5, DomainId, LanguageId);
            Boolean ret = SiteProvider.Store.UpdateSetting(Setting1);
            if (Settings.EnableCaching & ret)
                InvalidateCache();
            return ret;
        }

        public bool DeleteSetting(Guid Id) 
        {


            Boolean ret = SiteProvider.Store.DeleteSetting(Id);
            if (Settings.EnableCaching & ret)
                InvalidateCache();
            return ret;
        }







        //    /// <summary>
        //    /// تبدیل داده های لایه دیتا به داده های لایه تجاری 
        //    /// </summary>
        //    /// <param name="records">رکوردهای ورودی حاوی داده های لایه دیتا</param>
        //    /// <returns></returns>
        private static List<Store_Setting> GetStore_SettingCollectionFromOrderDal(List<Store_SettingDetails> records)
        {
            List<Store_Setting> items = new List<Store_Setting>();
            foreach (Store_SettingDetails item in records)
                items.Add(GetStore_SettingFromOrderDal(item));
            return items;
        }

        /// <summary>
        /// تبدیل داده لایه دیتا به داده لایه تجاری
        /// </summary>
        /// <param name="record">رکورد ورودی حاوی داده لایه دیتا</param>
        /// <returns></returns>
        private static Store_Setting GetStore_SettingFromOrderDal(Store_SettingDetails record)
        {
            if (record != null)
                return new Store_Setting(record.SettingId , record.Parameter,record.Value1,record.Value2,record.Value3,record.Value4,record.Value5,record.DomainId,record.LanguageId);
            return null;
        }

        #endregion
    }
}
