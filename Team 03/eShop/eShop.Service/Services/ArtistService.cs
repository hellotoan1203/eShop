using eShop.Model.Models;
using eShop.Service.Infrastructure;
using System.Collections.Generic;

namespace eShop.Service.Services
{
    public interface IArtistService : IServiceBase<Artist>
    {

    }

    public class ArtistService : ServiceBase<Artist>, IArtistService
    {
        public IEnumerable<Artist> GetArtist()
        {
            return GetAll();
        }
    }
}
