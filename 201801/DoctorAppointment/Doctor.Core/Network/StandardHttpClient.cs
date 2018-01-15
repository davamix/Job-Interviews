using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Doctor.Core.Network
{
	public class StandardHttpClient : IHttpClient
	{
		private HttpClient _client;

		public StandardHttpClient()
		{
			_client = new HttpClient();
		}

		public async Task<string> GetStringAsync(string uri)
		{
			var response = await _client.GetAsync(uri);

			return await response.Content.ReadAsStringAsync();
		}

		public async Task<HttpResponseMessage> PostAsync<T>(string uri, T item)
		{
			var requestMessage = new HttpRequestMessage(HttpMethod.Post, uri);
			requestMessage.Content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");

			var response = await _client.SendAsync(requestMessage);

			// Check status code

			return response;
		}
	}
}
