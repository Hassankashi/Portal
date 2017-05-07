using System;
using System.Linq;

namespace Pine.Dal.Menu
{
    /// <summary>
    /// کلاسی برای نگهداری جزئیات گروه منو
    /// </summary>
    public class MenuGroupDetails
    {


        #region Constructors (2)

        /// <summary>
        /// سازنده اصلی کلاس جزئیات گروه منو
        /// </summary>
        /// <param name="menuNameId">کد گروه منو</param>
        /// <param name="menuName">نام گروه منو</param>
        public MenuGroupDetails(Int32 menuNameId, String menuName)
        {
            MenuNameId = menuNameId;
            MenuName = menuName;
        }

        /// <summary>
        /// سازنده پیش فرض کلاس جزئیات گروه منو
        /// </summary>
        public MenuGroupDetails()
        {
        }

        #endregion Constructors

        #region Properties (2)

        /// <summary>
        /// کد گروه منو
        /// </summary>
        public Int32 MenuNameId { get; set; }

        /// <summary>
        /// نام گروه منو
        /// </summary>
        public String MenuName { get; set; }


        #endregion Properties

    }
}
