using System;
using System.Linq;


namespace Pine
{
    /// <summary>
    /// وضعیت سفارش
    /// </summary>
    public enum OrderStatus
    {
        /// <summary>
        /// سفارش جدید
        /// </summary>
        New = 0,
        /// <summary>
        /// ارسال شده
        /// </summary>
        Sended = 1,
        /// <summary>
        /// تایید پرداخت
        /// </summary>
        Confirmed = 2,
        /// <summary>
        /// گم شده
        /// </summary>
        Lost = 3
    }

    /// <summary>
    /// وضعیت پرداخت اینترنتی
    /// </summary>
    public enum PayOnlineStatus
    {
        /// <summary>
        /// خطا در پرداخت
        /// </summary>
        Error = 0,
        /// <summary>
        /// تایید پرداخت
        /// </summary>
        Confirm = 1
    }

    /// <summary>
    /// نحوه پرداخت
    /// </summary>
    public enum PayType
    {
        Cash,
        Swift,
        Naghd
    }

    /// <summary>
    /// نحوه ارسال
    /// </summary>
    public enum SendType
    {
       PostSefareshi = 0,
    }

    /// <summary>
    /// اندازه تصاویر
    /// </summary>
    public enum ImageSize
    {
        /// <summary>
        /// اندازه کوچک
        /// </summary>
        Small = 0,

        /// <summary>
        /// اندازه بزرگ
        /// </summary>
        Large = 1,
    }
}
