using System.Net.Http;
using System.Threading.Tasks;
using Doctor.Core.Network;
using UnitTests.Mocks.HttpResponses;

namespace UnitTests.Mocks
{
	public class HttpClientMock : IHttpClient
	{
		private readonly IResponseMock _response;
		private readonly HttpResponseMessage _message;

		public HttpClientMock(IResponseMock response)
		{
			_response = response;
		}

		public HttpClientMock(HttpResponseMessage message){
			_message = message;
		}

		public async Task<string> GetStringAsync(string uri)
		{
			var result = await Task.FromResult(_response.Response);

			return result;
		}

		public async Task<HttpResponseMessage> PostAsync<T>(string uri, T item)
		{
			var result = await Task.FromResult(_message);

			return result;
		}
	}
}