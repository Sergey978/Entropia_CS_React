using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Entropia_CS_React.Domain.Models;
using Entropia_CS_React.Resources;

namespace Entropia_CS_React.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<CustomItem, CustomItemResource>()
                .ForMember("Cost", opt => opt.MapFrom(c => c.Price));
            CreateMap<StandartItem, StandartItemResource>();
            CreateMap<UserStandartItem, UserStandartItemResource>()
                .ForMember("Name", opt => opt.MapFrom(c => c.StandartItem.Name))
                .ForMember("Cost", opt => opt.MapFrom(c => c.StandartItem.Price));
            CreateMap<UserStandartItem, SelectUserStandartItemResource>();
        }
    }
}
