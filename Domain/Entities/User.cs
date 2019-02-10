using System;

namespace Domain.Entities
{
    public class User : ICloneable
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public string Email { get; set; }
        public object Clone()
        {
            return new User
            {
                Id = Id,
                FirstName = FirstName,
                LastName = LastName,
                UserName = UserName,
                Password = Password,
                Email = Email
            };

        }
    }
}
