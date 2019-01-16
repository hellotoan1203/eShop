using eShop.Data.Infrastructure;
using eShop.Model.Models;

namespace eShop.Data.Repositories
{
    public interface IOrderNumberRepository : IRepositoryBase<OrderNumber>
    {

    }

    public class OrderNumberRepository : RepositoryBase<OrderNumber>, IOrderNumberRepository
    {

    }
}
