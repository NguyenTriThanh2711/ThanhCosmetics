using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanhCometics.Common.Helpers;
using ThanhCometics.Repository.Models.Category;
using ThanhCometics.Repository.ViewModels;

namespace ThanhCometics.Service.Interfaces
{
    public interface ICategoryService
    {
        Task<MethodResult<IEnumerable<CategoryViewModel>>> GetCategoriesAsync();
        Task<MethodResult<CategoryViewModel>> GetCategoryAsync(int categoryId);
        Task<MethodResult<CategoryCountProductModel>> CountProductAsync(int categoryId);
    }
}
