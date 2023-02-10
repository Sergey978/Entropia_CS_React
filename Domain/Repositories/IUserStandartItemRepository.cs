using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entropia_CS_React.Domain.Models;

namespace Entropia_CS_React.Domain.Repositories
{
    public interface IUserStandartItemRepository
    {
        Task<IEnumerable<UserStandartItem>> ListAsync(int userId);
        Task AddAsync(UserStandartItem item);
        Task<UserStandartItem> FindByIdAsync(int id);
        void Update(UserStandartItem category);
        void Remove(UserStandartItem category);

    }
}