using ToDo.Domain.Entities;
using ToDo.Domain.Models.ViewModels;

namespace ToDo.Domain.Interfaces.Service
{
	public interface IUsuarioService
	{
		Usuario Inserir(Usuario usuario);
	}
}
