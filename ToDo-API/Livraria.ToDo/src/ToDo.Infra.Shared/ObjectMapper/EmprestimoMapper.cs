using System.Collections.Generic;
using System.Linq;
using ToDo.Domain.Entities;
using ToDo.Domain.Models.ViewModels;

namespace ToDo.Infra.Shared.ObjectMapper
{
	public static class EmprestimoMapper
	{
		public static Emprestimo ToEntity(this EmprestimoViewModel objModel) => new Emprestimo(id: objModel.Id,
																						   idUsuario: objModel.IdUsuario,
																						   idLivro: objModel.IdLivro,
																						   dataDevolucao: objModel.DataDevolucao,
																						   dataPrevistaDevolucao: objModel.DataPrevistaDevolucao,
																						   dataEmprestimo: objModel.DataEmprestimo);

		public static EmprestimoViewModel ToModel(this Emprestimo objRepository) => new EmprestimoViewModel()
		{
			Id = objRepository.Id,
			IdUsuario = objRepository.IdUsuario,
			IdLivro = objRepository.IdLivro,
			DataDevolucao = objRepository.DataDevolucao,
			DataPrevistaDevolucao = objRepository.DataPrevistaDevolucao,
			DataEmprestimo = objRepository.DataEmprestimo,
		};

		public static IEnumerable<EmprestimoViewModel> ToEnumerableModel(this IList<Emprestimo> list) => new List<EmprestimoViewModel>(list.Select(obj => ToModel(obj)));
	}
}
