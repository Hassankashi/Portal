using System;
using System.Collections.Generic;
using System.Data;

namespace Pine.Dal.Core
{
    public abstract class CoreProvider : DataAccess
    {
        #region Fields (1)

        static private CoreProvider _instance;

        #endregion Fields

        #region Constructors (1)

        /// <summary>
        /// سازنده اصلی کلاس
        /// </summary>
        protected CoreProvider()
        {
            ConnectionString = Globals.Settings.Core.ConnectionString;
            EnableCaching = Globals.Settings.Core.EnableCaching;
            CacheDuration = Globals.Settings.Core.CacheDuration;
        }

        #endregion Constructors

        #region Properties (1)

        /// <summary>
        /// Returns an instance of the provider type specified in the config file
        /// </summary>
        static public CoreProvider Instance
        {
            get
            {
                return _instance ?? (_instance = (CoreProvider)Activator.CreateInstance(
                    Type.GetType(Globals.Settings.Core.ProviderType)));
            }
        }

        #endregion Properties

        #region CoreParameter (2)

        /// <summary>
        /// بازیابی اطلاعات پارامتر
        /// </summary>
        /// <param name="parameter">نام پارامتر</param>
        /// <returns>کلاس پارامتر</returns>
        public abstract List<CoreParameterDetails> GetCoreParameterByParameter(String parameter);

        /// <summary>
        /// بازیابی اطلاعات پارامتر
        /// </summary>
        /// <param name="parameter">نام پارامتر</param>
        /// <param name="Value">مقدار</param>
        /// <returns>کلاس پارامتر</returns>
        public abstract List<CoreParameterDetails> GetCoreParameterByParameterAndValue(String parameter,String value);

        /// <summary>
        /// بازیابی اطلاعات پارامتر
        /// </summary>
        /// <param name="coreParameterId">کد پارامتر</param>
        /// <returns>کلاس پارامتر</returns>
        public abstract CoreParameterDetails GetCoreParameterByCoreParameterId(Int32 coreParameterId);

        /// <summary>
        /// حذف یک پارامتر
        /// </summary>
        /// <param name="coreParameterId">کد پارامتر</param>
        /// <returns>کلاس پارامتر</returns>
        public abstract Boolean DeleteCoreParameterByParameter(String parameter);

        /// <summary>
        /// ورود پارامتر
        /// </summary>
        /// <param name="coreParameter">پارامتر</param>
        /// <returns></returns>
        public abstract int InsertCoreParameter(CoreParameterDetails coreParameter);

        /// <summary>
        /// ورود پارامتر
        /// </summary>
        /// <param name="coreParameter">پارامتر</param>
        /// <returns></returns>
        public abstract Boolean UpdateCoreParameter(CoreParameterDetails coreParameter);

        #endregion

        #region CoreMasterPageContents
        public abstract List<CoreMasterPageContentsDetails> GetCoreMasterPageContentsByContentNameIdAndMasterPageNameId(Int32 contentNameId, Int32 masterPageNameId);
        public abstract int InsertCoreMasterPageContents(CoreMasterPageContentsDetails coreMasterPageContents);
        public abstract Boolean UpdateCoreMasterPageContents(CoreMasterPageContentsDetails coreMasterPageContents);
        public abstract Boolean DeleteCoreMasterPageContents(int masterPageContentId);
        #endregion

        #region CoreThemeSetting(1)

        /// <summary>
        /// بازیابی اطلاعات پارامتر
        /// </summary>
        /// <param name="parameter">نام طرح</param>
        /// <returns>کلاس پارامتر</returns>
        public abstract List<CoreThemeSettingDetails> GetCoreThemeSettingDetailsByThemeName(String themeName);
        public abstract int InsertCoreThemeSetting(CoreThemeSettingDetails coreThemeSettingDetails);
        public abstract Boolean UpdateCoreThemeSetting(CoreThemeSettingDetails coreThemeSettingDetails);
        public abstract Boolean DeleteCoreThemeSetting(int themeSettingId);

        #endregion

        #region CoreMasterPageNames(1)

        /// <summary>
        /// بازیابی اطلاعات نام طرح
        /// </summary>
        /// <returns> کلاس نام مسترپیج</returns>
        public abstract CoreMasterPageNamesDetails GetCoreMasterPageNamesDetailsThemeName();
        public abstract int InsertCoreMasterPageNames(CoreMasterPageNamesDetails coreMasterPageNamesDetails);
        public abstract Boolean UpdateCoreMasterPageNames(CoreMasterPageNamesDetails coreMasterPageNamesDetails);
        public abstract Boolean DeleteCoreMasterPageNames(int masterPageNameId);


