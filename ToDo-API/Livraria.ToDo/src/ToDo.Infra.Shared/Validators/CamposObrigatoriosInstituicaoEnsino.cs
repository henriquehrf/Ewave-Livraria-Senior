using Flunt.Notifications;
using System.Collections.Generic;
using ToDo.Domain.Entities;

namespace ToDo.Infra.Shared.Validators
{
	public class CamposObrigatoriosInstituicaoEnsino : BaseValidator<IList<Notification>>
	{
		private readonly InstituicaoEnsino _instituicaoEnsino;

		public CamposObrigatoriosInstituicaoEnsino(InstituicaoEnsino instituicaoEnsino)
		{
			_instituicaoEnsino = instituicaoEnsino;
		}

		public override IList<Notification> Validar()
		{
			var validacoes = new List<Notification>();

			if (string.IsNullOrWhiteSpace(_instituicaoEnsino.Nome.ToString()))
				validacoes.Add(new Notification("Nome", "O campo nome é obrigatório"));

			if (string.IsNullOrWhiteSpace(_instituicaoEnsino.Endereco.ToString()))
				validacoes.Add(new Notification("Endereco", "O campo endereco é obrigatório"));

			if (string.IsNullOrWhiteSpace(_instituicaoEnsino.Cnpj.ToString()))
				validacoes.Add(new Notification("Cnpj", "O campo cnpj é obrigatório"));

			if (string.IsNullOrWhiteSpace(_instituicaoEnsino.Telefone.ToString()))
				validacoes.Add(new Notification("Telefone", "O campo telefone é obrigatório"));

			return validacoes;
		}
	}
}
