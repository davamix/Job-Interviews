using OrderService.Client.Services.Request;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows.Media.Imaging;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OrderService.Client.Services.Order
{
    public class OrderService : IOrderService
    {
        private readonly IRequestService _requestService;
        private string _uri => "https://localhost:44387/api/order";

        public OrderService(IRequestService requestService)
        {
            _requestService = requestService;
        }

        public IEnumerable<string> GetOrderedText(string text, string orderOption) => throw new NotImplementedException();
        public async Task<IEnumerable<string>> GetOrderOptions()
        {
            var message = new HttpRequestMessage(HttpMethod.Get, _uri);
            HttpResponseMessage response = await _requestService.SendRequestMessageAsync(message);
            string responseString = await response.Content.ReadAsStringAsync();

            var options = JsonConvert.DeserializeObject<List<string>>(responseString);

            return options;
        }
        public string GetStatistics(string test) => throw new NotImplementedException();
    }
}
