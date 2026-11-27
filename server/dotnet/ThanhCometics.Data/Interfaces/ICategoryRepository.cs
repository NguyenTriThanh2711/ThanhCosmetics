using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanhCometics.Repository.Entities;
using ThanhCometics.Repository.Models.Category;
using ThanhCometics.Repository.ViewModels;

namespace ThanhCometics.Repository.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<CategoryViewModel?>> GetCategoriesAsync();
        Task<Category?> GetCategoryAsync(int categoryId);
        Task<CategoryCountProductModel?> CountProductAsync(int categoryId);
    }
}
