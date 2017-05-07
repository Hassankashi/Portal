using System;
using System.Linq;
using System.Collections.Generic;
using Pine.Dal;
using Pine.Dal.Link;

namespace Pine.Bll.Link
{
    /// <summary>
    /// کلاسی برای نگهداری منو
    /// </summary>
    public class Link : BaseLink
    {
        #region Constructors (1)
       /// <summary>
        /// کلاس سازنده جزئیات لینک
        /// </summary>
        /// <param name="linkId">آی دی</param>
        /// <param name="linkGroupId">آی دی گروه</param>
        /// <param name="linkName">نام</param>
        /// <param name="navigateUrl">مسیر لینک</param>
        /// <param name="iconUrl">مسیر آیکن</param>
        /// <param name="isActive">فعال بودن</param>
        /// <param name="priority">اولویت</param>
        /// <param name="enterDate">تاریخ ورود</param>
        /// <param name="userControl">نام یوزرکنترل</param>
        public Link(Int32 linkId, Int32 linkGroupId, String linkName, String navigateUrl, String iconUrl, Boolean isActive, Byte priority, DateTime enterDate, String userControl)
        {
            LinkId = linkId;
            LinkGroupId = linkGroupId;
            LinkName = linkName;
            NavigateUrl = navigateUrl;
            IconUrl = iconUrl;
            IsActive = isActive;
            Priority = priority;
            EnterDate = enterDate;
            UserControl = userControl;
        }

        /// <summary>
        /// سازنده پیش فرض کلاس جزئیات لینک
        /// </summary>
        public Link()
        {
            CacheDuration = Settings.CacheDuration;
            MasterCacheKey = "Link";
        }

        #endregion Constructors

        #region Properties (9)

        /// <summary>
        /// کد لینک
        /// </summary>
        public Int32 LinkId { get; set; }

        /// <summary>
        /// کد گروه لینک
        /// </summary>
        public Int32 LinkGroupId { get; set; }

        /// <summary>
        /// نام لینک
        /// </summary>
        public String LinkName { get; set; }

        /// <summary>
        /// مسیر لینک
        /// </summary>
        public String NavigateUrl { get; set; }

        /// <summary>
        /// مسیر آیکن
        /// </summary>
        public String IconUrl { get; set; }

        /// <summary>
        /// فعال بودن
        /// </summary>
        public Boolean IsActive { get; set; }

        /// <summary>
        /// اولویت
        /// </summary>
        public Byte Priority { get; set; }

        /// <summary>
        /// تاریخ ورود
        /// </summary>
        public DateTime EnterDate { get; set; }

        /// <summary>
        /// نام یوزر کنترل
        /// </summary>
        public String UserControl { get; set; }
        #endregion Properties

        #region Methods(3)

        public List<Link> GetLinkByLinkGroupId(Int32 linkGroupId)
        {
            List<Link> item;

            String key = "Link_LinkGroupId_" + linkGroupId;

            if (Settings.EnableCaching)
            {

                item = GetCacheItem(key) as List<Link>;
                if (item == null)
                {
                    List<LinkDetails> recordSet = SiteProvider.Link.GetLinkByLinkGroupId(linkGroupId);
                    item = GetLinkCollectionFromOrderDal(recordSet);
                    AddCacheItem(key, item);
                }
            }
            else
            {
                    List<LinkDetails> recordSet = SiteProvider.Link.GetLinkByLinkGroupId(linkGroupId);
                    item = GetLinkCollectionFromOrderDal(recordSet);
            }
            return item;
        }

        public Link GetLinkByLinkId(Int32 linkId)
        {
            Link item;

            String key = "Link_LinkId_" + linkId;

            if (Settings.EnableCaching)
            {

                item = GetCacheItem(key) as Link;
                if (item == null)
                {
                    LinkDetails recordSet = SiteProvider.Link.GetLinkByLinkId(linkId);
                    item = GetLinkFromOrderDal(recordSet);
                    AddCacheItem(key, item);
                }
            }
            else
            {
                LinkDetails recordSet = SiteProvider.Link.GetLinkByLinkId(linkId);
                item = GetLinkFromOrderDal(recordSet);
            }
            return item;
        }

        public Int32 Insert()
        {
            return Insert(LinkId, LinkGroupId, LinkName, NavigateUrl,IconUrl, IsActive, Priority,EnterDate , UserControl);
        }

        private Int32 Insert(Int32 linkId, Int32 linkGroupId, String linkName, String navigateUrl, String iconUrl, Boolean isActive, Byte priority, DateTime enterDate, String userControl)
        {
            LinkDetails link = new LinkDetails(linkId, linkGroupId, linkName, navigateUrl, iconUrl, isActive, priority,enterDate , userControl);
            Int32 ret = SiteProvider.Link.InsertLink(link);
            if (Settings.EnableCaching & ret > 0)
                InvalidateCache();
            return ret;
        }

        public bool UpdateLink()
        {
            return UpdateLink(LinkId, LinkGroupId, LinkName, NavigateUrl, IconUrl, IsActive, Priority, EnterDate, UserControl);
        }

        private Boolean UpdateLink(Int32 linkId, Int32 linkGroupId, String linkName, String navigateUrl, String iconUrl, Boolean isActive, Byte priority, DateTime enterDate, String userControl)
        {
            LinkDetails link = new LinkDetails(linkId, linkGroupId, linkName, navigateUrl, iconUrl, isActive, priority, enterDate, userControl);
            Boolean ret = SiteProvider.Link.UpdateLink(link);
            if (Settings.EnableCaching & ret)
                InvalidateCache();
            return ret;
        }

        //public bool UpdateMenu()
        //{
        //    return UpdateMenu(Id, MenuNameId, ParentMenuId, Text, NavigateUrl, ImageUrl, Priority, UserControl);
        //}

        //private Boolean UpdateMenu(Int32 id, Int32 menuNameId, Int32? parentMenuId, String text, String navigateUrl, String imageUrl, Int16 priority, String userControl)
        //{
        //    MenuDetails menu = new MenuDetails(id, menuNameId, parentMenuId, text, navigateUrl, imageUrl, priority, userControl);
        //    Boolean ret = SiteProvider.Menu.UpdateMenu(menu);
        //    if (Settings.EnableCaching & ret)
        //        InvalidateCache();
        //    return ret;
        //}



        /// <summary>
        /// تبدیل داده لایه دیتا به داده لایه تجاری
        /// </summary>
        /// <param name="record">رکورد ورودی حاوی داده لایه دیتا</param>
        /// <returns></returns>
        private static Link GetLinkFromOrderDal(LinkDetails record)
        {
            if (record != null)
                return new Link(record.LinkId , record.LinkGroupId , record.LinkName , record.NavigateUrl , record.IconUrl, record.IsActive , record.Priority, record.EnterDate ,record.UserControl);
            return null;
        }

        /// <summary>
        /// تبدیل داده های لایه دیتا به داده های لایه تجاری 
        /// </summary>
        /// <param name="records">رکوردهای ورودی حاوی داده های لایه دیتا</param>
        /// <returns></returns>
        private static List<Link> GetLinkCollectionFromOrderDal(List<LinkDetails> records)
        {
            List<Link> items = new List<Link>();
            foreach (LinkDetails item in records)
                items.Add(GetLinkFromOrderDal(item));
            return items;
        }

        #endregion
    }
}
