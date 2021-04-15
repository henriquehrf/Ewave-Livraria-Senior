using System;

namespace ToDo.Domain.Models.ViewModels
{
	public class InstituicaoEnsinoViewModel
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public string Endereco { get; set; }
		public string Cnpj { get; set; }
		public string Telefone { get; set; }
		public Guid? GuidFoto { get; set; }
		public bool Ativo { get; set; }
	}
}
