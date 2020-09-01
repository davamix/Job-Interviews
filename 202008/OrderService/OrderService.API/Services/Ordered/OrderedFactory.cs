using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.API.Services.Ordered
{
    public class OrderedFactory : IOrderedFactory
    {
        private readonly Dictionary<OrderType, IOrderedType> _orderTypes;
        public OrderedFactory()
        {
            _orderTypes = new Dictionary<OrderType, IOrderedType>() {
                { OrderType.AlphabeticAsc, new OrderedAsc() },
                { OrderType.AlphabeticDesc, new OrderedDesc() },
                { OrderType.LengthAsc, new OrderedLength() }
            };
        }

        public IOrderedType GetOrdered(OrderType orderType) => _orderTypes[orderType];

    }
}
