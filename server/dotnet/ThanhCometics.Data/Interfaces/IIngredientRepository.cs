using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanhCometics.Repository.ViewModels;

namespace ThanhCometics.Repository.Interfaces
{
    public interface IIngredientRepository
    {
        Task<IEnumerable<IngredientViewModel?>> GetIngredientsAsync();
    }
}
