using System;
using System.Data;
using System.Data.Common;
using System.Web;
using System.Web.Caching;


namespace Pine.Dal
{
    public abstract class DataAccess
    {

		#region Fields (1) 
 
        private Boolean _enableCaching = true;

		#endregion Fields 

		#region Properties (1) 

        //public string ConnectionString
        //{
        //    get
        //    {
        //        return ConfigurationSettings.AppSettings["ConnectionString"].ToString();
        //    }
        //}
        protected Cache Cache
        {
            get { return HttpContext.Current.Cache; }
        }

        protected Int32 CacheDuration { get; set; }

        protected String ConnectionString { get; set; }

        protected Boolean EnableCaching
        {
            get { return _enableCaching; }
            set { _enableCaching = value; }
        }

		#endregion Properties 

		#region Methods (4) 

		// Protected Methods (4) 

        protected Int32 ExecuteNonQuery(DbCommand cmd)
        {
            return cmd.ExecuteNonQuery();
        }

        protected IDataReader ExecuteReader(DbCommand cmd)
        {
            return ExecuteReader(cmd, CommandBehavior.Default);
        }

        protected IDataReader ExecuteReader(DbCommand cmd, CommandBehavior behavior)
        {
            return cmd.ExecuteReader(behavior);
        }

        protected object ExecuteScalar(DbCommand cmd)
        {
            return cmd.ExecuteScalar();
        }

		#endregion Methods 
 
    }
}
