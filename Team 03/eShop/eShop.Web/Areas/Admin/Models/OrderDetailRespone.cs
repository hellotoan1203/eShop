using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eShop.Model.Models;

namespace eShop.Web.Areas.Admin.Models
{
    [Serializable]
    public class OrderDetailRespone
    {
        public string ProductName { get; set; }
        public string Image { get; set; }
        public string ArtistName { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double Subtotal { get; set; }
    }
}