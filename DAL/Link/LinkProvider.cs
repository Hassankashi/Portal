using System;
using System.Collections.Generic;
using System.Data;

namespace Pine.Dal.Link
{
    public abstract class LinkProvider : DataAccess
    {
        #region Fields (1)

        static private LinkProvider _instance;

        #endregion Fields

        #region Constructors (1)

        /// <summary>
        /// سازنده اصلی کلاس
        /// </summary>
        protected LinkProvider()
        {
            ConnectionString = Globals.Settings.Link.ConnectionString;
            EnableCaching = Globals.Settings.Link.EnableCaching;
            CacheDuration = Globals.Settings.Link.CacheDuration;
        }

        #endregion Constructors

        #region Properties (1)

        /// <summary>
        /// Returns an instance of the provider type specified in the config file
        /// </summary>
        static public LinkProvider Instance
        {
            get
            {
                return _instance ?? (_instance = (LinkProvider)Activator.CreateInstance(
                    Type.GetType(Globals.Settings.Link.ProviderType)));
            }
        }

        #endregion Properties

        #region LinkGroup (3)
        /// <summary>
        /// گرفتن نام گروه منو
        /// </summary>
        /// <param name="menuNameId">کد گروه منو</param>
        /// <returns>نام گروه</returns>
        public abstract LinkGroupDetails GetLinkGroupByLinkGroupId(Int32 linkGroupId);

        /// <summary>
        /// وارد کردن نام گروه
        /// </summary>
        /// <param name="groupMenuId">کد گروه منو</param>
        /// <param name="name">نام گروه منو</param>
        /// <returns>کد گروه وارد شده</returns>
        public abstract Int32 InsertLinkGroup(LinkGroupDetails linkGroup);

        /// <summary>
        /// ویرایش نام گروه
        /// </summary>
        /// <param name="menuGroup"></param>
        /// <returns></returns>
        public abstract Boolean UpdateLinkGroup(LinkGroupDetails linkGroup);
        #endregion

        #region Link (4)

        /// <summary>
        /// بازیابی اطلاعات یک لینک
        /// </summary>
        /// <param name="menuNameId">کد گروه لینک</param>
        /// <returns>کلاسی از لینک</returns>
        public abstract List<LinkDetails> GetLinkByLinkGroupId(Int32 linkGroupId);

        /// <summary>
        /// بازیابی اطلاعات یک رکورد لینک
        /// </summary>
        /// <param name="menuNameId">کد لینک</param>
        /// <returns>کلاس لینک</returns>
        public abstract LinkDetails GetLinkByLinkId(Int32 linkId);


        /// <summary>
        /// ویرایش لینک 
        /// </summary>
        /// <param name="menuGroup"></param>
        /// <returns></returns>
        public abstract Boolean UpdateLink(LinkDetails link);

        /// <summary>
        /// وارد کردن یک لینک
        /// </summary>
        /// <param name="menu">کلاس لینک</param>
        /// <returns>کد لینک</returns>
        public abstract Int32 InsertLink(LinkDetails link);

        #endregion

        #region Virtual Protected Methods (2)

        protected virtual List<LinkDetails> GetLinkCollectionFromDataReader(IDataReader reader)
        {
            List<LinkDetails> items = new List<LinkDetails>();
            while (reader.Read())
                items.Add(GetLinkFromDataReader(reader));
            return items;
        }



        protected virtual LinkDetails GetLinkFromDataReader(IDataReader reader)
        {
            return new LinkDetails
                (
                    (Int32)reader["LinkId"],
                    (Int32)reader["LinkGroupId"],
                    reader["LinkName"].ToString(),
                    reader["NavigateUrl"].ToString(),
                    reader["IconUrl"].ToString(),
                   (Boolean) reader["IsActive"],
                    (Byte)reader["Priority"],
                    (DateTime)reader["EnterDate"],
                    reader["UserControl"].ToString()
                );
        }


        protected virtual LinkGroupDetails GetLinkGroupFromDataReader(IDataReader reader)
        {
            return new LinkGroupDetails
                (
                    (Int32)reader["LinkGroupId"],
                    reader["Name"].ToString()
                );
        }
        #endregion

    }
}
