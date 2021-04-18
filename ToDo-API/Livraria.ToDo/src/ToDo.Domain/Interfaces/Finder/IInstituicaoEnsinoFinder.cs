using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.Domain.Models.Dtos;

namespace ToDo.Domain.Interfaces.Finder
{
	public interface IInstituicaoEnsinoFinder
	{
		Task<IEnumerable<DropdownDto>> InstituicaoDropdown();
		Task<IEnumerable<InstituicaoEnsinoDto>> RetornarInstituicaoPorNome(PaginacaoDto paginacao, string nomeInstituicao);
	}
}
