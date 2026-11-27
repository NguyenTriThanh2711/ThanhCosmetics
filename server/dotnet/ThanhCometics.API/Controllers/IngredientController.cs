using Microsoft.AspNetCore.Mvc;
using ThanhCometics.Common.Helpers;
using ThanhCometics.Service.Interfaces;

namespace ThanhCometics.API.Controllers
{
    public class IngredientController : BaseApiController
    {
        private readonly IIngredientService _ingredientService;

        public IngredientController(IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        [HttpGet("get-ingredients")]
        public async Task<IActionResult> GetIngredientAsync()
        {
            var result = await _ingredientService.GetIngredientsAsync();
            return result.Match(
                (l, c) => Problem(detail: l, statusCode: c),
                Ok
            );
        }
    }
}
