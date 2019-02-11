using CrossCuttingServices;
using Domain.DbContext;
using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Application.Services.AccessControl
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly AcademateDbContext _dbContext;
        private readonly AppSettings _appSettings;

        private IList<User> _users = new List<User>
        {
            new User { Id = 1, FirstName = "Test", LastName = "User", UserName = "admin", Password = "admin", Email = "admin@gmail.com"}
        };

        public AuthenticationService(IOptions<AppSettings> appSettings, IDbProvider dbProvider)
        {
            _dbContext = dbProvider.Context;
            _appSettings = appSettings.Value;
        }

        public User Authenticate(string userName, string password)
        {
            var user = _dbContext.Users
                .AsNoTracking()
                .SingleOrDefault(u => u.UserName == userName && u.Password == password);
            if (user == null)
                return null;

            user.Token = GenerateTokenForTheUser(user);
            user.Password = null;

            return user;
        }

        private string GenerateTokenForTheUser(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(CustomClaimTypes.UserName, user.UserName),
                    new Claim(CustomClaimTypes.FirstName, user.FirstName),
                    new Claim(CustomClaimTypes.Email, user.Email)
                }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(securityToken);

            return token;
        }
    }
}
