using System;
using System.Linq;
using System.Collections.Generic;
using Pine.Dal;
using Pine.Dal.Core;

namespace Pine.Bll.Core
{
    /// <summary>
    /// کلاسی برای نگهداری منو
    /// </summary>
    public class CoreThemeSettingChild : BaseCore
    {
        #region Properties(12)
       public Int32 ThemeSettingChildId { get; set; }

       public Int32 ThemeSettingId { get; set; }

        /// <summary>
       /// مقدار 1 
       /// </summary>
       public String Value1 { get; set; }


       /// <summary>
       /// مقدار 2
       /// </summary>
       public String Value2 { get; set; }


       /// <summary>
       /// مقدار 3
       /// </summary>
       public String Value3 { get; set; }


       /// <summary>
       /// مقدار 4
       /// </summary>
       public String Value4 { get; set; }

       /// <summary>
       /// مقدار 5
       /// </summary>
       public String Value5 { get; set; }


       /// <summary>
       /// مقدار 6 
       /// </summary>
       public String Value6 { get; set; }

       /// <summary>
       /// مقدار 7
       /// </summary>
       public String Value7 { get; set; }


       /// <summary>
       ///  پارامتر
       /// </summary>
       public String Parameter { get; set; }
       public Int32 DomainId { get; set; }
       public Int32 LanguageId { get; set; }


       #endregion

       #region constructor

       public CoreThemeSettingChild()
       {
           CacheDuration = Settings.CacheDuration;
           MasterCacheKey = "Core";
       }

       public CoreThemeSettingChild(Int32 themeSettingChildId, Int32 themeSettingId, String value1, String value2, String value3, String value4, String value5, String value6, String value7, String parameter, Int32 domainId, Int32 languageId) 
       {
           ThemeSettingChildId = themeSettingChildId;
           ThemeSettingId = themeSettingId;
           Value1 = value1;
           Value2 = value2;
           Value3 = value3;
           Value4 = value4;
           Value5 = value5;
           Value6 = value6;
           Value7 = value7;
           Parameter = parameter;
           DomainId = domainId;
           LanguageId = languageId;
       }

       #endregion

        #region Methods(3)

       public static CoreThemeSettingChild GetCoreThemeSettingChild(Int32 themeSettingChildId)
       {
           CoreThemeSettingChild item;
           SetCache();
           String key = "CoreThemeSettingChild_themeSettingChildId_" + themeSettingChildId;

           if (Settings.EnableCaching)
           {
               item = GetCacheItem(key) as CoreThemeSettingChild;
               if (item == null)
               {
                   CoreThemeSettingChildDetails record = SiteProvider.Core.GetCoreThemeSettingChild(themeSettingChildId);
                   item = GetCoreThemeSettingChildFromOrderDal(record);
                   AddCacheItem(key, item);
               }
           }
           else
           {
               CoreThemeSettingChildDetails recordSet = SiteProvider.Core.GetCoreThemeSettingChild(themeSettingChildId);
               item = GetCoreThemeSettingChildFromOrderDal(recordSet);
           }

           return item;
       }

       public static List<CoreThemeSettingChild> GetCoreThemeSettingChildByThemeSettingId(Int32 themeSettingId)
       {
           List<CoreThemeSettingChild> item;
           SetCache();
           String key = "CoreThemeSettingChild_themeSettingId_" + themeSettingId;

           if (Settings.EnableCaching)
           {
               item = GetCacheItem(key) as List<CoreThemeSettingChild>;
               if (item == null)
               {
                   List<CoreThemeSettingChildDetails> record = SiteProvider.Core.GetCoreThemeSettingChildByThemeSettingId(themeSettingId);
                   item = GetCoreThemeSettingChildCollectionFromOrderDal(record);
                   AddCacheItem(key, item);
               }
           }
           else
           {
               List<CoreThemeSettingChildDetails> recordSet = SiteProvider.Core.GetCoreThemeSettingChildByThemeSettingId(themeSettingId);
               item = GetCoreThemeSettingChildCollectionFromOrderDal(recordSet);
           }

           return item;
       }

