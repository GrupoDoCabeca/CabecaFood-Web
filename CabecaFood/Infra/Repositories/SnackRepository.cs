using Domain.Entities;
using Infra.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class SnackRepository : ISnackRepository
    {

        private MainContext _context;

        public SnackRepository(MainContext context)
        {
            _context = context;
        }

        public async Task Create(Snack entity)
        {
            await _context.Snack.AddAsync(entity);
        }

        public async Task Delete(int id)
        {
            var entity = await _context.Snack.FindAsync(id);
            entity.DeleteItem();
            _context.Snack.Update(entity).State = EntityState.Modified;
        }

        public async Task<IEnumerable<Snack>> GetAll()
        {
            return await _context.Snack.Where(x => !x.Deleted).ToListAsync();
        }

        public async Task<Snack> GetById(int id)
        {
            return await _context.Snack.FirstOrDefaultAsync(x => x.Id == id && !x.Deleted);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Update(Snack entity)
        {
            _context.Snack.Update(entity);
        }
    }
}
