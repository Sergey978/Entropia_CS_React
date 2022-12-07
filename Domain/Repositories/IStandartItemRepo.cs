using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entropia_CS_React.Domain.Models;

namespace Entropia_CS_React.Domain.Repositories
{
    public interface IStandartItemRepo
    {
        Task<IEnumerable<StandartItem>> ListAsync();

        Task AddAsync(StandartItem item);

        Task<StandartItem> FindByIdAsync(int id);

        Task<StandartItem> UpdateAsync(StandartItem item);

        void Update(StandartItem product);

        void Remove(StandartItem product);
    }
}
