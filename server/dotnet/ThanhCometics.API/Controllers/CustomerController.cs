using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ThanhCometics.Common.Helpers;
using ThanhCometics.Repository.Models.CustomerModel;
using ThanhCometics.Service.Interfaces;

namespace ThanhCometics.API.Controllers
{
    public class CustomerController : BaseApiController
    {
        private readonly ICustomerService _customerService;
        private readonly IAuthenticationService _authenticationService;
        public CustomerController(ICustomerService customerService, IAuthenticationService authenticationService)
        {
            _customerService = customerService;
            _authenticationService = authenticationService;
        }

        [HttpPatch("update-profile")]
        [Authorize]
        public async Task<IActionResult> UpdateProfile([FromForm] ProfileUpdateRequest request)
        {
            var userEmail = User.Claims.FirstOrDefault(x=> x.Type == ClaimTypes.Email)?.Value;
            var result = await _customerService.RequestUpdateProfileAsync(userEmail, request);
            return result.Match(
                    (l, c) => Problem(detail: l, statusCode: c),
                    Ok
                );

        }

        [HttpPatch("change-password")]
        [Authorize]
        public async Task<IActionResult> UpdatePassword([FromBody] PasswordUpdateRequest request)
        {
            return Ok("Hello from UpdatePassword!");
        }

        [HttpPut("change-email")]
        [Authorize]
        public async Task<IActionResult> UpdateEmail(string newEmail)
        {
            return Ok("Hello from UpdatePassword!");
        }

        [HttpGet("verify-updated-email")]
        public async Task<IActionResult> VerifyUpdatedEmail(string token)
        {
            return Ok("Hello from UpdatePassword!");
        }

        [HttpPatch("update-avatar")]
        public async Task<IActionResult> UpdateAvatar(string image)
        {
            return Ok("Hello from UpdatePassword!");
        }

        [HttpGet("get-number-customer")]
        public async Task<IActionResult> GetNumberCustomer()
        {
            return Ok("Hello from UpdatePassword!");
        }

        [HttpGet("customers")]
        [Authorize(Roles = Constants.USER_ROLE_MANAGER)]
        public async Task<IActionResult> GetCustomers()
        {
            return Ok("Hello from UpdatePassword!");
        }

        [HttpPatch("active-customer")]
        [Authorize(Roles = Constants.USER_ROLE_MANAGER)]
        public async Task<IActionResult> ActiveCustomer(int userId)
        {
            return Ok("Hello from UpdatePassword!");
        }

        [HttpPatch("deactive-customer")]
        [Authorize(Roles = Constants.USER_ROLE_MANAGER)]
        public async Task<IActionResult> DeactiveCustomer(int userId)
        {
            return Ok("Hello from UpdatePassword!");
        }
    }
}
