using eShop.Data.Infrastructure;
using eShop.Model.Models;

namespace eShop.Data.Repositories
{
    public interface ICartRepository : IRepositoryBase<Cart>
    {

    }

    public class CartRepository : RepositoryBase<Cart>, ICartRepository
    {
       
    }
}
