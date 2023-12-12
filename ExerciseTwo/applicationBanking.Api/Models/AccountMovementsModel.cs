using System.ComponentModel.DataAnnotations;

namespace applicationBanking.Api.Models
{
	public class AccountMovementsModel
	{
		public string? accountId { get; set; }
		public string? type { get; set; }
		public double amount { get; set; }
	}
}
