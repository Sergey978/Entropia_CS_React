using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Entropia_CS_React.Domain.Models;
using Entropia_CS_React.Resources;

namespace Entropia_CS_React.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveCustomItemResource, CustomItem>();
            CreateMap<SaveStandartItemResource, StandartItem>();
            CreateMap<UpdateCustomItemResource, CustomItem>();
            CreateMap<SelectUserStandartItemResource, UserStandartItem>();
            CreateMap<ToggleHideStandartItemResource, UserStandartItem>();
        }
    }
}
