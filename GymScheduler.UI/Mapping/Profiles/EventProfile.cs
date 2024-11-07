using AutoMapper;
using GymScheduler.Application.Features.Events.Commands;
using GymScheduler.Domain.Models;
using GymScheduler.Models;

namespace GymScheduler.UI.Mapping.Profiles
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<DateTime, string>().ConvertUsing(dt => dt.ToString("yyyy-MM-ddTHH:mm"));
            CreateMap<EventVm, Event>().ReverseMap();
            CreateMap<EventVm, UpdateRequest>().ReverseMap();
            CreateMap<EventVm, CreateRequest>().ReverseMap();
        }
    }
}
