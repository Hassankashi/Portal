using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pine.Dal;
using Pine.Dal.Core;

namespace Pine.Bll.Core
{
   public class CoreThemeSettingMiddelSettingMasterPageName : BaseCore
    {

        #region Properties

        public int ThemeSettingId { get; set; }
        public int ThemeSettingTypeId { get; set; }
        public int MasterPageNameId { get; set; }
        public String Value1 { get; set; }
        public String Value2 { get; set; }
        public String Value3 { get; set; }
        public String Value4 { get; set; }
        public String Value5 { get; set; }
        public String Value6 { get; set; }
        public String Value7 { get; set; }
        public String Parameter { get; set; }
        public String ThemeName { get; set; }
       
        #endregion

        #region costructor

        public CoreThemeSettingMiddelSettingMasterPageName(int themeSettingId, int themeSettingTypeId, int masterPageNameId, String value1, String value2,
                                                                  String value3, String value4, String value5, String value6, String value7, String parameter, String themeName)
        {
            ThemeSettingId = themeSettingId;
            ThemeSettingTypeId = themeSettingTypeId;
            MasterPageNameId = masterPageNameId;
            Value1 = value1;
            Value2 = value2;
            Value3 = value3;
            Value4 = value4;
            Value5 = value5;
            Value6 = value6;
            Value7 = value7;
            Parameter = parameter;
            ThemeName = themeName;
        }

      public CoreThemeSettingMiddelSettingMasterPageName()
      {
          CacheDuration = Settings.CacheDuration;
          MasterCacheKey = "Core";
      }
        #endregion

     #region Method

      public static List<CoreThemeSettingMiddelSettingMasterPageName> GetCoreThemeSettingMiddelSettingMasterPageName(String themeName)
      {
        SetCache();
            List<CoreThemeSettingMiddelSettingMasterPageName> item;

            String key = "CoreThemeSettingMiddelSettingMasterPageName_themeName_" + themeName;

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as List<CoreThemeSettingMiddelSettingMasterPageName>;
                if (item == null)
                {
                    List<CoreThemeSettingMiddelSettingMasterPageNameDetails> recordSet =
                        SiteProvider.Core.GetCoreThemeSettingMiddelSettingMasterPageName(themeName);
                    item = GetCoreThemeSettingMiddelSettingMasterPageNameCollectionFromOrderDal(recordSet);
                    AddCacheItem(key, item);
                }
            }
            else
            {
                List<CoreThemeSettingMiddelSettingMasterPageNameDetails> recordSet = SiteProvider.Core.GetCoreThemeSettingMiddelSettingMasterPageName(themeName);
                item = GetCoreThemeSettingMiddelSettingMasterPageNameCollectionFromOrderDal(recordSet);
            }
            return item;
        }

      private static List<CoreThemeSettingMiddelSettingMasterPageName> GetCoreThemeSettingMiddelSettingMasterPageNameCollectionFromOrderDal(List<CoreThemeSettingMiddelSettingMasterPageNameDetails> recordSet)
        {
            List<CoreThemeSettingMiddelSettingMasterPageName> items = new List<CoreThemeSettingMiddelSettingMasterPageName>();
            foreach (CoreThemeSettingMiddelSettingMasterPageNameDetails item in recordSet)
                items.Add(CoreThemeSettingMiddelSettingMasterPageNameFromOrderDal(item));
            return items;
        }

      private static CoreThemeSettingMiddelSettingMasterPageName CoreThemeSettingMiddelSettingMasterPageNameFromOrderDal(CoreThemeSettingMiddelSettingMasterPageNameDetails item)
        {
            if (item != null)
                return new CoreThemeSettingMiddelSettingMasterPageName(item.ThemeSettingId, item.ThemeSettingTypeId,
                                                                       item.ThemeSettingId, item.Value1, item.Value2,
                                                                       item.Value3, item.Value4, item.Value5,
                                                                       item.Value6, item.Value7, item.Parameter,
                                                                       item.ThemeName);
            return null;
        }


    #endregion
    }
}
