using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entropia_CS_React.Domain.Models;

namespace Entropia_CS_React.Domain.Services.Communications.Items
{
    public class StandartItemResponse : BaseResponse
    {
        public StandartItem StandartItem { get; private set; }

        private StandartItemResponse(
            bool success,
            string message,
            StandartItem item
        ) :
            base(success, message)
        {
            StandartItem = item;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="item">Saved standard item.</param>
        /// <returns>Response.</returns>
        public StandartItemResponse(StandartItem item) :
            this(true, string.Empty, item)
        {
        }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public StandartItemResponse(string message) :
            this(false, message, null)
        {
        }
    }
}
