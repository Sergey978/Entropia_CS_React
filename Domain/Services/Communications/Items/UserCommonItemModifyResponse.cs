using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entropia_CS_React.Resources;

namespace Entropia_CS_React.Domain.Services.Communications.Items
{
    public class UserCommonItemModifyResponse : BaseResponse<UserCommonItemResource>
    {
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="category">Saved custom item.</param>
        /// <returns>Response.</returns>
        public UserCommonItemModifyResponse(UserCommonItemResource item) : base(item) { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public UserCommonItemModifyResponse(string message) : base(message) { }
    }
}
