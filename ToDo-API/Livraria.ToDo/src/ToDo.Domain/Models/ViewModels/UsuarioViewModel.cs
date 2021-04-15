using System;

namespace ToDo.Domain.Models.ViewModels
{
	public class UsuarioViewModel
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public string Endereco { get; set; }
		public string Cpf { get; set; }
		public int InstituicaoEnsinoId { get; set; }
		public string Telefone { get; set; }
		public string Email { get; set; }
		public int PerfilUsuario { get; set; }
		public string Login { get; set; }
		public string Senha { get; set; }
		public DateTime? DataSuspencao { get; set; }
		public Guid? GuidFoto { get; set; }
		public bool Ativo { get; set; }
	}
}
