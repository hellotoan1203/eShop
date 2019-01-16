using eShop.Data.Infrastructure;
using eShop.Model.Models;

namespace eShop.Data.Repositories
{
    public interface ICartItemRepository : IRepositoryBase<CartItem>
    {

    }


    public class CartItemRepository : RepositoryBase<CartItem>, ICartItemRepository
    {
        
    }
}
