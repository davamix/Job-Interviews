using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrderService.API.Models;
using OrderService.API.Services.Ordered;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrderService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderedFactory _orderedFactory;

        public OrderController(IOrderedFactory orderedFactory)
        {
            _orderedFactory = orderedFactory;
        }
        // GET: api/<OrderController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "AlphabeticAsc", "AlphabeticDesc", "LengthAsc" };
        }

        [Route("[action]")]
        [HttpGet]
        public IEnumerable<string> GetOrderedText([FromBody] Order textToOrder, [FromQuery] string orderOption)
        {
            if (!string.IsNullOrEmpty(textToOrder.Content))
            {
                Enum.TryParse(orderOption, out OrderType orderType);
                var orderedService = _orderedFactory.GetOrdered(orderType);

                return orderedService.Sort(textToOrder.Content);
            }

            return Enumerable.Empty<string>();

        }

        [Route("[action]")]
        [HttpGet]
        public string GetStatistics([FromBody] Order textToAnalyze)
        {
            return "GetStatistics";
        }
    }
}
