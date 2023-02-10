using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entropia_CS_React.Domain.Models;

namespace Entropia_CS_React.Domain.Services.Communications.Items
{
    public class CustomItemResponse : BaseResponse
    {
        public CustomItem CustomItem { get; private set; }

        private CustomItemResponse(bool success, string message, CustomItem item)
            : base(success, message)
        {
            CustomItem = item;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="category">Saved category.</param>
        /// <returns>Response.</returns>
        public CustomItemResponse(CustomItem item) : this(true, string.Empty, item) { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public CustomItemResponse(string message) : this(false, message, null) { }
    }
}
