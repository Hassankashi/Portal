using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Pine.Dal.Statistics;

namespace Pine.Dal.SqlClient
{
    /// <summary>
    /// کلاسی برای پیاده سازی منوها
    /// </summary>
    public class SqlStatisticsProvider : StatisticsProvider
    {
        #region StatisticDates (3)


        /// <summary>
        /// دریافت تعداد بوسیله تاریخ
        /// </summary>
        /// <param name="date">تاریخ</param>
        /// <returns></returns>
        public override Int32?  GetStatisticDatesByDate(DateTime date)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "Select number From StatisticDates where EnterDate=@EnterDate";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@EnterDate", SqlDbType.Date).Value = date.Date;
                    connection.Open();
                    IDataReader reader = ExecuteReader(command, CommandBehavior.SingleRow);

                    if (reader.Read())
                        return Int32.Parse(reader["number"].ToString());
                    return null;
                }
            }
        }

        /// <summary>
        /// دریافت تعداد از تاریخ
        /// </summary>
        /// <param name="date">تاریخ</param>
        /// <returns></returns>
        public override Int32? GetStatisticDatesByAzDate(DateTime date)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "Select sum(number) as number From StatisticDates where EnterDate>=@EnterDate AND EnterDate < @EnterDateStart";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@EnterDate", SqlDbType.Date).Value = date.Date;
                    command.Parameters.Add("@EnterDateStart", SqlDbType.Date).Value = DateTime.Now.Date;
                    connection.Open();
                    IDataReader reader = ExecuteReader(command, CommandBehavior.SingleRow);

                    if (reader.Read())
                        return reader["number"] as Int32?;
                    return null;
                }
            }
        }

        /// <summary>
        /// کل تعداد آمار بازدید
        /// </summary>
        /// <param name="date">تاریخ</param>
        /// <returns></returns>
        public override Int32? GetStatisticDatesAllCount(DateTime date)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "Select sum(number) as number From StatisticDates where EnterDate<@EnterDate";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@EnterDate", SqlDbType.Date).Value = date.Date;
                    connection.Open();
                    IDataReader reader = ExecuteReader(command, CommandBehavior.SingleRow);

                    if (reader.Read())
                        return Int32.Parse(reader["number"].ToString());
                    return null;
                }
            }
        }

        #endregion

  

    }
}

