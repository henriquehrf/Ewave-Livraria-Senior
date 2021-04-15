using System.Collections.Generic;
using System.Linq;
using ToDo.Domain.Entities;
using ToDo.Domain.Models.ViewModels;

namespace ToDo.Infra.Shared.ObjectMapper
{
	public static class LivroMapper
	{
		public static Livro ToEntity(this LivroViewModel objModel) => new Livro(id: objModel.Id,
																			titulo: objModel.Titulo,
																			genero: objModel.Genero,
																			autor: objModel.Autor,
																			sinopse: objModel.Sinopse,
																			disponivel: objModel.Disponivel,
																			reservado: objModel.Reservado,
																			ativo: objModel.Ativo,
																			guidCapa: objModel.GuidCapa);

		public static LivroViewModel ToModel(this Livro objRepository) => new LivroViewModel()
		{
			Id = objRepository.Id,
			Titulo = objRepository.Titulo,
			Genero = objRepository.Genero,
			Autor = objRepository.Sinopse,
			Disponivel = objRepository.Disponivel,
			Reservado = objRepository.Reservado,
			Sinopse = objRepository.Sinopse,
			Ativo = objRepository.Ativo,
			GuidCapa = objRepository.GuidCapa
		};

		public static IEnumerable<LivroViewModel> ToEnumerableModel(this IList<Livro> list) => new List<LivroViewModel>(list.Select(obj => ToModel(obj)));
	}
}
