using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Doctor.Core.Network
{
	public interface IHttpClient
	{
		Task<string> GetStringAsync(string uri);
		Task<HttpResponseMessage> PostAsync<T>(string uri, T item);
	}
}
