using eShop.Data.Infrastructure;
using eShop.Model.Models;

namespace eShop.Data.Repositories
{
    public interface IArtistRepository : IRepositoryBase<Artist>
    {

    }

    public class ArtistRepository : RepositoryBase<Artist>, IArtistRepository
    {
        
    }
}
