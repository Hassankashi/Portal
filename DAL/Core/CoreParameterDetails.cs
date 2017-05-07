using System;
using System.Linq;

namespace Pine.Dal.Core
{
    /// <summary>
    /// کلاسی برای نگهداری جزئیات گروه منو
    /// </summary>
    public class CoreParameterDetails
    {

        #region Constructors (2)

        /// <summary>
        /// سازنده اصلی کلاس جزئیات پارامترهای هسته
        /// </summary>
        /// <param name="coreParameterId">کد پارامتر</param>
        /// <param name="parameter">نام پارامتر</param>
        /// <param name="name">نام</param>
        /// <param name="value1">مقدار 1</param>
        /// <param name="value2">مقدار 2</param>
        /// <param name="value3">مقدار 3</param>
        public CoreParameterDetails(Int32 coreParameterId, String parameter, String name, String value1, String value2, String value3, Int32 domainId, Int32 languageId)
        {
            CoreParameterId = coreParameterId;
            Parameter = parameter;
            Name = name;
            Value1 = value1;
            Value2 = value2;
            Value3 = value3;
            DomainId = domainId;
            LanguageId = languageId;
        }




        /// <summary>
        /// سازنده پیش فرض کلاس جزئیات گروه منو
        /// </summary>
        public CoreParameterDetails()
        {
        }

        #endregion Constructors

        #region Properties (8)

        /// <summary>
        /// کد پارامتر هسته
        /// </summary>
        public Int32 CoreParameterId { get; set; }

        /// <summary>
        /// نام پارامتر
        /// </summary>
        public String Parameter { get; set; }

        /// <summary>
        /// نام 
        /// </summary>
        public String Name { get; set; }


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

        public Int32 DomainId { get; set; }

        public Int32 LanguageId { get; set; }

        #endregion Properties

    }
}
