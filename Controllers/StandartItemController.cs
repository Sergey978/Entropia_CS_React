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
    public class StandartItemController : BaseController
    {
        private readonly IStandartItemService _itemService;
        private readonly IMapper _mapper;

        public StandartItemController(IStandartItemService itemService, IMapper mapper)
        {
            this._itemService = itemService;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<StandartItemResource>> GetAllAsync()
        {
            // get only user's custom items
            var items = await _itemService.ListAsync();
            var resources = _mapper.Map<
                IEnumerable<StandartItem>,
                IEnumerable<StandartItemResource>
            >(items);
            return resources;
        }
    }
}
