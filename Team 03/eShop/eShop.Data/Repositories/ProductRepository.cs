using eShop.Data.Infrastructure;
using eShop.Model.Models;

namespace eShop.Data.Repositories
{
    public interface IProductRepository : IRepositoryBase<Product>
    {

    }

    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
      
    }
}
