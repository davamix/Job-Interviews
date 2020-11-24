using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CountriesInfo.Core.Entities
{
    public class EntityBase
    {
        public int Id { get; set; }
        [MaxLength(30)]
        public string Code { get; set; }
    }
}
