using System;

namespace ToDo.Domain.Models.Dtos
{
	public class EmprestimoDto
	{
		public int Id { get; set; }
		public int IdUsuario { get; set; }
		public LivroDto Livro { get; set; }
		public UsuarioDto Usuario { get; set; }
		public DateTime DataEmprestimo { get; set; }
		public DateTime? DataDevolucao { get; set; }
		public DateTime DataPrevistaDevolucao { get; set; }

	}
}
