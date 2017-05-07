using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.WebHost;
using System.Web.SessionState;
using System.Web.Routing;

/// <summary>
/// This class is used for Global.asax in order to ability to define and fill session
/// </summary>

public class SessionableControllerHandler : HttpControllerHandler, IRequiresSessionState
{
    public SessionableControllerHandler(RouteData routeData)
        : base(routeData)
    { }
}