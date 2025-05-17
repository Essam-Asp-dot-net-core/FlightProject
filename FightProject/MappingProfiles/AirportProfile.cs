using AutoMapper;
using Flight.Core.Entities;
using FlightProject.DTOs;

namespace FlightProject.MapperProfiles
{
    public class AirportProfile : Profile
    {
        public AirportProfile()
        {
            CreateMap<AirPort, AirPortDto>().ReverseMap();
        }
    }
}
