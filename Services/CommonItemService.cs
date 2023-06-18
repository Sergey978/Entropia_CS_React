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
            UserCommonItemResource returnedCommonItemResource;
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
            }
            else if (existingUserStandartItem != null)
            {
                existingUserStandartItem.Quantity = item.Quantity;
                existingUserStandartItem.BeginQuantity = item.BeginQuantity;
                existingUserStandartItem.Markup = item.Markup;
                existingUserStandartItem.PurchasePrice = item.PurchasePrice;
                existingUserStandartItem.Step = item.Step;
            }

            try
            {
                await _unitOfWork.CompleteAsync();
                // make returned resource

                if (existingCustomItem != null)
                {
                    returnedCommonItemResource = new UserCommonItemResource
                    {
                        Id = existingCustomItem.Id,
                        Name = existingCustomItem.Name,
                        BeginQuantity = existingCustomItem.BeginQuantity,
                        Markup = existingCustomItem.Markup,
                        PurchasePrice = existingCustomItem.PurchasePrice,
                        Quantity = existingCustomItem.Quantity,
                        Step = existingCustomItem.Step
                    };
                }
                else
                {
                    returnedCommonItemResource = new UserCommonItemResource
                    {
                        Id = existingUserStandartItem.Id,
                        BeginQuantity = existingUserStandartItem.BeginQuantity,
                        Markup = existingUserStandartItem.Markup,
                        PurchasePrice = existingUserStandartItem.PurchasePrice,
                        Quantity = existingUserStandartItem.Quantity,
                        Step = existingUserStandartItem.Step
                    };
                }
                return new UserCommonItemModifyResponse(returnedCommonItemResource);
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
