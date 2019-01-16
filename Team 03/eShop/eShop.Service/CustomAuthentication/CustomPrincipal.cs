using System;
using System.Linq;
using System.Security.Principal;

namespace eShop.Web.CustomAuthentication
{
    public class CustomPrincipal : IPrincipal
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Roles { get; set; }

        public CustomPrincipal(string username)
        {
            Identity = new GenericIdentity(username);
        }

        public IIdentity Identity { get; }

        public bool IsInRole(string role)
        {
            if (string.IsNullOrWhiteSpace(role))
            {
                return true;
            }

            var roles = role.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
            return Roles.Equals(role);
        }
    }
}