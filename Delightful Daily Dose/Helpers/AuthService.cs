﻿using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CryptoHelper;
using Delightful_Daily_Dose.Models.Entities;
using Microsoft.IdentityModel.Tokens;

namespace Delightful_Daily_Dose.Helpers
{
    public class AuthService : IAuthService
    {
        private readonly string _jwtSecret;
        public AuthService(string jwtSecret)
        {
            this._jwtSecret = jwtSecret;
        }
        public virtual AuthData GetAuthData(string name, string role)
        {
            var expirationTime = DateTime.UtcNow.AddSeconds(2592000);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, name),
                    new Claim(ClaimTypes.Role, role)
                }),
                Expires = expirationTime,
                // new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256Signature)
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSecret)),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));

            return new AuthData
            {
                Token = token,
                TokenExpirationTime = ((DateTimeOffset)expirationTime).ToUnixTimeSeconds(),
                Id = name
            };
        }

        public virtual string HashPassword(string password)
        {
            return Crypto.HashPassword(password);
        }

        public virtual bool VerifyPassword(string actualPassword, string hashedPassword)
        {
            return Crypto.VerifyHashedPassword(hashedPassword, actualPassword);
        }
    }
}
