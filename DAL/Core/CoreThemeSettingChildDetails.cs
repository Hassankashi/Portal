using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pine.Dal.Core
{
   public class CoreThemeSettingChildDetails
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

       public CoreThemeSettingChildDetails() { }

       public CoreThemeSettingChildDetails(Int32 themeSettingChildId, Int32 themeSettingId, String value1, String value2, String value3, String value4, String value5, String value6, String value7, String parameter, Int32 domainId, Int32 languageId) 
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


   }
}
