using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Helper
{
    public class StringHelper
    {
        public static string AdHocTableNameQuery(string query)
        {
            var a = query.ToLower().Replace(" artist ", " [artist] ")
                                          .Replace(" cart ", " [cart] ")
                                          .Replace(" cartitem ", " [cartitem] ")
                                          .Replace(" error ", " [error] ")
                                          .Replace(" order ", " [order] ")
                                          .Replace(" orderdetail ", " [orderdetail] ")
                                          .Replace(" ordernumber ", " [ordernumber] ")
                                          .Replace(" product ", " [product] ")
                                          .Replace(" rating ", " [rating] ")
                                          .Replace("user", "[user]");

            return query = query.ToLower().Replace(" artist ", " [artist] ")
                                          .Replace(" cart ", " [cart] ")
                                          .Replace(" cartitem ", " [cartitem] ")
                                          .Replace(" error ", " [error] ")
                                          .Replace(" order ", " [order] ")
                                          .Replace(" orderdetail ", " [orderdetail] ")
                                          .Replace(" ordernumber ", " [ordernumber] ")
                                          .Replace(" product ", " [product] ")
                                          .Replace(" rating ", " [rating] ")
                                          .Replace(" user ", " [user] ");
        }
    }
}
