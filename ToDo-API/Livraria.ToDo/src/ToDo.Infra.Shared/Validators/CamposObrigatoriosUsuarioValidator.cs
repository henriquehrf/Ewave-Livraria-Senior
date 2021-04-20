using Flunt.Notifications;
using System.Collections.Generic;
using ToDo.Domain.Entities;

namespace ToDo.Infra.Shared.Validators
{
	public class CamposObrigatoriosUsuarioValidator : BaseValidator<IList<Notification>>
	{
		private readonly Usuario _usuario;

		public CamposObrigatoriosUsuarioValidator(Usuario usuario)
		{
			_usuario = usuario;
		}

		public override IList<Notification> Validar()
		{
			var validacoes = new List<Notification>();

			if (string.IsNullOrWhiteSpace(_usuario.Nome.ToString()))
				validacoes.Add(new Notification("Nome", "O campo nome é obrigatório"));

			if (string.IsNullOrWhiteSpace(_usuario.Cpf.ToString()))
				validacoes.Add(new Notification("Cpf", "O campo cpf é obrigatório"));

			if ((string.IsNullOrWhiteSpace(_usuario.Telefone.ToString())) &&
				(string.IsNullOrWhiteSpace(_usuario.Email.ToString())))
				validacoes.Add(new Notification(string.Empty, "É obrigatório informar ao menos um telefone e/ou email."));

			if (string.IsNullOrWhiteSpace(_usuario.Login))
				validacoes.Add(new Notification("Login", "O campo login é obrigatório"));

			if (string.IsNullOrWhiteSpace(_usuario.Senha))
				validacoes.Add(new Notification("Senha", "O campo senha é obrigatório"));

			if (_usuario.PerfilUsuario == 0)
				validacoes.Add(new Notification("PerfilUsuario", "O campo perfil usuário é obrigatório"));

			return validacoes;
		}
	}
}
