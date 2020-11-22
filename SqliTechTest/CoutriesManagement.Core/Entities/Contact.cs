using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CoutriesManagement.Core.Entities
{
    public class Contact : EntityBase
    {
        [MaxLength(100)]
        public string Name { get; set; }

        public virtual ICollection<Country> Countries { get; private set; } = new ObservableCollection<Country>();
    }
}
