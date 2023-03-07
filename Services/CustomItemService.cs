using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entropia_CS_React.Domain.Models;
using Entropia_CS_React.Domain.Services;
using Entropia_CS_React.Domain.Services.Communications.Items;
using Entropia_CS_React.Domain.Repositories;

namespace Entropia_CS_React.Services
{
    public class CustomItemService : ICustomItemService
    {
        private readonly ICustomItemRepo _customItemRepo;
        private readonly IUnitOfWork _unitOfWork;

        public CustomItemService(ICustomItemRepo customItemRepo, IUnitOfWork unitOfWork)
        {
            this._customItemRepo = customItemRepo;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<CustomItem>> ListAsync(int userId)
        {
            return await _customItemRepo.ListAsync(userId);
        }

        public async Task<CustomItemResponse> SaveAsync(CustomItem item)
        {
            try
            {
                await _customItemRepo.AddAsync(item);
                await _unitOfWork.CompleteAsync();

                return new CustomItemResponse(item);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new CustomItemResponse(
                    $"An error occurred when saving the category: {ex.Message}"
                );
            }
        }

        public async Task<CustomItemResponse> DeleteAsync(int id)
        {
            var existingCustomItem = await _customItemRepo.FindByIdAsync(id);

            if (existingCustomItem == null)
                return new CustomItemResponse("Item not found.");

            try
            {
                _customItemRepo.Remove(existingCustomItem);
                await _unitOfWork.CompleteAsync();

                return new CustomItemResponse(existingCustomItem);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new CustomItemResponse(
                    $"An error occurred when deleting the item: {ex.Message}"
                );
            }
        }

        public async Task<CustomItemResponse> UpdateAsync(int id, CustomItem item)
        {
            var existingItem = await _customItemRepo.FindByIdAsync(id);

            if (existingItem == null)
                return new CustomItemResponse("Item not found.");

            existingItem.Name = item.Name;
            existingItem.Price = item.Price;
            existingItem.Selected = item.Selected;
            existingItem.BeginQuantity = item.BeginQuantity;
            existingItem.Markup = item.Markup;
            existingItem.PurchasePrice = item.PurchasePrice;
            existingItem.Step = item.Step;

            try
            {
                await _unitOfWork.CompleteAsync();

                return new CustomItemResponse(existingItem);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new CustomItemResponse(
                    $"An error occurred when updating the category: {ex.Message}"
                );
            }
        }
    }
}
