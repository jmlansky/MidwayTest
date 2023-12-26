using Auth.Contracts;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Auth
{
    public class AuthService : IAuthService
    {
        private readonly string _secretKey;
        private readonly string _issuer;
        private readonly string _audience;

        public AuthService(string secretKey, string issuer, string audience)
        {
            _secretKey = secretKey;
            _issuer = issuer;
            _audience = audience;
        }


        public bool ValidateCredentials(string username, string password)
        {
            if (username == "admin" && password == "password")
            {
                return true;
            }
            return false;
        }
        
        public Task<bool> ValidateCredentialsAsync(string username, string password)
        {
            throw new NotImplementedException();
        }
        
        public string GenerateJwtToken(string username)
        {
            var claims = new List<Claim>
              {
                  new Claim(ClaimTypes.Name, username)
              };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey.PadRight(32, '0')));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.UtcNow.AddMinutes(10);

            var token = new JwtSecurityToken(
                _issuer,
                _audience,
                claims,
                expires: expires,
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public Task<string> GenerateJwtTokenAsync(string username)
        {
            throw new NotImplementedException();
        }

        
    }
}