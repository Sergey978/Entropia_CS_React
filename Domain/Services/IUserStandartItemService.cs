using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entropia_CS_React.Domain.Models;

namespace Entropia_CS_React.Domain.Services
{
    public interface IUserStandartItemService
    {
        Task<IEnumerable<UserStandartItem>> ListAsync(int userId);

        Task<UserStandartItem> SaveAsync(UserStandartItem item);

        Task<UserStandartItem> UpdateAsync(int id, UserStandartItem item);

        Task<UserStandartItem> DeleteAsync(int id);
    }
}
