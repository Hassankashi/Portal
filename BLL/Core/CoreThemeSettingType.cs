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
    public class CoreThemeSettingType : BaseCore
    {
        #region properties
       public Int32 ThemeSettingTypeId { get; set; }
       public String Parameter { get; set; }
       public String Name { get; set; }
       public Int32 DomainId { get; set; }
       public Int32 LanguageId { get; set; }

       #endregion 

       #region constructor
       public CoreThemeSettingType()
       {
           CacheDuration = Settings.CacheDuration;
           MasterCacheKey = "Core";
       }

       public CoreThemeSettingType(Int32 themeSettingTypeId, String parameter, String name, Int32 domainId, Int32 languageId) 
       {
           ThemeSettingTypeId = themeSettingTypeId;
           Parameter = parameter;
           Name = name;
           DomainId = domainId;
           LanguageId = languageId;
       
       }
       #endregion 

        #region Methods(3)

       public Int32 Insert()
       {
           return Insert(ThemeSettingTypeId,Parameter,Name,DomainId, LanguageId);
       }

       private Int32 Insert(Int32 themeSettingTypeId, String parameter, String name, Int32 domainId, Int32 languageId)
       {
           CoreThemeSettingTypeDetails coreThemeSettingTypeDetails = new CoreThemeSettingTypeDetails(themeSettingTypeId, parameter, name, domainId, languageId);
           Int32 ret = SiteProvider.Core.InsertCoreThemeSettingType(coreThemeSettingTypeDetails);
           if (Settings.EnableCaching & ret > 0)
               InvalidateCache();
           return ret;
       }

       public bool Update()
       {
           return Update(ThemeSettingTypeId, Parameter, Name, DomainId, LanguageId);
       }

       private Boolean Update(Int32 themeSettingTypeId, String parameter, String name, Int32 domainId, Int32 languageId)
       {
           CoreThemeSettingTypeDetails coreThemeSettingTypeetails = new CoreThemeSettingTypeDetails(themeSettingTypeId, parameter, name, domainId, languageId);
           Boolean ret = SiteProvider.Core.UpdateCoreThemeSettingType(coreThemeSettingTypeetails);
           if (Settings.EnableCaching & ret)
               InvalidateCache();
           return ret;
       }

       public bool Delete()
       {
           return Delete(ThemeSettingTypeId, Parameter, Name, DomainId, LanguageId);
       }

       private bool Delete(Int32 themeSettingTypeId, String parameter, String name, Int32 domainId, Int32 languageId)
       {
           CoreThemeSettingTypeDetails coreThemeSettingTypeDetails = new CoreThemeSettingTypeDetails(themeSettingTypeId, parameter, name, domainId, languageId);
           bool ret = SiteProvider.Core.DeleteCoreThemeSettingType(coreThemeSettingTypeDetails.ThemeSettingTypeId);
           if (Settings.EnableCaching & ret)
               InvalidateCache();
           return ret;
       }

       

        /// <summary>
        /// تبدیل داده های لایه دیتا به داده های لایه تجاری 
        /// </summary>
        /// <param name="records">رکوردهای ورودی حاوی داده های لایه دیتا</param>
        /// <returns></returns>
        private static List<CoreThemeSettingType> GetCoreThemeSettingTypeCollectionFromOrderDal(List<CoreThemeSettingTypeDetails> records)
        {
            List<CoreThemeSettingType> items = new List<CoreThemeSettingType>();
            foreach (CoreThemeSettingTypeDetails item in records)
                items.Add(GetCoreThemeSettingTypeFromOrderDal(item));
            return items;
        }

        /// <summary>
        /// تبدیل داده لایه دیتا به داده لایه تجاری
        /// </summary>
        /// <param name="record">رکورد ورودی حاوی داده لایه دیتا</param>
        /// <returns></returns>
        /// 
     
        private static CoreThemeSettingType GetCoreThemeSettingTypeFromOrderDal(CoreThemeSettingTypeDetails record)
        {
            if (record != null)
                return new CoreThemeSettingType(record.ThemeSettingTypeId, record.Parameter, record.Name, record.DomainId, record.LanguageId);
            return null;
        }

        #endregion
    }
}
