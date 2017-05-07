using System;
using System.Linq;

namespace Pine.Dal.Statistics
{
    /// <summary>
    /// کلاسی برای نگهداری منو
    /// </summary>
    public class StatisticDatesDetails
    {
        #region Constructors (1)

        public StatisticDatesDetails(Int32 statisticDatesId, DateTime enterDate, Int32 number)
        {
            StatisticDatesId = statisticDatesId;
            EnterDate = enterDate;
            Number = number;
        }

        /// <summary>
        /// سازنده پیش فرض کلاس جزئیات منو
        /// </summary>
        public StatisticDatesDetails() { }

        #endregion Constructors

        #region Properties (3)

        /// <summary>
        /// کد
        /// </summary>
        public Int32 StatisticDatesId { get; set; }

        /// <summary>
        /// تاریخ
        /// </summary>
        public DateTime EnterDate { get; set; }

        /// <summary>
        /// تعداد
        /// </summary>
        public Int32 Number { get; set; }

        #endregion Properties

        //private static List<Menu> GetMenuByIdInDal(int id)
        //{
        //    return GetMenuUserCollectionFromDataReader(SiteProvider.Menu.GetMenuByMenuNameId(id));
        //}
    }
}