        #endregion

        #region CoreUserControlPaths_PageContents (1)

        public abstract List<CoreUserControlPaths_PageContentsDetails> GetCoreUserControlPaths_PageContentsDetailsByPageContentId(Int32 pageContentId);

        #endregion


        #region CorePageContents (1)

        public abstract List<CorePageContentsDetails> GetCorePageContentsByPageId(Int32 pageId);
        public abstract int InsertCorePageContents(CorePageContentsDetails corePageContentsDetails);
        public abstract Boolean UpdateCorePageContents(CorePageContentsDetails corePageContentsDetails);
        public abstract Boolean DeleteCorePageContents(int pageContentId);
        #endregion

        #region CoreMasterPageNamesCorePages (1)

        public abstract CoreMasterPageNamesCorePagesDetails GetCoreMasterPageNamesCorePagesByIsDefault();
        public abstract CoreMasterPageNamesCorePagesDetails GetCoreMasterPageNamesCorePages();
        public abstract List<CoreMasterPageNamesCorePagesDetails> GetCoreMasterPageNamesCorePagesByPageId(Int32 pageId);

        #endregion

        #region CoreAccess
        public abstract int InsertCoreAccess(CoreAccessDetails coreAccessDetails);
        public abstract Boolean UpdateCoreAccess(CoreAccessDetails coreAccessDetails);
        public abstract Boolean DeleteCoreAccess(Int32 accessId);
        #endregion

        #region CoreAccessPage
        public abstract int InsertCoreAccessPage(CoreAccessPageDetails coreAccessPageDetails);
        public abstract Boolean UpdateCoreAccessPage(CoreAccessPageDetails coreAccessPageDetails);
        public abstract Boolean DeleteCoreAccessPage(Int32 accessPageId);
        #endregion
       
        #region CoreContentNames
        public abstract int InsertCoreContentNames(CoreContentNamesDetails coreContentNamesDetails);
        public abstract Boolean UpdateCoreContentNames(CoreContentNamesDetails coreContentNamesDetails);
        public abstract Boolean DeleteCoreContentNames(Int32 contentNameId);

       #endregion

        #region CoreDomains
        public abstract int InsertCoreDomains(CoreDomainsDetails coreDomainsDetails);
        public abstract Boolean UpdateCoreDomains(CoreDomainsDetails coreDomainsDetails);
        public abstract Boolean DeleteCoreDomains(Int32 domainId);
        #endregion

        #region CoreLocationPageContent
        public abstract int InsertCoreLocationPageContent(CoreLocationPageContentDetails coreLocationPageContent);
        public abstract Boolean UpdateCoreLocationPageContent(CoreLocationPageContentDetails coreLocationPageContent);
        public abstract Boolean DeleteCoreLocationPageContent(Int32 coreLocationPageContentId);
        #endregion

        #region CoreMasterPageGroupName
        public abstract int InsertCoreMasterPageGroupName(CoreMasterPageGroupNameDetails coreMasterPageGroupName);
        public abstract Boolean UpdateCoreMasterPageGroupName(CoreMasterPageGroupNameDetails coreMasterPageGroupName);
        public abstract Boolean DeleteCoreMasterPageGroupName(Int32 masterPageGroupNameId);
        #endregion

        #region CorePages

        public abstract List<CorePagesDetails> GetCorePages();
        public abstract int InsertCorePages(CorePagesDetails corePages);
        public abstract Boolean UpdateCorePages(CorePagesDetails corePages);
        public abstract Boolean DeleteCorePages(Int32 pageId);

        #endregion 

        #region CoreThemeMiddleSetting
        public abstract int InsertCoreThemeMiddleSetting(CoreThemeMiddleSettingDetails coreThemeMiddleSetting);
        public abstract Boolean UpdateCoreThemeMiddleSetting(CoreThemeMiddleSettingDetails coreThemeMiddleSetting);
        public abstract Boolean DeleteCoreThemeMiddleSetting(int masterPageNameId, int themeSettingId);
        #endregion 

        #region coreThemeSettingChild

        public abstract CoreThemeSettingChildDetails GetCoreThemeSettingChild(Int32 themeSettingChildId);
        public abstract List<CoreThemeSettingChildDetails> GetCoreThemeSettingChildByThemeSettingId(Int32 themeSettingId);
        public abstract int InsertCoreThemeSettingChild(CoreThemeSettingChildDetails coreThemeSettingChild);
        public abstract Boolean UpdateCoreThemeSettingChild(CoreThemeSettingChildDetails coreThemeSettingChild);
        public abstract Boolean DeleteCoreThemeSettingChild(int themeSettingChildId);
#endregion

