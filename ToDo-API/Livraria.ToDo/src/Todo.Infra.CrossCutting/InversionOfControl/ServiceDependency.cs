using Microsoft.Extensions.DependencyInjection;

namespace Todo.Infra.CrossCutting.InversionOfControl
{
	public static class ServiceDependency
	{
		public static void AddServiceDependency(this IServiceCollection services)
		{
			//services.AddScoped<IUsuarioService, UsuarioService>();
			//services.AddScoped<IInstituicaoEnsinoService, InstituicaoEnsinoService>();
			//services.AddScoped<ILivroService, LivroService>();
			//services.AddScoped<IEmprestimoService, EmprestimoService>();
			//services.AddScoped<ILoginService, LoginService>();
			//services.AddScoped<IReservaService, ReservaService>();
		}
	}
}
