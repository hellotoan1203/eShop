using eShop.Helper;
using eShop.Model.Models;
using eShop.Service.Services;
using eShop.Web.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace eShop.Web.Areas.Admin.Controllers
{
    public class AdHocAdminController : Controller
    {
        IAdHocService _adHocService;
        User currentUser = UserHelper.GetCurrentUser();

        public AdHocAdminController(IAdHocService adHocService)
        {
            _adHocService = adHocService;
        }
        // GET: Admin/AdHocAdmin
        public ActionResult Index()
        {
            if (currentUser == null || currentUser.Role != 1)
                return RedirectToAction("Unauthorized", "Account");

            return View("~/Areas/Admin/Views/AdHocAdmin/Index.cshtml");
        }

        public JsonResult AdHocQuery(string query)
        {
            var result = _adHocService.AdHocQuery(query);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}