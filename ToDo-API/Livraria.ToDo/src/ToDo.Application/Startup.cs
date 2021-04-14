using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Todo.Infra.CrossCutting.Filter;
using Todo.Infra.CrossCutting.InversionOfControl;

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

			services.AddControllers();

			services.AddRouting(options => options.LowercaseUrls = true);

			services.AddMvc(config =>
			{
				config.Filters.Add<NotificationFilter>();
				config.Filters.Add<ErrorResponseExceptionFilter>();
			});

			services.AddDependencySql(Configuration);
			services.AddServiceDependency();
			services.AddRepositoryDependency();
			services.AddNotificationDependency();
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "ToDo.Application", Version = "v1" });
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(options =>
				{
					options.DefaultModelsExpandDepth(-1);
					options.SwaggerEndpoint("/swagger/v1/swagger.json", "ToDo.Application v1");
				});
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
