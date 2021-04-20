using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Todo.Infra.CrossCutting.Filter;

namespace Todo.Infra.CrossCutting.InversionOfControl
{
	public static class SwaggerDependency
	{
		public static void AddSwaggerDependency(this IServiceCollection services)
		{
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "ToDo.Application", Version = "v1" });

				c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
				{
					Name = "Authorization",
					Type = SecuritySchemeType.ApiKey,
					Scheme = "Bearer",
					BearerFormat = "JWT",
					In = ParameterLocation.Header,
					Description = "JWT Authorization header using the Bearer scheme."
				});
				c.OperationFilter<SecurityRequirementsOperationFilter>();

			});
		}

		public static void UseSwaggerDependency(this IApplicationBuilder app)
		{
			app.UseSwagger();
			app.UseSwaggerUI(options =>
			{
				options.DefaultModelsExpandDepth(-1);
				options.SwaggerEndpoint("/swagger/v1/swagger.json", "ToDo.Application v1");
			});
		}
	}
}
