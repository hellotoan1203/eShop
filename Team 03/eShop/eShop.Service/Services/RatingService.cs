using eShop.Model.Models;
using eShop.Service.Infrastructure;

namespace eShop.Service.Services
{
    public interface IRatingService : IServiceBase<Rating>
    {

    }

    public class RatingService : ServiceBase<Rating>, IRatingService
    {

    }
}
