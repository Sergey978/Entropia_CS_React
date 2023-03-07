using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Entropia_CS_React.Domain.Models;
using Entropia_CS_React.Domain.Services;
using Entropia_CS_React.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Entropia_CS_React.Extensions;

namespace Entropia_CS_React.Controllers
{
    [Authorize(Role.Admin)]
    [ApiController]
    [Route("[controller]")]
    public class AdminStandartItemController : BaseController
    {
        private readonly IStandartItemService _itemService;
        private readonly IMapper _mapper;

        public AdminStandartItemController(IStandartItemService itemService, IMapper mapper)
        {
            _itemService = itemService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<StandartItemResource>> ListAsync()
        {
            var items = await _itemService.ListAsync();
            var resources = _mapper.Map<
                IEnumerable<StandartItem>,
                IEnumerable<StandartItemResource>
            >(items);
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveStandartItemResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var standartItem = _mapper.Map<SaveStandartItemResource, StandartItem>(resource);

            var result = await _itemService.SaveAsync(standartItem);

            if (!result.Success)
                return BadRequest(result.Message);

            var itemResource = _mapper.Map<StandartItem, StandartItemResource>(result.Resource);
            return Ok(itemResource);
        }

        /// <summary>
        /// Deletes a given custom item according to an identifier.
        /// </summary>
        /// <param name="id">Custom Item identifier.</param>
        /// <returns>Response for the request.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(CustomItemResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _itemService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var standartItemResource = _mapper.Map<StandartItem, StandartItemResource>(
                result.Resource
            );
            return Ok(standartItemResource);
        }
    }
}
