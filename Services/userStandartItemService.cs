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
            var existingItem = await _userStandartItemRepository.FindByItemIdandUserIdAsync(
                item.Id,
                accountId
            );

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
                    BeginQuantity = 100,
                    Quantity = 500,
                    Markup = 1,
                    PurchasePrice = 103,
                    Step = 1,
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
            UserStandartItem item,
            int userId
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

        public async Task<SelectUserStandartItemResponse> ToggleHide(
            UserStandartItem item,
            int accountId
        )
        {
            var existingItem = await _userStandartItemRepository.FindByItemIdandUserIdAsync(
                item.StandartItemId,
                accountId
            );

            if (existingItem != null)
            //if item exist update it
            {
                existingItem.Selected = item.Selected;

                try
                {
                    await _unitOfWork.CompleteAsync();
                    return new SelectUserStandartItemResponse(existingItem);
                }
                catch (Exception ex)
                {
                    // Do some logging stuff
                    return new SelectUserStandartItemResponse(
                        $"An error occurred when saving the item: {ex.Message}"
                    );
                }
            }
            else
            //create userstandartitem
            {
                return await SaveAsync(item, accountId);
            }
        }
    }
}
