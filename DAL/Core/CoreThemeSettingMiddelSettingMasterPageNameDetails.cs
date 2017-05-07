using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pine.Dal.Properties;

namespace Pine.Dal.Core
{
    public  class CoreThemeSettingMiddelSettingMasterPageNameDetails
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

        public CoreThemeSettingMiddelSettingMasterPageNameDetails(int themeSettingId, int themeSettingTypeId, int masterPageNameId, String value1, String value2,
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

      public CoreThemeSettingMiddelSettingMasterPageNameDetails()
      {
        
      }
        #endregion
    }
}