        #region CoreThemeSettingType
        public abstract int InsertCoreThemeSettingType(CoreThemeSettingTypeDetails coreThemeSettingType);
        public abstract Boolean UpdateCoreThemeSettingType(CoreThemeSettingTypeDetails coreThemeSettingType);
        public abstract Boolean DeleteCoreThemeSettingType(int themeSettingTypeId);
        #endregion

        #region CoreUserControlNames
        public abstract int InsertCoreUserControlNames(CoreUserControlNamesDetails coreUserControlNames);
        public abstract Boolean UpdateCoreUserControlNames(CoreUserControlNamesDetails coreUserControlNames);
        public abstract Boolean DeleteCoreUserControlNames(int userControlNameId);
        #endregion

        #region CoreUserControlPath

        public abstract CoreUserControlPathDetails GetCoreUserControlPathByPath(String path);
        public abstract CoreUserControlPathDetails GetCoreUserControlPathByUserControlPathId(Int32 userControlPathId);
        public abstract int InsertCoreUserControlPaths(CoreUserControlPathDetails coreUserControlPath);
        public abstract Boolean UpdateCoreUserControlPaths(CoreUserControlPathDetails coreUserControlPath);
        public abstract Boolean DeleteCoreUserControlPaths(int userControlPathId);

        #endregion

        #region CoreUserControlPosition
        public abstract int InsertCoreUserControlPosition(CoreUserControlPositionDetails coreUserControlPosition);
        public abstract Boolean UpdateCoreUserControlPosition(CoreUserControlPositionDetails coreUserControlPosition);
        public abstract Boolean DeleteCoreUserControlPosition(int userControlPathId);
        #endregion

        #region CoreUserControlSetting
        public abstract int InsertCoreUserControlSetting(CoreUserControlSettingDetails coreUserControlSetting);
        public abstract Boolean UpdateCoreUserControlSetting(CoreUserControlSettingDetails coreUserControlSetting);
        public abstract Boolean DeleteCoreUserControlSetting(int userControlSettingId);
        #endregion

        #region Join

        public abstract List<CorePageUserControlPathsPageContentDetails> GetCorePage_UserControlPaths_PageContent(String queryString);
        public abstract List<CoreUserControlPathsCoreAccessDetails> GetCoreUserControlPaths_CoreAccess(Int32 userControlNameId);
        public abstract List<CoreUserControlPathsCoreAccessDetails> GetCoreUserControlPathsCoreAccessByPath(String userName , String path);
        public abstract List<CoreUserControlNamesAccessUserControlPathsDetails> GetCoreUserControlNames_Access_UserControlPaths(String username);
        public abstract List<CoreThemeSettingMiddelSettingMasterPageNameDetails> GetCoreThemeSettingMiddelSettingMasterPageName(String themeName);
        public abstract List<CoreMasterPageNameCoreAccessPageDetails> GetCoreMasterPageNameCoreAccessPage(String userName);
        public abstract List<CoreMasterPageNameCoreAccessPageDetails> GetCoreMasterPageNameCoreAccessPage(String userName , Int32 masterPageNameId);
        #endregion

        #region Virtual Protected Methods (2)

        protected virtual List<CoreAccessDetails> GetCoreAccessDetailsCollectionFromDataReader(IDataReader reader)
        {
            List<CoreAccessDetails> items = new List<CoreAccessDetails>();
            while (reader.Read())
                items.Add(GetCoreAccessDetailsFromDataReader(reader));
            return items;
        }


        protected virtual CoreAccessDetails GetCoreAccessDetailsFromDataReader(IDataReader reader)
        {
            return new CoreAccessDetails
                (
                   (Int32)reader["AccessId"],
                   (Int32)reader["UserControlPathId"],
                   (String)reader["ContentNameId"],
                   (Boolean)reader["UseManager"],
                   (Int32)reader["DomainId"],
                   (Int32)reader["LanguageId"]

                );
        }

        protected virtual List<CoreAccessPageDetails> GetCoreAccessPageDetailsCollectionFromDataReader(IDataReader reader)
        {
            List<CoreAccessPageDetails> items = new List<CoreAccessPageDetails>();
            while (reader.Read())
                items.Add(GetCoreAccessPageDetailsFromDataReader(reader));
            return items;
        }


