using exercise_three.Models;
using exercise_three.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace exercise_three.Services.Implements
{
	public class ConvertTypeCurrencyService : IConvertTypeCurrencyService
	{
		private readonly IProcessHttp _ProcessHttp;
		private readonly IOptions<resources> _resource;
		public ConvertTypeCurrencyService(IProcessHttp ProcessHttp, IOptions<resources> resource)
		{
			_ProcessHttp = ProcessHttp;
			_resource = resource;
		}

		public async Task<ExchangeCurrency> resultTransaction()
		{
			return await _ProcessHttp.ProcessResponse<ExchangeCurrency>(_resource.Value.ConvertTypeCurrency);
		}
	}
}
