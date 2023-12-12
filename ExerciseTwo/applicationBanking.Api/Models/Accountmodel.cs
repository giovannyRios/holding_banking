using System.ComponentModel.DataAnnotations;

namespace applicationBanking.Api.Models
{
	public class Accountmodel
	{

		[Required(ErrorMessage = "El Cliente es requerido para la cuenta")]
		public string? clientName { get; set; }

		[Required(ErrorMessage = "El Cliente es requerido para la cuenta")]
		public string? clientIdentification { get; set; }

		[Required(ErrorMessage = "El tipo de cuenta es requerido")]
		public string? typeAccount { get; set; }

		[Required(ErrorMessage = "El balance es requerido")]
		[Range(0, double.MaxValue, ErrorMessage = "El balance debe ser mayor o igual a 0")]
		public double balance { get; set; }
	}
}