        protected virtual CoreAccessPageDetails GetCoreAccessPageDetailsFromDataReader(IDataReader reader)
        {
            return new CoreAccessPageDetails
                (
                   (Int32)reader["AccessPage"],
                   reader["MasterPageNameId"] as Int32?,
                   reader["Username"].ToString(),
                   (Boolean)reader["UseManager"],
                   (Int32)reader["DomainId"],
                   (Int32)reader["LanguageId"]

                );
        }

        protected virtual List<CoreContentNamesDetails> GetCoreContentNamesDetailsCollectionFromDataReader(IDataReader reader)
        {
            List<CoreContentNamesDetails> items = new List<CoreContentNamesDetails>();
            while (reader.Read())
                items.Add(GetCoreContentNamesDetailsFromDataReader(reader));
            return items;
        }


        protected virtual CoreContentNamesDetails GetCoreContentNamesDetailsFromDataReader(IDataReader reader)
        {
            return new CoreContentNamesDetails
                (
                   (Int32)reader["ContentNameId"],
                   (String)reader["Position"],
                   reader["NameFarsi"].ToString(),
                   (Int32)reader["DomainId"],
                   (Int32)reader["LanguageId"]
                );
        }

        protected virtual List<CoreDomainsDetails> GetCoreDomainsDetailsCollectionFromDataReader(IDataReader reader)
        {
            List<CoreDomainsDetails> items = new List<CoreDomainsDetails>();
            while (reader.Read())
                items.Add(GetCoreDomainsDetailsFromDataReader(reader));
            return items;
        }


        protected virtual CoreDomainsDetails GetCoreDomainsDetailsFromDataReader(IDataReader reader)
        {
            return new CoreDomainsDetails
                (
                   (Int32)reader["DomainId"],
                   (String)reader["DomainName"],
                   reader["DomainTheme"].ToString(),
                   reader["EnterDate"] as DateTime?,
                   (Int32)reader["LanguageId"]
                );
        }

        protected virtual List<CoreLocationPageContentDetails> GetCoreLocationPageContentDetailsCollectionFromDataReader(IDataReader reader)
        {
            List<CoreLocationPageContentDetails> items = new List<CoreLocationPageContentDetails>();
            while (reader.Read())
                items.Add(GetCoreLocationPageContentDetailsFromDataReader(reader));
            return items;
        }


        protected virtual CoreLocationPageContentDetails GetCoreLocationPageContentDetailsFromDataReader(IDataReader reader)
        {
            return new CoreLocationPageContentDetails
                (
                   (Int32)reader["CoreLocationPageContentId"],
                   (Int32)reader["UserControlPathId"],
                   (Int32)reader["ContentNameId"],
                   reader["CoreParameterId"] as Int32?,
                   (Byte)reader["Priority"],
                   (Int32)reader["DomainId"],
                   (Int32)reader["LanguageId"]
                );
        }

        protected virtual List<CoreMasterPageContentsDetails> GetCoreMasterPageContentsDetailsCollectionFromDataReader(IDataReader reader)
        {
            List<CoreMasterPageContentsDetails> items = new List<CoreMasterPageContentsDetails>();
            while (reader.Read())
                items.Add(GetCoreMasterPageContentsDetailsFromDataReader(reader));
            return items;
        }


        protected virtual CoreMasterPageContentsDetails GetCoreMasterPageContentsDetailsFromDataReader(IDataReader reader)
        {
            return new CoreMasterPageContentsDetails
                (
                   (Int32)reader["MasterPageContentId"],
                   (Int32)reader["MasterPageNameId"],
                   (Int32)reader["ContentNameId"],
                   reader["MasterPageContentName"].ToString(),
                   (Int32)reader["DomainId"],
                   (Int32)reader["LanguageId"]
                );
        }

        protected virtual List<CoreMasterPageGroupNameDetails> GetCoreMasterPageGroupNameDetailsCollectionFromDataReader(IDataReader reader)
        {
            List<CoreMasterPageGroupNameDetails> items = new List<CoreMasterPageGroupNameDetails>();
            while (reader.Read())
                items.Add(GetCoreMasterPageGroupNameDetailsFromDataReader(reader));
            return items;
        }

        protected virtual CoreMasterPageGroupNameDetails GetCoreMasterPageGroupNameDetailsFromDataReader(IDataReader reader)
        {
            return new CoreMasterPageGroupNameDetails
                (
                   (Int32)reader["MasterPageGroupNameId"],
                   reader["Name"].ToString(),
                   (Int32)reader["DomainId"],
                   (Int32)reader["LanguageId"]
                );
        }

