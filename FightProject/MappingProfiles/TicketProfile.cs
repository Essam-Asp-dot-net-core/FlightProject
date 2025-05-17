using AutoMapper;
using Flight.Core.Entities;
using FlightProject.DTOs;

namespace FlightProject.Profiles
{
    public class TicketProfile : Profile
    {
        public TicketProfile()
        {
            CreateMap<Ticket, TicketDto>()
                .ForMember(dest => dest.BookingId, opt => opt.MapFrom(src => src.BookingId))
                .ForMember(dest => dest.FlightId, opt => opt.MapFrom(src => src.FlightId))
                .ForMember(dest => dest.PassengerName, opt => opt.MapFrom(src => src.PassengerName))
                .ForMember(dest => dest.SeatNumber, opt => opt.MapFrom(src => src.SeatNumber))
                .ForMember(dest => dest.Class, opt => opt.MapFrom(src => src.Class))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ReverseMap(); // لو محتاج ترجع من DTO للكيان
        }
    }
}
