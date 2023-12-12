using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace applicationBanking.Domain.Entities.Models
{
	public class AccountMovementHistoryModel
	{
		public string? id { get; set; }

		public string? accountId { get; set; }

		public string? type { get; set; }

		public double amount { get; set; }

		public double balance { get; set; }

		public double Endbalance { get; set; }
		public string? date { get; set; }
	}
}
