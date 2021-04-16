using ToDo.Domain.Interfaces.Token;

namespace Todo.Infra.CrossCutting.Token
{
	public class TokenConfiguration : ITokenConfiguration
	{
		public string Key { get; set; }
		public string Audience { get; set; }
		public string Issuer { get; set; }
		public int LifeTimeSeconds { get; set; }
	}
}
