using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Models
{
    public partial class Bar
    {
        public Bar()
        {
            Mapping_Bar_Beers = new HashSet<Mapping_Bar_Beer>();
        }

        public int BarId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Mapping_Bar_Beer> Mapping_Bar_Beers { get; set; }
    }
}
