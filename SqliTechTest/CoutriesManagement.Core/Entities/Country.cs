using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CoutriesManagement.Core.Entities
{
    public class Country : EntityBase
    {
        [MaxLength(100)]
        public string Name { get; set; }
        public int RegionId { get; set; }
        public int ContactId { get; set; }
        public int BackupContactId { get; set; }

        public virtual ICollection<Market> Markets { get; private set; } = new ObservableCollection<Market>();


    }
}
