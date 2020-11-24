using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace CountriesInfo.Core.Entities
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