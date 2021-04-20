using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Todo.Infra.CrossCutting.Filter;
using Todo.Infra.CrossCutting.InversionOfControl;
using Todo.Infra.CrossCutting.Token;

namespace ToDo.Application
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{

			services.AddControllers().AddNewtonsoftJson();
			services.AddRouting(options => options.LowercaseUrls = true);

			services.AddMvc(config =>
			{
				config.Filters.Add<NotificationFilter>();
				config.Filters.Add<ErrorResponseExceptionFilter>();
			});

			services.AddDependencySql(Configuration);
			services.AddServiceDependency();
			services.AddRepositoryDependency();
			services.AddFinderDependency();
			services.AddNotificationDependency();
			services.ConfigureToken(Configuration);
			services.AddSwaggerDependency();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				
			}

			app.UseSwaggerDependency();

			app.UseHttpsRedirection();
			app.UseCors(builder => builder
				.AllowAnyOrigin()
				.AllowAnyMethod()
				.AllowAnyHeader());

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
