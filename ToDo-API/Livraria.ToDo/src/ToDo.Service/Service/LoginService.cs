using Flunt.Notifications;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using ToDo.Domain.Entities;
using ToDo.Domain.Interfaces.Repository;
using ToDo.Domain.Interfaces.Service;
using ToDo.Domain.Interfaces.Token;
using ToDo.Domain.Models.Dtos;
using ToDo.Domain.Models.ViewModels;
using ToDo.Infra.Shared.NotificationContext;

namespace ToDo.Service.Service
{
	public class LoginService : ILoginService
	{
		private readonly IUsuarioRepository _usuarioRepository;
		private readonly ITokenConfiguration _tokenConfiguration;
		private readonly NotificationContext _notificationContext;

		public LoginService(IUsuarioRepository usuarioRepository,
							ITokenConfiguration tokenConfiguration,
							NotificationContext notificationContext)
		{
			_usuarioRepository = usuarioRepository;
			_tokenConfiguration = tokenConfiguration;
			_notificationContext = notificationContext;
		}

		public object EfetuarLogin(CredenciaisViewModel credenciais)
		{
			var usuarioBase = _usuarioRepository.UsuarioPorLogin(credenciais.Usuario);

			ValidaCredenciais(credenciais, usuarioBase);
			if (_notificationContext.Invalid)
				return default;


			ClaimsIdentity identity = new ClaimsIdentity(
				new GenericIdentity(credenciais.Usuario, "Login"),
				new[] {
						new Claim("id", usuarioBase.Id.ToString()),
						new Claim("nome",usuarioBase.Nome.ToString()),
						new Claim("usuario", usuarioBase.Login),
						new Claim("cpf", usuarioBase.Cpf.ToString()),
						new Claim("idPerfil", usuarioBase.PerfilUsuario.ToString()),
				}
			);

			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenConfiguration.Key));
			var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
			var issuer = _tokenConfiguration.Issuer;
			var audience = _tokenConfiguration.Audience;

			var dataHoraExpiracao = RetornarDataExpiracaoToken(_tokenConfiguration.LifeTimeSeconds);
			var handler = new JwtSecurityTokenHandler();
			var securityToken = handler.CreateToken(new SecurityTokenDescriptor
			{
				Issuer = issuer,
				Audience = audience,
				SigningCredentials = credentials,
				Subject = identity,
				NotBefore = DateTime.Now,
				Expires = dataHoraExpiracao

			});
			var token = handler.WriteToken(securityToken);

			return new CredencialDto()
			{
				Authenticated = true,
				Created = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
				Expiration = dataHoraExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
				AcessToken = token,
			};
		}

		private DateTime RetornarDataExpiracaoToken(int tempoEmSegundos)
		{
			return DateTime.Now + TimeSpan.FromSeconds(tempoEmSegundos);
		}

		private void ValidaCredenciais(CredenciaisViewModel credenciais, Usuario usuarioBase)
		{
			if (credenciais == null ||
				usuarioBase == null ||
				string.IsNullOrWhiteSpace(credenciais.Usuario))
				_notificationContext.AddNotification(new Notification("usuario", "Usuário inválido e/ou não encontrado!"));

			if (usuarioBase != null && credenciais.Senha != usuarioBase.Senha)
				_notificationContext.AddNotification(new Notification("senha", "Senha incorreta!"));

		}
	}
}