        protected virtual List<CoreMasterPageNamesDetails> GetCoreMasterPageNamesDetailsCollectionFromDataReader(IDataReader reader)
        {
            List<CoreMasterPageNamesDetails> items = new List<CoreMasterPageNamesDetails>();
            while (reader.Read())
                items.Add(GetCoreMasterPageNamesDetailsFromDataReader(reader));
            return items;
        }


        protected virtual CoreMasterPageNamesDetails GetCoreMasterPageNamesDetailsFromDataReader(IDataReader reader)
        {
            return new CoreMasterPageNamesDetails
                (
                    (Int32)reader["MasterPageNameId"],
                    (Int32)reader["MasterPageGroupNameId"],
                    reader["ThemeName"].ToString(),
                    reader["Path"].ToString(),
                    reader["PathSmallImage"].ToString(),
                    reader["PathImage"].ToString(),
                    reader["NameImage"].ToString(),
                   (Boolean)reader["RTL"],
                   (Int32)reader["DomainId"],
                   (Int32)reader["LanguageId"]
                );
        }

        protected virtual List<CorePageContentsDetails> GetCorePageContentsDetailsCollectionFromDataReader(IDataReader reader)
        {
            List<CorePageContentsDetails> items = new List<CorePageContentsDetails>();
            while (reader.Read())
                items.Add(GetCorePageContentsDetailsFromDataReader(reader));
            return items;
        }


        protected virtual CorePageContentsDetails GetCorePageContentsDetailsFromDataReader(IDataReader reader)
        {
            return new CorePageContentsDetails
                (
                    (Int32)reader["PageContentId"],
                    (Int32)reader["PageId"],
                    (Int32)reader["UserControlPathId"],
                    (Int32)reader["ContentNameId"],
                    reader["CoreParameterId"] as Int32?,
                    Int16.Parse(reader["Priority"].ToString()),
                    (Boolean)reader["IsStaticCantent"],
                    (Int32)reader["DomainId"],
                    (Int32)reader["LanguageId"]
                );
        }
        protected virtual List<CoreMasterPageNamesCorePagesDetails> GetCoreMasterPageNamesCorePagesDetailsCollectionFromDataReader(IDataReader reader)
        {
            List<CoreMasterPageNamesCorePagesDetails> items = new List<CoreMasterPageNamesCorePagesDetails>();
            while (reader.Read())
                items.Add(GetCoreMasterPageNamesCorePagesDetailsFromDataReader(reader));
            return items;
        }


        protected virtual CoreMasterPageNamesCorePagesDetails GetCoreMasterPageNamesCorePagesDetailsFromDataReader(IDataReader reader)
        {
            return new CoreMasterPageNamesCorePagesDetails
                (
                    (Int32)reader["MasterPageNameId"],
                    (Int32)reader["PageId"],
                    reader["ThemeName"].ToString(),
                    reader["Path"].ToString(),
                    reader["PathSmallImage"].ToString(),
                    reader["NameImage"].ToString()
                );
        }

        protected virtual List<CorePagesDetails> GetCorePagesDetailsCollectionFromDataReader(IDataReader reader)
        {
            List<CorePagesDetails> items = new List<CorePagesDetails>();
            while (reader.Read())
                items.Add(GetCorePagesDetailsFromDataReader(reader));
            return items;
        }


        protected virtual CorePagesDetails GetCorePagesDetailsFromDataReader(IDataReader reader)
        {
            return new CorePagesDetails
                (
                    (Int32)reader["PageId"],
                    (Int32)reader["MasterPageNameId"],
                    (Boolean)reader["IsDefault"],
                    (String)reader["PageName"],
                    (Int32)reader["DomainId"],
                    (Int32)reader["LanguageId"]
                );
        }

        protected virtual List<CoreParameterDetails> GetCoreParameterCollectionFromDataReader(IDataReader reader)
        {
            List<CoreParameterDetails> items = new List<CoreParameterDetails>();
            while (reader.Read())
                items.Add(GetCoreParameterFromDataReader(reader));
            return items;
        }


        protected virtual CoreParameterDetails GetCoreParameterFromDataReader(IDataReader reader)
        {
            return new CoreParameterDetails
                (
                    (Int32)reader["CoreParameterId"],
                    reader["Parameter"].ToString(),
                    reader["name"].ToString(),
                    reader["Value1"].ToString(),
                    reader["Value2"].ToString(),
                    reader["Value3"].ToString(),
                    (Int32)reader["DomainId"],
                    (Int32)reader["LanguageId"]
                );
        }

