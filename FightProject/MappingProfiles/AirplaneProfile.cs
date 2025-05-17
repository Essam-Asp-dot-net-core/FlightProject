using AutoMapper;
using Flight.Core.Entities;
using FlightProject.DTOs;

namespace Flight.API.Helpers
{
    public class AirplaneProfile : Profile
    {
        public AirplaneProfile()
        {
            CreateMap<Airplane, AirplaneDto>().ReverseMap();
        }
    }
}
