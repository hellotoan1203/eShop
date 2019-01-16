using eShop.Web.Areas.Admin.Models;
using eShop.Service.Services;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using eShop.Model.Models;
using eShop.Web.Attributes;

namespace eShop.Web.Areas.Admin.Controllers
{
    public class ReportAdminController : Controller
    {
        IUserService _userService;
        IProductService _productService;
        IOrderService _orderService;
        IOrderDetailService _orderDetailService;
        IArtistService _artistService;
        User currentUser = UserHelper.GetCurrentUser();

        public ReportAdminController(IUserService us, IProductService pr, IOrderService or, IOrderDetailService ods, IArtistService a)
        {
            this._orderService = or;
            this._productService = pr;
            this._userService = us;
            this._orderDetailService = ods;
            this._artistService = a;
        }
        public ActionResult Index()
        {
            if (currentUser == null || currentUser.Role != 1)
                return RedirectToAction("Unauthorized", "Account");

            ViewBag.AllUsers = this._userService.GetAll().Count();
            ViewBag.AllOrders = this._orderService.GetAll().Count();
            ViewBag.AllProducts = this._productService.GetAll().Count();
            ViewBag.TotalProfit = this._orderService.GetAll().Sum(x => x.TotalPrice);
            ViewBag.TotalProfitLastWeek = this._orderService.GetAll().Where(x => x.OrderDate > DateTime.Now.Date.AddDays(-7)).Sum(x => x.TotalPrice);
                
            return View("~/Areas/Admin/Views/ReportAdmin/Index.cshtml");
        }
        public ActionResult OrderReport(int? page, int? sortcaterial)
        {
            if (currentUser == null || currentUser.Role != 1)
                return RedirectToAction("Unauthorized", "Account");

            var listOrders = this._orderService.GetAll().Join(this._userService.GetAll(),
                    o => o.UserId,
                    u => u.Id,
                    (o, u) => new { Orders = o, Users = u }
                );
            List<OrdersbyUser> listOrderbyUser = new List<OrdersbyUser>();
            foreach(var item in listOrders)
            {
                listOrderbyUser.Add(new OrdersbyUser(item.Orders, item.Users));
            }
            switch (sortcaterial)
            {
                case 2:
                    listOrderbyUser= listOrderbyUser.OrderBy(x => x.user.FirstName).ToList();
                    break;
                case 3:
                    listOrderbyUser=listOrderbyUser.OrderBy(x => x.order.Id).ToList();
                    break;
                case 4:
                    listOrderbyUser=listOrderbyUser.OrderBy(x => x.order.TotalPrice).ToList();
                    break;
                case 5:
                    listOrderbyUser = listOrderbyUser.OrderBy(x => x.order.ItemCount).ToList();
                    break;
                default:
                    listOrderbyUser= listOrderbyUser.OrderBy(x => x.order.OrderDate).ToList();
                    break;
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View("~/Areas/Admin/Views/ReportAdmin/OrderReport.cshtml",listOrderbyUser.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult OrderReportDetail(int id)
        {
            if (currentUser == null || currentUser.Role != 1)
                return RedirectToAction("Unauthorized", "Account");

            var order = this._orderService.GetSingleById(id);
            var customer = this._userService.GetSingleById(order.UserId);
            ViewBag.Order = order;
            ViewBag.CustomerName = customer.FirstName;
            List<OrderDetailRespone> orderDetailRespone = new List<OrderDetailRespone>();
            var listOrderDetail = this._orderDetailService.GetAll().Where(x => x.OrderId == id);
            foreach(var ord in listOrderDetail)
            {
                OrderDetailRespone tempResult = new OrderDetailRespone();
                var temoproduct = this._productService.GetSingleById(ord.ProductId);
                var temartist = this._artistService.GetSingleById(temoproduct.ArtistId);
                tempResult.ArtistName = temartist.Name;
                tempResult.ProductName = temoproduct.Title;
                tempResult.Quantity = ord.Quantity;
                tempResult.Subtotal = ord.Price;
                tempResult.Price = temoproduct.Price;
                tempResult.Image = temoproduct.Image;
                orderDetailRespone.Add(tempResult);
            }

            return View("~/Areas/Admin/Views/ReportAdmin/OrderReportDetail.cshtml", orderDetailRespone);
        }
    }
}