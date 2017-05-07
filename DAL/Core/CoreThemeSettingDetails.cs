using System;
using System.Linq;

namespace Pine.Dal.Core
{
    /// <summary>
    /// کلاسی برای نگهداری جزئیات طرح
    /// </summary>
    public class CoreThemeSettingDetails
    {

        #region Constructors (2)

        /// <summary>
        /// سازنده اصلی کلاس جزئیات تنظیمات طرح
        /// </summary>
        /// <param name="themeSettingId">کد تنظیمات طرح</param>
        /// <param name="themeSettingTypeId">کد نوع تنظیمات طرح</param>
        /// <param name="value1">مقدار 1</param>
        /// <param name="value2">مقدار 2</param>
        /// <param name="value3">مقدار 3</param>
        /// <param name="value4">مقدار 4</param>
        /// <param name="value5">مقدار 5</param>
        /// <param name="value6">مقدار 6</param>
        /// <param name="value7">مقدار 7</param>
        public CoreThemeSettingDetails(Int32 themeSettingId, Int32 themeSettingTypeId, String value1, String value2, String value3, String value4, String value5, String value6, String value7, String parameter, Int32 domainId, Int32 languageId)
        {
            ThemeSettingId = themeSettingId;
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
        /// سازنده پیش فرض کلاس تنظیمات طرح
        /// </summary>
        public CoreThemeSettingDetails()
        {
        }

        #endregion Constructors

        #region Properties (12)

        /// <summary>
        /// کد تنظیمات طرح
        /// </summary>
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
        public String Value3{ get; set; }


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

    }
}
