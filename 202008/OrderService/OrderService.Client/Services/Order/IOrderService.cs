using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Client.Services.Order
{
    public interface IOrderService
    {
        Task<IEnumerable<string>> GetOrderOptions();
        Task<IEnumerable<string>> GetOrderedText(Models.Order order, string orderOption);
        string GetStatistics(string test);
    }
}
