using System;
using System.Collections.Generic;
using System.Text;
using Doctor.Core;
using Doctor.Core.Models;
using Doctor.Core.Network;
using Doctor.Core.Services;
using Microsoft.Extensions.Options;
using UnitTests.Mocks;
using UnitTests.Mocks.HttpResponses;
using Xunit;

namespace UnitTests.Doctor.Core.Services.AvailabilityServiceTests
{	
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
		public async void A_Valid_Response_Returns_An_Availability_Object_With_Data()
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
