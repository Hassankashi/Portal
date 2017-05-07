using System;
using System.Linq;
using System.Collections.Generic;
using Pine.Dal;
using Pine.Dal.Link;

namespace Pine.Bll.Link
{
    /// <summary>
    /// کلاسی برای نگهداری گروه لینک
    /// </summary>
    public class LinkGroup : BaseLink
    {
        #region Constructors (1)
    
        /// <summary>
        /// سازنده اصلی کلاس جزئیات گروه لینک
        /// </summary>
        /// <param name="menuNameId">کد گروه لینک</param>
        /// <param name="menuName">نام گروه لینک</param>
        public LinkGroup(Int32 linkGroupId, String name)
        {
            LinkGroupId = linkGroupId;
            Name = name;
        }

        /// <summary>
        /// سازنده پیش فرض کلاس جزئیات لینک
        /// </summary>
        public LinkGroup()
        {
            CacheDuration = Settings.CacheDuration;
            MasterCacheKey = "Link";
        }

        #endregion Constructors

        #region Properties (2)

        /// <summary>
        /// کد گروه لینک
        /// </summary>
        public Int32 LinkGroupId { get; set; }

        /// <summary>
        /// نام گروه لینک
        /// </summary>
        public String Name { get; set; }


        #endregion Properties

        #region Methods(3)

        public LinkGroup GetLinkGroupByLinkGroupId(Int32 linkGroupId)
        {
            LinkGroup item;

            String key = "LinkGroup_LinkGroupId_" + linkGroupId;

            if (Settings.EnableCaching)
            {

                item = GetCacheItem(key) as LinkGroup;
                if (item == null)
                {
                    LinkGroupDetails recordSet = SiteProvider.Link.GetLinkGroupByLinkGroupId(linkGroupId);
                    item = GetLinkGroupFromOrderDal(recordSet);
                    AddCacheItem(key, item);
                }
            }
            else
            {
                LinkGroupDetails recordSet = SiteProvider.Link.GetLinkGroupByLinkGroupId(linkGroupId);
                item = GetLinkGroupFromOrderDal(recordSet);
            }
            return item;
        }

        //public Link GetLinkByLinkId(Int32 linkId)
        //{
        //    Link item;
        //    String key = "Link_LinkId_" + linkId;
        //    if (Settings.EnableCaching)
        //    {
        //        item = GetCacheItem(key) as Link;
        //        if (item == null)
        //        {
        //            LinkDetails recordSet = SiteProvider.Link.GetLinkByLinkId(linkId);
        //            item = GetLinkFromOrderDal(recordSet);
        //            AddCacheItem(key, item);
        //        }
        //    }
        //    else
        //    {
        //        LinkDetails recordSet = SiteProvider.Link.GetLinkByLinkId(linkId);
        //        item = GetLinkFromOrderDal(recordSet);
        //    }
        //    return item;
        //}

        public Int32 Insert()
        {
            return Insert(LinkGroupId, Name);
        }

        private Int32 Insert(Int32 linkGroupId, String name)
        {
            LinkGroupDetails linkGroup = new LinkGroupDetails(linkGroupId,name);
            Int32 ret = SiteProvider.Link.InsertLinkGroup(linkGroup);
            if (Settings.EnableCaching & ret > 0)
                InvalidateCache();
            return ret;
        }

        public bool UpdateLinkGroup()
        {
            return UpdateLinkGroup(LinkGroupId, Name);
        }

        private Boolean UpdateLinkGroup(Int32 linkGroupId, String name)
        {
            LinkGroupDetails linkGroup = new LinkGroupDetails(linkGroupId, name);
            Boolean ret = SiteProvider.Link.UpdateLinkGroup(linkGroup);
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
        private static LinkGroup GetLinkGroupFromOrderDal(LinkGroupDetails record)
        {
            if (record != null)
                return new LinkGroup(record.LinkGroupId, record.Name);
            return null;
        }

        /// <summary>
        /// تبدیل داده های لایه دیتا به داده های لایه تجاری 
        /// </summary>
        /// <param name="records">رکوردهای ورودی حاوی داده های لایه دیتا</param>
        /// <returns></returns>
        private static List<LinkGroup> GetLinkGroupCollectionFromOrderDal(List<LinkGroupDetails> records)
        {
            List<LinkGroup> items = new List<LinkGroup>();
            foreach (LinkGroupDetails item in records)
                items.Add(GetLinkGroupFromOrderDal(item));
            return items;
        }

        #endregion
    }
}
