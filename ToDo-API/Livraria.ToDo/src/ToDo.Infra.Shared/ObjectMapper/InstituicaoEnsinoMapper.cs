using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Entities;
using ToDo.Domain.Models.ViewModels;

namespace ToDo.Infra.Shared.ObjectMapper
{
	public static class InstituicaoEnsinoMapper
	{


		public static InstituicaoEnsino ToEntity(this InstituicaoEnsinoViewModel objModel) => new InstituicaoEnsino(id: objModel.Id,
																												nome: objModel.Nome,
																												endereco: objModel.Endereco,
																												cnpj: objModel.Cnpj,
																												telefone: objModel.Telefone,
																												guidFoto: objModel.GuidFoto,
																												ativo: objModel.Ativo);

		public static InstituicaoEnsinoViewModel ToModel(this InstituicaoEnsino objRepository) => new InstituicaoEnsinoViewModel()
		{
			Id = objRepository.Id,
			Nome = objRepository.Nome.ToString(),
			Endereco = objRepository.Endereco.ToString(),
			Cnpj = objRepository.Cnpj.ToString(),
			Telefone = objRepository.Telefone.ToString(),
			GuidFoto = objRepository.GuidFoto,
			Ativo = objRepository.Ativo
		};

		public static IEnumerable<InstituicaoEnsinoViewModel> ToEnumerableModel(this IList<InstituicaoEnsino> list) => new List<InstituicaoEnsinoViewModel>(list.Select(obj => ToModel(obj)));
	}
}
