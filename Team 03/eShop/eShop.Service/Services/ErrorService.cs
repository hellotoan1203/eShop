using eShop.Model.Models;
using eShop.Service.Infrastructure;

namespace eShop.Service.Services
{
    public interface IErrorService : IServiceBase<Error>
    {

    }

    public class ErrorService : ServiceBase<Error>, IErrorService
    {

    }
}
