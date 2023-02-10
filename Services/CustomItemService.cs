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
        private readonly ICustomItemRepo _customItemyRepo;
        private readonly IUnitOfWork _unitOfWork;

        public CustomItemService(ICustomItemRepo customItemRepo, IUnitOfWork unitOfWork)
        {
            this._customItemyRepo = customItemRepo;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<CustomItem>> ListAsync(int userId)
        {
            return await _customItemyRepo.ListAsync(userId);
        }

        public async Task<CustomItemResponse> SaveAsync(CustomItem item)
        {
            try
            {
                await _customItemyRepo.AddAsync(item);
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

        public Task<CustomItemResponse> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CustomItemResponse> UpdateAsync(int id, CustomItem item)
        {
            throw new NotImplementedException();
        }
    }
}
