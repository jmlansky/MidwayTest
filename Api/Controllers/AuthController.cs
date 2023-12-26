using Api.Requests;
using Auth.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult LoginAsync([FromBody] LoginRequest request)
        {
            var isValid = _authService.ValidateCredentials(request.Username, request.Password);

            if (!isValid)
            {
                return Unauthorized();  
            }

            //var token = await _authService.GenerateJwtTokenAsync(request.Username);
            var token = _authService.GenerateJwtToken(request.Username);

            return Ok(new { token });
        }
    }
}
