using System;

namespace OnlineMarketPlace.Data.Models
{
    public class Technician
    {
        public Guid TechnicialId { get; set; }
        public string Name{ get; set; }
        public string Surname{ get; set; }

        // Add more fields to your desire and run migration afterwards
    }
}