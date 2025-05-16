using NewProjectRoateAcademy.Error;
using System.Text.Json;

namespace NewProjectRoateAcademy.MiddelWare
{
	public class ExceptionMiddleWare
	{
		private readonly RequestDelegate _next;
		private readonly ILogger<ExceptionMiddleWare> _logger;
		private readonly IHostEnvironment _env;

		public ExceptionMiddleWare(RequestDelegate next, ILogger<ExceptionMiddleWare> logger, IHostEnvironment env)
		{
			_next = next;
			_logger = logger;
			_env = env;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			try
			{
				await _next.Invoke(context);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, ex.Message);
				context.Response.ContentType = "application/json";
				context.Response.StatusCode = 500;

				var Option = new JsonSerializerOptions()
				{
					PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
				};
				if (_env.IsDevelopment())
				{
					var Resopnse = new ApiExeptionResponse(500, ex.Message, ex.StackTrace);
					var JsonResponse = JsonSerializer.Serialize(Resopnse , Option);
					await context.Response.WriteAsync(JsonResponse);
				}
				else
				{
					var Resopnse = new ApiExeptionResponse(500);
					var JsonResponse = JsonSerializer.Serialize(Resopnse , Option);
					await context.Response.WriteAsync(JsonResponse);
				}



			}
		}
	}
}
