using AppService.Core.Interfaces.Services;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AppService.Core.Services
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly IConfiguration _configuration;
        private readonly string _issuer;
        private readonly string _audience;
        private readonly byte[] _key;
        public JwtTokenService(IConfiguration configuration)
        {
            ArgumentNullException.ThrowIfNull(configuration, nameof(configuration));    
            _configuration = configuration;
            _issuer = _configuration["Jwt:Issuer"];
             _audience = _configuration["Jwt:Audience"];
            _key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
        }
        public string GetJwtToken(double expiryminutes,string mobileno)
        {
            
            var claims = new ClaimsIdentity(new[]
            {
                     new Claim(ClaimTypes.NameIdentifier,Guid.NewGuid().ToString()),
                     new Claim("CustomerId",mobileno),
                     new Claim(ClaimTypes.MobilePhone,mobileno)


            });
            //var securityKey = new SymmetricSecurityKey(_key);
            //var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
            // var tokenDescriptor = new JwtSecurityToken(_issuer, _audience, claims,
            //     expires: DateTime.UtcNow.AddMinutes(expiryminutes),
            //     signingCredentials: credentials);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires=DateTime.UtcNow.AddMinutes(expiryminutes),
                Issuer = _issuer,
                Audience = _audience,   
                SigningCredentials = new SigningCredentials
            (new SymmetricSecurityKey(_key),
            SecurityAlgorithms.HmacSha512Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public bool ValidateToken(string token)
        {
            var mySecurityKey= new SymmetricSecurityKey(_key);
            var tokenHandler= new JwtSecurityTokenHandler();

            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = _issuer,
                    ValidAudience = _audience,
                    IssuerSigningKey = mySecurityKey,
                }, out SecurityToken validatedToken);

            }catch
            {
                return false;
            }
            return true;
        }
    }
}
