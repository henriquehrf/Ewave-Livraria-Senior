using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Linq;

namespace Todo.Infra.CrossCutting.Filter
{
	public class SecurityRequirementsOperationFilter : IOperationFilter
	{
		public void Apply(OpenApiOperation operation, OperationFilterContext context)
		{
			if (!context.MethodInfo.GetCustomAttributes(true).Any(x => x is AllowAnonymousAttribute) &&
				!(context.MethodInfo.DeclaringType?.GetCustomAttributes(true).Any(x => x is AllowAnonymousAttribute) ?? false))
			{
				operation.Security = new List<OpenApiSecurityRequirement>
			{
				new OpenApiSecurityRequirement
				{
					{
						new OpenApiSecurityScheme {
							Reference = new OpenApiReference {
								Type = ReferenceType.SecurityScheme,
								Id = "Bearer"
							},
							Scheme="oauth2",
							Name="Bearer",
							In = ParameterLocation.Header

						}, new List<string>()
					}
				}
			};
			}
		}
	}
}
