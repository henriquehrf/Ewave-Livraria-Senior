using Microsoft.Extensions.DependencyInjection;

namespace Todo.Infra.CrossCutting.InversionOfControl
{
	public static class ToDoRepositoryDependency
	{
		public static void AddRepositoryDependency(this IServiceCollection services)
		{
			//services.AddScoped<IEmprestimoRepository, EmprestimoRepository>();
			//services.AddScoped<ILivroRepository, LivroRepository>();
			//services.AddScoped<IUsuarioRepository, UsuarioRepository>();
			//services.AddScoped<IInstituicaoEnsinoRepository, InstituicaoEnsinoRepository>();
		}
	}
}
