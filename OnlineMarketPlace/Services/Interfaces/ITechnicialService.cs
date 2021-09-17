using OnlineMarketPlace.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineMarketPlace.Services.Interfaces
{
    public interface ITechnicialService
    {
        Task<IEnumerable<Technician>> GetTechnicians();
    }
}