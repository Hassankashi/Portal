using System;
using System.Collections.Generic;
using System.Data;

namespace Pine.Dal.Statistics
{
    public abstract class StatisticsProvider : DataAccess
    {
        #region Fields (1)

        static private StatisticsProvider _instance;

        #endregion Fields

        #region Constructors (1)

        /// <summary>
        /// سازنده اصلی کلاس
        /// </summary>
        protected StatisticsProvider()
        {
            ConnectionString = Globals.Settings.Statistics.ConnectionString;
            EnableCaching = Globals.Settings.Statistics.EnableCaching;
            CacheDuration = Globals.Settings.Statistics.CacheDuration;
        }

        #endregion Constructors

        #region Properties (1)

        /// <summary>
        /// Returns an instance of the provider type specified in the config file
        /// </summary>
        static public StatisticsProvider Instance
        {
            get
            {
                return _instance ?? (_instance = (StatisticsProvider)Activator.CreateInstance(
                    Type.GetType(Globals.Settings.Statistics.ProviderType)));
            }
        }

        #endregion Properties

        #region StatisticDates (1)


        public abstract Int32?  GetStatisticDatesByDate(DateTime date);

        public abstract Int32? GetStatisticDatesByAzDate(DateTime date);

        public abstract Int32? GetStatisticDatesAllCount(DateTime date);

        #endregion


        #region Virtual Protected Methods (2)

        //protected virtual List<MenuDetails> GetMenuUserCollectionFromDataReader(IDataReader reader)
        //{
        //    List<MenuDetails> items = new List<MenuDetails>();
        //    while (reader.Read())
        //        items.Add(GetMenuUserFromDataReader(reader));
        //    return items;
        //}



        //protected virtual MenuDetails GetMenuUserFromDataReader(IDataReader reader)
        //{
        //    return new MenuDetails
        //        (
        //            (Int32)reader["MenuId"],
        //            (Int32)reader["MenuNameId"],
        //            reader["ParentMenuId"] as Int32?,
        //            reader["Text"].ToString(),
        //            reader["NavigateUrl"].ToString(),
        //            reader["ImageUrl"].ToString(),
        //            Int16.Parse(reader["Priority"].ToString()),
        //            reader["UserControl"].ToString()
        //        );
        //}


        //protected virtual MenuGroupDetails GetMenuGroupFromDataReader(IDataReader reader)
        //{
        //    return new MenuGroupDetails
        //        (
        //            Int32.Parse(reader["MenuNameId"].ToString()),
        //            reader["MenuName"].ToString()
        //        );
        //}
        #endregion

    }
}
