using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Client.Services.Order
{
    public interface IOrderService
    {
        Task<IEnumerable<string>> GetOrderOptions();
        IEnumerable<string> GetOrderedText(string text, string orderOption);
        string GetStatistics(string test);
    }
}
