using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ThanhCometics.Service.Interfaces;

namespace ThanhCometics.API.Controllers
{
    public class CategoryController : BaseApiController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("get-categories")]
        public async Task<IActionResult> GetCategories()
        {
            var result = await _categoryService.GetCategoriesAsync();
            return result.Match(
                (l, c) => Problem(detail: l, statusCode: c),
                Ok
            );
        }
        [HttpGet("get-category-by-id")]
        public async Task<IActionResult> GetCategory(int categoryId)
        {
            var result = await _categoryService.GetCategoryAsync(categoryId);
            return result.Match(
                (l, c) => Problem(detail: l, statusCode: c),
                Ok
            );
        }

        [HttpGet("get-number-product-by-category-id")]
        public async Task<IActionResult> CountProduct(int categoryId)
        {
            var result = await _categoryService.CountProductAsync(categoryId);
            return result.Match(
                (l, c) => Problem(detail: l, statusCode: c),
                Ok
            );
        }
    }
}
