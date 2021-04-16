using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ToDo.Domain.Interfaces.Token;

namespace Todo.Infra.CrossCutting.Token
{
	public static class TokenSecurity
	{
		public static void ConfigureToken(this IServiceCollection services, IConfiguration configuration)
		{
			var tokenConfigurations = RetornarTokenConfiguration(configuration);
			services.AddSingleton(tokenConfigurations);

			services.AddAuthentication
				 (JwtBearerDefaults.AuthenticationScheme)
				 .AddJwtBearer(options =>
				 {
					 options.TokenValidationParameters = new TokenValidationParameters
					 {
						 ValidateIssuer = true,
						 ValidateAudience = true,
						 ValidateLifetime = true,
						 ValidateIssuerSigningKey = true,
						 ValidIssuer = tokenConfigurations.Issuer,
						 ValidAudience = tokenConfigurations.Audience,
						 IssuerSigningKey = new SymmetricSecurityKey
					   (Encoding.UTF8.GetBytes(tokenConfigurations.Key))
					 };
				 });

			services.AddAuthorization(auth =>
			{
				auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
					.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
					.RequireAuthenticatedUser().Build());
			});
		}

		private static ITokenConfiguration RetornarTokenConfiguration(IConfiguration configuration)
		{
			var tokenConfigurations = new TokenConfiguration();
			new ConfigureFromConfigurationOptions<ITokenConfiguration>(
				configuration.GetSection("TokenConfigurations"))
					.Configure(tokenConfigurations);
			return tokenConfigurations;
		}
	}
}
