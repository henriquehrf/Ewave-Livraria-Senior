using Flunt.Notifications;
using System.Collections.Generic;
using ToDo.Domain.Entities;

namespace ToDo.Infra.Shared.Validators
{
	public class CamposObrigatoriosLivroValidator : BaseValidator<IList<Notification>>
	{
		private readonly Livro _livro;

		public CamposObrigatoriosLivroValidator(Livro livro)
		{
			_livro = livro;
		}

		public override IList<Notification> Validar()
		{
			var validacoes = new List<Notification>();

			if (string.IsNullOrWhiteSpace(_livro.Titulo))
				validacoes.Add(new Notification("Titulo", "O campo título é obrigatório"));

			if (string.IsNullOrWhiteSpace(_livro.Genero))
				validacoes.Add(new Notification("Genero", "O campo gênero é obrigatório"));

			if (string.IsNullOrWhiteSpace(_livro.Autor))
				validacoes.Add(new Notification("Autor", "O campo autor é obrigatório"));

			if (string.IsNullOrWhiteSpace(_livro.Sinopse))
				validacoes.Add(new Notification("Sinopse", "O campo sinopse é obrigatório"));

			if (string.IsNullOrWhiteSpace(_livro.GuidCapa.ToString()))
				validacoes.Add(new Notification("GuidCapa", "O campo guidCapa é obrigatório"));


			return validacoes;
		}
	}
}
