using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entropia_CS_React.Domain.Models;
using Entropia_CS_React.Domain.Services.Communications;

namespace Entropia_CS_React.Domain.Repositories
{
    public interface ICustomItemRepo
    {
        Task<IEnumerable<CustomItem>> ListAsync(int userId);
        Task AddAsync(CustomItem item);
        Task<CustomItem> FindByIdAsync(int id);
        Task<CustomItem> FindByIdandUserIdAsync(int itemId, int userId);

        void UpdateAsync(CustomItem item);

        void Remove(CustomItem item);
    }
}
