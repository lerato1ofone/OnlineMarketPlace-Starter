using OnlineMarketPlace.Data.Models;
using OnlineMarketPlace.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMarketPlace.Services
{
    public class TechnicialService : ITechnicialService
    {
        public Task<IEnumerable<Technician>> GetTechnicians()
        {
            throw new NotImplementedException();
        }
    }
}
