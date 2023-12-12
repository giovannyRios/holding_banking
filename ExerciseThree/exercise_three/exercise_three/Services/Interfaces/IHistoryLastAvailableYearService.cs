using exercise_three.Models;

namespace exercise_three.Services.Interfaces
{
	public interface IHistoryLastAvailableYearService
	{
		public Task<CurrencyHistory> resultTransaction();
	}
}
