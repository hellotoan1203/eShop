using System;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace eShop.Web.Attributes
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var roleList = Roles.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            string role = string.Empty;
            var currentUser = UserHelper.GetCurrentUser();
            if (currentUser != null)
            {
                role = currentUser.RoleName;
            }

            return currentUser != null && (string.IsNullOrWhiteSpace(Roles) || roleList.Contains(role));
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            RedirectToRouteResult routeData = null;
            var currentUser = UserHelper.GetCurrentUser();
            if (currentUser == null)
                routeData = new RedirectToRouteResult
                (new RouteValueDictionary
                (new
                    {
                        controller = "Account",
                        action = "Unauthorized"
                    }
                ));
            else
                routeData = new RedirectToRouteResult
                (new RouteValueDictionary
                (new
                    {
                        controller = "Account",
                        action = "Unauthorized"
                }
                ));

            filterContext.Result = routeData;
        }
    }
}