        protected virtual List<CoreThemeMiddleSettingDetails> GetCoreThemeMiddleSettingDetailsCollectionFromDataReader(IDataReader reader)
        {
            List<CoreThemeMiddleSettingDetails> items = new List<CoreThemeMiddleSettingDetails>();
            while (reader.Read())
                items.Add(GetCoreThemeMiddleSettingDetailsFromDataReader(reader));
            return items;
        }


        protected virtual CoreThemeMiddleSettingDetails GetCoreThemeMiddleSettingDetailsFromDataReader(IDataReader reader)
        {
            return new CoreThemeMiddleSettingDetails
                (
                    (Int32)reader["MasterPageNameId"],
                    (Int32)reader["ThemeSettingId"],
                    (Int32)reader["DomainId"],
                    (Int32)reader["LanguageId"]
                );
        }
        protected virtual List<CoreThemeSettingDetails> GetCoreThemeSettingDetailsCollectionFromDataReader(IDataReader reader)
        {
            List<CoreThemeSettingDetails> items = new List<CoreThemeSettingDetails>();
            while (reader.Read())
                items.Add(GetCoreThemeSettingDetailsFromDataReader(reader));
            return items;
        }


        protected virtual CoreThemeSettingDetails GetCoreThemeSettingDetailsFromDataReader(IDataReader reader)
        {
            return new CoreThemeSettingDetails
                (
                    (Int32)reader["ThemeSettingId"],
                    (Int32)reader["ThemeSettingTypeId"],
                    reader["Value1"].ToString(),
                    reader["Value2"].ToString(),
                    reader["Value3"].ToString(),
                    reader["Value4"].ToString(),
                    reader["Value5"].ToString(),
                    reader["Value6"].ToString(),
                    reader["Value7"].ToString(),
                    reader["Parameter"].ToString(),
                     (Int32)reader["DomainId"],
                    (Int32)reader["LanguageId"]
                );
        }

        protected virtual List<CoreThemeSettingChildDetails> GetCoreThemeSettingChildDetailsCollectionFromDataReader(IDataReader reader)
        {
            List<CoreThemeSettingChildDetails> items = new List<CoreThemeSettingChildDetails>();
            while (reader.Read())
                items.Add(GetCoreThemeSettingChildDetailsFromDataReader(reader));
            return items;
        }


        protected virtual CoreThemeSettingChildDetails GetCoreThemeSettingChildDetailsFromDataReader(IDataReader reader)
        {
            return new CoreThemeSettingChildDetails
                (
                    (Int32)reader["ThemeSettingChildId"],
                    (Int32)reader["ThemeSettingId"],
                    reader["Value1"].ToString(),
                    reader["Value2"].ToString(),
                    reader["Value3"].ToString(),
                    reader["Value4"].ToString(),
                    reader["Value5"].ToString(),
                    reader["Value6"].ToString(),
                    reader["Value7"].ToString(),
                    reader["Parameter"].ToString(),
                    (Int32)reader["DomainId"],
                    (Int32)reader["LanguageId"]
                );
        }

        protected virtual List<CoreThemeSettingTypeDetails> GetCoreThemeSettingTypeDetailsCollectionFromDataReader(IDataReader reader)
        {
            List<CoreThemeSettingTypeDetails> items = new List<CoreThemeSettingTypeDetails>();
            while (reader.Read())
                items.Add(GetCoreThemeSettingTypeDetailsFromDataReader(reader));
            return items;
        }


        protected virtual CoreThemeSettingTypeDetails GetCoreThemeSettingTypeDetailsFromDataReader(IDataReader reader)
        {
            return new CoreThemeSettingTypeDetails
                (
                    (Int32)reader["ThemeSettingTypeId"],
                    (String)reader["Parameter"],
                    reader["Name"].ToString(),
                    (Int32)reader["DomainId"],
                    (Int32)reader["LanguageId"]
                );
        }


        protected virtual List<CoreUserControlNamesDetails> GetCoreUserControlNamesDetailsCollectionFromDataReader(IDataReader reader)
        {
            List<CoreUserControlNamesDetails> items = new List<CoreUserControlNamesDetails>();
            while (reader.Read())
                items.Add(GetCoreUserControlNamesDetailsFromDataReader(reader));
            return items;
        }


