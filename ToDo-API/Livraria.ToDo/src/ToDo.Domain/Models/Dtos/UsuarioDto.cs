﻿namespace ToDo.Domain.Models.Dtos
{
	public class UsuarioDto
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public string Cpf { get; set; }
		public string Telefone { get; set; }
		public string Endereco { get; set; }
		public string Login { get; set; }
		public string Email { get; set; }
		public string IdInstituicaoEnsino { get; set; }
		public int PerfilUsuario { get; set; }
		public string InstituicaoEnsinoDescricao { get; set; }
		public string Ativo { get; set; }
	}
}