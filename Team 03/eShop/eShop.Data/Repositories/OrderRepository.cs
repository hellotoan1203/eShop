using eShop.Data.Infrastructure;
using eShop.Model.Models;

namespace eShop.Data.Repositories
{
    public interface IOrderRepository : IRepositoryBase<Order>
    {

    }

    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
       
    }
}
