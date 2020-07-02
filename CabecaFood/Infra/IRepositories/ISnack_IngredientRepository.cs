using Domain.Entities;
using System.Threading.Tasks;

namespace Infra.IRepositories
{
    public interface ISnack_IngredientRepository
    {
        Task Create(Snack_Ingredient snack_Ingredient);
        Task Save();

    }
}
