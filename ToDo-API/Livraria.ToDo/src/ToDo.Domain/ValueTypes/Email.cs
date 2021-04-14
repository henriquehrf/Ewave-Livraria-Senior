using Flunt.Validations;

namespace ToDo.Domain.ValueTypes
{
	public struct Email
	{
		private readonly string _valor;
		public readonly Contract _contract;

		private Email(string value)
		{
			_valor = value;
			_contract = new Contract();
			Validar();
		}

		public override string ToString() => _valor;

		public static implicit operator Email(string value) => new Email(value);

		private bool Validar()
		{
			if (string.IsNullOrEmpty(_valor))
				return true;

			bool ehUmFinalValido = (_valor.EndsWith(".com") || _valor.EndsWith(".com.br"));
			bool contemArroba = _valor.Contains("@");

			if (!contemArroba || !ehUmFinalValido)
				return AdicionarNotificacao("Formato de email inválido!");

			return true;
		}

		private bool AdicionarNotificacao(string mensagem)
		{
			_contract.AddNotification(nameof(Email), mensagem);
			return false;
		}
	}
}
