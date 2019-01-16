using eShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eShop.Web.Models
{
    [Serializable]
    public class ShoppingCart
    {
        public Product product { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        public int CartId { get; set; }
    }
}