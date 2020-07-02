using Domain.Entities;
using Infra.IRepositories.IGenericRepository;

namespace Infra.IRepositories
{
    public interface IIngredientRepository : IGenericRepository<Ingredient>
    {
    }
}
