using OrderService.API.Services.Ordered;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace OrderService.API.Tests.Services.Ordered.OrderedLength
{
    public class Sort
    {
        IOrderedType _orderedType;
        string _text => "My car is red";
        IEnumerable<string> _exepected => new List<string> { "My", "is", "car", "red" };

        public Sort()
        {
            _orderedType = new OrderedFactory().GetOrdered(OrderType.LengthAsc);
        }

        [Fact]
        public void TextIsSortedInAscendingMode()
        {
            var result = _orderedType.Sort(_text);

            Assert.Equal(_exepected, result);
        }
    }
}
