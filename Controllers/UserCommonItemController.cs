using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Entropia_CS_React.Domain.Services;
using Entropia_CS_React.Resources;
using Entropia_CS_React.Extensions;
using Entropia_CS_React.Domain.Services.Communications.Items;

namespace Entropia_CS_React.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UserCommonItemController : BaseController
    {
        private readonly ICommonItemService _commonItemService;
        private readonly IMapper _mapper;

        public UserCommonItemController(ICommonItemService itemService, IMapper mapper)
        {
            _commonItemService = itemService;
            _mapper = mapper;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(
            int id,
            [FromBody] UserCommonItemResource resource
        )
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var result = await _commonItemService.UpdateAsync(resource, Account.Id);

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.Resource);
        }
    }
}
