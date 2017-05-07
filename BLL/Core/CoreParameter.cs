using System;
using System.Linq;
using System.Collections.Generic;
using Pine.Dal;
using Pine.Dal.Core;

namespace Pine.Bll.Core
{

    public class CoreParameter : BaseCore
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
        public CoreParameter(Int32 coreParameterId, String parameter, String name, String value1, String value2, String value3 , Int32 domainId , Int32 languageId )
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



        public CoreParameter()
        {
            CacheDuration = Settings.CacheDuration;
            MasterCacheKey = "Core";
        }

        #endregion Constructors

        #region Properties (6)

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

        #region Methods(3)

        public CoreParameter GetCoreParameterByCoreParameterId(Int32 coreParameterId)
        {
            CoreParameter item;

            String key = "CoreParameter_CoreParameterId_" + coreParameterId;

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as CoreParameter;
                if (item == null)
                {
                    CoreParameterDetails recordSet = SiteProvider.Core.GetCoreParameterByCoreParameterId(coreParameterId);
                    item = GetCoreParameterFromOrderDal(recordSet);
                    AddCacheItem(key, item);
                }
            }
            else
            {
                CoreParameterDetails recordSet = SiteProvider.Core.GetCoreParameterByCoreParameterId(coreParameterId);
                item = GetCoreParameterFromOrderDal(recordSet);
            }
            return item;
        }

        public List<CoreParameter> GetCoreParameterByParameterAndValue(String parameter, String value)
        {
           List<CoreParameter> item;
            String key = "CoreParameter_Parameter_Value1_" + parameter + "_" + value;

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as List<CoreParameter>;
                if (item == null)
                {
                    List<CoreParameterDetails> recordSet = SiteProvider.Core.GetCoreParameterByParameterAndValue(parameter, value);
                    item = GetCoreParameterCollectionFromOrderDal(recordSet);
                    AddCacheItem(key, item);
                }
            }
            else
            {
                List<CoreParameterDetails> recordSet = SiteProvider.Core.GetCoreParameterByParameterAndValue(parameter, value);
                item = GetCoreParameterCollectionFromOrderDal(recordSet);
            }
            return item;
        }

        public Boolean DeleteCoreParameterByParameter(String parameter)
        {
            Boolean ret = Delete(parameter);
            //if (ret)
            //    Id = -1;
            return ret;
        }

        /// <summary>
        /// حذف یک پرداخت نقدی
        /// </summary>
        /// <param name="cashId">کد پرداخت</param>
        /// <returns></returns>
        protected Boolean Delete(String parameter)
        {
            Boolean ret = SiteProvider.Core.DeleteCoreParameterByParameter(parameter);
            if (Settings.EnableCaching & ret)
                InvalidateCache();
            return ret;
        }
         

        public  Int32 Insert()
        {
            return Insert(CoreParameterId, Parameter, Name, Value1, Value2, Value3, DomainId, LanguageId);
        }

        private static Int32 Insert(Int32 coreParameterId, String parameter, String name, String value1, String value2, String value3, Int32 domainId, Int32 languageId)
        {
            CoreParameterDetails coreParameter = new CoreParameterDetails(coreParameterId, parameter, name, value1, value2, value3, domainId, languageId);
            Int32 ret = SiteProvider.Core.InsertCoreParameter(coreParameter);
            if (Settings.EnableCaching & ret > 0)
            {
                SetCache();
                InvalidateCache();
            }
            return ret;
        }

        public bool Update()
        {
            return Update(CoreParameterId, Parameter, Name, Value1, Value2, Value3 , DomainId , LanguageId);
        }

        private Boolean Update(Int32 coreParameterId, String parameter, String name, String value1, String value2, String value3, Int32 domainId, Int32 languageId)
        {
            CoreParameterDetails coreParameter = new CoreParameterDetails(coreParameterId, parameter, name, value1, value2, value3, domainId, languageId);
            Boolean ret = SiteProvider.Core.UpdateCoreParameter(coreParameter);
            if (Settings.EnableCaching & ret)
                InvalidateCache();
            return ret;
        }

        /// <summary>
        /// تبدیل داده های لایه دیتا به داده های لایه تجاری 
        /// </summary>
        /// <param name="records">رکوردهای ورودی حاوی داده های لایه دیتا</param>
        /// <returns></returns>
        private static List<CoreParameter> GetCoreParameterCollectionFromOrderDal(List<CoreParameterDetails> records)
        {
            List<CoreParameter> items = new List<CoreParameter>();
            foreach (CoreParameterDetails item in records)
                items.Add(GetCoreParameterFromOrderDal(item));
            return items;
        }

        /// <summary>
        /// تبدیل داده لایه دیتا به داده لایه تجاری
        /// </summary>
        /// <param name="record">رکورد ورودی حاوی داده لایه دیتا</param>
        /// <returns></returns>
        private static CoreParameter GetCoreParameterFromOrderDal(CoreParameterDetails record)
        {
            if (record != null)
                return new CoreParameter(record.CoreParameterId , record.Parameter, record.Name, record.Value1, record.Value2, record.Value3 , record.DomainId , record.LanguageId);
            return null;
        }

        #endregion
    }
}
