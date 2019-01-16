using eShop.Model.Models;
using eShop.Service.Infrastructure;

namespace eShop.Service.Services
{
    public interface IOrderService : IServiceBase<Order>
    {

    }

    public class OrderService : ServiceBase<Order>, IOrderService
    {

    }
}
