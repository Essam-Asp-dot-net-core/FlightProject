using AutoMapper;
using Flight.Core.Entities;
using FlightProject.DTOs;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class FlightProfile : Profile
{
    public FlightProfile()
    {
        CreateMap<Flight.Core.Entities.Flight, FlightDto>()
            .ForMember(dest => dest.DepartureAirPortName,
                       opt => opt.MapFrom(src => src.DepartureAirPort.Name))
            .ForMember(dest => dest.ArrivalAirPortName,
                       opt => opt.MapFrom(src => src.ArrivalAirPort.Name))
            .ForMember(dest => dest.AirplaneModel,
                       opt => opt.MapFrom(src => src.Airplane.Model));

        CreateMap<FlightDto, Flight.Core.Entities.Flight>();
    }
}
