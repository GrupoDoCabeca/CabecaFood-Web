using Domain.Entities;
using Infra.IRepositories.IGenericRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infra.IRepositories
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<ICollection<Order>> GetByRestaurantId(int restaurantId);
    }
}
