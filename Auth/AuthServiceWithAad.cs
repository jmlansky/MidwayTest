using Auth.Contracts;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Auth
{
    public class AuthServiceWithAad : IAuthService
    {
        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly string _tenantId;
        private readonly string[] _scopes;
        private readonly string _secretKey;
        private readonly string _issuer;
        private readonly string _audience;

        public AuthServiceWithAad(IOptions<AzureAdOptions> azureAdOptions,
            string secretKey, string issuer, string audience)
        {
            _clientId = azureAdOptions.Value.ClientId;
            _clientSecret = azureAdOptions.Value.ClientSecret;
            _tenantId = azureAdOptions.Value.TenantId;
            _scopes = azureAdOptions.Value.Scopes;
            _secretKey = secretKey;
            _issuer = issuer;
            _audience = audience;
        }

        public string GenerateJwtToken(string username)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GenerateJwtTokenAsync(string username)
        {
            var app = ConfidentialClientApplicationBuilder
            .Create(_clientId)
            .WithClientSecret(_clientSecret)
            .WithAuthority(AzureCloudInstance.AzurePublic, _tenantId)
            .Build();

            var result = await app.AcquireTokenForClient(_scopes).ExecuteAsync();
            var token = result.AccessToken;
            return token;

            //var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey.PadRight(32, '0')));
            //var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            //var expires = DateTime.UtcNow.AddMinutes(10);

            //var jwtTokenHandler = new JwtSecurityTokenHandler();
            //var jwtToken = jwtTokenHandler.ReadJwtToken(token);

            //var newJwtToken = new JwtSecurityToken(
            //    issuer: jwtToken.Issuer,
            //    audience: jwtToken.Audiences.FirstOrDefault(),
            //    claims: jwtToken.Claims,
            //    expires: expires,
            //    signingCredentials: credentials
            //);


            //return jwtTokenHandler.WriteToken(newJwtToken);
        }


        public bool ValidateCredentials(string username, string password)
        {
            var authorityUri = $"https://login.microsoftonline.com/{_tenantId}";
            var redirectUri = "http://localhost";
            var confidentialClient = ConfidentialClientApplicationBuilder
                .Create(_clientId)
                .WithClientSecret(_clientSecret)
                .WithAuthority(new Uri(authorityUri))
                .WithRedirectUri(redirectUri)
            .Build();
            var accessTokenRequest = confidentialClient.AcquireTokenForClient(_scopes);

            var result = accessTokenRequest.ExecuteAsync().Result.AccessToken;
            return result != null;
        }

        public Task<bool> ValidateCredentialsAsync(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
