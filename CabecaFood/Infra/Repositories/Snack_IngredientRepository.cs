using Domain.Entities;
using Infra.IRepositories;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class Snack_IngredientRepository : ISnack_IngredientRepository
    {

        private MainContext _context;

        public Snack_IngredientRepository(MainContext context)
        {
            _context = context;
        }
        public async Task Create(Snack_Ingredient snack_Ingredient)
        {
            await _context.Snack_Ingredient.AddAsync(snack_Ingredient);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
