using System;
using System.Web.Configuration;

namespace Pine
{
    /// <summary>
    /// کلاس استاتیک برای دسترسی به تنظیمات نرم افزار
    /// </summary>
    public static class Globals
    {
        /// <summary>
        /// خاصیت برای دستیابی به تنظیمات
        /// </summary>
        public readonly static PineSection Settings = (PineSection)WebConfigurationManager.GetSection("PineSection");


        /// <summary>
        /// سازنده پیش فرض
        /// </summary>
        static Globals() { }
    }
}
