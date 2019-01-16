using System.Security.Claims;
using System.Web;
using eShop.Model.Models;
using eShop.Service.Services;
using Microsoft.Owin.Security;
using Unity;

namespace eShop.Web.Attributes
{
    public class UserHelper
    {
        public static User GetCurrentUser()
        {
            IAuthenticationManager authentication = HttpContext.Current.GetOwinContext().Authentication;
            AuthenticateResult ticket = authentication.AuthenticateAsync("Application").Result;
            ClaimsIdentity identity = ticket != null ? ticket.Identity : null;
            if (identity == null)
            {
                return null;
            }

            var userService = UnityConfig.Container.Resolve<IUserService>();
            return userService.GetByEmail(identity.Name);
        }
    }
}