using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Doctor.Core;
using Doctor.Core.Models;
using Doctor.Core.Network;
using Doctor.Core.Services;
using Microsoft.Extensions.Options;
using Xunit;

namespace UnitTests.Doctor.Core.Services.AvailabilityServiceTests
{
	public class HttpClientMock :IHttpClient
	{
		public async Task<string> GetStringAsync(string uri)
		{
			var result = await Task.FromResult("");
			
			return result;
		}

		public async Task<HttpResponseMessage> PostAsync<T>(string uri, T item)
		{
			var result = await Task.FromResult(new HttpResponseMessage());

			return result;
		}
	}

	public class OptionsMock : IOptions<AppSettings>
	{
		public AppSettings Value { get; }

		public OptionsMock()
		{
			Value = new AppSettings();
		}
	}

	public class GetAvailability
	{
		private readonly IHttpClient _client;
		private readonly IOptions<AppSettings> _options;

		public GetAvailability()
		{
			_client =  new HttpClientMock();
			_options = new OptionsMock();
			
		}

	    [Fact]
	    public async void A_Empty_Response_Create_An_Empty_Availabiltiy_Object()
	    {
		    var service = new AvailabilityService(_client, _options);

		    var result = await service.GetAvailability(DateTime.UtcNow);

			Assert.IsType<Availability>(result);
	    }
    }
}
