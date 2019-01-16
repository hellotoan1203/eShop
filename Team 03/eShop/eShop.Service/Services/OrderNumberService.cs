using eShop.Model.Models;
using eShop.Service.Infrastructure;

namespace eShop.Service.Services
{
    public interface IOrderNumberService : IServiceBase<OrderNumber>
    {

    }

    public class OrderNumberService : ServiceBase<OrderNumber>, IOrderNumberService
    {

    }
}
