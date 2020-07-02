﻿using Domain.Entities;
using Infra.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class OrderRepository : IOrderRepository
    {

        private MainContext _context;

        public OrderRepository(MainContext context)
        {
            _context = context;
        }

        public async Task Create(Order entity)
        {
            await _context.Order.AddAsync(entity);
        }

        public async Task Delete(int id)
        {
            var entity = await _context.Order.FindAsync(id);
            entity.DeleteItem();
            _context.Order.Update(entity).State = EntityState.Modified;
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            return await _context.Order.Where(x => !x.Deleted).ToListAsync();
        }

        public async Task<Order> GetById(int id)
        {
            return await _context.Order.FirstOrDefaultAsync(x => x.Id == id && !x.Deleted);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Update(Order entity)
        {
            _context.Order.Update(entity);
        }
    }
}
