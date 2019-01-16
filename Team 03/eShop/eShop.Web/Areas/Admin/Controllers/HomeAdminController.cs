using eShop.Model.Models;
using eShop.Service.Services;
using eShop.Web.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eShop.Web.Areas.Admin.Controllers
{
    public class HomeAdminController : Controller
    {
        IUserService _userService;
        IProductService _productService;
        IOrderService _orderService;
        User currentUser = UserHelper.GetCurrentUser();

        public HomeAdminController(IUserService userService, IProductService productService, IOrderService orderService)
        {
            _userService = userService;
            _productService = productService;
            _orderService = orderService;
        }


        // GET: Admin/HomeAdmin
        public ActionResult Index()
        {
            if (currentUser == null || currentUser.Role != 1)
                return RedirectToAction("Unauthorized", "Account");

            DateTime today = DateTime.Now;
            var users = _userService.GetAll();
            int[] userInWeek = new int[16];
            int[] orderInWeek = new int[16];
            for (int i = 1; i < 17; i++)
            {
                userInWeek[i-1] = users.Where(x => x.SignupDate > DateTime.Now.AddDays(-7 * i) && x.SignupDate < DateTime.Now.AddDays(-7*(i-1))).Count();
                orderInWeek[i - 1] = this._orderService.GetAll().Where(x => x.OrderDate > DateTime.Now.AddDays(-7 * i) && x.OrderDate < DateTime.Now.AddDays(-7 * (i - 1))).Count();
            }

            ViewBag.ListUserInMonth = userInWeek;

            ViewBag.AllUsers = users.Count();

            ViewBag.AllProducts = _productService.GetAll().Count();

            ViewBag.AllOrders = _orderService.GetAll().Count();

            ViewBag.ListSaleInWeek = orderInWeek;

            ViewBag.AllUsersInMonth = users
                .Where(x => x.SignupDate.Month == today.Month && x.SignupDate.Year == today.Year)
                .Count();

            ViewBag.ListUserRegions = _userService.GetAll().GroupBy(x => x.Country).Select( x => new { Regions = x.Key, y = x.Count() }).ToList();

            return View("~/Areas/Admin/Views/HomeAdmin/Index.cshtml");
        }


        [ChildActionOnly]
        public ActionResult FooterAdmin()
        {
            return PartialView("~/Areas/Admin/Views/Shared/FooterAdmin.cshtml");
        }

        [ChildActionOnly]
        public ActionResult HeaderAdmin()
        {
            return PartialView("~/Areas/Admin/Views/Shared/HeaderAdmin.cshtml");
        }

        [ChildActionOnly]
        public ActionResult LeftMenuAdmin()
        {
            return PartialView("~/Areas/Admin/Views/Shared/LeftMenuAdmin.cshtml");
        }
    }
}