using Flight.Core.IRepository;
using Flight.Repository.Repository;
using FlightProject.Errors;
using FlightProject.Helper;
using Microsoft.AspNetCore.Mvc;

namespace FlightProject.Extention
{
	public static class ApplicationServicesExtention
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection Services)
		{
			Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
			Services.AddAutoMapper(typeof(MappingProfile));
			//Errors
			Services.Configure<ApiBehaviorOptions>(Option =>
			{
				Option.InvalidModelStateResponseFactory = (actionContext) =>
				{
					var error = actionContext.ModelState.Where(p => p.Value.Errors.Count() > 0).SelectMany(p => p.Value.Errors).Select(p => p.ErrorMessage).ToArray();

					var ValidationErrorResponse = new ApiValidationErrorResponse()
					{
						Errors = error
					};
					return new BadRequestObjectResult(ValidationErrorResponse);
				};
			});
			
			return Services;
		}
	}
}
