using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Entropia_CS_React.Domain.Services;
using Entropia_CS_React.Resources;
using Entropia_CS_React.Domain.Models;
using Entropia_CS_React.Extensions;
using Entropia_CS_React.Services;

namespace Entropia_CS_React.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class CustomItemController : BaseController
    {
        private readonly ICustomItemService _itemService;
        private readonly IMapper _mapper;

        public CustomItemController(ICustomItemService itemService, IMapper mapper)
        {
            _itemService = itemService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CustomItemResource>> GetAllAsync()
        {
            // get only user's custom items
            var items = await _itemService.ListAsync(Account.Id);
            var resources = _mapper.Map<IEnumerable<CustomItem>, IEnumerable<CustomItemResource>>(
                items
            );
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveCustomItemResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var customItem = _mapper.Map<SaveCustomItemResource, CustomItem>(resource);
            customItem.AccountId = Account.Id;

            var result = await _itemService.SaveAsync(customItem);

            if (!result.Success)
                return BadRequest(result.Message);

            var itemResource = _mapper.Map<CustomItem, CustomItemResource>(result.CustomItem);
            return Ok(itemResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(
            int id,
            [FromBody] UpdateCustomItemResource resource
        )
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var item = _mapper.Map<UpdateCustomItemResource, CustomItem>(resource);
            var result = await _itemService.UpdateAsync(id, item);

            if (!result.Success)
                return BadRequest(result.Message);

            var categoryResource = _mapper.Map<CustomItem, CustomItemResource>(result.CustomItem);
            return Ok(categoryResource);
        }
    }
}
