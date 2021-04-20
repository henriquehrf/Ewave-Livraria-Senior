using Flunt.Validations;

namespace ToDo.Domain.ValueTypes
{
	public struct Cnpj
	{
		public Contract Contract { get; }

		private readonly string _valor;

		private Cnpj(string value)
		{
			_valor = value;
			Contract = new Contract();
			Validar();
		}

		public override string ToString() => _valor;

		public static implicit operator Cnpj(string value) => new Cnpj(value);

		private bool Validar()
		{
			if (!string.IsNullOrEmpty(_valor) && _valor.Length != 18)
				return AdicionarNotificacao("Um CNPJ valido deve conter 18 caracteres.");

			return true;
		}

		private bool AdicionarNotificacao(string mensagem)
		{
			Contract.AddNotification(nameof(Cnpj), mensagem);
			return false;
		}
	}
}
