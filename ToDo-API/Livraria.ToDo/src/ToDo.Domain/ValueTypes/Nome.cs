using Flunt.Validations;

namespace ToDo.Domain.ValueTypes
{
	public struct Nome
	{
		public Contract Contract { get; }

		private readonly string _valor;

		private Nome(string value)
		{
			_valor = value;
			Contract = new Contract();
			Validar();
		}

		public override string ToString() => _valor;

		public static implicit operator Nome(string value) => new Nome(value);

		private bool Validar()
		{
			if (string.IsNullOrWhiteSpace(_valor))
				return AdicionarNotificacao("Obrigatório informar um nome.");

			if (_valor.Length < 3)
				return AdicionarNotificacao("Um nome não pode ter menos que 3 caracteres.");

			return true;
		}

		private bool AdicionarNotificacao(string mensagem)
		{
			Contract.AddNotification(nameof(Nome), mensagem);
			return false;
		}
	}
}
