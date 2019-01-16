using System.Data.Entity;
using System.Linq;
using eShop.Data.Infrastructure;
using eShop.Model.Models;

namespace eShop.Data.Repositories
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        
    }

    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        
    }
}
