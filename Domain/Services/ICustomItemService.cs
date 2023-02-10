using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entropia_CS_React.Domain.Models;
using Entropia_CS_React.Domain.Services.Communications.Items;

namespace Entropia_CS_React.Domain.Services
{
    public interface ICustomItemService
    {
        Task<IEnumerable<CustomItem>> ListAsync(int userId);
        Task<CustomItemResponse> SaveAsync(CustomItem item);
        Task<CustomItemResponse> UpdateAsync(int id, CustomItem item);
        Task<CustomItemResponse> DeleteAsync(int id);
    }
}
