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
    public class StandartItemService : IStandartItemService
    {
        private readonly IStandartItemRepo _standartItemRepo;
        private readonly IUnitOfWork _unitOfWork;

        public StandartItemService(IStandartItemRepo standartItemRepo, IUnitOfWork unitOfWork)
        {
            this._standartItemRepo = standartItemRepo;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<StandartItem>> ListAsync()
        {
            return await _standartItemRepo.ListAsync();
        }

        public async Task<StandartItemResponse> SaveAsync(StandartItem item)
        {
            try
            {
                await _standartItemRepo.AddAsync(item);
                await _unitOfWork.CompleteAsync();

                return new StandartItemResponse(item);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new StandartItemResponse(
                    $"An error occurred when saving the category: {ex.Message}"
                );
            }
        }

        public Task<StandartItemResponse> UpdateAsync(int id, StandartItem item)
        {
            throw new NotImplementedException();
        }

        public async Task<StandartItemResponse> DeleteAsync(int id)
        {
            var existStandartItem = await _standartItemRepo.FindByIdAsync(id);

            if (existStandartItem == null)
                return new StandartItemResponse("Item not found.");

            try
            {
                _standartItemRepo.Remove(existStandartItem);
                await _unitOfWork.CompleteAsync();

                return new StandartItemResponse(existStandartItem);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new StandartItemResponse(
                    $"An error occurred when deleting the item: {ex.Message}"
                );
            }
        }
    }
}
