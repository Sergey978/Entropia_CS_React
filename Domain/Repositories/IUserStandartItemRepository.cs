using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entropia_CS_React.Domain.Models;
using Entropia_CS_React.Resources;

namespace Entropia_CS_React.Domain.Repositories
{
    public interface IUserStandartItemRepository
    {
        Task<IEnumerable<UserStandartItem>> ListAsync(int userId);
        Task<IEnumerable<SelectUserStandartItemResource>> ListSelectAsync(int userId);
        Task AddAsync(UserStandartItem item);
        Task<UserStandartItem> FindByIdAsync(int id);
        void Update(UserStandartItem item);
        void Remove(UserStandartItem item);
    }
}
