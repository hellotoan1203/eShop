using eShop.Helper;
using eShop.Service.Services;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eShop.Web.Controllers
{
    public class ProductResultController : Controller
    {
        IProductService productService;
        public ProductResultController(IProductService productService)
        {
            this.productService = productService;
        }
        // GET: ProductResult
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetSearchProducts(int? priceMin, int? priceMax, string title, string sortBy, string artist, int? page)
        {
            var modelSearch = productService.SearchProduct(title, sortBy, artist, priceMin, priceMax);
            //var pagedData = PaginationHelper.PagedResult(modelSearch, pageNumber, pageSize);
            int pageSize = 9;
            int pageNumber = (page ?? 1);
            return PartialView("productpatialview", modelSearch.ToList().ToPagedList(pageNumber, pageSize));
        }
    }
}