using eShop.Data.Repositories;
using eShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Service.Services
{
    public interface IAdHocService : IAdHocRepository
    {

    }

    public class AdHocService : IAdHocService
    {
        IAdHocRepository _dHocRepository;
        public AdHocService()
        {
            _dHocRepository = new AdHocRepository();
        }

        public AdHocResult AdHocQuery(string query)
        {
            return _dHocRepository.AdHocQuery(query);
        }
    }
}
