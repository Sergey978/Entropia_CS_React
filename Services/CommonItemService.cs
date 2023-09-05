using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entropia_CS_React.Domain.Repositories;
using Entropia_CS_React.Domain.Services;
using Entropia_CS_React.Domain.Services.Communications.Items;
using Entropia_CS_React.Resources;

namespace Entropia_CS_React.Services
{
    public class CommonItemService : ICommonItemService
    {
        private readonly ICustomItemRepo _customItemRepo;
        private readonly IUserStandartItemRepository _standartItemRepo;
        private readonly IUnitOfWork _unitOfWork;

        public CommonItemService(
            ICustomItemRepo customItemRepo,
            IUserStandartItemRepository standartItemRepository,
            IUnitOfWork unitOfWork
        )
        {
            _customItemRepo = customItemRepo;
            _standartItemRepo = standartItemRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<UserCommonItemModifyResponse> UpdateAsync(
            UserCommonItemResource item,
            int accountId
        )
        {
            UserCommonItemResource _returnedCommonItemResource = new UserCommonItemResource
            {
                Id = 0,
                Name = "",
                BeginQuantity = 1,
                Markup = 1,
                PurchasePrice = 101,
                Quantity = 500,
                Step = 1
            };
            // find by userId and itemId custom item
            var existingCustomItem = await _customItemRepo.FindByIdandUserIdAsync(
                item.Id,
                accountId
            );

            // find by userId and itemId standart item
            var existingUserStandartItem = await _standartItemRepo.FindByItemIdandUserIdAsync(
                item.Id,
                accountId
            );
            // check standart or customitem was found
            if (existingCustomItem != null)
            {
                existingCustomItem.Quantity = item.Quantity;
                existingCustomItem.BeginQuantity = item.BeginQuantity;
                existingCustomItem.Markup = item.Markup;
                existingCustomItem.PurchasePrice = item.PurchasePrice;
                existingCustomItem.Step = item.Step;
                // make returned resource
                _returnedCommonItemResource.Id = existingCustomItem.Id;
                _returnedCommonItemResource.Name = existingCustomItem.Name;
                _returnedCommonItemResource.BeginQuantity = existingCustomItem.BeginQuantity;
                _returnedCommonItemResource.Markup = existingCustomItem.Markup;
                _returnedCommonItemResource.PurchasePrice = existingCustomItem.PurchasePrice;
                _returnedCommonItemResource.Quantity = existingCustomItem.Quantity;
                _returnedCommonItemResource.Step = existingCustomItem.Step;
            }
            else if (existingUserStandartItem != null)
            {
                existingUserStandartItem.Quantity = item.Quantity;
                existingUserStandartItem.BeginQuantity = item.BeginQuantity;
                existingUserStandartItem.Markup = item.Markup;
                existingUserStandartItem.PurchasePrice = item.PurchasePrice;
                existingUserStandartItem.Step = item.Step;
                // make returned resource
                _returnedCommonItemResource.Id = existingUserStandartItem.Id;
                _returnedCommonItemResource.BeginQuantity = existingUserStandartItem.BeginQuantity;
                _returnedCommonItemResource.Markup = existingUserStandartItem.Markup;
                _returnedCommonItemResource.PurchasePrice = existingUserStandartItem.PurchasePrice;
                _returnedCommonItemResource.Quantity = existingUserStandartItem.Quantity;
                _returnedCommonItemResource.Step = existingUserStandartItem.Step;
            }

            try
            {
                await _unitOfWork.CompleteAsync();

                return new UserCommonItemModifyResponse(_returnedCommonItemResource);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new UserCommonItemModifyResponse(
                    $"An error occurred when updating the category: {ex.Message}"
                );
            }
        }
    }
}
