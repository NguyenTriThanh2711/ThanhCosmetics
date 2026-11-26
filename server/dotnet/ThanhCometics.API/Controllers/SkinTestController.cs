using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ThanhCometics.Repository.Models.SkinTestModel;
using ThanhCometics.Service.Interfaces;

namespace ThanhCometics.API.Controllers
{
    public class SkinTestController : BaseApiController
    {
        private readonly ISkinTestService _skinTestService;
        public SkinTestController(ISkinTestService skinTestService)
        {
            _skinTestService = skinTestService;
        }

        [HttpGet("get-active-skin-test")]
        public async Task<IActionResult> GetActiveSkinTest()
        {
            var result = await _skinTestService.GetActiveSkinTestAsync();
            return result.Match(
                (l, c) => Problem(detail: l, statusCode: c),
                Ok
            );
        }

        [HttpPost("determine-skin-type")]
        public async Task<IActionResult> DetermineSkinType([FromBody] ListUserAnswerModel request)
        {
            var userId = Int32.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid).Value);
            var result = await _skinTestService.DetermineSkinTypeAsync(userId, request);
            return result.Match(
                (l,c) => Problem(detail : l, statusCode : c),
                Ok
            );
        }
    }
}
