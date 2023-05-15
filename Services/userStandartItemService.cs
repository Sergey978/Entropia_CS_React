using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entropia_CS_React.Services;
using Entropia_CS_React.Domain.Services;
using Entropia_CS_React.Domain.Models;
using Entropia_CS_React.Domain.Repositories;
using Entropia_CS_React.Resources;
using Entropia_CS_React.Domain.Services.Communications.Items;

namespace Entropia_CS_React.Services
{
    public class UserStandartItemService : IUserStandartItemService
    {
        private readonly IUserStandartItemRepository _userStandartItemRepository;
        private readonly IStandartItemRepo _standartItemRepo;
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

        public async Task<SelectUserStandartItemResponse> SaveAsync(
            UserStandartItem item,
            int accountId
        )
        {
            var existingItem = await _userStandartItemRepository.FindByIdAsync(item.Id);

            if (existingItem != null)
            //if item exist update it
            {
                existingItem.BeginQuantity = item.BeginQuantity;
                existingItem.Markup = item.Markup;
                existingItem.PurchasePrice = item.PurchasePrice;
                existingItem.Selected = item.Selected;
                existingItem.Step = item.Step;

                try
                {
                    await _unitOfWork.CompleteAsync();

                    return new SelectUserStandartItemResponse(existingItem);
                }
                catch (Exception ex)
                {
                    // Do some logging stuff
                    return new SelectUserStandartItemResponse(
                        $"An error occurred when saving the category: {ex.Message}"
                    );
                }
            }
            else
            {
                //create new userStandartItem

                var newStandartUserItem = new UserStandartItem
                {
                    Id = 0,
                    StandartItemId = item.StandartItemId,
                    Selected = true,
                    BeginQuantity = 0,
                    Markup = 0,
                    PurchasePrice = 0,
                    Step = 0,
                    AccountId = accountId
                };
                try
                {
                    await _userStandartItemRepository.AddAsync(newStandartUserItem);
                    await _unitOfWork.CompleteAsync();

                    return new SelectUserStandartItemResponse(newStandartUserItem);
                }
                catch (Exception ex)
                {
                    // Do some logging stuff
                    return new SelectUserStandartItemResponse(
                        $"An error occurred when saving the category: {ex.Message}"
                    );
                }
            }
        }

        public async Task<SelectUserStandartItemResponse> UpdateAsync(
            int id,
            SelectUserStandartItemResource item
        )
        {
            throw new NotImplementedException();
        }

        Task<UserStandartItem> IUserStandartItemService.DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<SelectUserStandartItemResource>> ListSelectAsync(int userId)
        {
            return await _userStandartItemRepository.ListSelectAsync(userId);
        }

        Task<UserStandartItem> IUserStandartItemService.UpdateAsync(int id, UserStandartItem item)
        {
            throw new NotImplementedException();
        }
    }
}
