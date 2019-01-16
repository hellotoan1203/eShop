using eShop.Model.Models;
using eShop.Service.Infrastructure;

namespace eShop.Service.Services
{
    public interface ICartService : IServiceBase<Cart>
    {

    }

    public class CartService : ServiceBase<Cart>, ICartService
    {

    }
}
