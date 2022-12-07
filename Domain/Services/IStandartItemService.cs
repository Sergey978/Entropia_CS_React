using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entropia_CS_React.Domain.Models;
using Entropia_CS_React.Domain.Services.Communications.Items;

namespace Entropia_CS_React.Domain.Services
{
    public interface IStandartItemService
    {
        Task<IEnumerable<StandartItem>> ListAsync();

        Task<StandartItemResponse> SaveAsync(StandartItem item);

        Task<StandartItemResponse> UpdateAsync(int id, StandartItem item);

        Task<StandartItemResponse> DeleteAsync(int id);
    }
}
