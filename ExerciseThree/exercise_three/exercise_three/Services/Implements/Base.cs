using exercise_three.Models;
using exercise_three.Services.Interfaces;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;

namespace exercise_three.Services.Implements
{
	public class Base:IBase
	{
		private HttpClient _HttpClient;
		private readonly IOptions<resources> _resources;
		
		public Base(IOptions<resources> resources)
		{
			_resources = resources;
		}

		public HttpClient getClient()
		{
			_HttpClient = new HttpClient();
			_HttpClient.BaseAddress = new Uri(_resources.Value.basePath);
			return _HttpClient;
		}
	}
}
