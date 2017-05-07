using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pine.Dal;
using Pine.Dal.Tag;

namespace Pine.Bll.Tag
{
    public class TagGroup : BaseTag
    {
        #region constructor
    public TagGroup()
    {
    }

    public TagGroup(Guid tagGroupId, String tagGroupName, Int32 languageId, Int32 domainId)
    {
        TagGroupId = tagGroupId;
        TagGroupName = tagGroupName;
        LanguageId = languageId;
        DomainId = domainId;
    }
       #endregion

#region properties

       public Guid TagGroupId { get; set; }
       public String TagGroupName { get; set; }
       public Int32 LanguageId { get; set; }
       public Int32 DomainId { get; set; }
       #endregion
    

        #region Methods

       public static List<TagGroup> GetAllTagGroup(Int32 laguageId, Int32 domainId)
       {

           SetCache();
           List<TagGroup> item;

           String key = "TagGroup_TagGroupId_laguageId_domainId_" + laguageId + domainId;

           if (Settings.EnableCaching)
           {
               item = GetCacheItem(key) as List<TagGroup>;
               if (item == null)
               {
                   List<TagGroupDetails> recordSet = SiteProvider.Tag.GetAllTagGroup(laguageId, domainId);
                   item = GetTagGroupCollectionFromOrderDal(recordSet);
                   AddCacheItem(key, item);
               }
           }
           else
           {
               List<TagGroupDetails> recordSet = SiteProvider.Tag.GetAllTagGroup(laguageId, domainId);
               item = GetTagGroupCollectionFromOrderDal(recordSet);
           }
           return item;
       }

       public static TagGroup GetTagGroupByTagGroupId(Guid tagGroupId)
        {
            TagGroup item;
            SetCache();
            String key = "Tag_tagGroupId_" + tagGroupId;

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as TagGroup;
                if (item == null)
                {
                    TagGroupDetails record = SiteProvider.Tag.GetTagGroupByTagGroupId(tagGroupId);
                    item = GetTagGroupFromOrderDal(record);
                    AddCacheItem(key, item);
                }
            }
            else
            {
                TagGroupDetails recordSet = SiteProvider.Tag.GetTagGroupByTagGroupId(tagGroupId);
                item = GetTagGroupFromOrderDal(recordSet);
            }

            return item;
        }
        
        public Int32 InsertTagGroup()
        {
            return InsertTagGroup(TagGroupId,TagGroupName,LanguageId,DomainId);
        }

        private Int32 InsertTagGroup(Guid tagGroupId, String tagGroupName, Int32 languageId, Int32 domainId)
        {
            TagGroupDetails tagGroupDetails = new TagGroupDetails(tagGroupId, tagGroupName, languageId, domainId);
            Int32 ret = SiteProvider.Tag.InsertTagGroup(tagGroupDetails);
            if (Settings.EnableCaching & ret > 0)
            {
                SetCache();
                InvalidateCache();
            }

            return ret;
        }

        public bool UpdateTagGroup()
        {
            return UpdateTagGroup(TagGroupId, TagGroupName, LanguageId, DomainId);
        }
        private Boolean UpdateTagGroup(Guid tagGroupId, String tagGroupName, Int32 languageId, Int32 domainId)
        {
            TagGroupDetails tagDetails = new TagGroupDetails(tagGroupId, tagGroupName, languageId, domainId);
            Boolean ret = SiteProvider.Tag.UpdateTagGroup(tagDetails);
            if (Settings.EnableCaching & ret)
            {
                SetCache();
                InvalidateCache();
            }
            return ret;
        }
        public bool DeleteTagGroup()
        {
            return DeleteTagGroup(TagGroupId, TagGroupName, LanguageId, DomainId);
        }
        private bool DeleteTagGroup(Guid tagGroupId, String tagGroupName, Int32 languageId, Int32 domainId)
        {
            TagGroupDetails tagGroupDetails = new TagGroupDetails(tagGroupId, tagGroupName, languageId, domainId);
            bool ret = SiteProvider.Tag.DeleteTagGroup(tagGroupDetails.TagGroupId);
            if (Settings.EnableCaching & ret)
                InvalidateCache();
            return ret;
        }

        /// <summary>
        /// تبدیل داده لایه دیتا به داده لایه تجاری
        /// </summary>
        /// <param name="record">رکورد ورودی حاوی داده لایه دیتا</param>
        /// <returns></returns>
        /// 
       
        private static TagGroup GetTagGroupFromOrderDal(TagGroupDetails record)
        {
            if (record != null)
                return new TagGroup(record.TagGroupId, record.TagGroupName, record.LanguageId,record.DomainId);
            return null;
        }
        private static List<TagGroup> GetTagGroupCollectionFromOrderDal(List<TagGroupDetails> records)
        {
            List<TagGroup> items = new List<TagGroup>();
            foreach (TagGroupDetails item in records)
                items.Add(GetTagGroupFromOrderDal(item));
            return items;
        }

        #endregion


    }
}
