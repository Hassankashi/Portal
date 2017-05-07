using System;
using System.Linq;
using System.Collections.Generic;
using Pine.Dal;
using Pine.Dal.Statistics;

namespace Pine.Bll.Statistics
{
    /// <summary>
    /// کلاسی برای نگهداری آمار بازدیدکندگان
    /// </summary>
    public class StatisticDates : BaseStatistics
    {
        #region Constructors (1)
        /// <summary>
        /// سازنده اصلی کلاس جزئیات منو
        /// </summary>
        /// <param name="menuId">کد منو</param>
        /// <param name="menuNameId">کد گروه منو</param>
        /// <param name="parentMenuId">کد پدر منو</param>
        /// <param name="text">عنوان</param>
        /// <param name="navigateUrl">رفتن به آدرس</param>
        /// <param name="imageUrl">آدرس عکس</param>
        /// <param name="priority">اولویت</param>
        /// <param name="userControl">عنوان ماژولی که وصل شده</param>
        public StatisticDates(Int32 statisticDatesId, DateTime enterDate, Int32 number)
        {
            Id = statisticDatesId;
            EnterDate = enterDate;
            Number = number;
        }

        /// <summary>
        /// سازنده پیش فرض کلاس جزئیات منو
        /// </summary>
        public StatisticDates()
        {
            CacheDuration = Settings.CacheDuration;
            MasterCacheKey = "Statistics";
        }

        #endregion Constructors

        #region Properties (2)

        /// <summary>
        /// تاریخ
        /// </summary>
        public DateTime EnterDate { get; set; }

        /// <summary>
        /// تعداد
        /// </summary>
        public Int32 Number { get; set; }

        #endregion Properties

        #region Methods(3)

        public Int32? GetStatisticDatesByDate(DateTime date)
        {
            Int32? item=0;

            String key = "StatisticDatesByDate_" + date.Date;

            if (Settings.EnableCaching && DateTime.Now.Date != date.Date)
            {

                item = GetCacheItem(key) as Int32?;
                if (item == null)
                {
                    item = SiteProvider.Statistics.GetStatisticDatesByDate(date);
                   // item = recordSet;
                    if (item==null)
                    {
                        item = 0;
                    }
                    AddCacheItem(key, item);
                }
            }
            else
            {
                item = SiteProvider.Statistics.GetStatisticDatesByDate(date);
            
            }
            return item;
        }

        public Int32? GetStatisticDatesAzDate(DateTime date)
        {
            Int32? item;

            String key = "StatisticDatesAzDate_" + date.Date;

            if (Settings.EnableCaching)
            {

                item = GetCacheItem(key) as Int32?;
                if (item == null)
                {
                    item = SiteProvider.Statistics.GetStatisticDatesByAzDate(date);
                    if (item == null)
                    {
                        item = 0;
                    }
                    AddCacheItem(key, item);
                }
            }
            else
            {
                item = SiteProvider.Statistics.GetStatisticDatesByAzDate(date);
            }
            return item;
        }

        public Int32? GetStatisticDatesAllCount(DateTime date)
        {
            Int32? item;

            String key = "StatisticDatesAllCount_" + date.Date;

            if (Settings.EnableCaching)
            {

                item = GetCacheItem(key) as Int32?;
                if (item == null)
                {
                    item = SiteProvider.Statistics.GetStatisticDatesAllCount(date);
                    if (item == null)
                    {
                        item = 0;
                    }
                    AddCacheItem(key, item);
                }
            }
            else
            {
                item = SiteProvider.Statistics.GetStatisticDatesAllCount(date);
            }
            return item;
        }
        #endregion
    }
}
