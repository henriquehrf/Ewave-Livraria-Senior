using System;

namespace ToDo.Domain.Models.Dtos
{
	public class CredencialDto
	{
		public bool Authenticated { get; set; }
		public string Created { get; set; }
		public string Expiration { get; set; }
		public string AcessToken { get; set; }
	}
}
