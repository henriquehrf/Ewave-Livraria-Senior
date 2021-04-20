using Flunt.Validations;

namespace ToDo.Domain.ValueTypes
{
	public struct Endereco
	{
		public Contract Contract { get; }

		private readonly string _valor;

		private Endereco(string value)
		{
			_valor = value;
			Contract = new Contract();
			Validar();
		}

		public override string ToString() => _valor;

		public static implicit operator Endereco(string value) => new Endereco(value);

		private bool Validar()
		{
			if (!string.IsNullOrEmpty(_valor) && _valor.Length < 10)
				return AdicionarNotificacao("Um endereço não pode ter menos que 10 caracteres.");

			return true;
		}

		private bool AdicionarNotificacao(string mensagem)
		{
			Contract.AddNotification(nameof(Endereco), mensagem);
			return false;
		}
	}
}
