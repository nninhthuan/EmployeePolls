using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace EmployeePolls
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            var settings = new FriendlyUrlSettings();
            settings.AutoRedirectMode = RedirectMode.Permanent;
            routes.EnableFriendlyUrls(settings);

            routes.MapPageRoute(
                "HomeRoute",
                "",
                "~/Home_Page/HomePage.aspx"
            );

            routes.MapPageRoute(
                "LeaderboardRoute",
                "leader-board",
                "~/Leaderboard/Leaderboard.aspx"
            );

            routes.MapPageRoute(
                "CreatePollRoute",
                "create",
                "~/Create_Poll/CreatePoll.aspx"
            );
        }
    }
}
