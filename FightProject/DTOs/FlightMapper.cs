using Flight.Core.Entities;
using FlightProject.DTOs;

namespace FlightProject.Mappers
{
    public static class FlightMapper
    {
        public static FlightDto ToDto(Flight.Core.Entities.Flight flight)
        {
            return new FlightDto
            {
                Id = flight.Id,
                FlightNumber = flight.FlightNumber,
                FromAirportId = flight.DepartureAirPortId,
                FromAirportName = flight.DepartureAirPort?.Name,
                ToAirportId = flight.ArrivalAirPortId,
                ToAirportName = flight.ArrivalAirPort?.Name,
                DepartureTime = flight.DepartureTime,
                ArrivalTime = flight.ArrivalTime,
                AirplaneId = flight.AirplaneId,
                Price = flight.Price,
                Status = flight.Status
            };
        }

        public static Flight.Core.Entities.Flight ToEntity(FlightDto dto)
        {
            return new Flight.Core.Entities.Flight
            {
                Id = dto.Id,
                FlightNumber = dto.FlightNumber,
                DepartureAirPortId = dto.FromAirportId,
                ArrivalAirPortId = dto.ToAirportId,
                DepartureTime = dto.DepartureTime,
                ArrivalTime = dto.ArrivalTime,
                AirplaneId = dto.AirplaneId,
                Price = dto.Price,
                Status = dto.Status
            };
        }
    }
}
