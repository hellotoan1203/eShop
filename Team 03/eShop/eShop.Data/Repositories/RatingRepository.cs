using eShop.Data.Infrastructure;
using eShop.Model.Models;

namespace eShop.Data.Repositories
{
    public interface IRatingRepository : IRepositoryBase<Rating>
    {

    }

    public class RatingRepository : RepositoryBase<Rating>, IRatingRepository
    {
     
    }
}
