using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pine.Dal.Store
{
    public  class Store_SettingDetails
    { 
         #region Constructors (2)


        public Store_SettingDetails(Guid settingId, String parameter,String value1,String value2,String value3,String value4,String value5, Int32 domainId, Int32 languageId)
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

       public Store_SettingDetails()
        {
        }

        #endregion Constructors

        #region Properties (9)

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
    }
}
