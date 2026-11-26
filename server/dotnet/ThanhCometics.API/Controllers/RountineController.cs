using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThanhCometics.Service.Interfaces;

namespace ThanhCometics.API.Controllers
{
    public class RountineController : BaseApiController
    {
        private readonly IRoutineService _routineService;
        public RountineController(IRoutineService routineService)
        {
            _routineService = routineService;
        }

        [HttpGet("get-routine-by-skin-type-id")]
        public async Task<IActionResult> GetRoutine(int skinTypeId)
        {
            var result = await _routineService.GetRoutineAsync(skinTypeId);
            return result.Match(
                (l, c) => Problem(detail: l, statusCode: c),
                Ok
            );
        }
    }
}
