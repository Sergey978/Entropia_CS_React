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
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UserStandartItemController : BaseController
    {
        private readonly IUserStandartItemService _userStandartItemService;

        private readonly IMapper _mapper;

        public UserStandartItemController(
            IUserStandartItemService userStandartItemService,
            IMapper mapper
        )
        {
            _userStandartItemService = userStandartItemService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<UserStandartItemResource>> List()
        {
            var items = await _userStandartItemService.ListAsync(Account.Id);
            var resources = _mapper.Map<
                IEnumerable<UserStandartItem>,
                IEnumerable<UserStandartItemResource>
            >(items);
            return resources;
        }

        //select/userstandartitem
        [HttpGet("select")]
        public async Task<IEnumerable<SelectUserStandartItemResource>> SelectList()
        {
            var items = await _userStandartItemService.ListSelectAsync(Account.Id);

            return items;
        }

        [HttpPost("select")]
        public async Task<IActionResult> PostAsync(
            [FromBody] SelectUserStandartItemResource resource
        )
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var userStandartItem = _mapper.Map<SelectUserStandartItemResource, UserStandartItem>(
                resource
            );

            var result = await _userStandartItemService.SaveAsync(userStandartItem, Account.Id);

            return Ok(result);
        }
    }
}
