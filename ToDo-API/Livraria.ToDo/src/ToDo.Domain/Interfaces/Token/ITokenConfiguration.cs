namespace ToDo.Domain.Interfaces.Token
{
	public interface ITokenConfiguration
	{
		string Key { get; set; }
		string Audience { get; set; }
		string Issuer { get; set; }
		int LifeTimeSeconds { get; set; }
	}
}
