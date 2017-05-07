using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net.Http;

namespace App_Code
{
    /// <summary>
    /// Summary description for WebApiConfig
    /// </summary>
    /// 
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new
                {
                    id = RouteParameter.Optional
                });
        }
    }
}

//public class WebApiConfig
//{
//    public WebApiConfig()
//    {
//        //
//        // TODO: Add constructor logic here
//        //
//    }
//}