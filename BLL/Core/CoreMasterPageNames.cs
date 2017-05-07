using System;
using System.Linq;
using System.Collections.Generic;
using Pine.Dal;
using Pine.Dal.Core;

namespace Pine.Bll.Core
{
    /// <summary>
    /// کلاسی برای نگهداری طرح مسترپیج
    /// </summary>
    public class CoreMasterPageNames : BaseCore
    {
        #region Constructors (2)

        /// <summary>
        /// سازنده اصلی کلاس جزئیات تنظیمات طرح
        /// </summary>

        public CoreMasterPageNames(Int32 masterPageNameId, Int32 masterPageGroupNameId, String themeName, String path, String pathSmallImage, String pathImage, String nameImage, Boolean rtl,Int32 domainId , Int32 languageId)
        {
            MasterPageNameId = masterPageNameId;
            MasterPageGroupNameId = masterPageGroupNameId;
            ThemeName = themeName;
            Path = path;
            PathSmallImage = pathSmallImage;
            PathImage = pathImage;
            NameImage = nameImage;
            Rtl = rtl;
            DomainId = domainId;
            LanguageId = languageId;
        }

        /// <summary>
        /// سازنده پیش فرض کلاس جزئیات تنظیمات طرح
        /// </summary>
        public CoreMasterPageNames()
        {
            CacheDuration = Settings.CacheDuration;
            MasterCacheKey = "Core";
        }

        #endregion Constructors

        #region Properties (8)

        public Int32 MasterPageNameId { get; set; }
        /// <summary>
        /// کد گروه مسترپیج
        /// </summary>
        public Int32 MasterPageGroupNameId { get; set; }

        /// <summary>
        /// نام طرح 
        /// </summary>
        public String ThemeName { get; set; }


        /// <summary>
        /// مسیر مستر پیج طرح
        /// </summary>
        public String Path { get; set; }


        /// <summary>
        /// مسیر عکس کوچک
        /// </summary>
        public String PathSmallImage { get; set; }


        /// <summary>
        /// مسیر عکس
        /// </summary>
        public String PathImage { get; set; }

        /// <summary>
        /// نام عکس
        /// </summary>
        public String NameImage { get; set; }


        /// <summary>
        /// راست به چپ
        /// </summary>
        public Boolean Rtl { get; set; }
        public Int32 DomainId { get; set; }
        public Int32 LanguageId { get; set; }

        #endregion Properties

        #region Methods(3)

        public CoreMasterPageNames GetCoreMasterPageNamesThemeName()
        {
            CoreMasterPageNames item;

            String key = "CoreMasterPageNames_ThemeName";

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as CoreMasterPageNames;
                if (item == null)
                {
                    CoreMasterPageNamesDetails recordSet = SiteProvider.Core.GetCoreMasterPageNamesDetailsThemeName();
                    item = GetCoreMasterPageNamesThemeNameFromOrderDal(recordSet);
                    AddCacheItem(key, item);
                }
            }
            else
            {

                CoreMasterPageNamesDetails recordSet = SiteProvider.Core.GetCoreMasterPageNamesDetailsThemeName();
                item = GetCoreMasterPageNamesThemeNameFromOrderDal(recordSet);
            }
            return item;
        }

       public Int32 Insert()
        {
            return Insert(MasterPageNameId, MasterPageGroupNameId, ThemeName, Path, PathImage, PathSmallImage, NameImage, Rtl, DomainId, LanguageId);
        }

        private Int32 Insert(Int32 masterPageNameId ,Int32 masterPageGroupNameId, String themeName, String path, String pathImage , String pathSmallImage , String nameImage, Boolean rtl , Int32 domainId , Int32 languageId)
        {
            CoreMasterPageNamesDetails coreMasterPageNamesDetails = new CoreMasterPageNamesDetails(masterPageNameId ,masterPageGroupNameId, themeName, path, pathImage, pathSmallImage, nameImage, rtl, domainId, languageId);
            Int32 ret = SiteProvider.Core.InsertCoreMasterPageNames(coreMasterPageNamesDetails);
            if (Settings.EnableCaching & ret > 0)
                InvalidateCache();
            return ret;
        }

        public bool Update()
        {
            return Update(MasterPageNameId, MasterPageGroupNameId, ThemeName, Path, PathImage, PathSmallImage, NameImage, Rtl, DomainId, LanguageId);
        }

        private Boolean Update(Int32 masterPageNameId, Int32 masterPageGroupNameId, String themeName, String path, String pathImage, String pathSmallImage, String nameImage, Boolean rtl, Int32 domainId, Int32 languageId)
        {
            CoreMasterPageNamesDetails coreMasterPageNamesDetails = new CoreMasterPageNamesDetails(masterPageNameId, masterPageGroupNameId, themeName, path, pathImage, pathSmallImage, nameImage, rtl, domainId, languageId);
            Boolean ret = SiteProvider.Core.UpdateCoreMasterPageNames(coreMasterPageNamesDetails);
            if (Settings.EnableCaching & ret)
                InvalidateCache();
            return ret;
        }


        public bool Delete()
        {
            return Delete(MasterPageNameId, MasterPageGroupNameId, ThemeName, Path, PathImage, PathSmallImage, NameImage, Rtl, DomainId, LanguageId);
        }

        private bool Delete(Int32 masterPageNameId, Int32 masterPageGroupNameId, String themeName, String path, String pathImage, String pathSmallImage, String nameImage, Boolean rtl, Int32 domainId, Int32 languageId)
        {
            CoreMasterPageNamesDetails coreMasterPageNamesDetails = new CoreMasterPageNamesDetails(masterPageNameId, masterPageGroupNameId, themeName, path, pathImage, pathSmallImage, nameImage, rtl, domainId, languageId);
            bool ret = SiteProvider.Core.DeleteCoreMasterPageNames(coreMasterPageNamesDetails.MasterPageNameId);
            if (Settings.EnableCaching & ret)
                InvalidateCache();
            return ret;
        }

    

       

        /// <summary>
        /// تبدیل داده های لایه دیتا به داده های لایه تجاری 
        /// </summary>
        /// <param name="records">رکوردهای ورودی حاوی داده های لایه دیتا</param>
        /// <returns></returns>
        private static List<CoreMasterPageNames> GetCoreMasterPageNamesThemeNameFromOrderDal(List<CoreMasterPageNamesDetails> records)
        {
            List<CoreMasterPageNames> items = new List<CoreMasterPageNames>();
            foreach (CoreMasterPageNamesDetails item in records)
                items.Add(GetCoreMasterPageNamesThemeNameFromOrderDal(item));
            return items;
        }

        /// <summary>
        /// تبدیل داده لایه دیتا به داده لایه تجاری
        /// </summary>
        /// <param name="record">رکورد ورودی حاوی داده لایه دیتا</param>
        /// <returns></returns>
        private static CoreMasterPageNames GetCoreMasterPageNamesThemeNameFromOrderDal(CoreMasterPageNamesDetails record)
        {
            if (record != null)
                return new CoreMasterPageNames(record.MasterPageNameId , record.MasterPageGroupNameId , record.ThemeName , record.Path , record.PathSmallImage , record.PathImage , record.NameImage , record.Rtl ,record.DomainId,record.LanguageId);
            return null;
        }

        #endregion
    }
}
