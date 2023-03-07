using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entropia_CS_React.Domain.Models;

namespace Entropia_CS_React.Domain.Services.Communications.Items
{
    public class StandartItemResponse : BaseResponse<StandartItem>
    {
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="item">Saved standard item.</param>
        /// <returns>Response.</returns>
        public StandartItemResponse(StandartItem item) : base(item) { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public StandartItemResponse(string message) : base(message) { }
    }
}
