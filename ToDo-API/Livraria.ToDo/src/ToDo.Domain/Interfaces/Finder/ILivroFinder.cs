using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.Domain.Models.Dtos;

namespace ToDo.Domain.Interfaces.Finder
{
	public interface ILivroFinder
	{
		Task<IEnumerable<LivroDto>> RetornarLivroPorTitulo(PaginacaoDto pagina, string titulo);
	}
}
