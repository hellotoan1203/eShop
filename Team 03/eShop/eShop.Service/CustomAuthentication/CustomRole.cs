using System;
using System.Linq;
using System.Web;
using System.Web.Security;
using eShop.Model.Models;
using eShop.Service.Services;

namespace eShop.Web.CustomAuthentication
{
    public class CustomRole : RoleProvider
    {
        private readonly IUserService _userService;
        public CustomRole()
        {
            _userService = new UserService();
        }
        public CustomRole(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// </summary>
        /// <param name="username"></param>
        /// <param name="roleName"></param>
        /// <returns></returns>
        public override bool IsUserInRole(string username, string roleName)
        {
            string[] userRoles = GetRolesForUser(username);
            return userRoles.Contains(roleName);
        }

        /// <summary>
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public override string[] GetRolesForUser(string username)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated) return null;

            var userRoles = new string[] { };

            User user = _userService.GetByUsername(username);

            if (user != null)
            {
                userRoles = new[] { user.Role > 0 ? "Admin" : "User" };
            }

            return userRoles.ToArray();
        }


        #region Overrides of Role Provider

        public override string ApplicationName
        {
            get => throw new NotImplementedException();

            set => throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }


        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}