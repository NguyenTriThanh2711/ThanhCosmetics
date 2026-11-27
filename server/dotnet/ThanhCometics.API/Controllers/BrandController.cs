using Microsoft.AspNetCore.Mvc;
using ThanhCometics.Service.Interfaces;

namespace ThanhCometics.API.Controllers
{
    public class BrandController : BaseApiController
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet("get-brands")]
        public async Task<IActionResult> GetBrands()
        {
            var result = await _brandService.GetBrandsAsync();
            return result.Match(
                (l, c) => Problem(detail: l, statusCode: c),
                Ok
            );
        }
    }
}
