﻿using CrossCuttingServices;
using Domain.DbContext;
using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AccessControl
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly AcademateDbContext _dbContext;
        private readonly AppSettings _appSettings;

        public AuthenticationService(IOptions<AppSettings> appSettings, IDbProvider dbProvider)
        {
            _dbContext = dbProvider.Context;
            _appSettings = appSettings.Value;
        }

        public async Task<User> Authenticate(string userName, string password)
        {
            var user = await _dbContext.Users
                .AsNoTracking()
                .SingleOrDefaultAsync(u => u.UserName == userName && u.Password == password);
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
                Subject = new ClaimsIdentity(new[]
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
