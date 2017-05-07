using Pine.Dal.Menu;
using Pine.Dal.Core;
using Pine.Dal.Statistics;
using Pine.Dal.Blog;
using Pine.Dal.Link;
using Pine.Dal.Store;
using Pine.Dal.Advertisement;
using Pine.Dal.Tag;
using Pine.Dal.Chat;
using Pine.Dal.Poll;
namespace Pine.Dal
{
    /// <summary>
    /// کلاسی برای دسترسی به پروایدر سرویس های نرم افزار
    /// </summary>
    public static class SiteProvider
    {
        /// <summary>
        /// خصوصیت استاتیک برای دسترسی به یک نمونه از این کلاس
        /// </summary>
        public static MenuProvider Menu
        {
            get { return MenuProvider.Instance; }
        }

        public static LinkProvider Link
        {
            get { return LinkProvider.Instance; }
        }

        public static CoreProvider Core
        {
            get { return CoreProvider.Instance; }
        }

        public static StatisticsProvider Statistics
        {
            get { return StatisticsProvider.Instance; }
        }

        public static BlogProvider Blog
        {
            get { return BlogProvider.Instance; }
        }

        public static StoreProvider Store
        {
            get { return StoreProvider.Instance; }
        }

        public static AdvertisementProvider Advertisement
        {
            get { return AdvertisementProvider.Instance; }
        }

        public static TagProvider Tag
        {
            get { return TagProvider.Instance; }
        }
        public static ChatProvider Chat
        {
            get { return ChatProvider.Instance; }
        }
        public static PollProvider Poll
        {
            get { return PollProvider.Instance; }
        }
    }
}