        protected virtual CoreUserControlNamesDetails GetCoreUserControlNamesDetailsFromDataReader(IDataReader reader)
        {
            return new CoreUserControlNamesDetails
                (
                    (Int32)reader["UserControlNameId"],
                    (String)reader["UserControlName"],
                    (Int32)reader["DomainId"],
                    (Int32)reader["LanguageId"]
                );
        }

        protected virtual List<CoreUserControlPathDetails> GetCoreUserControlPathDetailsCollectionFromDataReader(IDataReader reader)
        {
            List<CoreUserControlPathDetails> items = new List<CoreUserControlPathDetails>();
            while (reader.Read())
                items.Add(GetCoreUserControlPathDetailsFromDataReader(reader));
            return items;
        }


        protected virtual CoreUserControlPathDetails GetCoreUserControlPathDetailsFromDataReader(IDataReader reader)
        {
            return new CoreUserControlPathDetails
                (
                    (Int32)reader["UserControlPathId"],
                    (Int32)reader["UserControlNameId"],
                    (String)reader["Path"],
                    reader["name"].ToString(),
                    (bool)reader["IsQueryString"],
                    reader["QueryString"].ToString(),
                    (bool)reader["IsGroups"],
                    reader["parameter"].ToString(),
                    reader["AdminSetting"].ToString(),
                    reader["AdminInsert"].ToString(),
                    reader["DefaltValue"] as Int32?,
                    reader["OrderBy"] as Int32?,
                    (bool)reader["visible"],
                    reader["LocationName"].ToString(),
                    (Int32)reader["DomainId"],
                    (Int32)reader["LanguageId"]
                );
        }

        protected virtual List<CoreUserControlPositionDetails> GetCoreUserControlPositionDetailsCollectionFromDataReader(IDataReader reader)
        {
            List<CoreUserControlPositionDetails> items = new List<CoreUserControlPositionDetails>();
            while (reader.Read())
                items.Add(GetCoreUserControlPositionDetailsFromDataReader(reader));
            return items;
        }


        protected virtual CoreUserControlPositionDetails GetCoreUserControlPositionDetailsFromDataReader(IDataReader reader)
        {
            return new CoreUserControlPositionDetails
                (
                    (Int32)reader["UserControlpositionId"],
                    (Int32)reader["ContentNameId"],
                     (Int32)reader["UserControlPathId"],
                    (Int32)reader["DomainId"],
                    (Int32)reader["LanguageId"]
                );
        }

        protected virtual List<CoreUserControlSettingDetails> GetCoreUserControlSettingDetailsCollectionFromDataReader(IDataReader reader)
        {
            List<CoreUserControlSettingDetails> items = new List<CoreUserControlSettingDetails>();
            while (reader.Read())
                items.Add(GetCoreUserControlSettingDetailsFromDataReader(reader));
            return items;
        }


        protected virtual CoreUserControlSettingDetails GetCoreUserControlSettingDetailsFromDataReader(IDataReader reader)
        {
            return new CoreUserControlSettingDetails
                (
                    (Int32)reader["UserControlSettingId"],
                    (Int32)reader["UserControlPathId"],
                    (String)reader["UserControlParameter"],
                    (String)reader["UserControlValue"],
                    (Int32)reader["DomainId"],
                    (Int32)reader["LanguageId"]
                );
        }


        protected virtual List<CoreUserControlPaths_PageContentsDetails> GetCoreUserControlPaths_PageContentsDetailsCollectionFromDataReader(IDataReader reader)
        {
            List<CoreUserControlPaths_PageContentsDetails> items = new List<CoreUserControlPaths_PageContentsDetails>();
            while (reader.Read())
                items.Add(GetCoreUserControlPaths_PageContentsDetailsFromDataReader(reader));
            return items;
        }


        protected virtual CoreUserControlPaths_PageContentsDetails GetCoreUserControlPaths_PageContentsDetailsFromDataReader(IDataReader reader)
        {
            return new CoreUserControlPaths_PageContentsDetails
                (
                    reader["Path"].ToString(),
                    (Int32)reader["UserControlPathId"],
                    reader["CoreParameterId"] as Int32?
                );
        }







        #endregion

        #region Join Virtual
        protected virtual List<CorePageUserControlPathsPageContentDetails> GetCorePageUserControlPathsPageContentCollectionFromDataReader(IDataReader reader)
        {
            List<CorePageUserControlPathsPageContentDetails> items = new List<CorePageUserControlPathsPageContentDetails>();
            while (reader.Read())
                items.Add(GetCorePageUserControlPathsPageContentFromDataReader(reader));
            return items;
        }


