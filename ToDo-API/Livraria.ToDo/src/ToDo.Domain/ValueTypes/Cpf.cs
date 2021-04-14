using Flunt.Validations;

namespace ToDo.Domain.ValueTypes
{
	public struct Cpf
	{
		private readonly string _valor;
		public readonly Contract _contract;

		private Cpf(string value)
		{
			_valor = value;
			_contract = new Contract();
			Validar();
		}

		public override string ToString() => _valor;

		public static implicit operator Cpf(string value) => new Cpf(value);

		private bool Validar()
		{
			if (string.IsNullOrWhiteSpace(_valor))
				return AdicionarNotificacao("Obrigatório informar um CPF.");

			if (_valor.Replace(".", "").Replace("-", "").Length != 11)
				return AdicionarNotificacao("Um CPF valido deve conter 11 caracteres.");

			return true;
		}

		private bool AdicionarNotificacao(string mensagem)
		{
			_contract.AddNotification(nameof(Cpf), mensagem);
			return false;
		}
	}
}
