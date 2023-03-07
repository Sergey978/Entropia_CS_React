using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entropia_CS_React.Domain.Models;

namespace Entropia_CS_React.Domain.Services.Communications.Items
{
    public class CustomItemResponse : BaseResponse<CustomItem>
    {
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="category">Saved custom item.</param>
        /// <returns>Response.</returns>
        public CustomItemResponse(CustomItem item) : base(item) { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public CustomItemResponse(string message) : base(message) { }
    }
}
