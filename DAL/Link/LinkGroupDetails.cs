using System;
using System.Linq;

namespace Pine.Dal.Link
{
    /// <summary>
    /// کلاسی برای نگهداری جزئیات گروه منو
    /// </summary>
    public class LinkGroupDetails
    {


        #region Constructors (2)

        /// <summary>
        /// سازنده اصلی کلاس جزئیات گروه لینک
        /// </summary>
        /// <param name="menuNameId">کد گروه لینک</param>
        /// <param name="menuName">نام گروه لینک</param>
        public LinkGroupDetails(Int32 linkGroupId, String name)
        {
            LinkGroupId = linkGroupId;
            Name = name;
        }

        /// <summary>
        /// سازنده پیش فرض کلاس جزئیات گروه لینک
        /// </summary>
        public LinkGroupDetails()
        {
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

    }
}
