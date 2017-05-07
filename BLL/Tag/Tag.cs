using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pine.Dal;
using Pine.Dal.Tag;

namespace Pine.Bll.Tag
{
    public class Tag : BaseTag
    {
        public Tag(Guid tagId, String title, Guid tagGroupId)
        {
            TagId = tagId;
            Title = title;
            TagGroupId = tagGroupId;
        }

        public Tag()
        {
        }

        #region properties
        public Guid TagId { get; set; }
        public String Title { get; set; }
        public Guid TagGroupId { get; set; }
        #endregion

        #region Methods

        public static Tag GetTagByTagId(Guid tagId)
        {
            Tag item;
            SetCache();
            String key = "Tag_tagId_" + tagId;

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as Tag;
                if (item == null)
                {
                    TagDetails record = SiteProvider.Tag.GetTagByTagId(tagId);
                    item = GetTagFromOrderDal(record);
                    AddCacheItem(key, item);
                }
            }
            else
            {
                TagDetails recordSet = SiteProvider.Tag.GetTagByTagId(tagId);
                item = GetTagFromOrderDal(recordSet);
            }

            return item;
        }
        public static List<Tag> GetTagByTagGroupId(Guid tagGroupId)
        {

            SetCache();
            List<Tag> item;

            String key = "Tag_TagGroupId_" + tagGroupId;

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as List<Tag>;
                if (item == null)
                {
                    List<TagDetails> recordSet = SiteProvider.Tag.GetTagByTagGroupId(tagGroupId);
                    item = GetTagCollectionFromOrderDal(recordSet);
                    AddCacheItem(key, item);
                }
            }
            else
            {
                List<TagDetails> recordSet = SiteProvider.Tag.GetTagByTagGroupId(tagGroupId);
                item = GetTagCollectionFromOrderDal(recordSet);
            }
            return item;
        }

        public static List<Tag> GetTagsByAdItemId(Guid AdItemId)
        {

            SetCache();
            List<Tag> item;

            String key = "Tag_AdItemId_" + AdItemId;

            if (Settings.EnableCaching)
            {
                item = GetCacheItem(key) as List<Tag>;
                if (item == null)
                {
                    List<TagDetails> recordSet = SiteProvider.Tag.GetTagByAdItemId(AdItemId);
                    item = GetTagCollectionFromOrderDal(recordSet);
                    AddCacheItem(key, item);
                }
            }
            else
            {
                List<TagDetails> recordSet = SiteProvider.Tag.GetTagByAdItemId(AdItemId);
                item = GetTagCollectionFromOrderDal(recordSet);
            }
            return item;
        }

        public Int32 InsertTag()
        {
            return InsertTag(TagId, Title, TagGroupId);
        }

        private Int32 InsertTag(Guid tagId, String title, Guid tagGroupId)
        {
            TagDetails tagDetails = new TagDetails(tagId, title, tagGroupId);
            Int32 ret = SiteProvider.Tag.InsertTag(tagDetails);
            if (Settings.EnableCaching & ret > 0)
            {
                SetCache();
                InvalidateCache();
            }

            return ret;
        }



        public bool UpdateTag()
        {
            return UpdateTag(TagId,Title,TagGroupId);
        }
       private Boolean UpdateTag(Guid tagId, String title, Guid tagGroupId)
        {
            TagDetails tagDetails = new TagDetails(tagId, title, tagGroupId);
            Boolean ret = SiteProvider.Tag.UpdateTag(tagDetails);
            if (Settings.EnableCaching & ret)
            {
                SetCache();
                InvalidateCache();
            }
            return ret;
        }

       public bool DeleteTag()
       {
           return DeleteTag(TagId, Title, TagGroupId);
       }

       private bool DeleteTag(Guid tagId, String title, Guid tagGroupId)
       {
           TagDetails tagDetails = new TagDetails(tagId, title, tagGroupId);
           bool ret = SiteProvider.Tag.DeleteTag(tagDetails.TagId);
           if (Settings.EnableCaching & ret)
               InvalidateCache();
           return ret;
       }
        /// <summary>
        /// تبدیل داده لایه دیتا به داده لایه تجاری
        /// </summary>
        /// <param name="record">رکورد ورودی حاوی داده لایه دیتا</param>
        /// <returns></returns>
        private static Tag GetTagFromOrderDal(TagDetails record)
        {
            if (record != null)
                return new Tag(record.TagId, record.Title, record.TagGroupId);
            return null;
        }
        private static List<Tag> GetTagCollectionFromOrderDal(List<TagDetails> records)
        {
            List<Tag> items = new List<Tag>();
            foreach (TagDetails item in records)
                items.Add(GetTagFromOrderDal(item));
            return items;
        }

        #endregion


    }
}
