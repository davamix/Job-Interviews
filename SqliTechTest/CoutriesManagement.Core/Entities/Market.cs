using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CoutriesManagement.Core.Entities
{
    public class Market : EntityBase
    {
        public int CountryId { get; set; }
    }
}
