using exercise_three.Models;
using exercise_three.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace exercise_three.Services.Implements
{
	public class ProcessHttpResponse : IProcessHttp
	{
		private readonly IBase _baseClient;
		private readonly IOptions<resources> _resources;
		private HttpClient _client;
		public ProcessHttpResponse(IBase baseClient, IOptions<resources> resource)
		{
			_baseClient = baseClient;
			_client = _baseClient.getClient();
			_resources = resource;
		}
		public async Task<T> ProcessResponse<T>(string data)
		{
			var response = await _client.GetAsync($"{data}access_key={_resources.Value.apiKey}");
			if (response.IsSuccessStatusCode)
			{
				return JsonSerializer.Deserialize<T>(await response.Content.ReadAsStringAsync());
			}
			else
			{
				var responseError = await response.Content.ReadAsStringAsync();
				throw new Exception(responseError);
			}
		}
	}
}
