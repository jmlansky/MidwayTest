using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Contracts
{
    public interface IAuthService
    {
        public bool ValidateCredentials(string username, string password);
        Task<bool> ValidateCredentialsAsync(string username, string password);

        public string GenerateJwtToken(string username);
        Task<string> GenerateJwtTokenAsync(string username);
    }
}
