using ToDo.Domain.Models.ViewModels;

namespace ToDo.Domain.Interfaces.Service
{
	public interface ILoginService
	{
		object EfetuarLogin(CredenciaisViewModel credenciais);
	}
}
