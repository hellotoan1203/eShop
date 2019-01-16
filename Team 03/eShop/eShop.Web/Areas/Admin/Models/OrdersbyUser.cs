using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShop.Model.Models;

namespace eShop.Web.Areas.Admin.Models
{
    public class OrdersbyUser
    {
        public Order order { set; get; }
        public User user { set; get; }
        public OrdersbyUser(Order o, User u)
        {
            this.order = o;
            this.user = u;
        }
    }
}
