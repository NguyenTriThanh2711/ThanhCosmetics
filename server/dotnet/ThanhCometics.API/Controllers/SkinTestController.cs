using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}
