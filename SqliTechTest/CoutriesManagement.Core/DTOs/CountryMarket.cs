using System;
using System.Collections.Generic;
using System.Text;

namespace CoutriesManagement.Core.DTOs
{
    public class CountryMarket
    {
        public int MarketId { get; set; }
        public bool IsActive { get; set; }
        public string Code { get; set; }
    }
}
