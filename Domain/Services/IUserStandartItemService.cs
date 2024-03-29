using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entropia_CS_React.Domain.Models;
using Entropia_CS_React.Domain.Services.Communications.Items;
using Entropia_CS_React.Resources;

namespace Entropia_CS_React.Domain.Services
{
    public interface IUserStandartItemService
    {
        Task<IEnumerable<UserStandartItem>> ListAsync(int userId);
        Task<IEnumerable<SelectUserStandartItemResource>> ListSelectAsync(int userId);

        Task<SelectUserStandartItemResponse> SaveAsync(UserStandartItem item, int accountId);

        Task<SelectUserStandartItemResponse> ToggleHide(UserStandartItem item, int accountId);
        Task<SelectUserStandartItemResponse> UpdateAsync(UserStandartItem item, int id);

        Task<UserStandartItem> DeleteAsync(int id);
    }
}
