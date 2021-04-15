using Microsoft.Extensions.DependencyInjection;
using ToDo.Domain.Interfaces.Repository;
using ToDo.Domain.Interfaces.UnitOfWork;
using ToDo.Infra.Data.EF.Context;
using ToDo.Infra.Data.EF.Repository;
using ToDo.Infra.Data.EF.UnitOfWork;

namespace Todo.Infra.CrossCutting.InversionOfControl
{
	public static class ToDoRepositoryDependency
	{
		public static void AddRepositoryDependency(this IServiceCollection services)
		{
			//services.AddScoped<IEmprestimoRepository, EmprestimoRepository>();
			//services.AddScoped<ILivroRepository, LivroRepository>();
			services.AddScoped<IUsuarioRepository, UsuarioRepository>();
			services.AddScoped<IUnitOfWork, UnitOfWork>();
			services.AddScoped<IInstituicaoEnsinoRepository, InstituicaoEnsinoRepository>();
		}
	}
}
