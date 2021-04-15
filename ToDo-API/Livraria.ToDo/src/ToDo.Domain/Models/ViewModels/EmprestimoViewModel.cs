using System;

namespace ToDo.Domain.Models.ViewModels
{
	public class EmprestimoViewModel
	{
		public int Id { get; set; }
		public int IdUsuario { get; set; }
		public int IdLivro { get; set; }
		public DateTime DataEmprestimo { get; set; }
		public DateTime? DataDevolucao { get; set; }
		public DateTime DataPrevistaDevolucao { get; set; }
	}
}
