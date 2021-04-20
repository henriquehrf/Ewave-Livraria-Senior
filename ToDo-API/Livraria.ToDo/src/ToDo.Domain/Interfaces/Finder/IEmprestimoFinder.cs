using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.Domain.Models.Dtos;

namespace ToDo.Domain.Interfaces.Finder
{
	public interface IEmprestimoFinder
	{
		Task<IEnumerable<EmprestimoDto>> BuscarEmprestimoAtivoPorUsuario(int idUsuario);
		Task<IEnumerable<EmprestimoDto>> TodosAtivo();
	}
}
