using System;
using System.Linq;

namespace Pine.Dal.Link
{
    /// <summary>
    /// کلاسی برای نگهداری منو
    /// </summary>
    public class LinkDetails
    {
        #region Constructors (2)
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
        public LinkDetails(Int32 linkId, Int32 linkGroupId, String linkName, String navigateUrl, String iconUrl, Boolean isActive, Byte priority, DateTime enterDate, String userControl)
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
        /// سازنده پیش فرض کلاس جزئیات منو
        /// </summary>
        public LinkDetails() { }

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

    }
}
