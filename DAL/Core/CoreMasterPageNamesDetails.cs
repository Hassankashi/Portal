using System;
using System.Linq;

namespace Pine.Dal.Core
{
    /// <summary>
    /// کلاسی برای نگهداری جزئیات گروه منو
    /// </summary>
    public class CoreMasterPageNamesDetails
    {

        #region Constructors (2)

        /// <summary>
        /// سازنده اصلی کلاس جزئیات نام مسترپیچ
        /// </summary>
        /// <param name="masterPageNameId">کد مسترپیج</param>
        /// <param name="masterPageGroupNameId">کدر گروه مسترپیج</param>
        /// <param name="ThemeName">نام طرح</param>
        /// <param name="Path">مسیر مسترپیج</param>
        /// <param name="PathSmallImage">مسیر عکس کوچک</param>
        /// <param name="PathImage">مسیر عکس</param>
        /// <param name="NameImage">نام عکس</param>
        /// <param name="rtl">راست به چپ بودن طرح</param>
        public CoreMasterPageNamesDetails(Int32 masterPageNameId, Int32 masterPageGroupNameId, String themeName, String path, String pathImage, String pathSmallImage, String nameImage, Boolean rtl, Int32 domainId , Int32 languageId)
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
        /// سازنده پیش فرض کلاس جزئیات گروه منو
        /// </summary>
        public CoreMasterPageNamesDetails()
        {
        }

        #endregion Constructors

        #region Properties (8)

        /// <summary>
        /// کد مسترپیج
        /// </summary>
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

    }
}
