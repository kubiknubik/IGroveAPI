using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Utils.WebAPI.Security
{
    public class JWTHandler : IJWTHandler
    {
        private readonly JWTSettings _settings;
        private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler;
        private readonly SecurityKey _issuerSigningKey;
        private readonly SigningCredentials _signingCredentials;

        public JWTHandler(IOptions<JWTSettings> settings)
        {
            _settings = settings.Value;

            _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            _issuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.HmacSecretKey));
            _signingCredentials = new SigningCredentials(_issuerSigningKey, SecurityAlgorithms.HmacSha256Signature);
        }

        public string Create(params Claim[] claims)
        {
            var claimsList = claims.ToList();

            return Create(claimsList);
        }

        public string Create(List<Claim> claims)
        {
            claims.Add(new Claim(JwtRegisteredClaimNames.Iss, _settings.Issuer));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = _signingCredentials
            };
            var token = _jwtSecurityTokenHandler.CreateToken(tokenDescriptor);

            return _jwtSecurityTokenHandler.WriteToken(token);
        }
    }
}