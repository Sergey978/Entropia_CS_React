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
        public async Task<IEnumerable<UserStandartItemResource>> ListAsync()
        {
            var items = await _userStandartItemService.ListAsync(Account.Id);
            var resources = _mapper.Map<
                IEnumerable<UserStandartItem>,
                IEnumerable<UserStandartItemResource>
            >(items);
            return resources;
        }
    }
}
