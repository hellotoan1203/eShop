using eShop.Helper;
using eShop.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eShop.Web.Controllers
{
    public class ProductController : Controller
    {
        IProductService productService;
        IArtistService artistService;

        public ProductController(IProductService productService, IArtistService artistService)
        {
            this.productService = productService;
            this.artistService = artistService;
        }

        public ActionResult Index()
        {
            ViewBag.BindArtist = artistService.GetAll().Select(a => a.Name);
            var product = productService.GetAll();
            return View(product);
        }
        public ActionResult AutocompleteProduct (string autoProduct)
        {
            var result = productService.GetMulti(x => x.Title.Contains(autoProduct)).Select(x=>x.Title);
            return new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public ActionResult SearchProduct(string title, string sortBy, string artist, int pageNumber, int pageSize, int? priceMin, int? priceMax)
        {
            var result = productService.SearchProduct(title, sortBy, artist, priceMin, priceMax);
            var pagedData = PaginationHelper.PagedResult(result, pageNumber, pageSize);
            return View(pagedData);
        }

    }
}