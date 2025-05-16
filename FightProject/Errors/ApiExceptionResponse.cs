using FlightProject.Errors;

namespace NewProjectRoateAcademy.Error
{
	public class ApiExeptionResponse : ApiResponse
	{
		public string? Details { get; set; }

		public ApiExeptionResponse(int StatusCodes, string? Message = null, string? details = null) : base(StatusCodes, Message)
		{
			Details = details;
		}
	}
}