       public Int32 Insert()
       {
           return Insert(ThemeSettingChildId, ThemeSettingId, Value1, Value2, Value3, Value4, Value5, Value6, Value7, Parameter, DomainId, LanguageId);
       }

       private Int32 Insert(Int32 themeSettingChildId, Int32 themeSettingId, String value1, String value2, String value3, String value4, String value5, String value6, String value7, String parameter, Int32 domainId, Int32 languageId)
       {
           CoreThemeSettingChildDetails coreThemeSettingChilDetails = new CoreThemeSettingChildDetails(themeSettingChildId, themeSettingId, value1, value2, value3, value4, value5, value6, value7, parameter, domainId, languageId);
           Int32 ret = SiteProvider.Core.InsertCoreThemeSettingChild(coreThemeSettingChilDetails);
           if (Settings.EnableCaching & ret > 0)
               InvalidateCache();
           return ret;
       }

       public bool Update()
       {
           return Update(ThemeSettingChildId, ThemeSettingId, Value1, Value2, Value3, Value4, Value5, Value6, Value7, Parameter, DomainId, LanguageId);
       }

       private Boolean Update(Int32 themeSettingChildId, Int32 themeSettingId, String value1, String value2, String value3, String value4, String value5, String value6, String value7, String parameter, Int32 domainId, Int32 languageId)
       {
           CoreThemeSettingChildDetails coreThemeSettingChilDetails = new CoreThemeSettingChildDetails(themeSettingChildId, themeSettingId, value1, value2, value3, value4, value5, value6, value7, parameter, domainId, languageId);
           Boolean ret = SiteProvider.Core.UpdateCoreThemeSettingChild(coreThemeSettingChilDetails);
           if (Settings.EnableCaching & ret)
               InvalidateCache();
           return ret;
       }

       public bool Delete()
       {
           return Delete(ThemeSettingChildId, ThemeSettingId, Value1, Value2, Value3, Value4, Value5, Value6, Value7, Parameter, DomainId, LanguageId);
       }

       private bool Delete(Int32 themeSettingChildId, Int32 themeSettingId, String value1, String value2, String value3, String value4, String value5, String value6, String value7, String parameter, Int32 domainId, Int32 languageId)
       {
           CoreThemeSettingChildDetails coreThemeSettingChilDetails = new CoreThemeSettingChildDetails(themeSettingChildId, themeSettingId, value1, value2, value3, value4, value5, value6, value7, parameter, domainId, languageId);
           bool ret = SiteProvider.Core.DeleteCoreThemeSettingChild(coreThemeSettingChilDetails.ThemeSettingChildId);
           if (Settings.EnableCaching & ret)
               InvalidateCache();
           return ret;
       }

       

        /// <summary>
        /// تبدیل داده های لایه دیتا به داده های لایه تجاری 
        /// </summary>
        /// <param name="records">رکوردهای ورودی حاوی داده های لایه دیتا</param>
        /// <returns></returns>
        private static List<CoreThemeSettingChild> GetCoreThemeSettingChildCollectionFromOrderDal(List<CoreThemeSettingChildDetails> records)
        {
            List<CoreThemeSettingChild> items = new List<CoreThemeSettingChild>();
            foreach (CoreThemeSettingChildDetails item in records)
                items.Add(GetCoreThemeSettingChildFromOrderDal(item));
            return items;
        }

        /// <summary>
        /// تبدیل داده لایه دیتا به داده لایه تجاری
        /// </summary>
        /// <param name="record">رکورد ورودی حاوی داده لایه دیتا</param>
        /// <returns></returns>
        /// 
     
        private static CoreThemeSettingChild GetCoreThemeSettingChildFromOrderDal(CoreThemeSettingChildDetails record)
        {
            if (record != null)
                return new CoreThemeSettingChild(record.ThemeSettingChildId , record.ThemeSettingId, record.Value1 , record.Value2 , record.Value3 , record.Value4 , record.Value5 , record.Value6 ,record.Value7,record.Parameter,record.DomainId,record.LanguageId);
            return null;
        }

        #endregion
    }
}
