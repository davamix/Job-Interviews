using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.API.Services.Ordered
{
    public class OrderedFactory : IOrderedFactory
    {
        public IOrderedType GetOrdered(OrderType orderType)
        {
            switch (orderType)
            {
                case OrderType.AlphabeticAsc:
                    return new OrderedAsc();
                case OrderType.AlphabeticDesc:
                    return new OrderedDesc();
                case OrderType.LengthAsc:
                    return new OrderedLength();

                default:
                    throw new InvalidEnumArgumentException();
            }
        }
    }
}
