using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.API.Services.Ordered
{
    public interface IOrderedFactory
    {
        IOrderedType GetOrdered(OrderType orderType);
    }
}
