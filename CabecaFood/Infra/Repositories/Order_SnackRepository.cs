using Domain.Entities;
using Infra.IRepositories;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class Order_SnackRepository : IOrder_SnackRepository
    {
        private MainContext _context;

        public Order_SnackRepository(MainContext context)
        {
            _context = context;
        }

        public async Task Create(Order_Snack order_Snack)
        {
            await _context.Order_Snack.AddAsync(order_Snack);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
