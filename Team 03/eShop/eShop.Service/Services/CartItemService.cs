using eShop.Model.Models;
using eShop.Service.Infrastructure;

namespace eShop.Service.Services
{
    public interface ICartItemService : IServiceBase<CartItem>
    {

    }

    public class CartItemService : ServiceBase<CartItem>, ICartItemService
    {

    }
}
