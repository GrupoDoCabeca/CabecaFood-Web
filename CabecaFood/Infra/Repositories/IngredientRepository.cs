using Domain.Entities;
using Infra.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class IngredientRepository : IIngredientRepository
    {

        private MainContext _context;

        public IngredientRepository(MainContext context)
        {
            _context = context;
        }
        public async Task Create(Ingredient entity)
        {
            await _context.Ingredient.AddAsync(entity);
        }

        public async Task Delete(int id)
        {
            var entity = await _context.Ingredient.FindAsync(id);
            entity.DeleteItem();
            _context.Ingredient.Update(entity).State = EntityState.Modified;
        }

        public async Task<IEnumerable<Ingredient>> GetAll()
        {
            return await _context.Ingredient.Where(x => !x.Deleted).ToListAsync();
        }

        public async Task<Ingredient> GetById(int id)
        {
            return await _context.Ingredient.FirstOrDefaultAsync(x => x.Id == id && !x.Deleted);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Update(Ingredient entity)
        {
            _context.Ingredient.Update(entity);
        }
    }
}
