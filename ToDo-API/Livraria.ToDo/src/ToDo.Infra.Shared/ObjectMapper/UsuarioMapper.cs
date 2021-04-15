using System.Collections.Generic;
using System.Linq;
using ToDo.Domain.Entities;
using ToDo.Domain.Models.ViewModels;

namespace ToDo.Infra.Shared.ObjectMapper
{
	public static class UsuarioMapper
	{
		public static Usuario ToEntity(this UsuarioViewModel objModel) => new Usuario(id: objModel.Id,
																				  nome: objModel.Nome,
																				  endereco: objModel.Endereco,
																				  cpf: objModel.Cpf,
																				  idInstituicaoEnsino: objModel.InstituicaoEnsinoId,
																				  telefone: objModel.Telefone,
																				  email: objModel.Email,
																				  login: objModel.Login,
																				  senha: objModel.Senha,
																				  dataSuspencao: objModel.DataSuspencao,
																				  perfilUsuario: objModel.PerfilUsuario,
																				  guidFoto: objModel.GuidFoto,
																				  ativo: objModel.Ativo
																				  );

		public static UsuarioViewModel ToModel(this Usuario objRepository) => new UsuarioViewModel()
		{
			Id = objRepository.Id,
			Nome = objRepository.Nome.ToString(),
			Endereco = objRepository.Endereco.ToString(),
			Cpf = objRepository.Cpf.ToString(),
			InstituicaoEnsinoId = objRepository.IdInstituicaoEnsino,
			InstituicaoEnsinoDescricao = objRepository.InstituicaoEnsino?.Nome.ToString(),
			Telefone = objRepository.Telefone.ToString(),
			Email = objRepository.Email.ToString(),
			Login = objRepository.Login,
			Senha = objRepository.Senha,
			DataSuspencao = objRepository.DataSuspencao,
			PerfilUsuario = objRepository.PerfilUsuario
		};

		public static IEnumerable<UsuarioViewModel> ToEnumerableModel(this IList<Usuario> list) => new List<UsuarioViewModel>(list.Select(obj => ToModel(obj)));
	}
}
