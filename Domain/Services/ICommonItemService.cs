using Entropia_CS_React.Domain.Services.Communications.Items;
using System.Threading.Tasks;
using Entropia_CS_React.Resources;

namespace Entropia_CS_React.Domain.Services
{
    public interface ICommonItemService
    {
        Task<UserCommonItemModifyResponse> UpdateAsync(UserCommonItemResource item, int accountId);
    }
}
