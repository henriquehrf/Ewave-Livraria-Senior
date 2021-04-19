using Microsoft.Extensions.DependencyInjection;
using ToDo.Domain.Interfaces.Finder;
using ToDo.Infra.Dapper.Finder;

namespace Todo.Infra.CrossCutting.InversionOfControl
{
	public static class FinderDependency
	{
		public static void AddFinderDependency(this IServiceCollection services)
		{
			services.AddScoped<IUsuarioFinder, UsuarioFinder>();
			services.AddScoped<IInstituicaoEnsinoFinder, InstituicaoEnsinoFinder>();
			services.AddScoped<ILivroFinder, LivroFinder>();
		}
	}
}
