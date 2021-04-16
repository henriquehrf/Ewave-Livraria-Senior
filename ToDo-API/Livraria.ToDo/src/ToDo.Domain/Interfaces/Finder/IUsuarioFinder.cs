using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.Domain.Models.Dtos;

namespace ToDo.Domain.Interfaces.Finder
{
	public interface IUsuarioFinder
	{
		Task<IEnumerable<UsuarioDto>> RetornarUsuarioPorNome(PaginacaoDto pagina, string nome);
	}
}
