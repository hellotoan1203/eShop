using System;
using System.Web.Security;
using eShop.Model.Models;

namespace eShop.Web.CustomAuthentication
{
    public class CustomMembershipUser : MembershipUser
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }

        public CustomMembershipUser(User user) : base("CustomMembership", user.Username, user.Id, user.Email,
            string.Empty, string.Empty, true, false, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now,
            DateTime.Now)
        {
            UserId = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Role = user.Role > 0 ? "Admin" : "User";
        }
    }
}