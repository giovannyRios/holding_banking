using exercise_three.Models;
using exercise_three.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace exercise_three.Services.Implements
{
	public class HistoryLastAvailableYearService : IHistoryLastAvailableYearService
	{
		private readonly IProcessHttp _ProcessHttp;
		private readonly IOptions<resources> _resource;
		public HistoryLastAvailableYearService(IProcessHttp ProcessHttp, IOptions<resources> resource)
		{
			_ProcessHttp = ProcessHttp;
			_resource = resource;


		}
		public async Task<CurrencyHistory> resultTransaction()
		{
			return await _ProcessHttp.ProcessResponse<CurrencyHistory>(_resource.Value.HistoryLastAvailableYearCurrency);
		}
	}
}
