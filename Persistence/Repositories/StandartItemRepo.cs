using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entropia_CS_React.Persistence.Contexts;
using Entropia_CS_React.Domain.Repositories;
using Entropia_CS_React.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Entropia_CS_React.Persistence.Repositories
{
    public class StandartItemRepo : BaseRepository, IStandartItemRepo
    {
        public StandartItemRepo(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<StandartItem>> ListAsync()
        {
            return await _context.StandartItems.ToListAsync();
        }

        public async Task AddAsync(StandartItem item)
        {
            await _context.StandartItems.AddAsync(item);
        }

        public async Task<StandartItem> FindByIdAsync(int id)
        {
            return await _context.StandartItems.FindAsync(id);
        }

        public void Remove(StandartItem item)
        {
            _context.StandartItems.Remove(item);
        }

        public void Update(StandartItem product)
        {
            throw new NotImplementedException();
        }

        public Task<StandartItem> UpdateAsync(StandartItem item)
        {
            throw new NotImplementedException();
        }
    }
}
