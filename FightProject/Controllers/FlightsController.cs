using AutoMapper;
using Fight.Core.Entities;
using Flight.Core.IRepository;
using Flight.Core.ISpecifIcation;
using FlightProject.DTOs;
using FlightProject.Errors;
using FlightProject.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightProject.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FlightsController : ControllerBase
	{
		private readonly IGenericRepository<FlightModel> _flightrepo;
		private readonly IMapper _mapper;

		public FlightsController(IGenericRepository<FlightModel> Flightrepo, IMapper mapper)
		{
			_flightrepo = Flightrepo;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<ActionResult<Pagination<IEnumerable<FlightModelDTOs>>>> GetAllFlights([FromQuery] FlightSpecParams Params)
		{
			var Spec = new FlightWithTicketSpecification(Params);
			var Data = await _flightrepo.GetAllWithSpecificationAsync(Spec);
			if (Data is null) return NotFound(new ApiResponse(404));
			var MappedData = _mapper.Map<IEnumerable<FlightModel>, IEnumerable<FlightModelDTOs>>(Data);
			var CountSpec = new FlightWithSpecForCountAsync(Params);
			var Count = await _flightrepo.GetCountWithSpecAsync(CountSpec);
			var ReturnedObject = new Pagination<FlightModelDTOs>()
			{
				PageIndex = Params.PageIndex,
				PageSize = Params.PageSize,
				Count = Params.count,
				Data = MappedData
			};
			return Ok(ReturnedObject);
		}
		[HttpGet("{id}")]
		public async Task<ActionResult<FlightModel>> GetFlightById(int id)
		{
			var Spec = new FlightWithTicketSpecification(id);
			var Data = await _flightrepo.GetByIdWithSpecificationAsync(Spec);
			var MappedData = _mapper.Map<FlightModel, FlightModelDTOs>(Data);
			return Ok(MappedData);
		}
	}
}
