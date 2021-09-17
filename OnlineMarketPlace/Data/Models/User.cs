using OnlineMarketPlace.Data.Enums;
using System;

namespace OnlineMarketPlace.Models
{
    public class User
    {
        public Guid UserId { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public UserRole UserRole { get; set; }
    }
}