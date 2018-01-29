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
	public interface IResponseMock
	{
		string Response { get; }
	}
	public class ResponseEmpty : IResponseMock
	{
		public string Response => string.Empty;
	}

	public class ResponseAvailability : IResponseMock
	{
		public string Response => "{\"Facility\": {\"FacilityId\": \"eff24e99-ceb1-49d8-b5f5-ce6b6483e8ed\",\"Name\": \"Las Palmeras\",\"Address\": \"Plaza de la independencia 36, 38006 Santa Cruz de Tenerife\"}}";
	}

	public class HttpClientMock : IHttpClient
	{
		private readonly IResponseMock _response;

		public HttpClientMock(IResponseMock response)
		{
			_response = response;
		}

		public async Task<string> GetStringAsync(string uri)
		{
			var result = await Task.FromResult(_response.Response);

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
			_options = new OptionsMock();

		}

		[Fact]
		public async void A_Empty_Response_Returns_No_Data_Available_Message()
		{
			var response = new ResponseEmpty();
			var client = new HttpClientMock(response);
			var resultMsg = string.Empty; // To save the error message from service call

			var service = new AvailabilityService(client, _options);

			var resultService = await service.GetAvailability(DateTime.UtcNow);
			resultService.Match((left) => resultMsg = left, null);

			Assert.Equal("No data available", resultMsg);
		}

		[Fact]
		public async void Availability_Response()
		{
			var response = new ResponseAvailability();
			var client = new HttpClientMock(response);
			var resultAvailabilty = new Availability();
			var service = new AvailabilityService(client, _options);

			var resultService = await service.GetAvailability(DateTime.UtcNow);
			resultService.Match(null, (right) => resultAvailabilty);

			Assert.NotNull(resultAvailabilty.Facility);
		}
	}
}
