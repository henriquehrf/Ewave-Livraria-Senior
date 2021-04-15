using System;

namespace ToDo.Domain.Models.ViewModels
{
	public class LivroViewModel
	{
		public int Id { get; set; }
		public string Titulo { get; set; }
		public string Genero { get; set; }
		public string Autor { get; set; }
		public string Sinopse { get; set; }
		public Guid GuidCapa { get; set; }
		public bool Disponivel { get; set; }
		public bool Reservado { get; set; }
		public bool Ativo { get; set; }
	}
}
