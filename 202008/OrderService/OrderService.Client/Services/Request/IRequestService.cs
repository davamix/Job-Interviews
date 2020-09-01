using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Client.Services.Request
{
    public interface IRequestService
    {
        Task<HttpResponseMessage> SendRequestMessageAsync(HttpRequestMessage message);
    }
}
