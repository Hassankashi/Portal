using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pine.Dal;
using Pine.Dal.Tag;

namespace Pine.Bll.Tag
{
    public class TagJunction : BaseTag
    {
        public TagJunction(Guid tagId, Guid adItemId)
       {
           TagId = tagId;
           AdItemId = adItemId;
       }

        public TagJunction()
        {
        }

        #region properties
        public Guid TagId { get; set; }
        public Guid AdItemId { get; set; }
        #endregion

        #region Methods

       public Int32 InsertTagJunction()
        {
            return InsertTagJunction(TagId, AdItemId);
        }

       private Int32 InsertTagJunction(Guid tagId, Guid adItemId)
        {
            TagJunctionDetails tagJunctionDetails = new TagJunctionDetails(tagId, adItemId);
            Int32 ret = SiteProvider.Tag.InsertTagJunction(tagJunctionDetails);
            if (Settings.EnableCaching & ret > 0)
            {
                SetCache();
                InvalidateCache();
            }

            return ret;
        }

       public static List<TagJunction> GetTagJunctionByadItemId(Guid adItemId)
       {
           List<TagJunction> item;
           SetCache();
           String key = "TagJunction_adItemId_" + adItemId;

           if (Settings.EnableCaching)
           {
               item = GetCacheItem(key) as List<TagJunction>;
               if (item == null)
               {
                   List<TagJunctionDetails> recordSet = SiteProvider.Tag.GetTagJunctionByadItemId(adItemId);
                   item = GetTagJunctionCollectionFromOrderDal(recordSet);
                   AddCacheItem(key, item);
               }
           }
           else
           {
               List<TagJunctionDetails> recordSet = SiteProvider.Tag.GetTagJunctionByadItemId(adItemId);
               item = GetTagJunctionCollectionFromOrderDal(recordSet);
           }
           return item;
       }
       public bool DeleteTagJunction()
       {
           return DeleteTagJunction(TagId, AdItemId);
       }
       private bool DeleteTagJunction(Guid tagId, Guid adItemId)
       {
           TagJunctionDetails tagJunctionDetails = new TagJunctionDetails(tagId, adItemId);
           bool ret = SiteProvider.Tag.DeleteTagJunction(tagJunctionDetails.TagId, tagJunctionDetails.AdItemId);
           if (Settings.EnableCaching & ret)
               InvalidateCache();
           return ret;
       }

       private static TagJunction GetTagJunctionFromOrderDal(TagJunctionDetails record)
       {
           if (record != null)
               return new TagJunction(record.TagId, record.AdItemId);
           return null;
       }
       private static List<TagJunction> GetTagJunctionCollectionFromOrderDal(List<TagJunctionDetails> records)
       {
           List<TagJunction> items = new List<TagJunction>();
           foreach (TagJunctionDetails item in records)
               items.Add(GetTagJunctionFromOrderDal(item));
           return items;
       }


        #endregion


    }
}
