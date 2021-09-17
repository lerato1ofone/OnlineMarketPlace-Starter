using System;

namespace OnlineMarketPlace.Data.DTO
{
    public class UserDto
    {
        public Guid UserId { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
        public String UserRole { get; set; }
        public String Token { get; set; }
    }
}