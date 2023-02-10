using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entropia_CS_React.Domain.Models;
using Entropia_CS_React.Domain.Repositories;
using Entropia_CS_React.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Entropia_CS_React.Persistence.Repositories
{
    public class UserStandartItemRepository : BaseRepository, IUserStandartItemRepository
    {
        public UserStandartItemRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<UserStandartItem>> ListAsync(int userId)
        {
            // return await _context.Products.Include(p => p.Category)
            //                               .ToListAsync();

            // return await _context.UserStandartItems.


            return await _context.UserStandartItems.Include(i => i.UserId).ToListAsync();
        }

        public Task AddAsync(UserStandartItem item)
        {
            throw new NotImplementedException();
        }

        public Task<UserStandartItem> FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(UserStandartItem category)
        {
            throw new NotImplementedException();
        }

        public void Update(UserStandartItem category)
        {
            throw new NotImplementedException();
        }
    }
}
