using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CountriesInfo.Core.Entities
{
    public class Region : EntityBase
    {
        [MaxLength(100)]
        public string Name { get; set; }
        public virtual ICollection<Country> Countries { get; private set; } = new ObservableCollection<Country>();
    }
}
