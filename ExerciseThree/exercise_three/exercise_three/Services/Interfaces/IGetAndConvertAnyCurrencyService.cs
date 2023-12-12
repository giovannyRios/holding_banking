using exercise_three.Models;

namespace exercise_three.Services.Interfaces
{
	public interface IGetAndConvertAnyCurrencyService
	{
		public Task<CurrencyHistory> resultTransaction();
	}
}
