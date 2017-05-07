using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web;
using System.Web.Routing;

/// <summary>
/// This class is used for Global.asax in order to ability to define and fill session
/// </summary>
public class SessionStateRouteHandler : IRouteHandler
{
    IHttpHandler IRouteHandler.GetHttpHandler(RequestContext requestContext)
    {
        return new SessionableControllerHandler(requestContext.RouteData);
    }
}