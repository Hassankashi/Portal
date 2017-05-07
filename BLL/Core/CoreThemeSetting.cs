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
    public class CoreThemeSetting : BaseCore
    {
        #region Constructors (2)

        /// <summary>
        /// سازنده اصلی کلاس جزئیات تنظیمات طرح
        /// </summary>

        public CoreThemeSetting(Int32 themeSettingId, Int32 themeSettingTypeId, String value1, String value2, String value3, String value4, String value5, String value6, String value7, String parameter, Int32 domainId, Int32 languageId)
        {
            Id = themeSettingId;
            ThemeSettingTypeId = themeSettingTypeId;
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

        /// <summary>
        /// سازنده پیش فرض کلاس جزئیات تنظیمات طرح
        /// </summary>
        public CoreThemeSetting()
        {
            CacheDuration = Settings.CacheDuration;
            MasterCacheKey = "Core";
        }

        #endregion Constructors

        #region Properties (12)

        public Int32 ThemeSettingId { get; set; }
        /// <summary>
        /// کد پارامتر نوع تنظیمات
        /// </summary>
        public Int32 ThemeSettingTypeId { get; set; }

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

        #endregion Properties

        #region Methods(3)

        public  List<CoreThemeSetting> GetCoreThemeSettingByThemeName(String themeName)
        {
            List<CoreThemeSetting> item;

            String key = "CoreThemeSetting_ThemeName_" + themeName;

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as List<CoreThemeSetting>;
                if (item == null)
                {
                    List<CoreThemeSettingDetails> recordSet = SiteProvider.Core.GetCoreThemeSettingDetailsByThemeName(themeName);
                    item = GetCoreThemeSettingCollectionFromOrderDal(recordSet);
                    AddCacheItem(key, item);
                }
            }
            else
            {

                List<CoreThemeSettingDetails> recordSet = SiteProvider.Core.GetCoreThemeSettingDetailsByThemeName(themeName);
                item = GetCoreThemeSettingCollectionFromOrderDal(recordSet);
            }
            return item;
        }



        public Int32 Insert()
        {
            return Insert(ThemeSettingId, ThemeSettingTypeId, Value1, Value2, Value3, Value4, Value5, Value6, Value7, Parameter, DomainId, LanguageId);
        }

        private Int32 Insert(Int32 themeSettingId, Int32 themeSettingTypeId, String value1, String value2, String value3, String value4, String value5, String value6, String value7, String parameter, Int32 domainId, Int32 languageId)
        {
            CoreThemeSettingDetails coreThemeSettingDetails = new CoreThemeSettingDetails(themeSettingId, themeSettingTypeId, value1, value2, value3, value4, value5, value6, value7, parameter, domainId, languageId);
            Int32 ret = SiteProvider.Core.InsertCoreThemeSetting(coreThemeSettingDetails);
            if (Settings.EnableCaching & ret > 0)
                InvalidateCache();
            return ret;
        }

        public bool Update()
        {
            return Update(ThemeSettingId, ThemeSettingTypeId, Value1, Value2, Value3, Value4, Value5, Value6, Value7, Parameter, DomainId, LanguageId);
        }

        private Boolean Update(Int32 themeSettingId, Int32 themeSettingTypeId, String value1, String value2, String value3, String value4, String value5, String value6, String value7, String parameter, Int32 domainId, Int32 languageId)
        {
            CoreThemeSettingDetails coreThemeSettingDetails = new CoreThemeSettingDetails(themeSettingId, themeSettingTypeId, value1, value2, value3, value4, value5, value6, value7, parameter, domainId, languageId);
            Boolean ret = SiteProvider.Core.UpdateCoreThemeSetting(coreThemeSettingDetails);
            if (Settings.EnableCaching & ret)
                InvalidateCache();
            return ret;
        }

        public bool Delete()
        {
            return Delete(ThemeSettingId, ThemeSettingTypeId, Value1, Value2, Value3, Value4, Value5, Value6, Value7, Parameter, DomainId, LanguageId);
        }

        private bool Delete(Int32 themeSettingId, Int32 themeSettingTypeId, String value1, String value2, String value3, String value4, String value5, String value6, String value7, String parameter, Int32 domainId, Int32 languageId)
        {
            CoreThemeSettingDetails coreThemeSettingDetails = new CoreThemeSettingDetails(themeSettingId, themeSettingTypeId, value1, value2, value3, value4, value5, value6, value7, parameter, domainId, languageId);
            bool ret = SiteProvider.Core.DeleteCoreThemeSetting(coreThemeSettingDetails.ThemeSettingId);
            if (Settings.EnableCaching & ret)
                InvalidateCache();
            return ret;
        }

       

        /// <summary>
        /// تبدیل داده های لایه دیتا به داده های لایه تجاری 
        /// </summary>
        /// <param name="records">رکوردهای ورودی حاوی داده های لایه دیتا</param>
        /// <returns></returns>
        private static List<CoreThemeSetting> GetCoreThemeSettingCollectionFromOrderDal(List<CoreThemeSettingDetails> records)
        {
            List<CoreThemeSetting> items = new List<CoreThemeSetting>();
            foreach (CoreThemeSettingDetails item in records)
                items.Add(GetCoreThemeSettingFromOrderDal(item));
            return items;
        }

        /// <summary>
        /// تبدیل داده لایه دیتا به داده لایه تجاری
        /// </summary>
        /// <param name="record">رکورد ورودی حاوی داده لایه دیتا</param>
        /// <returns></returns>
        private static CoreThemeSetting GetCoreThemeSettingFromOrderDal(CoreThemeSettingDetails record)
        {
            if (record != null)
                return new CoreThemeSetting(record.ThemeSettingId , record.ThemeSettingTypeId, record.Value1 , record.Value2 , record.Value3 , record.Value4 , record.Value5 , record.Value6 ,record.Value7,record.Parameter,record.DomainId,record.LanguageId);
            return null;
        }

        #endregion
    }
}
