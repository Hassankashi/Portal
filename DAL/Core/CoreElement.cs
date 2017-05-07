using System.Configuration;
using System.Web.Configuration;
using System;

namespace Pine.Dal.Core
{
    public class CoreElement : ConfigurationElement
    {
        [ConfigurationProperty("connectionStringName")]
        public String ConnectionStringName
        {
            get { return (String)base["connectionStringName"]; }
            set { base["connectionStringName"] = value; }
        }

        public String ConnectionString
        {
            get
            {
                String connStringName = (String.IsNullOrEmpty(ConnectionStringName) ?
                   Globals.Settings.DefaultConnectionStringName : ConnectionStringName);
                return WebConfigurationManager.ConnectionStrings[connStringName].ConnectionString;
            }
        }

        [ConfigurationProperty("providerType", DefaultValue = "Pine.Dal.SqlClient.SqlCoreProvider")]
        public String ProviderType
        {
            get { return (String)base["providerType"]; }
            set { base["providerType"] = value; }
        }

        [ConfigurationProperty("pageSize", DefaultValue = "10")]
        public Int32 PageSize
        {
            get { return (Int32)base["pageSize"]; }
            set { base["pageSize"] = value; }
        }
        [ConfigurationProperty("enableCaching", DefaultValue = "true")]
        public Boolean EnableCaching
        {
            get { return (Boolean)base["enableCaching"]; }
            set { base["enableCaching"] = value; }
        }

        [ConfigurationProperty("cacheDuration")]
        public Int32 CacheDuration
        {
            get
            {
                Int32 duration = (Int32)base["cacheDuration"];
                return (duration > 0 ? duration : Globals.Settings.DefaultCacheDuration);
            }
            set { base["cacheDuration"] = value; }
        }
    }
}
