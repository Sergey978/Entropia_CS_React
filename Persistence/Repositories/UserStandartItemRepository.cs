using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entropia_CS_React.Domain.Models;
using Entropia_CS_React.Domain.Repositories;
using Entropia_CS_React.Persistence.Contexts;
using Entropia_CS_React.Resources;
using Microsoft.EntityFrameworkCore;

namespace Entropia_CS_React.Persistence.Repositories
{
    public class UserStandartItemRepository : BaseRepository, IUserStandartItemRepository
    {
        public UserStandartItemRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<UserStandartItem>> ListAsync(int userId)
        {
            return await _context.UserStandartItems
                .Where(usi => usi.AccountId == userId && usi.Selected == true)
                .Include("StandartItem")
                .ToListAsync();
        }

        public async Task AddAsync(UserStandartItem item)
        {
            await _context.UserStandartItems.AddAsync(item);
        }

        public async Task<UserStandartItem> FindByIdAsync(int id)
        {
            return await _context.UserStandartItems.FindAsync(id);
        }

        public async Task<UserStandartItem> FindByStandartItemIdAsync(int standartItemId)
        {
            return await _context.UserStandartItems
                .Where(usi => usi.StandartItemId == standartItemId)
                .FirstOrDefaultAsync();
        }

        public void Remove(UserStandartItem category)
        {
            throw new NotImplementedException();
        }

        public void Update(UserStandartItem category)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<SelectUserStandartItemResource>> ListSelectAsync(int userId)
        {
            return await _context.StandartItems
                .GroupJoin(
                    _context.UserStandartItems.Where(usi => usi.AccountId == userId),
                    si => si.Id,
                    usi => usi.StandartItemId,
                    (si, usi) => new { si, usi }
                )
                .SelectMany(
                    x => x.usi.DefaultIfEmpty(),
                    (si, usi) =>
                        new SelectUserStandartItemResource
                        {
                            Id = usi.Id,
                            StandartItemId = si.si.Id,
                            Name = si.si.Name,
                            Price = si.si.Price,
                            Selected = usi.Selected
                        }
                )
                .ToListAsync();
        }
    }
}
