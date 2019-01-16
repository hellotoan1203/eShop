using eShop.Helper;
using eShop.Model.Models;
using eShop.Service.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Service.Services
{
    public interface IProductService : IServiceBase<Product>
    {
        IEnumerable<Product> SearchProduct(string title, string SortBy, string artist, int? priceMin, int? priceMax);
    }

    public class ProductService : ServiceBase<Product>, IProductService
    {
        private readonly ArtistService _ArtistService = new ArtistService();
        public IEnumerable<Product> GetProduct()
        {
            return GetAll();
        }
        public IEnumerable<Product> SearchProduct(string title, string sortBy, string artist, int? priceMin, int? priceMax)
        {
            var ListProduct = GetAll();
            if (!string.IsNullOrEmpty(title))
            {
                ListProduct = GetMulti(x => x.Title.Contains(title));
            }

            if (string.IsNullOrEmpty(sortBy))
            {
                ListProduct = ListProduct.OrderBy(x => x.Id);
            }
            switch (sortBy)
            {
                case "populariry":
                    ListProduct = ListProduct.OrderBy(p => p.QuantitySold);
                    break;

                case "rating":
                    ListProduct = ListProduct.OrderBy(p => p.AvgStars);
                    break;

                case "price":
                    ListProduct = ListProduct.OrderBy(p => p.Price);
                    break;

                default:
                    ListProduct = ListProduct.OrderBy(p => p.Id);
                    break;
            }
            if (priceMin != null && priceMax != null && priceMax >= priceMin)
            {
                ListProduct = ListProduct.Where(p => p.Price >= priceMin && p.Price <= priceMax);
            }
            if (!string.IsNullOrEmpty(artist))
            {
                string[] arrArtist = artist.Split(',');

                var aaa = _ArtistService.GetArtist();
                aaa = aaa.Where(x => arrArtist.ToList().Contains(x.Name));
                var ccc = aaa.Select(x => x.Id).ToList();
                var bbb = ListProduct.Where(x => ccc.Contains(x.ArtistId));

                ListProduct = from l in ListProduct
                              join a in _ArtistService.GetArtist() on l.ArtistId equals a.Id
                              where arrArtist.Contains(a.Name)
                              select l;
            }
            var list = ListProduct.ToList();
            //var pagedData = PaginationHelper.PagedResult(ListProduct, pageNumber, pageSize);
            return list;
            //return Json(pagedData, JsonRequestBehavior.AllowGet);
        }
    }
}
