using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using Doctor.Core.DTOs;
using Doctor.Core.Services;
using Doctor.Core.Types;
using UnitTests.Mocks;
using UnitTests.Mocks.HttpResponses;
using Xunit;

namespace UnitTests.Doctor.Core.Services.AvailabilityServiceTests
{
	public static class HttpResponseMessageMock
	{
		public static HttpResponseMessage ValidMessage => new HttpResponseMessage(HttpStatusCode.OK);
		public static HttpResponseMessage InvalidMessage => new HttpResponseMessage(HttpStatusCode.BadRequest);
	}

	public class TakeSlot
    {
	    private OptionsMock _options;

	    public TakeSlot()
	    {
		    _options = new OptionsMock();
	    }

	    [Fact]
	    public async void A_Valid_Status_Code_Return_A_Message()
	    {
		    var client = new HttpClientMock(HttpResponseMessageMock.ValidMessage);
		    var service = new AvailabilityService(client, _options);
			var resultErrorMessage = string.Empty;

			var result = await service.TakeSlot(new SlotDto());
		    result.Match(Some:(some) => resultErrorMessage = some, None:()=>null);
		    
			Assert.Equal("None", result.ToString());
			Assert.Empty(resultErrorMessage);
		}

	    [Fact]
	    public async void A_Invalid_Status_Code_Return_A_Message()
	    {
		    var client = new HttpClientMock(HttpResponseMessageMock.InvalidMessage);
		    var service = new AvailabilityService(client, _options);
		    var resultErrorMessage = string.Empty;

			var result = await service.TakeSlot(new SlotDto());
		    result.Match(Some: (some) => resultErrorMessage = some, None: () => null);

			Assert.Equal("Error", resultErrorMessage);
	    }
    }
}
