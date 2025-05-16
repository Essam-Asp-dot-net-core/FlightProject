using AutoMapper;
using Fight.Core.Entities;
using FlightProject.DTOs;

namespace FlightProject.Helper
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<FlightModel , FlightModelDTOs>()
				.ForMember(x=>x.Tickets , x=>x.MapFrom(s=>s.Tickets));
		}
	}
}
