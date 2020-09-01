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
using System.Security.Cryptography.Xml;
using System.Net.Mime;

namespace OrderService.Client.Services.Order
{
    public class OrderService : IOrderService
    {
        private readonly IRequestService _requestService;
        private readonly string _base_url = "https://localhost:44387/api/order";
        private readonly string _get_ordered_text_url = "https://localhost:44387/api/order/GetOrderedText";

        public OrderService(IRequestService requestService)
        {
            _requestService = requestService;
        }

        public async Task<IEnumerable<string>> GetOrderedText(Models.Order order, string orderOption)
        {
            var message = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(_get_ordered_text_url),
                Content = new StringContent(JsonConvert.SerializeObject(order), Encoding.UTF8, "application/json")
            };

            HttpResponseMessage response = await _requestService.SendRequestMessageAsync(message);
            string responseString = await response.Content.ReadAsStringAsync();

            var values = JsonConvert.DeserializeObject<List<string>>(responseString);

            return values;
        }
        
        public async Task<IEnumerable<string>> GetOrderOptions()
        {
            var message = new HttpRequestMessage(HttpMethod.Get, _base_url);

            HttpResponseMessage response = await _requestService.SendRequestMessageAsync(message);
            string responseString = await response.Content.ReadAsStringAsync();

            var options = JsonConvert.DeserializeObject<List<string>>(responseString);

            return options;
        }
        
        public string GetStatistics(string test) => throw new NotImplementedException();
    }
}
