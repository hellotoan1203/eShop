using eShop.Model.Models;
using eShop.Service.Infrastructure;

namespace eShop.Service.Services
{
    public interface IOrderDetailService : IServiceBase<OrderDetail>
    {

    }

    public class OrderDetailService : ServiceBase<OrderDetail>, IOrderDetailService
    {

    }
}
