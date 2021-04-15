using Microsoft.Extensions.DependencyInjection;
using ToDo.Domain.Interfaces.Service;
using ToDo.Service.Service;

namespace Todo.Infra.CrossCutting.InversionOfControl
{
	public static class ServiceDependency
	{
		public static void AddServiceDependency(this IServiceCollection services)
		{
			services.AddScoped<IUsuarioService, UsuarioService>();
			//services.AddScoped<IInstituicaoEnsinoService, InstituicaoEnsinoService>();
			//services.AddScoped<ILivroService, LivroService>();
			//services.AddScoped<IEmprestimoService, EmprestimoService>();
			//services.AddScoped<ILoginService, LoginService>();
			//services.AddScoped<IReservaService, ReservaService>();
		}
	}
}
