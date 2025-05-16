using AutoMapper;
using Fight.Core.Entities;
using Flight.Core.Entities;
using Flight.Repository.MyFlightDbContext;
using FlightProject.DTOs;
using FlightProject.Errors;
using FlightProject.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightProject.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BookingsController : ControllerBase
	{
		private readonly FlightDbContext _dbContext;
		private readonly IMapper _mapper;

		public BookingsController(FlightDbContext dbContext , IMapper mapper)
		{
			_dbContext = dbContext;
			_mapper = mapper;
		}

		[HttpPost]
		public async Task<ActionResult<BookingResponseDTO>> SendBooking([FromQuery] BookingDTO model)
		{
			var flight = await _dbContext.Flights.FindAsync(model.FlightId);
			if (flight is null) return NotFound(new ApiResponse(404));

			var Data = new Booking()
			{
				FlightId = model.FlightId,
				PassengerName = model.PassengerName,
				Email = model.Email,
				SeatCount = model.SeatCount,
				BookingDate = DateTime.UtcNow,
				Status = BookingStatus.Pending,
				TotalPriceForBooking = flight.Price * model.SeatCount,
			};
			await _dbContext.Bookings.AddAsync(Data);
			await _dbContext.SaveChangesAsync();

			return Ok(new BookingResponseDTO { Message = "Booking is Succed" });
			
		}
	}
}
