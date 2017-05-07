using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace Pine.Dal.Tag
{
   public abstract class TagProvider : DataAccess
    {
       #region Fields (1)

       static private TagProvider _instance;

       #endregion Fields


        #region Constructors (1)

        /// <summary>
        /// سازنده اصلی کلاس
        /// </summary>
       protected TagProvider()
        {
            ConnectionString = Globals.Settings.Tag.ConnectionString;
            EnableCaching = Globals.Settings.Tag.EnableCaching;
            CacheDuration = Globals.Settings.Tag.CacheDuration;
        }

        #endregion Constructors

       static public TagProvider Instance
       {
           get
           {
               return _instance ?? (_instance = (TagProvider)Activator.CreateInstance(
                   Type.GetType(Globals.Settings.Tag.ProviderType)));
           }
       }

#region Tag
       public abstract TagDetails GetTagByTagId(Guid tagId);
       public abstract List<TagDetails> GetTagByTagGroupId(Guid tagGroupId);
       public abstract List<TagDetails> GetTagByAdItemId(Guid adItemId);
       public abstract Int32 InsertTag(TagDetails tagDetails);
       public abstract Boolean UpdateTag(TagDetails tagDetails);
       public abstract Boolean DeleteTag(Guid tagId);
#endregion

       #region Virtual Protected Methods (2)

       protected virtual List<TagDetails> GetTagCollectionFromDataReader(IDataReader reader)
       {
           List<TagDetails> items = new List<TagDetails>();
           while (reader.Read())
               items.Add(GetTagFromDataReader(reader));
           return items;
       }

     
       protected virtual TagDetails GetTagFromDataReader(IDataReader reader)
       {
           return new TagDetails
               (
                   (Guid)reader["TagId"],
                   (String)reader["Title"],
                   (Guid)reader["TagGroupId"]
               );
       }
       #endregion


#region TagGroup

       public abstract List<TagGroupDetails> GetAllTagGroup(Int32 languageId, Int32 domainId);
       public abstract TagGroupDetails GetTagGroupByTagGroupId(Guid tagGroupId);
       public abstract Int32 InsertTagGroup(TagGroupDetails tagGroupDetails);
       public abstract Boolean UpdateTagGroup(TagGroupDetails tagGroupDetails);
       public abstract Boolean DeleteTagGroup(Guid tagGroupId);

       #region Virtual Protected Methods (2)

       protected virtual List<TagGroupDetails> GetTagGroupCollectionFromDataReader(IDataReader reader)
       {
           List<TagGroupDetails> items = new List<TagGroupDetails>();
           while (reader.Read())
               items.Add(GetTagGroupFromDataReader(reader));
           return items;
       }

     protected virtual TagGroupDetails GetTagGroupFromDataReader(IDataReader reader)
       {
           return new TagGroupDetails
               (
                   (Guid)reader["TagGroupId"],
                   (String)reader["TagGroupName"],
                   (Int32)reader["LanguageId"],
                   (Int32)reader["DomainId"]
               );
       }
       #endregion
#endregion

#region TagJunction
     public abstract List<TagJunctionDetails> GetTagJunctionByadItemId(Guid adItemId);
       public abstract Int32 InsertTagJunction(TagJunctionDetails tagJunctionDetails);
       public abstract Boolean DeleteTagJunction(Guid tagId, Guid adItemId);

       protected virtual List<TagJunctionDetails> GetTagJunctionCollectionFromDataReader(IDataReader reader)
       {
           List<TagJunctionDetails> items = new List<TagJunctionDetails>();
           while (reader.Read())
               items.Add(GetTagJunctionFromDataReader(reader));
           return items;
       }
       protected virtual TagJunctionDetails GetTagJunctionFromDataReader(IDataReader reader)
       {
           return new TagJunctionDetails
               (
                   (Guid)reader["TagId"],
                    (Guid)reader["AdItemId"]
               );
       }
#endregion
    }
}
