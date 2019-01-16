using eShop.Helper;
using eShop.Model.Models;
using eShop.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using eShop.Web.Attributes;
namespace eShop.Web.Areas.Admin.Controllers
{
    public class UserAdminController : Controller
    {
        IUserService _userService;
        User currentUser = UserHelper.GetCurrentUser();

        public UserAdminController(IUserService userService)
        {
            _userService = userService;         
        }

        // GET: Admin/UserAdmin
        public ActionResult Index()
        {
            if (currentUser == null || currentUser.Role != 1)
                return RedirectToAction("Unauthorized", "Account");
            //var users = _userService.GetAll().Where(u => u.Role != 1);
            //return View("~/Areas/Admin/Views/UserAdmin/Index.cshtml", users);
            return View("~/Areas/Admin/Views/UserAdmin/Index.cshtml");
        }


        //public ActionResult DeleteUser(int userId)
        //{
        //    _userService.Delete(userId);
        //    return RedirectToAction("Index");
        //}

        //Ajax
        [HttpGet]
        public JsonResult GetUsers()
        {
            var users = _userService.GetAll().Where(u => u.Role != 1);
            return Json(users, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteUser(int userId)
        {
            var result = _userService.Delete(userId);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddOrUpdateUser(string jsonUser)
        {
            var user = new JavaScriptSerializer().Deserialize<User>(jsonUser);


            object result = null;

            user.ChangedOn = DateTime.Now;
            user.ChangedBy = 1;

            if (user.Id == 0)
            {
                user.CreatedOn = DateTime.Now;
                user.SignupDate = DateTime.Now;
                user.CreatedBy = 1;

                result = _userService.Add(user);
            }
            else
            {
                result = _userService.Update(user);
            }

            return Json(result, JsonRequestBehavior.AllowGet);

        }

        //public JsonResult UpdateUser(string jsonUser)
        //{
        //    var user = new JavaScriptSerializer().Deserialize<User>(jsonUser);
        //    user.ChangedOn = DateTime.Now;
        //    user.ChangedBy = 1;

        //    var result = _userService.Update(user);

        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}

        public JsonResult GetUserById(int userId)
        {
            var user = _userService.GetSingleById(userId);
            return Json(user, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPaggedData(int pageNumber, int pageSize = 20, string sortBy = "")
        {
            IEnumerable<User> listData = _userService.GetAll().OrderBy(x => x.Id);

            switch (sortBy)
            {
                case "Country":
                    listData = listData.OrderBy(x => x.Country);
                    break;
                case "Sigup":
                    listData = listData.OrderByDescending(x => x.SignupDate);
                    break;
                case "Order":
                    listData = listData.OrderByDescending(x => x.OrderCount);
                    break;
                case "None":
                    listData = listData.OrderBy(x => x.Id);
                    break;
            }

            var pagedData = PaginationHelper.PagedResult(listData, pageNumber, pageSize);
            return Json(pagedData, JsonRequestBehavior.AllowGet);
        }
    }
}