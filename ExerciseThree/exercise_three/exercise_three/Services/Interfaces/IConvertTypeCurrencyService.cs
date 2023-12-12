using exercise_three.Models;

namespace exercise_three.Services.Interfaces
{
	public interface IConvertTypeCurrencyService
	{
		public Task<ExchangeCurrency> resultTransaction();
	}
}
