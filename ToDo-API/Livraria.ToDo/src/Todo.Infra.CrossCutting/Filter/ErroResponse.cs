namespace Todo.Infra.CrossCutting.Filter
{
	public class ErroResponse
	{
		public int Codigo { get; set; }
		public string Mensagem { get; set; }
		public string Detalhes { get; set; }
		public ErroResponse InnerError { get; set; }

		public static ErroResponse From(System.Exception e)
		{
			if (e == null)
			{
				return null;
			}
			return new ErroResponse
			{
				Codigo = e.HResult,
				Mensagem = e.Message,
				Detalhes = e.StackTrace,
				InnerError = From(e.InnerException)
			};
		}
	}
}
