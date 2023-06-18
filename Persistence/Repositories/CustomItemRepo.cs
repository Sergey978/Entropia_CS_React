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
    public class CustomItemRepo : BaseRepository, ICustomItemRepo
    {
        public CustomItemRepo(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<CustomItem>> ListAsync(int userId)
        {
            return await _context.CustomItems.Where(i => i.AccountId == userId).ToListAsync();
        }

        public async Task AddAsync(CustomItem item)
        {
            await _context.CustomItems.AddAsync(item);
        }

        public async Task<CustomItem> FindByIdAsync(int id)
        {
            return await _context.CustomItems.FindAsync(id);
        }

        public async Task<CustomItem> FindByIdandUserIdAsync(int itemId, int userId)
        {
            return await _context.CustomItems
                .Where(i => i.Id == itemId && i.AccountId == userId)
                .FirstOrDefaultAsync<CustomItem>();
        }

        public void Remove(CustomItem item)
        {
            _context.CustomItems.Remove(item);
        }

        public void UpdateAsync(CustomItem item)
        {
            _context.CustomItems.Update(item);
        }
    }
}
