﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.API.Services.Ordered
{
    public class OrderedDesc : IOrderedType
    {
        public IEnumerable<string> Sort(string content) => content?.Split().OrderByDescending(x => x);
    }
}
