using System.Configuration;
using System;
using Pine.Dal.Core;
using Pine.Dal.Menu;
using Pine.Dal.Statistics;
using Pine.Dal.Blog;
using Pine.Dal.Link;
using Pine.Dal.Store;
using Pine.Dal.Advertisement;
using Pine.Dal.Tag;
using Pine.Dal.Chat;
using Pine.Dal.Poll;
namespace Pine
{
    public class PineSection : ConfigurationSection
    {
        #region Properties (5)

        [ConfigurationProperty("defaultCacheDuration", DefaultValue = "600")]
        public Int32 DefaultCacheDuration
        {
            get { return (Int32)base["defaultCacheDuration"]; }
            set { base["defaultCacheDuration"] = value; }
        }

        [ConfigurationProperty("defaultConnectionStringName", DefaultValue = "LocalSqlServer")]
        public String DefaultConnectionStringName
        {
            get { return (String)base["defaultConnectionStringName"]; }
            set { base["defaultConnectionStringName"] = value; }
        }


        //[ConfigurationProperty("Pronunciations", IsRequired = true)]
        //public PronunciationsElement Pronunciations
        //{
        //    get { return (PronunciationsElement)base["Pronunciations"]; }
        //}

        [ConfigurationProperty("Menu")]
        public MenuElement Menu
        {
            get { return (MenuElement)base["Menu"]; }
            set { base["Menu"] = value; }
        }

        [ConfigurationProperty("Link")]
        public LinkElement Link
        {
            get { return (LinkElement)base["Link"]; }
            set { base["Link"] = value; }
        }

        [ConfigurationProperty("Core")]
        public CoreElement Core
        {
            get { return (CoreElement)base["Core"]; }
            set { base["Core"] = value; }
        }

        [ConfigurationProperty("Advertisement")]
        public AdvertisementElement Advertisement
        {
            get { return (AdvertisementElement)base["Advertisement"]; }
            set { base["Advertisement"] = value; }
        }

        [ConfigurationProperty("Tag")]
        public TagElement Tag
        {
            get { return (TagElement)base["Tag"]; }
            set { base["Tag"] = value; }
        }

        [ConfigurationProperty("Statistics")]
        public StatisticsElement Statistics
        {
            get { return (StatisticsElement)base["Statistics"]; }
            set { base["Statistics"] = value; }
        }

        [ConfigurationProperty("Blog")]
        public BlogElement Blog
        {
            get { return (BlogElement)base["Blog"]; }
            set { base["Blog"] = value; }
        }

        [ConfigurationProperty("Store")]
        public StoreElement Store
        {
            get { return (StoreElement)base["Store"]; }
            set { base["Blog"] = value; }
        }

        [ConfigurationProperty("Chat")]
        public ChatElement Chat
        {
            get { return (ChatElement)base["Chat"]; }
            set { base["Chat"] = value; }
        }

        [ConfigurationProperty("Poll")]
        public PollElement Poll
        {
            get { return (PollElement)base["Poll"]; }
            set { base["Poll"] = value; }
        }
        #endregion Properties 
    }
}
