using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entropia_CS_React.Services;
using Entropia_CS_React.Domain.Services;
using Entropia_CS_React.Domain.Models;
using Entropia_CS_React.Domain.Repositories;

namespace Entropia_CS_React.Services
{
    public class UserStandartItemService : IUserStandartItemService
    {
        private readonly IUserStandartItemRepository _userStandartItemRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserStandartItemService(
            IUserStandartItemRepository userStandartItemRepository,
            IUnitOfWork unitOfWork
        )
        {
            this._userStandartItemRepository = userStandartItemRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<UserStandartItem>> ListAsync(int userId)
        {
            return await _userStandartItemRepository.ListAsync(userId);
        }

        Task<UserStandartItem> IUserStandartItemService.SaveAsync(UserStandartItem item)
        {
            throw new NotImplementedException();
        }

        Task<UserStandartItem> IUserStandartItemService.UpdateAsync(int id, UserStandartItem item)
        {
            throw new NotImplementedException();
        }

        Task<UserStandartItem> IUserStandartItemService.DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