        protected virtual CorePageUserControlPathsPageContentDetails GetCorePageUserControlPathsPageContentFromDataReader(IDataReader reader)
        {
            return new CorePageUserControlPathsPageContentDetails
                (
                    (Int32)reader["PageId"],
                    (Int32)reader["UserControlPathId"],
                    (String)reader["QueryString"],
                    (String)reader["PageName"],
                    (bool)reader["IsQueryString"],
                    (bool)reader["IsDefault"]
                );
        }


        protected virtual List<CoreUserControlPathsCoreAccessDetails> GetCoreUserControlPathsCoreAccessCollectionFromDataReader(IDataReader reader)
        {
            List<CoreUserControlPathsCoreAccessDetails> items = new List<CoreUserControlPathsCoreAccessDetails>();
            while (reader.Read())
                items.Add(GetCoreUserControlPathsCoreAccessFromDataReader(reader));
            return items;
        }


        protected virtual CoreUserControlPathsCoreAccessDetails GetCoreUserControlPathsCoreAccessFromDataReader(IDataReader reader)
        {
            return new CoreUserControlPathsCoreAccessDetails
                (
                    (Int32)reader["UserControlNameId"],
                    (String)reader["Name"],
                    (Int32)reader["UserControlPathId"],
                    (String)reader["Username"],
                    (bool)reader["IsQueryString"],
                    (String)reader["Path"]
                );
        }

        protected virtual List<CoreUserControlNamesAccessUserControlPathsDetails> GetCoreUserControlNamesAccessUserControlPathsCollectionFromDataReader(IDataReader reader)
        {
            List<CoreUserControlNamesAccessUserControlPathsDetails> items = new List<CoreUserControlNamesAccessUserControlPathsDetails>();
            while (reader.Read())
                items.Add(GetCoreUserControlNamesAccessUserControlPathsFromDataReader(reader));
            return items;
        }


        protected virtual CoreUserControlNamesAccessUserControlPathsDetails GetCoreUserControlNamesAccessUserControlPathsFromDataReader(IDataReader reader)
        {
            return new CoreUserControlNamesAccessUserControlPathsDetails
                (
                    (Int32)reader["UserControlNameId"],
                    (Int32)reader["UserControlPathId"],
                    (String)reader["UserControlName"],
                    (String)reader["Username"],
                    (bool)reader["IsQueryString"]

                );
        }

        protected virtual List<CoreThemeSettingMiddelSettingMasterPageNameDetails> GetCoreThemeSettingMiddelSettingMasterPageNameCollectionFromDataReader(IDataReader reader)
        {
            List<CoreThemeSettingMiddelSettingMasterPageNameDetails> items = new List<CoreThemeSettingMiddelSettingMasterPageNameDetails>();
            while (reader.Read())
                items.Add(GetCoreThemeSettingMiddelSettingMasterPageNameFromDataReader(reader));
            return items;
        }


        protected virtual CoreThemeSettingMiddelSettingMasterPageNameDetails GetCoreThemeSettingMiddelSettingMasterPageNameFromDataReader(IDataReader reader)
        {
            return new CoreThemeSettingMiddelSettingMasterPageNameDetails
                (
                   (Int32)reader["ThemeSettingId"],
                   (Int32)reader["ThemeSettingTypeId"],
                   (Int32)reader["MasterPageNameId"],
                   (String)reader["Value1"],
                   (String)reader["Value2"],
                   (String)reader["Value3"],
                   (String)reader["Value4"],
                   (String)reader["Value5"],
                   (String)reader["Value6"],
                   (String)reader["Value7"],
                   (String)reader["Parameter"],
                   (String)reader["ThemeName"]


                );
        }

        protected virtual List<CoreMasterPageNameCoreAccessPageDetails> GetCoreMasterPageNameCoreAccessPageCollectionFromDataReader(IDataReader reader)
        {
            List<CoreMasterPageNameCoreAccessPageDetails> items = new List<CoreMasterPageNameCoreAccessPageDetails>();
            while (reader.Read())
                items.Add(GetCoreMasterPageNameCoreAccessPageFromDataReader(reader));
            return items;



        }

        protected virtual CoreMasterPageNameCoreAccessPageDetails GetCoreMasterPageNameCoreAccessPageFromDataReader(IDataReader reader)
        {
            return  new CoreMasterPageNameCoreAccessPageDetails(

                (Int32)reader["MasterPageNameId"],
                (String)reader["PathSmallImage"],
                (String)reader["PathImage"],
                (String)reader["NameImage"],
                (String)reader["userName"]
                
                );
        }

        #endregion

    }
}
