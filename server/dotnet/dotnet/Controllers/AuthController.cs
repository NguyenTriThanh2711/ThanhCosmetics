using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ThanhCometics.Common.Helpers;
using ThanhCometics.Repository.Models.AuthenticationModel;
using ThanhCometics.Service.Interfaces;

namespace ThanhCometics.API.Controllers
{
    public class AuthController : BaseApiController
    {
        private readonly ICustomerService _customerService;
        private readonly IAuthenticationService _authenticationService;

        public AuthController(ICustomerService customerService, IAuthenticationService authenticationService)
        {
            _customerService = customerService;
            _authenticationService = authenticationService;
        }
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody]SignupRequest request)
        {
            var result = await _customerService.SignupAsync(request);
            return result.Match(
                (errorMessage, statusCode) => Problem(detail: errorMessage, statusCode: statusCode),
                Ok
            );
        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var result = await _authenticationService.SigninAsync(request);
            return result.Match(
                (errorMessage, statusCode) => Problem(detail: errorMessage, statusCode: statusCode),
                Ok
            );
        }

        [HttpPost]
        [Route("forgot-password")]
        // hàm này gọi trước sau đó sẽ gọi đến verify change password
        public async Task<IActionResult> ForgotPassword([FromQuery] string email)
        {
            var result = await _customerService.RequestPasswordResetAsync(email);
            return result.Match(
                (errorMessage, statusCode) => Problem(detail: errorMessage, statusCode: statusCode),
                Ok
            );
        }

        [HttpGet]
        [Route("profile")]
        [Authorize(Roles = Constants.USER_ROLE_CUSTOMER)]
        public async Task<IActionResult> GetProfile()
        {
            //get profile by claims
            var email = User.FindFirstValue(ClaimTypes.Email);
            if (email== null) return Unauthorized();

            var result = await _customerService.GetProfileAsync(email);
            return result.Match(
                (errorMessage, statusCode) => Problem(detail: errorMessage, statusCode: statusCode),
                Ok
            );
        }
    }
}
